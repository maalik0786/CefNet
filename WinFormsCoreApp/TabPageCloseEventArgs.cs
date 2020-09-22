using System.ComponentModel;

namespace System.Windows.Forms
{
	public class TabPageCloseEventArgs : CancelEventArgs
	{
		public TabPageCloseEventArgs(TabPage tab)
			: this(tab, false)
		{
		}

		public TabPageCloseEventArgs(TabPage tab, bool force)
		{
			Tab = tab;
			Force = force;
		}

		public TabPage Tab { get; }

		public bool Force { get; }
	}
}