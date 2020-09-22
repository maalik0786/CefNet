﻿// --------------------------------------------------------------------------------------------
// Copyright (c) 2019 The CefNet Authors. All rights reserved.
// Licensed under the MIT license.
// See the licence file in the project root for full license information.
// --------------------------------------------------------------------------------------------
// Generated by CefGen
// Source: include/capi/cef_cookie_capi.h
// --------------------------------------------------------------------------------------------﻿
// DO NOT MODIFY! THIS IS AUTOGENERATED FILE!
// --------------------------------------------------------------------------------------------

#pragma warning disable 0169, 1591, 1573

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CefNet.CApi
{
	/// <summary>
	///  Structure to implement for visiting cookie values. The functions of this
	///  structure will always be called on the UI thread.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct cef_cookie_visitor_t
	{
		/// <summary>
		///  Base structure.
		/// </summary>
		public cef_base_ref_counted_t @base;

		/// <summary>
		///  int (*)(_cef_cookie_visitor_t* self, const const _cef_cookie_t* cookie, int count, int total, int* deleteCookie)*
		/// </summary>
		public void* visit;

		/// <summary>
		///  Method that will be called once for each cookie. |count| is the 0-based
		///  index for the current cookie. |total| is the total number of cookies. Set
		///  |deleteCookie| to true (1) to delete the cookie currently being visited.
		///  Return false (0) to stop visiting cookies. This function may never be
		///  called if no cookies are found.
		/// </summary>
		[NativeName("visit")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern int Visit([Immutable] cef_cookie_t* cookie, int count, int total, int* deleteCookie);
	}
}