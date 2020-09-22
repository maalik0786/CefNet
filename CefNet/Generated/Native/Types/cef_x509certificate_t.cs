﻿// --------------------------------------------------------------------------------------------
// Copyright (c) 2019 The CefNet Authors. All rights reserved.
// Licensed under the MIT license.
// See the licence file in the project root for full license information.
// --------------------------------------------------------------------------------------------
// Generated by CefGen
// Source: include/capi/cef_x509_certificate_capi.h
// --------------------------------------------------------------------------------------------﻿
// DO NOT MODIFY! THIS IS AUTOGENERATED FILE!
// --------------------------------------------------------------------------------------------

#pragma warning disable 0169, 1591, 1573

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CefNet.CApi
{
	/// <summary>
	///  Structure representing a X.509 certificate.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct cef_x509certificate_t
	{
		/// <summary>
		///  Base structure.
		/// </summary>
		public cef_base_ref_counted_t @base;

		/// <summary>
		///  _cef_x509cert_principal_t* (*)(_cef_x509certificate_t* self)*
		/// </summary>
		public void* get_subject;

		/// <summary>
		///  Returns the subject of the X.509 certificate. For HTTPS server certificates
		///  this represents the web server.  The common name of the subject should
		///  match the host name of the web server.
		/// </summary>
		[NativeName("get_subject")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern cef_x509cert_principal_t* GetSubject();

		/// <summary>
		///  _cef_x509cert_principal_t* (*)(_cef_x509certificate_t* self)*
		/// </summary>
		public void* get_issuer;

		/// <summary>
		///  Returns the issuer of the X.509 certificate.
		/// </summary>
		[NativeName("get_issuer")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern cef_x509cert_principal_t* GetIssuer();

		/// <summary>
		///  _cef_binary_value_t* (*)(_cef_x509certificate_t* self)*
		/// </summary>
		public void* get_serial_number;

		/// <summary>
		///  Returns the DER encoded serial number for the X.509 certificate. The value
		///  possibly includes a leading 00 byte.
		/// </summary>
		[NativeName("get_serial_number")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern cef_binary_value_t* GetSerialNumber();

		/// <summary>
		///  cef_time_t (*)(_cef_x509certificate_t* self)*
		/// </summary>
		public void* get_valid_start;

		/// <summary>
		///  Returns the date before which the X.509 certificate is invalid.
		///  CefTime.GetTimeT() will return 0 if no date was specified.
		/// </summary>
		[NativeName("get_valid_start")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern cef_time_t GetValidStart();

		/// <summary>
		///  cef_time_t (*)(_cef_x509certificate_t* self)*
		/// </summary>
		public void* get_valid_expiry;

		/// <summary>
		///  Returns the date after which the X.509 certificate is invalid.
		///  CefTime.GetTimeT() will return 0 if no date was specified.
		/// </summary>
		[NativeName("get_valid_expiry")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern cef_time_t GetValidExpiry();

		/// <summary>
		///  _cef_binary_value_t* (*)(_cef_x509certificate_t* self)*
		/// </summary>
		public void* get_derencoded;

		/// <summary>
		///  Returns the DER encoded data for the X.509 certificate.
		/// </summary>
		[NativeName("get_derencoded")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern cef_binary_value_t* GetDEREncoded();

		/// <summary>
		///  _cef_binary_value_t* (*)(_cef_x509certificate_t* self)*
		/// </summary>
		public void* get_pemencoded;

		/// <summary>
		///  Returns the PEM encoded data for the X.509 certificate.
		/// </summary>
		[NativeName("get_pemencoded")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern cef_binary_value_t* GetPEMEncoded();

		/// <summary>
		///  size_t (*)(_cef_x509certificate_t* self)*
		/// </summary>
		public void* get_issuer_chain_size;

		/// <summary>
		///  Returns the number of certificates in the issuer chain. If 0, the
		///  certificate is self-signed.
		/// </summary>
		[NativeName("get_issuer_chain_size")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern UIntPtr GetIssuerChainSize();

		/// <summary>
		///  void (*)(_cef_x509certificate_t* self, size_t* chainCount, _cef_binary_value_t** chain)*
		/// </summary>
		public void* get_derencoded_issuer_chain;

		/// <summary>
		///  Returns the DER encoded data for the certificate issuer chain. If we failed
		///  to encode a certificate in the chain it is still present in the array but
		///  is an NULL string.
		/// </summary>
		[MethodImpl(MethodImplOptions.ForwardRef)]
		[NativeName("get_derencoded_issuer_chain")]
		public extern void GetDEREncodedIssuerChain(UIntPtr* chainCount, cef_binary_value_t** chain);

		/// <summary>
		///  void (*)(_cef_x509certificate_t* self, size_t* chainCount, _cef_binary_value_t** chain)*
		/// </summary>
		public void* get_pemencoded_issuer_chain;

		/// <summary>
		///  Returns the PEM encoded data for the certificate issuer chain. If we failed
		///  to encode a certificate in the chain it is still present in the array but
		///  is an NULL string.
		/// </summary>
		[MethodImpl(MethodImplOptions.ForwardRef)]
		[NativeName("get_pemencoded_issuer_chain")]
		public extern void GetPEMEncodedIssuerChain(UIntPtr* chainCount, cef_binary_value_t** chain);
	}
}