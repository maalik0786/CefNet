﻿// --------------------------------------------------------------------------------------------
// Copyright (c) 2019 The CefNet Authors. All rights reserved.
// Licensed under the MIT license.
// See the licence file in the project root for full license information.
// --------------------------------------------------------------------------------------------
// Generated by CefGen
// Source: Generated/Native/Types/cef_media_route_t.cs
// --------------------------------------------------------------------------------------------﻿
// DO NOT MODIFY! THIS IS AUTOGENERATED FILE!
// --------------------------------------------------------------------------------------------

#pragma warning disable 0169, 1591, 1573

using System;
using CefNet.CApi;

namespace CefNet
{
	/// <summary>
	///  Represents the route between a media source and sink. Instances of this
	///  object are created via cef_media_router_t::CreateRoute and retrieved via
	///  cef_media_observer_t::OnRoutes. Contains the status and metadata of a routing
	///  operation. The functions of this structure may be called on any browser
	///  process thread unless otherwise indicated.
	/// </summary>
	/// <remarks>
	///  Role: Proxy
	/// </remarks>
	public unsafe class CefMediaRoute : CefBaseRefCounted<cef_media_route_t>
	{
		public CefMediaRoute(cef_media_route_t* instance)
			: base((cef_base_ref_counted_t*) instance)
		{
		}

		/// <summary>
		///  Gets the ID for this route.
		///  The resulting string must be freed by calling cef_string_userfree_free().
		/// </summary>
		public virtual string Id => SafeCall(CefString.ReadAndFree(NativeInstance->GetId()));

		/// <summary>
		///  Gets the source associated with this route.
		/// </summary>
		public virtual CefMediaSource Source =>
			SafeCall(CefMediaSource.Wrap(CefMediaSource.Create, NativeInstance->GetSource()));

		/// <summary>
		///  Gets the sink associated with this route.
		/// </summary>
		public virtual CefMediaSink Sink => SafeCall(CefMediaSink.Wrap(CefMediaSink.Create, NativeInstance->GetSink()));

		internal static CefMediaRoute Create(IntPtr instance)
		{
			return new CefMediaRoute((cef_media_route_t*) instance);
		}

		/// <summary>
		///  Send a message over this route. |message| will be copied if necessary.
		/// </summary>
		public virtual void SendRouteMessage(IntPtr message, long messageSize)
		{
			NativeInstance->SendRouteMessage((void*) message, new UIntPtr((ulong) messageSize));
			GC.KeepAlive(this);
		}

		/// <summary>
		///  Terminate this route. Will result in an asynchronous call to
		///  cef_media_observer_t::OnRoutes on all registered observers.
		/// </summary>
		public virtual void Terminate()
		{
			NativeInstance->Terminate();
			GC.KeepAlive(this);
		}
	}
}