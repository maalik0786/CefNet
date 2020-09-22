using Avalonia.Interactivity;

namespace AvaloniaApp
{
	public class FullscreenModeChangeEventArgs : RoutedEventArgs
	{
		public FullscreenModeChangeEventArgs(IInteractive source, bool fullscreen)
			: base(CustomWebView.FullscreenEvent, source)
		{
			Fullscreen = fullscreen;
		}

		public bool Fullscreen { get; }
	}
}