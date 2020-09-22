﻿// --------------------------------------------------------------------------------------------
// Copyright (c) 2019 The CefNet Authors. All rights reserved.
// Licensed under the MIT license.
// See the licence file in the project root for full license information.
// --------------------------------------------------------------------------------------------
// Generated by CefGen
// Source: include/internal/cef_types.h
// --------------------------------------------------------------------------------------------﻿
// DO NOT MODIFY! THIS IS AUTOGENERATED FILE!
// --------------------------------------------------------------------------------------------

#pragma warning disable 0169, 1591, 1573

namespace CefNet
{
	/// <summary>
	///  Configuration options for registering a custom scheme.
	///  These values are used when calling AddCustomScheme.
	/// </summary>
	public enum CefSchemeOptions
	{
		None = 0,

		/// <summary>
		///  If CEF_SCHEME_OPTION_STANDARD is set the scheme will be treated as a
		///  standard scheme. Standard schemes are subject to URL canonicalization and
		///  parsing rules as defined in the Common Internet Scheme Syntax RFC 1738
		///  Section 3.1 available at http://www.ietf.org/rfc/rfc1738.txt
		///  In particular, the syntax for standard scheme URLs must be of the form:
		///  &lt;pre&gt;[scheme]://[username]:[password]
		///  @
		///  [host]:[port]/[url-path]
		///  &lt;/pre&gt;Standard scheme URLs must have a host component that is a fully
		///  qualified domain name as defined in Section 3.5 of RFC 1034 [13] and
		///  Section 2.1 of RFC 1123. These URLs will be canonicalized to
		///  &quot;scheme://host/path&quot; in the simplest case and
		///  &quot;scheme://username:password
		///  @post :port/path&quot; in the most explicit case. For
		///  example, &quot;scheme:host/path&quot; and &quot;scheme:///host/path&quot; will both be
		///  canonicalized to &quot;scheme://host/path&quot;. The origin of a standard scheme URL
		///  is the combination of scheme, host and port (i.e., &quot;scheme://host:port&quot; in
		///  the most explicit case).
		///  For non-standard scheme URLs only the &quot;scheme:&quot; component is parsed and
		///  canonicalized. The remainder of the URL will be passed to the handler as-
		///  is. For example, &quot;scheme:///some%20text&quot; will remain the same. Non-standard
		///  scheme URLs cannot be used as a target for form submission.
		/// </summary>
		Standard = 1 << 0,

		/// <summary>
		///  If CEF_SCHEME_OPTION_LOCAL is set the scheme will be treated with the same
		///  security rules as those applied to &quot;file&quot; URLs. Normal pages cannot link to
		///  or access local URLs. Also, by default, local URLs can only perform
		///  XMLHttpRequest calls to the same URL (origin + path) that originated the
		///  request. To allow XMLHttpRequest calls from a local URL to other URLs with
		///  the same origin set the CefSettings.file_access_from_file_urls_allowed
		///  value to true (1). To allow XMLHttpRequest calls from a local URL to all
		///  origins set the CefSettings.universal_access_from_file_urls_allowed value
		///  to true (1).
		/// </summary>
		Local = 1 << 1,

		/// <summary>
		///  If CEF_SCHEME_OPTION_DISPLAY_ISOLATED is set the scheme can only be
		///  displayed from other content hosted with the same scheme. For example,
		///  pages in other origins cannot create iframes or hyperlinks to URLs with the
		///  scheme. For schemes that must be accessible from other schemes don&apos;t set
		///  this, set CEF_SCHEME_OPTION_CORS_ENABLED, and use CORS
		///  &quot;Access-Control-Allow-Origin&quot; headers to further restrict access.
		/// </summary>
		DisplayIsolated = 1 << 2,

		/// <summary>
		///  If CEF_SCHEME_OPTION_SECURE is set the scheme will be treated with the same
		///  security rules as those applied to &quot;https&quot; URLs. For example, loading this
		///  scheme from other secure schemes will not trigger mixed content warnings.
		/// </summary>
		Secure = 1 << 3,

		/// <summary>
		///  If CEF_SCHEME_OPTION_CORS_ENABLED is set the scheme can be sent CORS
		///  requests. This value should be set in most cases where
		///  CEF_SCHEME_OPTION_STANDARD is set.
		/// </summary>
		CorsEnabled = 1 << 4,

		/// <summary>
		///  If CEF_SCHEME_OPTION_CSP_BYPASSING is set the scheme can bypass Content-
		///  Security-Policy (CSP) checks. This value should not be set in most cases
		///  where CEF_SCHEME_OPTION_STANDARD is set.
		/// </summary>
		CspBypassing = 1 << 5,

		/// <summary>
		///  If CEF_SCHEME_OPTION_FETCH_ENABLED is set the scheme can perform Fetch API
		///  requests.
		/// </summary>
		FetchEnabled = 1 << 6
	}
}