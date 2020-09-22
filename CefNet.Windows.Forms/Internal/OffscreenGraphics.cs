using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Threading;
using CefNet.WinApi;
using CefNet.Windows.Forms;

namespace CefNet.Internal
{
	public sealed class OffscreenGraphics
	{
		private readonly object _syncRoot;
		private CefRect _bounds;
		private Rectangle _popupBounds;
		private PixelBuffer PopupPixels;

		private PixelBuffer ViewPixels;

		public OffscreenGraphics()
		{
			_syncRoot = new object();
			_bounds = new CefRect(0, 0, 1, 1);
		}

		public VirtualDevice Device { get; set; }

		public IntPtr WidgetHandle { get; set; }

		public Color Background { get; set; }

		public static float PixelsPerDip { get; set; } = 1.0f;

		public InterpolationMode InterpolationMode { get; set; } = InterpolationMode.Bilinear;

		public void SetLocation(int x, int y)
		{
			_bounds.X = x;
			_bounds.Y = y;
		}

		public bool SetSize(int width, int height)
		{
			width = Math.Max(width, 1);
			height = Math.Max(height, 1);
			_bounds.Width = width;
			_bounds.Height = height;

			lock (_syncRoot)
			{
				return ViewPixels == null || ViewPixels.Width != width || ViewPixels.Height != height;
			}
		}

		public CefRect GetBounds()
		{
			var ppd = PixelsPerDip;
			if (ppd == 1.0f || Device != null)
				return _bounds;
			return new CefRect((int) (_bounds.X / ppd), (int) (_bounds.Y / ppd), (int) (_bounds.Width / ppd),
				(int) (_bounds.Height / ppd));
		}

		public CefRect Draw(CefPaintEventArgs e)
		{
			var ppd = PixelsPerDip;
			var device = Device;

			var dirtyRects = e.DirtyRects;
			if (dirtyRects.Length == 0)
				return new CefRect();

			var r = dirtyRects[0];
			var invalidRect = new CefRect(r.X, r.Y, r.Width, r.Height);
			for (var i = 1; i < dirtyRects.Length; i++) invalidRect.Union(dirtyRects[i]);

			if (device != null) invalidRect.Scale(device.Scale * ppd / device.DevicePixelRatio);

			if (e.PaintElementType == CefPaintElementType.Popup) invalidRect.Offset(_popupBounds.X, _popupBounds.Y);

			if (invalidRect.IsNullSize)
				return new CefRect();

			lock (_syncRoot)
			{
				var width = e.Width;
				var height = e.Height;

				if (device != null)
				{
					if (e.PaintElementType == CefPaintElementType.View)
					{
						width = (int) (_bounds.Width * device.Scale * ppd);
						height = (int) (_bounds.Height * device.Scale * ppd);
					}
					else if (e.PaintElementType == CefPaintElementType.Popup)
					{
						width = (int) (e.Width / device.DevicePixelRatio * device.Scale * ppd);
						height = (int) (e.Height / device.DevicePixelRatio * device.Scale * ppd);
					}
				}

				PixelBuffer pixelBuffer;
				if (e.PaintElementType == CefPaintElementType.View)
				{
					if (ViewPixels == null || ViewPixels.Width != width || ViewPixels.Height != height)
					{
						if (ViewPixels != null)
							ViewPixels.Dispose();

						ViewPixels = new PixelBuffer(width, height);
					}

					pixelBuffer = ViewPixels;
				}
				else if (e.PaintElementType == CefPaintElementType.Popup)
				{
					if (PopupPixels == null || PopupPixels.Width != width || PopupPixels.Height != height)
					{
						if (PopupPixels != null)
							PopupPixels.Dispose();
						PopupPixels = new PixelBuffer(width, height);
					}

					pixelBuffer = PopupPixels;
				}
				else
				{
					return new CefRect();
				}

				using (var g = Graphics.FromImage(pixelBuffer.Source))
				{
					var background = Background;
					if (background.A > 0)
						using (var brush = new SolidBrush(background))
						{
							g.FillRectangle(brush, 0, 0, width, height);
						}

					using (var bitmap = new Bitmap(e.Width, e.Height, e.Width << 2, PixelFormat.Format32bppArgb,
						e.Buffer))
					{
						if (e.Width != width || e.Height != height)
						{
							g.CompositingQuality = CompositingQuality.HighSpeed;
							g.InterpolationMode = InterpolationMode;
							g.DrawImage(bitmap, 0, 0, width, height);
						}
						else
						{
							g.DrawImage(bitmap, 0, 0);
						}

						g.Flush();
					}
				}
			}

			invalidRect.Inflate(2, 2);
			return invalidRect;
		}

