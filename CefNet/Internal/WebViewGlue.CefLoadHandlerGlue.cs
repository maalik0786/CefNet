using System;

namespace CefNet.Internal
{
	public partial class WebViewGlue
	{
		internal bool AvoidOnLoadingStateChange()
		{
			return false;
		}

		protected internal virtual void OnLoadingStateChange(CefBrowser browser, bool isLoading, bool canGoBack,
			bool canGoForward)
		{
#if DEBUG
			if (!BrowserObject.IsSame(browser))
				throw new InvalidOperationException();
#endif
			WebView.RaiseLoadingStateChange(new LoadingStateChangeEventArgs(isLoading, canGoBack, canGoForward));
		}

		internal bool AvoidOnLoadStart()
		{
			return false;
		}

		protected internal virtual void OnLoadStart(CefBrowser browser, CefFrame frame,
			CefTransitionType transitionType)
		{
#if DEBUG
			if (!BrowserObject.IsSame(browser))
				throw new InvalidOperationException();
#endif
		}

		internal bool AvoidOnLoadEnd()
		{
			return false;
		}

		protected internal virtual void OnLoadEnd(CefBrowser browser, CefFrame frame, int httpStatusCode)
		{
#if DEBUG
			if (!BrowserObject.IsSame(browser))
				throw new InvalidOperationException();
#endif
		}

		internal bool AvoidOnLoadError()
		{
			return false;
		}

		protected internal virtual void OnLoadError(CefBrowser browser, CefFrame frame, CefErrorCode errorCode,
			string errorText, string failedUrl)
		{
#if DEBUG
			if (!BrowserObject.IsSame(browser))
				throw new InvalidOperationException();
#endif
		}
	}
}