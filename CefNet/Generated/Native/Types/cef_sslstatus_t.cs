﻿// --------------------------------------------------------------------------------------------
// Copyright (c) 2019 The CefNet Authors. All rights reserved.
// Licensed under the MIT license.
// See the licence file in the project root for full license information.
// --------------------------------------------------------------------------------------------
// Generated by CefGen
// Source: include/capi/cef_ssl_status_capi.h
// --------------------------------------------------------------------------------------------﻿
// DO NOT MODIFY! THIS IS AUTOGENERATED FILE!
// --------------------------------------------------------------------------------------------

#pragma warning disable 0169, 1591, 1573

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CefNet.CApi
{
	/// <summary>
	///  Structure representing the SSL information for a navigation entry.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct cef_sslstatus_t
	{
		/// <summary>
		///  Base structure.
		/// </summary>
		public cef_base_ref_counted_t @base;

		/// <summary>
		///  int (*)(_cef_sslstatus_t* self)*
		/// </summary>
		public void* is_secure_connection;

		/// <summary>
		///  Returns true (1) if the status is related to a secure SSL/TLS connection.
		/// </summary>
		[NativeName("is_secure_connection")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern int IsSecureConnection();

		/// <summary>
		///  cef_cert_status_t (*)(_cef_sslstatus_t* self)*
		/// </summary>
		public void* get_cert_status;

		/// <summary>
		///  Returns a bitmask containing any and all problems verifying the server
		///  certificate.
		/// </summary>
		[NativeName("get_cert_status")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern CefCertStatus GetCertStatus();

		/// <summary>
		///  cef_ssl_version_t (*)(_cef_sslstatus_t* self)*
		/// </summary>
		public void* get_sslversion;

		/// <summary>
		///  Returns the SSL version used for the SSL connection.
		/// </summary>
		[NativeName("get_sslversion")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern CefSSLVersion GetSslversion();

		/// <summary>
		///  cef_ssl_content_status_t (*)(_cef_sslstatus_t* self)*
		/// </summary>
		public void* get_content_status;

		/// <summary>
		///  Returns a bitmask containing the page security content status.
		/// </summary>
		[NativeName("get_content_status")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern CefSSLContentStatus GetContentStatus();

		/// <summary>
		///  _cef_x509certificate_t* (*)(_cef_sslstatus_t* self)*
		/// </summary>
		public void* get_x509certificate;

		/// <summary>
		///  Returns the X.509 certificate.
		/// </summary>
		[NativeName("get_x509certificate")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern cef_x509certificate_t* GetX509certificate();
	}
}