		private void DrawPixels(PixelBuffer pixelBuffer, Graphics g, Rectangle r, int x, int y)
		{
			if (!Monitor.IsEntered(_syncRoot))
				throw new InvalidOperationException();

			r.Offset(-x, -y);

			var bitmapRect = new Rectangle(0, 0, pixelBuffer.Width, pixelBuffer.Height);
			r.Intersect(bitmapRect);
			if (r.Width == 0 || r.Height == 0)
				return;

			//g.DrawImage(pixelBuffer.Source, new Point(r.X + x, r.Y + y));

			var hdc = g.GetHdc();
			try
			{
				var DIB = pixelBuffer.Source.LockBits(new Rectangle(0, 0, pixelBuffer.Width, pixelBuffer.Height),
					ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
				try
				{
					NativeMethods.SetDIBitsToDevice(hdc, r.X + x, r.Y + y, r.Width, r.Height, r.X, bitmapRect.Height,
						r.Bottom, bitmapRect.Height, DIB.Scan0, ref pixelBuffer.DIBInfo, 0);
				}
				finally
				{
					pixelBuffer.Source.UnlockBits(DIB);
				}
			}
			finally
			{
				g.ReleaseHdc(hdc);
			}
		}

		public void Render(Graphics g, Rectangle r)
		{
			lock (_syncRoot)
			{
				if (ViewPixels != null)
				{
					var ppd = PixelsPerDip;

					var offsetX = 0;
					var offsetY = 0;
					var viewport = Device;
					if (viewport != null)
					{
						offsetX = viewport.X;
						offsetY = viewport.Y;
					}

					DrawPixels(ViewPixels, g, r, (int) (offsetX * ppd), (int) (offsetY * ppd));

					var pixelBuffer = PopupPixels;
					if (pixelBuffer == null)
						return;

					DrawPixels(pixelBuffer, g, r, (int) (_popupBounds.X + offsetX * ppd),
						(int) (_popupBounds.Y + offsetY * ppd));
				}
			}
		}

		public void SetPopup(bool visible, CefRect bounds)
		{
			if (visible)
				_popupBounds = bounds.ToRectangle();
			else
				lock (_syncRoot)
				{
					PopupPixels = null;
				}
		}

		public Rectangle GetRenderBounds()
		{
			lock (_syncRoot)
			{
				if (ViewPixels != null) return new Rectangle(0, 0, ViewPixels.Width, ViewPixels.Height);
			}

			return new Rectangle();
		}

		public Rectangle GetPopupBounds()
		{
			return _popupBounds;
		}

		private class PixelBuffer : IDisposable
		{
			internal BITMAPINFO DIBInfo;
			internal Bitmap Source;

			public PixelBuffer(int width, int height)
			{
				DIBInfo = new BITMAPINFO
				{
					Size = 40,
					BitCount = 32,
					Planes = 1,
					Width = width,
					Height = -height,
					SizeImage = width * height * 4
				};
				Source = new Bitmap(width, height, PixelFormat.Format32bppArgb);
			}

			public int Stride => DIBInfo.Width * 4;

			public int Size => DIBInfo.SizeImage;

			public int Width => DIBInfo.Width;

			public int Height => -DIBInfo.Height;

			public void Dispose()
			{
				Dispose(true);
				GC.SuppressFinalize(this);
			}

			~PixelBuffer()
			{
				Dispose(false);
			}

			private void Dispose(bool disposing)
			{
				Source?.Dispose();
				Source = null;
			}
		}
	}
}