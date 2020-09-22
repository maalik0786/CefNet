﻿// --------------------------------------------------------------------------------------------
// Copyright (c) 2019 The CefNet Authors. All rights reserved.
// Licensed under the MIT license.
// See the licence file in the project root for full license information.
// --------------------------------------------------------------------------------------------
// Generated by CefGen
// Source: include/capi/cef_print_settings_capi.h
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
	///  Structure representing print settings.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct cef_print_settings_t
	{
		/// <summary>
		///  Base structure.
		/// </summary>
		public cef_base_ref_counted_t @base;

		/// <summary>
		///  int (*)(_cef_print_settings_t* self)*
		/// </summary>
		public void* is_valid;

		/// <summary>
		///  Returns true (1) if this object is valid. Do not call any other functions
		///  if this function returns false (0).
		/// </summary>
		[NativeName("is_valid")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern int IsValid();

		/// <summary>
		///  int (*)(_cef_print_settings_t* self)*
		/// </summary>
		public void* is_read_only;

		/// <summary>
		///  Returns true (1) if the values of this object are read-only. Some APIs may
		///  expose read-only objects.
		/// </summary>
		[NativeName("is_read_only")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern int IsReadOnly();

		/// <summary>
		///  void (*)(_cef_print_settings_t* self, int landscape)*
		/// </summary>
		public void* set_orientation;

		/// <summary>
		///  Set the page orientation.
		/// </summary>
		[NativeName("set_orientation")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern void SetOrientation(int landscape);

		/// <summary>
		///  int (*)(_cef_print_settings_t* self)*
		/// </summary>
		public void* is_landscape;

		/// <summary>
		///  Returns true (1) if the orientation is landscape.
		/// </summary>
		[NativeName("is_landscape")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern int IsLandscape();

		/// <summary>
		///  void (*)(_cef_print_settings_t* self, const cef_size_t* physical_size_device_units, const cef_rect_t*
		///  printable_area_device_units, int landscape_needs_flip)*
		/// </summary>
		public void* set_printer_printable_area;

		/// <summary>
		///  Set the printer printable area in device units. Some platforms already
		///  provide flipped area. Set |landscape_needs_flip| to false (0) on those
		///  platforms to avoid double flipping.
		/// </summary>
		[MethodImpl(MethodImplOptions.ForwardRef)]
		[NativeName("set_printer_printable_area")]
		public extern void SetPrinterPrintableArea([Immutable] cef_size_t* physical_size_device_units,
			[Immutable] cef_rect_t* printable_area_device_units, int landscape_needs_flip);

		/// <summary>
		///  void (*)(_cef_print_settings_t* self, const cef_string_t* name)*
		/// </summary>
		public void* set_device_name;

		/// <summary>
		///  Set the device name.
		/// </summary>
		[NativeName("set_device_name")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern void SetDeviceName([Immutable] cef_string_t* name);

		/// <summary>
		///  cef_string_userfree_t (*)(_cef_print_settings_t* self)*
		/// </summary>
		public void* get_device_name;

		/// <summary>
		///  Get the device name.
		///  The resulting string must be freed by calling cef_string_userfree_free().
		/// </summary>
		[NativeName("get_device_name")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern cef_string_userfree_t GetDeviceName();

		/// <summary>
		///  void (*)(_cef_print_settings_t* self, int dpi)*
		/// </summary>
		public void* set_dpi;

		/// <summary>
		///  Set the DPI (dots per inch).
		/// </summary>
		[NativeName("set_dpi")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern void SetDpi(int dpi);

		/// <summary>
		///  int (*)(_cef_print_settings_t* self)*
		/// </summary>
		public void* get_dpi;

		/// <summary>
		///  Get the DPI (dots per inch).
		/// </summary>
		[NativeName("get_dpi")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern int GetDpi();

		/// <summary>
		///  void (*)(_cef_print_settings_t* self, size_t rangesCount, const cef_range_t* ranges)*
		/// </summary>
		public void* set_page_ranges;

		/// <summary>
		///  Set the page ranges.
		/// </summary>
		[NativeName("set_page_ranges")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern void SetPageRanges(UIntPtr rangesCount, [Immutable] cef_range_t* ranges);

		/// <summary>
		///  size_t (*)(_cef_print_settings_t* self)*
		/// </summary>
		public void* get_page_ranges_count;

		/// <summary>
		///  Returns the number of page ranges that currently exist.
		/// </summary>
		[NativeName("get_page_ranges_count")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern UIntPtr GetPageRangesCount();

		/// <summary>
		///  void (*)(_cef_print_settings_t* self, size_t* rangesCount, cef_range_t* ranges)*
		/// </summary>
		public void* get_page_ranges;

		/// <summary>
		///  Retrieve the page ranges.
		/// </summary>
		[NativeName("get_page_ranges")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern void GetPageRanges(UIntPtr* rangesCount, cef_range_t* ranges);

		/// <summary>
		///  void (*)(_cef_print_settings_t* self, int selection_only)*
		/// </summary>
		public void* set_selection_only;

		/// <summary>
		///  Set whether only the selection will be printed.
		/// </summary>
		[NativeName("set_selection_only")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern void SetSelectionOnly(int selection_only);

		/// <summary>
		///  int (*)(_cef_print_settings_t* self)*
		/// </summary>
		public void* is_selection_only;

		/// <summary>
		///  Returns true (1) if only the selection will be printed.
		/// </summary>
		[NativeName("is_selection_only")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern int IsSelectionOnly();

		/// <summary>
		///  void (*)(_cef_print_settings_t* self, int collate)*
		/// </summary>
		public void* set_collate;

		/// <summary>
		///  Set whether pages will be collated.
		/// </summary>
		[NativeName("set_collate")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern void SetCollate(int collate);

		/// <summary>
		///  int (*)(_cef_print_settings_t* self)*
		/// </summary>
		public void* will_collate;

		/// <summary>
		///  Returns true (1) if pages will be collated.
		/// </summary>
		[NativeName("will_collate")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern int WillCollate();

		/// <summary>
		///  void (*)(_cef_print_settings_t* self, cef_color_model_t model)*
		/// </summary>
		public void* set_color_model;

		/// <summary>
		///  Set the color model.
		/// </summary>
		[NativeName("set_color_model")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern void SetColorModel(CefColorModel model);

		/// <summary>
		///  cef_color_model_t (*)(_cef_print_settings_t* self)*
		/// </summary>
		public void* get_color_model;

		/// <summary>
		///  Get the color model.
		/// </summary>
		[NativeName("get_color_model")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern CefColorModel GetColorModel();

		/// <summary>
		///  void (*)(_cef_print_settings_t* self, int copies)*
		/// </summary>
		public void* set_copies;

		/// <summary>
		///  Set the number of copies.
		/// </summary>
		[NativeName("set_copies")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern void SetCopies(int copies);

		/// <summary>
		///  int (*)(_cef_print_settings_t* self)*
		/// </summary>
		public void* get_copies;

		/// <summary>
		///  Get the number of copies.
		/// </summary>
		[NativeName("get_copies")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern int GetCopies();

		/// <summary>
		///  void (*)(_cef_print_settings_t* self, cef_duplex_mode_t mode)*
		/// </summary>
		public void* set_duplex_mode;

		/// <summary>
		///  Set the duplex mode.
		/// </summary>
		[NativeName("set_duplex_mode")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern void SetDuplexMode(CefDuplexMode mode);

		/// <summary>
		///  cef_duplex_mode_t (*)(_cef_print_settings_t* self)*
		/// </summary>
		public void* get_duplex_mode;

		/// <summary>
		///  Get the duplex mode.
		/// </summary>
		[NativeName("get_duplex_mode")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern CefDuplexMode GetDuplexMode();
	}
}