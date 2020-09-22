﻿// --------------------------------------------------------------------------------------------
// Copyright (c) 2019 The CefNet Authors. All rights reserved.
// Licensed under the MIT license.
// See the licence file in the project root for full license information.
// --------------------------------------------------------------------------------------------
// Generated by CefGen
// Source: Generated/Native/Types/cef_task_t.cs
// --------------------------------------------------------------------------------------------﻿
// DO NOT MODIFY! THIS IS AUTOGENERATED FILE!
// --------------------------------------------------------------------------------------------

#pragma warning disable 0169, 1591, 1573

using System;
using System.Runtime.InteropServices;
using CefNet.CApi;
using CefNet.Internal;

namespace CefNet
{
	/// <summary>
	///  Implement this structure for asynchronous task execution. If the task is
	///  posted successfully and if the associated message loop is still running then
	///  the execute() function will be called on the target thread. If the task fails
	///  to post then the task object may be destroyed on the source thread instead of
	///  the target thread. For this reason be cautious when performing work in the
	///  task object destructor.
	/// </summary>
	/// <remarks>
	///  Role: Handler
	/// </remarks>
	public unsafe class CefTask : CefBaseRefCounted<cef_task_t>, ICefTaskPrivate
	{
		private static readonly ExecuteDelegate fnExecute = ExecuteImpl;

		public CefTask()
		{
			var self = NativeInstance;
			self->execute = (void*) Marshal.GetFunctionPointerForDelegate(fnExecute);
		}

		public CefTask(cef_task_t* instance)
			: base((cef_base_ref_counted_t*) instance)
		{
		}

		internal static CefTask Create(IntPtr instance)
		{
			return new CefTask((cef_task_t*) instance);
		}

		/// <summary>
		///  Method that will be executed on the target thread.
		/// </summary>
		protected internal virtual void Execute()
		{
		}

		// void (*)(_cef_task_t* self)*
		private static void ExecuteImpl(cef_task_t* self)
		{
			var instance = GetInstance((IntPtr) self) as CefTask;
			if (instance == null) return;
			instance.Execute();
		}

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		private delegate void ExecuteDelegate(cef_task_t* self);
	}
}