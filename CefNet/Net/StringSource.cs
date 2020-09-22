using System;
using System.Collections.Specialized;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;

namespace CefNet.Net
{
	/// <summary>
	///  Represents a HTTP-source that is backed by a single <see cref="string" />.
	/// </summary>
	public sealed class StringSource : CefResourceHandler
	{
		private readonly byte[] _data;
		private NameValueCollection _headers;
		private int _offset;

		/// <summary>
		///  Initializes a new instance of the <see cref="StringSource" /> class.
		/// </summary>
		/// <param name="content">The content used to initialize the <see cref="StringSource" />.</param>
		public StringSource(string content)
			: this(content, "text/plain")
		{
		}

		/// <summary>
		///  Initializes a new instance of the <see cref="StringSource" /> class.
		/// </summary>
		/// <param name="content">The content used to initialize the <see cref="StringSource" /></param>
		/// <param name="mimeType">A <see cref="string" /> value that indicates MIME type.</param>
		public StringSource(string content, string mimeType)
		{
			if (string.IsNullOrWhiteSpace(mimeType))
				throw new ArgumentOutOfRangeException(nameof(mimeType));

			MimeType = mimeType;
			StatusCode = HttpStatusCode.OK;
			_data = Encoding.UTF8.GetBytes(content);
		}

		/// <summary>
		///  Gets MIME type for the content.
		/// </summary>
		public string MimeType { get; }

		/// <summary>
		///  Gets or sets the status for the response.
		/// </summary>
		public HttpStatusCode StatusCode { get; set; }

		/// <summary>
		///  Gets a collection of content headers set on the <see cref="StringSource" />.
		/// </summary>
		public NameValueCollection Headers
		{
			get
			{
				if (_headers == null)
					_headers = new NameValueCollection();
				return _headers;
			}
		}

		protected internal override void Cancel()
		{
			_offset = _data.Length;
		}

		protected internal override void GetResponseHeaders(CefResponse response, ref long responseLength,
			ref string redirectUrl)
		{
			response.Status = (int) StatusCode;
			response.Charset = "utf-8";
			response.MimeType = MimeType;
			responseLength = _data.Length;

			if (_headers != null && _headers.Count > 0)
				using (var map = new CefStringMultimap())
				{
					map.Add(_headers);
					response.SetHeaderMap(map);
				}
		}

		protected internal override bool Open(CefRequest request, ref int handleRequest, CefCallback callback)
		{
			handleRequest = 1;
			_offset = 0;
			return true;
		}

		protected internal override bool Read(IntPtr dataOut, int bytesToRead, ref int bytesRead,
			CefResourceReadCallback callback)
		{
			if (bytesToRead < 0)
			{
				bytesRead = (int) CefErrorCode.Failed;
				return false;
			}

			var offset = _offset;
			bytesRead = Math.Min(_data.Length - offset, bytesToRead);
			Marshal.Copy(_data, offset, dataOut, bytesRead);
			_offset = offset + bytesRead;
			return true;
		}

		protected internal override bool Skip(long bytesToSkip, ref long bytesSkipped, CefResourceSkipCallback callback)
		{
			if (bytesToSkip < 0)
			{
				bytesSkipped = (long) CefErrorCode.Failed;
				return false;
			}

			bytesSkipped = Math.Min(_data.Length - _offset, bytesToSkip);
			_offset += (int) bytesSkipped;
			return true;
		}

		/// <summary>
		///  Returns a <see cref="String" /> that represents the current <see cref="StringSource" /> object.
		/// </summary>
		/// <returns>A <see cref="String" /> that represents the current object.</returns>
		public override string ToString()
		{
			return Encoding.UTF8.GetString(_data);
		}
	}
}