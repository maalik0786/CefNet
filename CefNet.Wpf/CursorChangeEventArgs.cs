using System;
using System.Windows.Input;

namespace CefNet.Wpf
{
	public class CursorChangeEventArgs : EventArgs
	{
		public CursorChangeEventArgs(Cursor cursor, CefCursorType cursorType)
		{
			Cursor = cursor;
			CursorType = cursorType;
		}

		public Cursor Cursor { get; }

		public CefCursorType CursorType { get; }
	}
}