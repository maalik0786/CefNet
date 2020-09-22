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
	///  Supported event bit flags.
	/// </summary>
	public enum CefEventFlags
	{
		None = 0,

		CapsLockOn = 1 << 0,

		ShiftDown = 1 << 1,

		ControlDown = 1 << 2,

		AltDown = 1 << 3,

		LeftMouseButton = 1 << 4,

		MiddleMouseButton = 1 << 5,

		RightMouseButton = 1 << 6,

		/// <summary>
		///  Mac OS-X command key.
		/// </summary>
		CommandDown = 1 << 7,

		/// <summary>
		///  Mac OS-X command key.
		/// </summary>
		NumLockOn = 1 << 8,

		/// <summary>
		///  Mac OS-X command key.
		/// </summary>
		IsKeyPad = 1 << 9,

		/// <summary>
		///  Mac OS-X command key.
		/// </summary>
		IsLeft = 1 << 10,

		/// <summary>
		///  Mac OS-X command key.
		/// </summary>
		IsRight = 1 << 11,

		/// <summary>
		///  Mac OS-X command key.
		/// </summary>
		AltgrDown = 1 << 12
	}
}