using System;

namespace CefNet
{
	public class LoadingStateChangeEventArgs : EventArgs
	{
		public LoadingStateChangeEventArgs(bool busy, bool canGoBack, bool canGoForward)
		{
			Busy = busy;
			CanGoBack = canGoBack;
			CanGoForward = canGoForward;
		}

		public bool Busy { get; }

		public bool CanGoBack { get; }

		public bool CanGoForward { get; }
	}
}