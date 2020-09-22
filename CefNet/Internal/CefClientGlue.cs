namespace CefNet.Internal
{
	internal partial class CefClientGlue
	{
		internal WebViewGlue Implementation { get; }

		public void NotifyPopupBrowserCreating()
		{
			Implementation.NotifyPopupBrowserCreating();
		}
	}
}