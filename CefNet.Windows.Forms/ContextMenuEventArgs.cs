using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CefNet.Windows.Forms
{
	public sealed class ContextMenuEventArgs : HandledEventArgs
	{
		public ContextMenuEventArgs(ContextMenuStrip menu, Point location)
		{
			ContextMenu = menu;
			Location = location;
		}

		public ContextMenuStrip ContextMenu { get; }

		public Point Location { get; }
	}
}