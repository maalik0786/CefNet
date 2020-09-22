using System.Runtime.CompilerServices;

namespace CefNet.Internal
{
	public partial class WebViewGlue
	{
		[MethodImpl(MethodImplOptions.ForwardRef)]
		internal extern bool AvoidOnBeforeDownload();

		protected internal virtual void OnBeforeDownload(CefBrowser browser, CefDownloadItem downloadItem,
			string suggestedName, CefBeforeDownloadCallback callback)
		{
		}

		[MethodImpl(MethodImplOptions.ForwardRef)]
		internal extern bool AvoidOnDownloadUpdated();

		protected internal virtual void OnDownloadUpdated(CefBrowser browser, CefDownloadItem downloadItem,
			CefDownloadItemCallback callback)
		{
		}
	}
}