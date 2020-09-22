namespace CefNet.Internal
{
	public partial class WebViewGlue
	{
		internal bool AvoidOnDragEnter()
		{
			return false;
		}

		protected internal virtual bool OnDragEnter(CefBrowser browser, CefDragData dragData,
			CefDragOperationsMask mask)
		{
			return false;
		}

		internal bool AvoidOnDraggableRegionsChanged()
		{
			return false;
		}

		protected internal virtual void OnDraggableRegionsChanged(CefBrowser browser, CefFrame frame,
			CefDraggableRegion[] regions)
		{
		}
	}
}