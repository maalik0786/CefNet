using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CefNet.WinApi;

namespace CefNet.Internal
{
	public partial class WebViewGlue
	{
		internal CefAccessibilityHandler GetAccessibilityHandler()
		{
			return null;
		}

		internal bool AvoidGetRootScreenRect()
		{
			return false;
		}

		protected internal virtual bool GetRootScreenRect(CefBrowser browser, ref CefRect rect)
		{
			rect = WebView.GetCefRootBounds();
			return !rect.IsNullSize;
		}

		internal bool AvoidGetViewRect()
		{
			return false;
		}

		protected internal virtual void GetViewRect(CefBrowser browser, ref CefRect rect)
		{
			rect = WebView.GetCefViewBounds();
		}

		internal bool AvoidGetScreenPoint()
		{
			return false;
		}

		protected internal virtual bool GetScreenPoint(CefBrowser browser, int viewX, int viewY, ref int screenX,
			ref int screenY)
		{
			var point = new CefPoint(viewX, viewY);
			if (WebView.CefPointToScreen(ref point))
			{
				screenX = point.X;
				screenY = point.Y;
				return true;
			}

			return false;
		}

		internal bool AvoidGetScreenInfo()
		{
			return false;
		}

		protected internal virtual bool GetScreenInfo(CefBrowser browser, ref CefScreenInfo screenInfo)
		{
			if (WebView.GetCefScreenInfo(ref screenInfo))
				return true;

			if (!PlatformInfo.IsWindows)
				return false;

			var devicePixelRatio = WebView.GetDevicePixelRatio();
			var hMonitor = NativeMethods.MonitorFromWindow(IntPtr.Zero, MonitorFlag.MONITOR_DEFAULTTOPRIMARY);

			var monitorInfo = new MONITORINFO();
			monitorInfo.Size = Marshal.SizeOf(typeof(MONITORINFO));
			NativeMethods.GetMonitorInfo(hMonitor, ref monitorInfo);

			screenInfo.Depth = 24;
			screenInfo.DepthPerComponent = 24;
			screenInfo.DeviceScaleFactor = devicePixelRatio;

			CefRect rect;
			rect = monitorInfo.Monitor.ToCefRect();
			rect.Scale(1.0f / devicePixelRatio);
			screenInfo.Rect = rect;

			rect = monitorInfo.Work.ToCefRect();
			rect.Scale(1.0f / devicePixelRatio);
			screenInfo.AvailableRect = rect;
			return true;
		}

		internal bool AvoidOnPopupShow()
		{
			return false;
		}

		protected internal virtual void OnPopupShow(CefBrowser browser, bool show)
		{
			if (!show) WebView.RaisePopupShow(new PopupShowEventArgs());
		}

		internal bool AvoidOnPopupSize()
		{
			return false;
		}

		protected internal virtual void OnPopupSize(CefBrowser browser, CefRect rect)
		{
			WebView.RaisePopupShow(new PopupShowEventArgs(rect));
		}

		internal bool AvoidOnPaint()
		{
			return false;
		}

		protected internal virtual void OnPaint(CefBrowser browser, CefPaintElementType type, CefRect[] dirtyRects,
			IntPtr buffer, int width, int height)
		{
			WebView.RaiseCefPaint(new CefPaintEventArgs(browser, type, dirtyRects, buffer, width, height));
		}

		internal bool AvoidOnAcceleratedPaint()
		{
			return false;
		}

		protected internal virtual void OnAcceleratedPaint(CefBrowser browser, CefPaintElementType type,
			CefRect[] dirtyRects, IntPtr sharedHandle)
		{
		}

		internal bool AvoidOnCursorChange()
		{
			return false;
		}

		protected internal virtual void OnCursorChange(CefBrowser browser, IntPtr cursor, CefCursorType type,
			CefCursorInfo customCursorInfo)
		{
		}

		[MethodImpl(MethodImplOptions.ForwardRef)]
		internal extern bool AvoidStartDragging();

		protected internal virtual bool StartDragging(CefBrowser browser, CefDragData dragData,
			CefDragOperationsMask allowedOps, int x, int y)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.ForwardRef)]
		internal extern bool AvoidUpdateDragCursor();

		protected internal virtual void UpdateDragCursor(CefBrowser browser, CefDragOperationsMask operation)
		{
		}

		internal bool AvoidOnScrollOffsetChanged()
		{
			return false;
		}

		protected internal virtual void OnScrollOffsetChanged(CefBrowser browser, double x, double y)
		{
		}

		internal bool AvoidOnImeCompositionRangeChanged()
		{
			return false;
		}

		protected internal virtual void OnImeCompositionRangeChanged(CefBrowser browser, CefRange selectedRange,
			CefRect[] characterBounds)
		{
		}

		internal bool AvoidOnTextSelectionChanged()
		{
			return false;
		}

		protected internal virtual void OnTextSelectionChanged(CefBrowser browser, string selectedText,
			CefRange selectedRange)
		{
		}

		internal bool AvoidOnVirtualKeyboardRequested()
		{
			return false;
		}

		protected internal virtual void OnVirtualKeyboardRequested(CefBrowser browser, CefTextInputMode inputMode)
		{
		}
	}
}