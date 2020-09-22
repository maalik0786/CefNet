using System;
using System.Buffers;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using CefNet.Wpf;

namespace CefNet.Internal
{
	public sealed class OffscreenGraphics
	{
		private readonly object _syncRoot;
		private CefRect _bounds;
		private CefRect _popupBounds;
		private PixelBuffer PopupPixels;

		private PixelBuffer ViewPixels;

		public OffscreenGraphics()
		{
			_syncRoot = new object();
			_bounds = new CefRect(0, 0, 1, 1);
		}

		public static DpiScale DpiScale { get; set; } = new DpiScale(1, 1);

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
			return _bounds;
		}

		public void Draw(CefPaintEventArgs e)
		{
			lock (_syncRoot)
			{
				PixelBuffer pixelBuffer;
				if (e.PaintElementType == CefPaintElementType.View)
				{
					if (ViewPixels == null || ViewPixels.Width != e.Width || ViewPixels.Height != e.Height)
					{
						if (ViewPixels != null)
							ViewPixels.Dispose();

						ViewPixels = new PixelBuffer(e.Width, e.Height);
					}

					pixelBuffer = ViewPixels;
				}
				else if (e.PaintElementType == CefPaintElementType.Popup)
				{
					if (PopupPixels == null || PopupPixels.Width != e.Width || PopupPixels.Height != e.Height)
					{
						if (PopupPixels != null)
							PopupPixels.Dispose();
						PopupPixels = new PixelBuffer(e.Width, e.Height);
					}

					pixelBuffer = PopupPixels;
				}
				else
				{
					return;
				}

				Marshal.Copy(e.Buffer, pixelBuffer.DIB, 0, pixelBuffer.Size);
				pixelBuffer.AddDirtyRects(e.DirtyRects);
			}
		}

		public void Render(DrawingContext drawingContext)
		{
			lock (_syncRoot)
			{
				if (ViewPixels != null)
				{
					WriteableBitmap surface;
					surface = GetSurface(ViewPixels);
					drawingContext.DrawImage(surface, new Rect(0, 0, surface.Width, surface.Height));

					var pixelBuffer = PopupPixels;
					if (pixelBuffer == null)
						return;

					surface = GetSurface(pixelBuffer);
					drawingContext.DrawImage(surface,
						new Rect(_popupBounds.X, _popupBounds.Y, surface.Width, surface.Height));
				}
			}
		}

		private WriteableBitmap GetSurface(PixelBuffer pixelBuffer)
		{
			if (!Monitor.IsEntered(_syncRoot))
				throw new InvalidOperationException();

			var surface = pixelBuffer.Surface;
			if (surface == null
			    || surface.PixelWidth != pixelBuffer.Width
			    || surface.PixelHeight != pixelBuffer.Height)
			{
				var dpi = DpiScale;
				surface = new WriteableBitmap(pixelBuffer.Width, pixelBuffer.Height, dpi.PixelsPerInchX,
					dpi.PixelsPerInchY, PixelFormats.Bgra32, null);
				pixelBuffer.Surface = surface;
			}

			surface.Lock();
			try
			{
				Marshal.Copy(pixelBuffer.DIB, 0, surface.BackBuffer, pixelBuffer.Size);
				surface.AddDirtyRect(pixelBuffer.GetDirtyRectangle());
				pixelBuffer.ClearDirtyRectangle();
			}
			finally
			{
				surface.Unlock();
			}

			return surface;
		}

		public void SetPopup(PopupShowEventArgs e)
		{
			if (e.Visible)
				_popupBounds = e.Bounds;
			else
				lock (_syncRoot)
				{
					PopupPixels?.Dispose();
					PopupPixels = null;
				}
		}

		private class PixelBuffer : IDisposable
		{
			private readonly List<CefRect> _dirtyRects = new List<CefRect>();
			public byte[] DIB;

			public readonly int Height;

			public WriteableBitmap Surface;

			public readonly int Width;

			public PixelBuffer(int width, int height)
			{
				Width = width;
				Height = height;
				DIB = ArrayPool<byte>.Shared.Rent(width * height * 4);
			}

			public int Stride => Width * 4;

			public int Size => Width * Height * 4;

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
				var buffer = Interlocked.Exchange(ref DIB, null);
				if (buffer != null) ArrayPool<byte>.Shared.Return(buffer);
			}

			public void AddDirtyRects(CefRect[] dirtyRects)
			{
				_dirtyRects.AddRange(dirtyRects);
			}

			public Int32Rect GetDirtyRectangle()
			{
				if (_dirtyRects.Count == 0)
					return new Int32Rect();
				var r = _dirtyRects[0];
				var dirtyRect = new Int32Rect(r.X, r.Y, r.Width, r.Height);
				for (var i = 1; i < _dirtyRects.Count; i++) dirtyRect.Union(_dirtyRects[i]);
				return dirtyRect;
			}

			public void ClearDirtyRectangle()
			{
				_dirtyRects.Clear();
			}
		}
	}
}