namespace CefNet
{
	public sealed class InvalidCefObjectException : CefRuntimeException
	{
		public InvalidCefObjectException()
			: base("CEF object that has been separated from its underlying RCW cannot be used.")
		{
		}

		public InvalidCefObjectException(string message)
			: base(message)
		{
		}
	}
}