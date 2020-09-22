namespace CefNet
{
	public class AddressChangeEventArgs : NavigatedEventArgs
	{
		public AddressChangeEventArgs(CefFrame frame, string url)
			: base(frame, url)
		{
		}

		public bool IsMainFrame => Frame?.IsMain ?? false;
	}
}