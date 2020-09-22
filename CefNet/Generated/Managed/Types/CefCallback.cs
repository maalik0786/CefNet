﻿// --------------------------------------------------------------------------------------------
// Copyright (c) 2019 The CefNet Authors. All rights reserved.
// Licensed under the MIT license.
// See the licence file in the project root for full license information.
// --------------------------------------------------------------------------------------------
// Generated by CefGen
// Source: Generated/Native/Types/cef_callback_t.cs
// --------------------------------------------------------------------------------------------﻿
// DO NOT MODIFY! THIS IS AUTOGENERATED FILE!
// --------------------------------------------------------------------------------------------

#pragma warning disable 0169, 1591, 1573

using System;
using CefNet.CApi;

namespace CefNet
{
	/// <summary>
	///  Generic callback structure used for asynchronous continuation.
	/// </summary>
	/// <remarks>
	///  Role: Proxy
	/// </remarks>
	public unsafe class CefCallback : CefBaseRefCounted<cef_callback_t>
	{
		public CefCallback(cef_callback_t* instance)
			: base((cef_base_ref_counted_t*) instance)
		{
		}

		internal static CefCallback Create(IntPtr instance)
		{
			return new CefCallback((cef_callback_t*) instance);
		}

		/// <summary>
		///  Continue processing.
		/// </summary>
		public virtual void Continue()
		{
			NativeInstance->Continue();
			GC.KeepAlive(this);
		}

		/// <summary>
		///  Cancel processing.
		/// </summary>
		public virtual void Cancel()
		{
			NativeInstance->Cancel();
			GC.KeepAlive(this);
		}
	}
}