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

using System.Runtime.InteropServices;

namespace CefNet.CApi
{
	/// <summary>
	///  Structure representing mouse event information.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct cef_mouse_event_t
	{
		/// <summary>
		///  X coordinate relative to the left side of the view.
		/// </summary>
		public int x;

		/// <summary>
		///  Y coordinate relative to the top side of the view.
		/// </summary>
		public int y;

		/// <summary>
		///  Bit flags describing any pressed modifier keys. See
		///  cef_event_flags_t for values.
		/// </summary>
		public uint modifiers;
	}
}