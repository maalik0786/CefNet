namespace CefNet
{
	internal struct DevToolsMethodResult
	{
		internal DevToolsMethodResult(int messageId, byte[] result, bool success)
		{
			MessageID = messageId;
			Result = result;
			Success = success;
		}

		public int MessageID { get; }

		public bool Success { get; }

		public byte[] Result { get; }
	}
}