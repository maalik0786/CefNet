using System;
using System.IO;
using System.Text;

namespace CefNet
{
	public class PostData
	{
		private readonly MemoryStream _content;
		private string _contentType;
		private Encoding _encoding;

		public PostData()
		{
			_content = new MemoryStream();
		}

		public PostData(byte[] content)
		{
			if (content == null)
				throw new ArgumentNullException(nameof(content));
			_content = new MemoryStream(content, 0, content.Length, false, true);
		}

		public string ContentType
		{
			get => _contentType ?? "application/x-www-form-urlencoded";
			set
			{
				if (_contentType != null && _contentType.IndexOf('\n') != -1)
					throw new ArgumentOutOfRangeException(nameof(value));
				_contentType = value;
			}
		}

		public byte[] Content => _content.GetBuffer();

		public long Length => _content.Length;

		public Encoding Encoding
		{
			get => _encoding ?? Encoding.UTF8;
			set => _encoding = value;
		}

		public void Add(string name, string value)
		{
			if (ContentType == "application/x-www-form-urlencoded")
				AddAsUrlEncoded(name, value);
			else
				throw new NotSupportedException();
		}

		public void AddAsUrlEncoded(string name, string value)
		{
			if (!_content.CanWrite)
				throw new InvalidOperationException();

			if (string.IsNullOrWhiteSpace(name))
				throw new ArgumentOutOfRangeException(nameof(name));

			byte[] buffer;
			if (_content.Position > 0) _content.WriteByte((byte) '&');
			name = Uri.EscapeDataString(name);
			buffer = Encoding.GetBytes(name);
			_content.Write(buffer, 0, buffer.Length);
			if (value != null)
			{
				_content.WriteByte((byte) '=');
				value = Uri.EscapeDataString(value);
				buffer = Encoding.GetBytes(value);
				_content.Write(buffer, 0, buffer.Length);
			}
		}
	}
}