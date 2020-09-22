﻿// --------------------------------------------------------------------------------------------
// Copyright (c) 2019 The CefNet Authors. All rights reserved.
// Licensed under the MIT license.
// See the licence file in the project root for full license information.
// --------------------------------------------------------------------------------------------
// Generated by CefGen
// Source: Generated/Native/Types/cef_x509cert_principal_t.cs
// --------------------------------------------------------------------------------------------﻿
// DO NOT MODIFY! THIS IS AUTOGENERATED FILE!
// --------------------------------------------------------------------------------------------

#pragma warning disable 0169, 1591, 1573

using System;
using CefNet.CApi;

namespace CefNet
{
	/// <summary>
	///  Structure representing the issuer or subject field of an X.509 certificate.
	/// </summary>
	/// <remarks>
	///  Role: Proxy
	/// </remarks>
	public unsafe class CefX509CertPrincipal : CefBaseRefCounted<cef_x509cert_principal_t>
	{
		public CefX509CertPrincipal(cef_x509cert_principal_t* instance)
			: base((cef_base_ref_counted_t*) instance)
		{
		}

		/// <summary>
		///  Gets a name that can be used to represent the issuer. It tries in this
		///  order: Common Name (CN), Organization Name (O) and Organizational Unit Name
		///  (OU) and returns the first non-NULL one found.
		///  The resulting string must be freed by calling cef_string_userfree_free().
		/// </summary>
		public virtual string DisplayName => SafeCall(CefString.ReadAndFree(NativeInstance->GetDisplayName()));

		/// <summary>
		///  Gets the common name.
		///  The resulting string must be freed by calling cef_string_userfree_free().
		/// </summary>
		public virtual string CommonName => SafeCall(CefString.ReadAndFree(NativeInstance->GetCommonName()));

		/// <summary>
		///  Gets the locality name.
		///  The resulting string must be freed by calling cef_string_userfree_free().
		/// </summary>
		public virtual string LocalityName => SafeCall(CefString.ReadAndFree(NativeInstance->GetLocalityName()));

		/// <summary>
		///  Gets the state or province name.
		///  The resulting string must be freed by calling cef_string_userfree_free().
		/// </summary>
		public virtual string StateOrProvinceName =>
			SafeCall(CefString.ReadAndFree(NativeInstance->GetStateOrProvinceName()));

		/// <summary>
		///  Gets the country name.
		///  The resulting string must be freed by calling cef_string_userfree_free().
		/// </summary>
		public virtual string CountryName => SafeCall(CefString.ReadAndFree(NativeInstance->GetCountryName()));

		internal static CefX509CertPrincipal Create(IntPtr instance)
		{
			return new CefX509CertPrincipal((cef_x509cert_principal_t*) instance);
		}

		/// <summary>
		///  Retrieve the list of street addresses.
		/// </summary>
		public virtual void GetStreetAddresses(CefStringList addresses)
		{
			NativeInstance->GetStreetAddresses(addresses.GetNativeInstance());
			GC.KeepAlive(this);
		}

		/// <summary>
		///  Retrieve the list of organization names.
		/// </summary>
		public virtual void GetOrganizationNames(CefStringList names)
		{
			NativeInstance->GetOrganizationNames(names.GetNativeInstance());
			GC.KeepAlive(this);
		}

		/// <summary>
		///  Retrieve the list of organization unit names.
		/// </summary>
		public virtual void GetOrganizationUnitNames(CefStringList names)
		{
			NativeInstance->GetOrganizationUnitNames(names.GetNativeInstance());
			GC.KeepAlive(this);
		}

		/// <summary>
		///  Retrieve the list of domain components.
		/// </summary>
		public virtual void GetDomainComponents(CefStringList components)
		{
			NativeInstance->GetDomainComponents(components.GetNativeInstance());
			GC.KeepAlive(this);
		}
	}
}