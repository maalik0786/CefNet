﻿// --------------------------------------------------------------------------------------------
// Copyright (c) 2019 The CefNet Authors. All rights reserved.
// Licensed under the MIT license.
// See the licence file in the project root for full license information.
// --------------------------------------------------------------------------------------------
// Generated by CefGen
// Source: include/capi/cef_browser_capi.h
// --------------------------------------------------------------------------------------------﻿
// DO NOT MODIFY! THIS IS AUTOGENERATED FILE!
// --------------------------------------------------------------------------------------------

#pragma warning disable 0169, 1591, 1573

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CefNet.CApi
{
	/// <summary>
	///  Callback structure for cef_browser_host_t::RunFileDialog. The functions of
	///  this structure will be called on the browser process UI thread.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct cef_run_file_dialog_callback_t
	{
		/// <summary>
		///  Base structure.
		/// </summary>
		public cef_base_ref_counted_t @base;

		/// <summary>
		///  void (*)(_cef_run_file_dialog_callback_t* self, int selected_accept_filter, cef_string_list_t file_paths)*
		/// </summary>
		public void* on_file_dialog_dismissed;

		/// <summary>
		///  Called asynchronously after the file dialog is dismissed.
		///  |selected_accept_filter| is the 0-based index of the value selected from
		///  the accept filters array passed to cef_browser_host_t::RunFileDialog.
		///  |file_paths| will be a single value or a list of values depending on the
		///  dialog mode. If the selection was cancelled |file_paths| will be NULL.
		/// </summary>
		[NativeName("on_file_dialog_dismissed")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern void OnFileDialogDismissed(int selected_accept_filter, cef_string_list_t file_paths);
	}
}