﻿// --------------------------------------------------------------------------------------------
// Copyright (c) 2019 The CefNet Authors. All rights reserved.
// Licensed under the MIT license.
// See the licence file in the project root for full license information.
// --------------------------------------------------------------------------------------------
// Generated by CefGen
// Source: include/internal/cef_string_types.h
// --------------------------------------------------------------------------------------------﻿
// DO NOT MODIFY! THIS IS AUTOGENERATED FILE!
// --------------------------------------------------------------------------------------------

#pragma warning disable 0169, 1591, 1573

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CefNet.CApi
{
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct cef_string_utf16_t
	{
		public char* str;

		public UIntPtr length;

		/// <summary>
		///  void (*)(char16* str)*
		/// </summary>
		public void* dtor;

		[NativeName("dtor")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern void Dtor(char* str);
	}
}