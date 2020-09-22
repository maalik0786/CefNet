﻿// --------------------------------------------------------------------------------------------
// Copyright (c) 2019 The CefNet Authors. All rights reserved.
// Licensed under the MIT license.
// See the licence file in the project root for full license information.
// --------------------------------------------------------------------------------------------
// Generated by CefGen
// Source: Generated/Native/Types/cef_media_sink_t.cs
// --------------------------------------------------------------------------------------------﻿
// DO NOT MODIFY! THIS IS AUTOGENERATED FILE!
// --------------------------------------------------------------------------------------------

#pragma warning disable 0169, 1591, 1573

using System;
using CefNet.CApi;

namespace CefNet
{
	/// <summary>
	///  Represents a sink to which media can be routed. Instances of this object are
	///  retrieved via cef_media_observer_t::OnSinks. The functions of this structure
	///  may be called on any browser process thread unless otherwise indicated.
	/// </summary>
	/// <remarks>
	///  Role: Proxy
	/// </remarks>
	public unsafe class CefMediaSink : CefBaseRefCounted<cef_media_sink_t>
	{
		public CefMediaSink(cef_media_sink_t* instance)
			: base((cef_base_ref_counted_t*) instance)
		{
		}

		/// <summary>
		///  Gets the ID for this sink.
		///  The resulting string must be freed by calling cef_string_userfree_free().
		/// </summary>
		public virtual string Id => SafeCall(CefString.ReadAndFree(NativeInstance->GetId()));

		/// <summary>
		///  Gets the name of this sink.
		///  The resulting string must be freed by calling cef_string_userfree_free().
		/// </summary>
		public virtual string Name => SafeCall(CefString.ReadAndFree(NativeInstance->GetName()));

		/// <summary>
		///  Gets the description of this sink.
		///  The resulting string must be freed by calling cef_string_userfree_free().
		/// </summary>
		public virtual string Description => SafeCall(CefString.ReadAndFree(NativeInstance->GetDescription()));

		/// <summary>
		///  Gets the icon type for this sink.
		/// </summary>
		public virtual CefMediaSinkIconType IconType => SafeCall(NativeInstance->GetIconType());

		/// <summary>
		///  Gets a value indicating whether this sink accepts content via Cast.
		/// </summary>
		public virtual bool IsCastSink => SafeCall(NativeInstance->IsCastSink() != 0);

		/// <summary>
		///  Gets a value indicating whether this sink accepts content via DIAL.
		/// </summary>
		public virtual bool IsDialSink => SafeCall(NativeInstance->IsDialSink() != 0);

		internal static CefMediaSink Create(IntPtr instance)
		{
			return new CefMediaSink((cef_media_sink_t*) instance);
		}

		/// <summary>
		///  Asynchronously retrieves device info.
		/// </summary>
		public virtual void GetDeviceInfo(CefMediaSinkDeviceInfoCallback callback)
		{
			NativeInstance->GetDeviceInfo(callback != null ? callback.GetNativeInstance() : null);
			GC.KeepAlive(this);
		}

		/// <summary>
		///  Returns true (1) if this sink is compatible with |source|.
		/// </summary>
		public virtual bool IsCompatibleWith(CefMediaSource source)
		{
			return SafeCall(NativeInstance->IsCompatibleWith(source != null ? source.GetNativeInstance() : null) != 0);
		}
	}
}