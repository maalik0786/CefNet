using System;
using CefNet;
using CefNet.Internal;
#if MODERNFORMS
using CefNet.Modern.Forms;

#else
using CefNet.Windows.Forms;
#endif

namespace WinFormsCoreApp
{
	public sealed class CustomWebView : WebView
	{
		public CustomWebView()
		{
		}

		public CustomWebView(CustomWebView opener)
			: base(opener)
		{
		}

		public CustomWebView(CefRequestContext requestContext)
		{
			RequestContext = requestContext;
		}

		protected override WebViewGlue CreateWebViewGlue()
		{
			return new CustomWebViewGlue(this);
		}

		protected override void OnSizeChanged(EventArgs e)
		{
			var device = Device;
			if (device != null)
			{
				float xScale = 1;
				float yScale = 1;
				var ppd = OffscreenGraphics.PixelsPerDip;

				var viewportRect = device.ViewportRect;
				viewportRect.Scale(OffscreenGraphics.PixelsPerDip);
				var clientRect = ClientRectangle;
				if (viewportRect.Height > clientRect.Height)
					yScale = Math.Max(clientRect.Height - 6.0f, 1.0f) / viewportRect.Height;

				if (viewportRect.Width > clientRect.Width)
					xScale = Math.Max(clientRect.Width - 6.0f, 1.0f) / viewportRect.Width;

				device.Scale = Math.Min(xScale, yScale);

				var bounds = device.GetBounds(ppd);
				device.X = (int) (((clientRect.Width - bounds.Width) >> 1) / ppd);
				device.Y = (int) (((clientRect.Height - bounds.Height) >> 1) / ppd);

				CefInvalidate();
			}

			base.OnSizeChanged(e);
		}

		public void AddSource(Guid sourceKey, CefResourceHandler source)
		{
			if (source == null)
				throw new ArgumentNullException(nameof(source));

			((CustomWebViewGlue) ViewGlue).AddSource(sourceKey, source);
		}
	}
}