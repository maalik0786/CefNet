using System;

namespace CefNet.Net
{
	/// <summary>
	///  Provides a set of properties and methods that are used to manage cookies.
	/// </summary>
	public sealed class CefNetCookie
	{
		private string _name;
		private string _value;

		/// <summary>
		///  Initializes a new instance of the <see cref="CefNetCookie" /> class.
		/// </summary>
		public CefNetCookie()
		{
			TimeStamp = DateTime.UtcNow;
			SameSite = CefCookieSameSite.LaxMode;
		}

		/// <summary>
		///  Initializes a new instance of the <see cref="CefNetCookie" /> class
		///  with a specified <see cref="Name" /> and <see cref="Value" />.
		/// </summary>
		/// <param name="name">
		///  The name of a cookie.
		///  <para />
		///  The following characters must not be used inside name: equal sign,
		///  semicolon, comma, newline (\n), return (\r), tab (\t), and space
		///  character. The dollar sign character ("$") cannot be the first
		///  character.
		/// </param>
		/// <param name="value">
		///  The value of a cookie.
		///  <para />
		///  The following characters must not be used inside value: semicolon,
		///  comma.
		/// </param>
		public CefNetCookie(string name, string value)
		{
			TimeStamp = DateTime.UtcNow;
			SameSite = CefCookieSameSite.LaxMode;
			Name = name;
			Value = value;
		}

		/// <summary>
		///  Initializes a new instance of the <see cref="CefNetCookie" /> class.
		/// </summary>
		public CefNetCookie(CefCookie cookie)
		{
			_name = cookie.Name;
			_value = cookie.Value ?? string.Empty;
			Path = cookie.Path;
			Domain = cookie.Domain;
			Secure = cookie.Secure;
			HttpOnly = cookie.HttpOnly;
			TimeStamp = cookie.Creation.ToDateTime();
			LastAccess = cookie.LastAccess.ToDateTime();

			if (cookie.HasExpires)
				Expires = cookie.Expires.ToDateTime();
			SameSite = cookie.SameSite;
			Priority = cookie.Priority;
		}

		/// <summary>
		///  Gets or sets the name for the cookie.
		/// </summary>
		public string Name
		{
			get => _name;
			set
			{
				if (value is null)
					throw new ArgumentNullException(nameof(value));

				if (value.Length == 0 || value[0] == '$')
					throw new ArgumentOutOfRangeException(nameof(value));

				foreach (var ch in value)
					if (ch == '=' || ch == ';' || ch == ',' || ch == '\n'
					    || ch == '\t' || ch == '\t' || char.IsWhiteSpace(ch))
						throw new ArgumentOutOfRangeException(nameof(value));

				_name = value;
			}
		}

		/// <summary>
		///  Gets or sets the value for the cookie.
		/// </summary>
		public string Value
		{
			get => _value;
			set
			{
				if (value != null)
					foreach (var ch in value)
						if (ch == ';' || ch == ',')
							throw new ArgumentOutOfRangeException(nameof(value));
				_value = value ?? string.Empty;
			}
		}

		/// <summary>
		///  Gets or sets the URIs to which the cookie applies.
		/// </summary>
		public string Path { get; set; }

		/// <summary>
		///  Gets or sets the URI for which the cookie is valid.
		/// </summary>
		public string Domain { get; set; }

		/// <summary>
		///  Gets or sets the security level of a cookie.
		/// </summary>
		/// <value>
		///  true, if the client is only to return the cookie in subsequent requests if
		///  those requests use Secure Hypertext Transfer Protocol (HTTPS); otherwise,
		///  false. The default is false.
		/// </value>
		public bool Secure { get; set; }

		/// <summary>
		///  Determines whether a page script or other active content can access this
		///  cookie.
		/// </summary>
		/// <value>
		///  Boolean value that determines whether a page script or other active
		///  content can access this cookie.
		/// </value>
		/// <remarks>
		///  When this property is set to true, a page script or other active content
		///  cannot access this cookie.
		/// </remarks>
		public bool HttpOnly { get; set; }

		/// <summary>
		///  Gets the time when the cookie was issued as a <see cref="DateTime" />.
		/// </summary>
		public DateTime TimeStamp { get; }

		/// <summary>
		///  The cookie last access date. This is automatically populated by the system
		///  on access.
		/// </summary>
		public DateTime LastAccess { get; }

		/// <summary>
		///  Gets or sets the current state of the cookie.
		/// </summary>
		/// <value>
		///  true if the cookie has expired; otherwise, false.
		/// </value>
		public bool Expired
		{
			get
			{
				var expires = Expires;
				return expires is null ? false : expires.Value <= DateTime.UtcNow;
			}
			set
			{
				if (value) Expires = DateTime.UtcNow;
			}
		}

		/// <summary>
		///  Gets or sets the expiration date and time for the cookie as
		///  a <see cref="DateTime" />.
		/// </summary>
		public DateTime? Expires { get; set; }

		/// <summary>
		///  Gets and sets a value that declares if your cookie should be restricted to
		///  a first-party or same-site context.
		/// </summary>
		public CefCookieSameSite SameSite { get; set; }

		/// <summary>
		///  Cookie priority.
		/// </summary>
		public CefCookiePriority Priority { get; set; }

		/// <summary>
		///  Creates a <see cref="CefCookie" /> structure.
		/// </summary>
		/// <returns>The new <see cref="CefCookie" /> that this method creates.</returns>
		/// <remarks>The <see cref="CefCookie" /> structure should be disposed after use.</remarks>
		public CefCookie ToCefCookie()
		{
			return new CefCookie
			{
				Name = Name,
				Value = Value,
				Path = Path,
				Domain = Domain,
				Secure = Secure,
				HttpOnly = HttpOnly,
				Creation = CefTime.FromDateTime(TimeStamp),
				LastAccess = CefTime.FromDateTime(LastAccess),
				SameSite = SameSite,
				Priority = Priority,
				HasExpires = Expires.HasValue,
				Expires = Expires.HasValue ? CefTime.FromDateTime(Expires.Value) : default
			};
		}

		/// <summary>
		///  Returns a string representation of this <see cref="CefNetCookie" /> object.
		/// </summary>
		/// <returns>
		///  A string representation of this <see cref="CefNetCookie" /> object.
		/// </returns>
		public override string ToString()
		{
			return Name + "=" + Value;
		}

		/// <inheritdoc />
		public override bool Equals(object obj)
		{
			var cookie = obj as CefNetCookie;
			if (cookie != null
			    && string.Equals(Name, cookie.Name, StringComparison.OrdinalIgnoreCase)
			    && string.Equals(Value, cookie.Value, StringComparison.Ordinal)
			    && string.Equals(Path ?? string.Empty, cookie.Path ?? string.Empty, StringComparison.Ordinal))
				return string.Equals(Domain ?? string.Empty, cookie.Domain ?? string.Empty,
					StringComparison.OrdinalIgnoreCase);
			return false;
		}

		/// <inheritdoc />
		public override int GetHashCode()
		{
			return (Name + "=" + Value + ";" + Path + "; " + Domain).GetHashCode();
		}
	}
}