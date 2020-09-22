using System;

namespace CefNet
{
	public sealed class DocumentTitleChangedEventArgs : EventArgs
	{
		public DocumentTitleChangedEventArgs(string title)
		{
			Title = title;
		}

		public string Title { get; }
	}
}