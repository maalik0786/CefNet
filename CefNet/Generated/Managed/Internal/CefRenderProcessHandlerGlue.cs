﻿// --------------------------------------------------------------------------------------------
// Copyright (c) 2019 The CefNet Authors. All rights reserved.
// Licensed under the MIT license.
// See the licence file in the project root for full license information.
// --------------------------------------------------------------------------------------------
// Generated by CefGen
// Source: Generated/Native/Types/cef_render_process_handler_t.cs
// --------------------------------------------------------------------------------------------﻿
// DO NOT MODIFY! THIS IS AUTOGENERATED FILE!
// --------------------------------------------------------------------------------------------

#pragma warning disable 0169, 1591, 1573

namespace CefNet.Internal
{
	internal sealed class CefRenderProcessHandlerGlue : CefRenderProcessHandler, ICefRenderProcessHandlerPrivate
	{
		private readonly CefAppGlue _implementation;

		public CefRenderProcessHandlerGlue(CefAppGlue impl)
		{
			_implementation = impl;
		}

		bool ICefRenderProcessHandlerPrivate.AvoidOnBrowserCreated()
		{
			return _implementation.AvoidOnBrowserCreated();
		}

		bool ICefRenderProcessHandlerPrivate.AvoidOnBrowserDestroyed()
		{
			return _implementation.AvoidOnBrowserDestroyed();
		}

		bool ICefRenderProcessHandlerPrivate.AvoidOnContextCreated()
		{
			return _implementation.AvoidOnContextCreated();
		}

		bool ICefRenderProcessHandlerPrivate.AvoidOnContextReleased()
		{
			return _implementation.AvoidOnContextReleased();
		}

		bool ICefRenderProcessHandlerPrivate.AvoidOnUncaughtException()
		{
			return _implementation.AvoidOnUncaughtException();
		}

		bool ICefRenderProcessHandlerPrivate.AvoidOnFocusedNodeChanged()
		{
			return _implementation.AvoidOnFocusedNodeChanged();
		}

		bool ICefRenderProcessHandlerPrivate.AvoidOnProcessMessageReceived()
		{
			return _implementation.AvoidOnProcessMessageReceived();
		}

		protected internal override void OnWebKitInitialized()
		{
			_implementation.OnWebKitInitialized();
		}

		protected internal override void OnBrowserCreated(CefBrowser browser, CefDictionaryValue extraInfo)
		{
			_implementation.OnBrowserCreated(browser, extraInfo);
		}

		protected internal override void OnBrowserDestroyed(CefBrowser browser)
		{
			_implementation.OnBrowserDestroyed(browser);
		}

		protected internal override CefLoadHandler GetLoadHandler()
		{
			return _implementation.GetLoadHandler();
		}

		protected internal override void OnContextCreated(CefBrowser browser, CefFrame frame, CefV8Context context)
		{
			_implementation.OnContextCreated(browser, frame, context);
		}

		protected internal override void OnContextReleased(CefBrowser browser, CefFrame frame, CefV8Context context)
		{
			_implementation.OnContextReleased(browser, frame, context);
		}

		protected internal override void OnUncaughtException(CefBrowser browser, CefFrame frame, CefV8Context context,
			CefV8Exception exception, CefV8StackTrace stackTrace)
		{
			_implementation.OnUncaughtException(browser, frame, context, exception, stackTrace);
		}

		protected internal override void OnFocusedNodeChanged(CefBrowser browser, CefFrame frame, CefDOMNode node)
		{
			_implementation.OnFocusedNodeChanged(browser, frame, node);
		}

		protected internal override bool OnProcessMessageReceived(CefBrowser browser, CefFrame frame,
			CefProcessId sourceProcess, CefProcessMessage message)
		{
			return _implementation.OnProcessMessageReceived(browser, frame, sourceProcess, message);
		}
	}
}