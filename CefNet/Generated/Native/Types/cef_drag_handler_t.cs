﻿// --------------------------------------------------------------------------------------------
// Copyright (c) 2019 The CefNet Authors. All rights reserved.
// Licensed under the MIT license.
// See the licence file in the project root for full license information.
// --------------------------------------------------------------------------------------------
// Generated by CefGen
// Source: include/capi/cef_drag_handler_capi.h
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
	///  Implement this structure to handle events related to dragging. The functions
	///  of this structure will be called on the UI thread.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct cef_drag_handler_t
	{
		/// <summary>
		///  Base structure.
		/// </summary>
		public cef_base_ref_counted_t @base;

		/// <summary>
		///  int (*)(_cef_drag_handler_t* self, _cef_browser_t* browser, _cef_drag_data_t* dragData, cef_drag_operations_mask_t
		///  mask)*
		/// </summary>
		public void* on_drag_enter;

		/// <summary>
		///  Called when an external drag event enters the browser window. |dragData|
		///  contains the drag event data and |mask| represents the type of drag
		///  operation. Return false (0) for default drag handling behavior or true (1)
		///  to cancel the drag event.
		/// </summary>
		[NativeName("on_drag_enter")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern int OnDragEnter(cef_browser_t* browser, cef_drag_data_t* dragData, CefDragOperationsMask mask);

		/// <summary>
		///  void (*)(_cef_drag_handler_t* self, _cef_browser_t* browser, _cef_frame_t* frame, size_t regionsCount, const
		///  cef_draggable_region_t* regions)*
		/// </summary>
		public void* on_draggable_regions_changed;

		/// <summary>
		///  Called whenever draggable regions for the browser window change. These can
		///  be specified using the &apos;-webkit-app-region: drag/no-drag&apos; CSS-property. If
		///  draggable regions are never defined in a document this function will also
		///  never be called. If the last draggable region is removed from a document
		///  this function will be called with an NULL vector.
		/// </summary>
		[MethodImpl(MethodImplOptions.ForwardRef)]
		[NativeName("on_draggable_regions_changed")]
		public extern void OnDraggableRegionsChanged(cef_browser_t* browser, cef_frame_t* frame, UIntPtr regionsCount,
			[Immutable] cef_draggable_region_t* regions);
	}
}