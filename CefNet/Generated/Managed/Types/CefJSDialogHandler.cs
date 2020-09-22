﻿// --------------------------------------------------------------------------------------------
// Copyright (c) 2019 The CefNet Authors. All rights reserved.
// Licensed under the MIT license.
// See the licence file in the project root for full license information.
// --------------------------------------------------------------------------------------------
// Generated by CefGen
// Source: Generated/Native/Types/cef_jsdialog_handler_t.cs
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
	///  Implement this structure to handle events related to JavaScript dialogs. The
	///  functions of this structure will be called on the UI thread.
	/// </summary>
	/// <remarks>
	///  Role: Handler
	/// </remarks>
	public unsafe class CefJSDialogHandler : CefBaseRefCounted<cef_jsdialog_handler_t>, ICefJSDialogHandlerPrivate
	{
		private static readonly OnJSDialogDelegate fnOnJSDialog = OnJSDialogImpl;

		private static readonly OnBeforeUnloadDialogDelegate fnOnBeforeUnloadDialog = OnBeforeUnloadDialogImpl;

		private static readonly OnResetDialogStateDelegate fnOnResetDialogState = OnResetDialogStateImpl;

		private static readonly OnDialogClosedDelegate fnOnDialogClosed = OnDialogClosedImpl;

		public CefJSDialogHandler()
		{
			var self = NativeInstance;
			self->on_jsdialog = (void*) Marshal.GetFunctionPointerForDelegate(fnOnJSDialog);
			self->on_before_unload_dialog = (void*) Marshal.GetFunctionPointerForDelegate(fnOnBeforeUnloadDialog);
			self->on_reset_dialog_state = (void*) Marshal.GetFunctionPointerForDelegate(fnOnResetDialogState);
			self->on_dialog_closed = (void*) Marshal.GetFunctionPointerForDelegate(fnOnDialogClosed);
		}

		public CefJSDialogHandler(cef_jsdialog_handler_t* instance)
			: base((cef_base_ref_counted_t*) instance)
		{
		}

		[MethodImpl(MethodImplOptions.ForwardRef)]
		extern bool ICefJSDialogHandlerPrivate.AvoidOnJSDialog();

		[MethodImpl(MethodImplOptions.ForwardRef)]
		extern bool ICefJSDialogHandlerPrivate.AvoidOnBeforeUnloadDialog();

		[MethodImpl(MethodImplOptions.ForwardRef)]
		extern bool ICefJSDialogHandlerPrivate.AvoidOnResetDialogState();

		[MethodImpl(MethodImplOptions.ForwardRef)]
		extern bool ICefJSDialogHandlerPrivate.AvoidOnDialogClosed();

		internal static CefJSDialogHandler Create(IntPtr instance)
		{
			return new CefJSDialogHandler((cef_jsdialog_handler_t*) instance);
		}

		/// <summary>
		///  Called to run a JavaScript dialog. If |origin_url| is non-NULL it can be
		///  passed to the CefFormatUrlForSecurityDisplay function to retrieve a secure
		///  and user-friendly display string. The |default_prompt_text| value will be
		///  specified for prompt dialogs only. Set |suppress_message| to true (1) and
		///  return false (0) to suppress the message (suppressing messages is
		///  preferable to immediately executing the callback as this is used to detect
		///  presumably malicious behavior like spamming alert messages in
		///  onbeforeunload). Set |suppress_message| to false (0) and return false (0)
		///  to use the default implementation (the default implementation will show one
		///  modal dialog at a time and suppress any additional dialog requests until
		///  the displayed dialog is dismissed). Return true (1) if the application will
		///  use a custom dialog or if the callback has been executed immediately.
		///  Custom dialogs may be either modal or modeless. If a custom dialog is used
		///  the application must execute |callback| once the custom dialog is
		///  dismissed.
		/// </summary>
		protected internal virtual bool OnJSDialog(CefBrowser browser, string originUrl, CefJSDialogType dialogType,
			string messageText, string defaultPromptText, CefJSDialogCallback callback, ref int suppressMessage)
		{
			return default;
		}

		// int (*)(_cef_jsdialog_handler_t* self, _cef_browser_t* browser, const cef_string_t* origin_url, cef_jsdialog_type_t dialog_type, const cef_string_t* message_text, const cef_string_t* default_prompt_text, _cef_jsdialog_callback_t* callback, int* suppress_message)*
		private static int OnJSDialogImpl(cef_jsdialog_handler_t* self, cef_browser_t* browser,
			cef_string_t* origin_url, CefJSDialogType dialog_type, cef_string_t* message_text,
			cef_string_t* default_prompt_text, cef_jsdialog_callback_t* callback, int* suppress_message)
		{
			var instance = GetInstance((IntPtr) self) as CefJSDialogHandler;
			if (instance == null || ((ICefJSDialogHandlerPrivate) instance).AvoidOnJSDialog())
			{
				ReleaseIfNonNull((cef_base_ref_counted_t*) browser);
				ReleaseIfNonNull((cef_base_ref_counted_t*) callback);
				return default;
			}

			return instance.OnJSDialog(CefBrowser.Wrap(CefBrowser.Create, browser), CefString.Read(origin_url),
				dialog_type, CefString.Read(message_text), CefString.Read(default_prompt_text),
				CefJSDialogCallback.Wrap(CefJSDialogCallback.Create, callback), ref *suppress_message)
				? 1
				: 0;
		}

		/// <summary>
		///  Called to run a dialog asking the user if they want to leave a page. Return
		///  false (0) to use the default dialog implementation. Return true (1) if the
		///  application will use a custom dialog or if the callback has been executed
		///  immediately. Custom dialogs may be either modal or modeless. If a custom
		///  dialog is used the application must execute |callback| once the custom
		///  dialog is dismissed.
		/// </summary>
		protected internal virtual bool OnBeforeUnloadDialog(CefBrowser browser, string messageText, bool isReload,
			CefJSDialogCallback callback)
		{
			return default;
		}

		// int (*)(_cef_jsdialog_handler_t* self, _cef_browser_t* browser, const cef_string_t* message_text, int is_reload, _cef_jsdialog_callback_t* callback)*
		private static int OnBeforeUnloadDialogImpl(cef_jsdialog_handler_t* self, cef_browser_t* browser,
			cef_string_t* message_text, int is_reload, cef_jsdialog_callback_t* callback)
		{
			var instance = GetInstance((IntPtr) self) as CefJSDialogHandler;
			if (instance == null || ((ICefJSDialogHandlerPrivate) instance).AvoidOnBeforeUnloadDialog())
			{
				ReleaseIfNonNull((cef_base_ref_counted_t*) browser);
				ReleaseIfNonNull((cef_base_ref_counted_t*) callback);
				return default;
			}

			return instance.OnBeforeUnloadDialog(CefBrowser.Wrap(CefBrowser.Create, browser),
				CefString.Read(message_text), is_reload != 0,
				CefJSDialogCallback.Wrap(CefJSDialogCallback.Create, callback))
				? 1
				: 0;
		}

		/// <summary>
		///  Called to cancel any pending dialogs and reset any saved dialog state. Will
		///  be called due to events like page navigation irregardless of whether any
		///  dialogs are currently pending.
		/// </summary>
		protected internal virtual void OnResetDialogState(CefBrowser browser)
		{
		}

		// void (*)(_cef_jsdialog_handler_t* self, _cef_browser_t* browser)*
		private static void OnResetDialogStateImpl(cef_jsdialog_handler_t* self, cef_browser_t* browser)
		{
			var instance = GetInstance((IntPtr) self) as CefJSDialogHandler;
			if (instance == null || ((ICefJSDialogHandlerPrivate) instance).AvoidOnResetDialogState())
			{
				ReleaseIfNonNull((cef_base_ref_counted_t*) browser);
				return;
			}

			instance.OnResetDialogState(CefBrowser.Wrap(CefBrowser.Create, browser));
		}

		/// <summary>
		///  Called when the default implementation dialog is closed.
		/// </summary>
		protected internal virtual void OnDialogClosed(CefBrowser browser)
		{
		}

		// void (*)(_cef_jsdialog_handler_t* self, _cef_browser_t* browser)*
		private static void OnDialogClosedImpl(cef_jsdialog_handler_t* self, cef_browser_t* browser)
		{
			var instance = GetInstance((IntPtr) self) as CefJSDialogHandler;
			if (instance == null || ((ICefJSDialogHandlerPrivate) instance).AvoidOnDialogClosed())
			{
				ReleaseIfNonNull((cef_base_ref_counted_t*) browser);
				return;
			}

			instance.OnDialogClosed(CefBrowser.Wrap(CefBrowser.Create, browser));
		}

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		private delegate int OnJSDialogDelegate(cef_jsdialog_handler_t* self, cef_browser_t* browser,
			cef_string_t* origin_url, CefJSDialogType dialog_type, cef_string_t* message_text,
			cef_string_t* default_prompt_text, cef_jsdialog_callback_t* callback, int* suppress_message);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		private delegate int OnBeforeUnloadDialogDelegate(cef_jsdialog_handler_t* self, cef_browser_t* browser,
			cef_string_t* message_text, int is_reload, cef_jsdialog_callback_t* callback);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		private delegate void OnResetDialogStateDelegate(cef_jsdialog_handler_t* self, cef_browser_t* browser);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		private delegate void OnDialogClosedDelegate(cef_jsdialog_handler_t* self, cef_browser_t* browser);
	}
}