using CefNet.Wpf;

namespace CefNet.Internal
{
	public interface IWpfWebViewPrivate : IChromiumWebViewPrivate
	{
		void RaiseCefCursorChange(CursorChangeEventArgs e);
		void CefSetToolTip(string text);
		void CefSetStatusText(string statusText);
		void RaiseStartDragging(StartDraggingEventArgs e);
	}
}