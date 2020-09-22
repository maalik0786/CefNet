using System.Windows;

namespace WpfCoreApp
{
	public class FullscreenModeChangeEventArgs : RoutedEventArgs
	{
		public FullscreenModeChangeEventArgs(object source, bool fullscreen)
			: base(CustomWebView.FullscreenEvent, source)
		{
			Fullscreen = fullscreen;
		}

		public bool Fullscreen { get; }
	}
}