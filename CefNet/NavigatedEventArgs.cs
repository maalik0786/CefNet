using System;

namespace CefNet
{
	public class NavigatedEventArgs : EventArgs
	{
		public NavigatedEventArgs(CefFrame frame, string url)
		{
			Frame = frame;
			Url = url;
		}

		public CefFrame Frame { get; }

		public string Url { get; }
	}
}