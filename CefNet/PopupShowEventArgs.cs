using System;

namespace CefNet
{
	public class PopupShowEventArgs : EventArgs
	{
		public PopupShowEventArgs()
		{
			Visible = false;
		}

		public PopupShowEventArgs(CefRect rect)
		{
			Visible = (rect.Width | rect.Height) != 0;
			Bounds = rect;
		}

		public bool Visible { get; }

		public CefRect Bounds { get; }
	}
}