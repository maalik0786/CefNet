﻿// --------------------------------------------------------------------------------------------
// Copyright (c) 2019 The CefNet Authors. All rights reserved.
// Licensed under the MIT license.
// See the licence file in the project root for full license information.
// --------------------------------------------------------------------------------------------
// Generated by CefGen
// Source: include/capi/cef_stream_capi.h
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
	///  Structure the client can implement to provide a custom stream writer. The
	///  functions of this structure may be called on any thread.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct cef_write_handler_t
	{
		/// <summary>
		///  Base structure.
		/// </summary>
		public cef_base_ref_counted_t @base;

		/// <summary>
		///  size_t (*)(_cef_write_handler_t* self, const void* ptr, size_t size, size_t n)*
		/// </summary>
		public void* write;

		/// <summary>
		///  Write raw binary data.
		/// </summary>
		[NativeName("write")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern UIntPtr Write([Immutable] void* ptr, UIntPtr size, UIntPtr n);

		/// <summary>
		///  int (*)(_cef_write_handler_t* self, int64 offset, int whence)*
		/// </summary>
		public void* seek;

		/// <summary>
		///  Seek to the specified offset position. |whence| may be any one of SEEK_CUR,
		///  SEEK_END or SEEK_SET. Return zero on success and non-zero on failure.
		/// </summary>
		[NativeName("seek")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern int Seek(long offset, int whence);

		/// <summary>
		///  int64 (*)(_cef_write_handler_t* self)*
		/// </summary>
		public void* tell;

		/// <summary>
		///  Return the current offset position.
		/// </summary>
		[NativeName("tell")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern long Tell();

		/// <summary>
		///  int (*)(_cef_write_handler_t* self)*
		/// </summary>
		public void* flush;

		/// <summary>
		///  Flush the stream.
		/// </summary>
		[NativeName("flush")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern int Flush();

		/// <summary>
		///  int (*)(_cef_write_handler_t* self)*
		/// </summary>
		public void* may_block;

		/// <summary>
		///  Return true (1) if this handler performs work like accessing the file
		///  system which may block. Used as a hint for determining the thread to access
		///  the handler from.
		/// </summary>
		[NativeName("may_block")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern int MayBlock();
	}
}