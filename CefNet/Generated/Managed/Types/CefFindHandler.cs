﻿// --------------------------------------------------------------------------------------------
// Copyright (c) 2019 The CefNet Authors. All rights reserved.
// Licensed under the MIT license.
// See the licence file in the project root for full license information.
// --------------------------------------------------------------------------------------------
// Generated by CefGen
// Source: Generated/Native/Types/cef_find_handler_t.cs
// --------------------------------------------------------------------------------------------﻿
// DO NOT MODIFY! THIS IS AUTOGENERATED FILE!
// --------------------------------------------------------------------------------------------

#pragma warning disable 0169, 1591, 1573

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CefNet.CApi;
using CefNet.Internal;

namespace CefNet
{
	/// <summary>
	///  Implement this structure to handle events related to find results. The
	///  functions of this structure will be called on the UI thread.
	/// </summary>
	/// <remarks>
	///  Role: Handler
	/// </remarks>
	public unsafe class CefFindHandler : CefBaseRefCounted<cef_find_handler_t>, ICefFindHandlerPrivate
	{
		private static readonly OnFindResultDelegate fnOnFindResult = OnFindResultImpl;

		public CefFindHandler()
		{
			var self = NativeInstance;
			self->on_find_result = (void*) Marshal.GetFunctionPointerForDelegate(fnOnFindResult);
		}

		public CefFindHandler(cef_find_handler_t* instance)
			: base((cef_base_ref_counted_t*) instance)
		{
		}

		[MethodImpl(MethodImplOptions.ForwardRef)]
		extern bool ICefFindHandlerPrivate.AvoidOnFindResult();

		internal static CefFindHandler Create(IntPtr instance)
		{
			return new CefFindHandler((cef_find_handler_t*) instance);
		}

		/// <summary>
		///  Called to report find results returned by cef_browser_host_t::find().
		///  |identifer| is the identifier passed to find(), |count| is the number of
		///  matches currently identified, |selectionRect| is the location of where the
		///  match was found (in window coordinates), |activeMatchOrdinal| is the
		///  current position in the search results, and |finalUpdate| is true (1) if
		///  this is the last find notification.
		/// </summary>
		protected internal virtual void OnFindResult(CefBrowser browser, int identifier, int count,
			CefRect selectionRect, int activeMatchOrdinal, bool finalUpdate)
		{
		}

		// void (*)(_cef_find_handler_t* self, _cef_browser_t* browser, int identifier, int count, const cef_rect_t* selectionRect, int activeMatchOrdinal, int finalUpdate)*
		private static void OnFindResultImpl(cef_find_handler_t* self, cef_browser_t* browser, int identifier,
			int count, cef_rect_t* selectionRect, int activeMatchOrdinal, int finalUpdate)
		{
			var instance = GetInstance((IntPtr) self) as CefFindHandler;
			if (instance == null || ((ICefFindHandlerPrivate) instance).AvoidOnFindResult())
			{
				ReleaseIfNonNull((cef_base_ref_counted_t*) browser);
				return;
			}

			instance.OnFindResult(CefBrowser.Wrap(CefBrowser.Create, browser), identifier, count,
				*(CefRect*) selectionRect, activeMatchOrdinal, finalUpdate != 0);
		}

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		private delegate void OnFindResultDelegate(cef_find_handler_t* self, cef_browser_t* browser, int identifier,
			int count, cef_rect_t* selectionRect, int activeMatchOrdinal, int finalUpdate);
	}
}