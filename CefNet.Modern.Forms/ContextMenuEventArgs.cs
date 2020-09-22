using System.ComponentModel;
using System.Drawing;
using Modern.Forms;

namespace CefNet.Modern.Forms
{
	public sealed class ContextMenuEventArgs : HandledEventArgs
	{
		public ContextMenuEventArgs(ContextMenu menu, Point location)
		{
			ContextMenu = menu;
			Location = location;
		}

		public ContextMenu ContextMenu { get; }

		public Point Location { get; }
	}
}