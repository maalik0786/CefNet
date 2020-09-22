﻿// --------------------------------------------------------------------------------------------
// Copyright (c) 2019 The CefNet Authors. All rights reserved.
// Licensed under the MIT license.
// See the licence file in the project root for full license information.
// --------------------------------------------------------------------------------------------
// Generated by CefGen
// Source: Generated/Native/Types/cef_client_t.cs
// --------------------------------------------------------------------------------------------﻿
// DO NOT MODIFY! THIS IS AUTOGENERATED FILE!
// --------------------------------------------------------------------------------------------

#pragma warning disable 0169, 1591, 1573

namespace CefNet.Internal
{
	internal sealed partial class CefClientGlue : CefClient, ICefClientPrivate
	{
		public CefClientGlue(WebViewGlue impl)
		{
			Implementation = impl;
		}

		bool ICefClientPrivate.AvoidOnProcessMessageReceived()
		{
			return Implementation.AvoidOnProcessMessageReceived();
		}

		protected internal override CefAudioHandler GetAudioHandler()
		{
			return Implementation.GetAudioHandler();
		}

		protected internal override CefContextMenuHandler GetContextMenuHandler()
		{
			return Implementation.GetContextMenuHandler();
		}

		protected internal override CefDialogHandler GetDialogHandler()
		{
			return Implementation.GetDialogHandler();
		}

		protected internal override CefDisplayHandler GetDisplayHandler()
		{
			return Implementation.GetDisplayHandler();
		}

		protected internal override CefDownloadHandler GetDownloadHandler()
		{
			return Implementation.GetDownloadHandler();
		}

		protected internal override CefDragHandler GetDragHandler()
		{
			return Implementation.GetDragHandler();
		}

		protected internal override CefFindHandler GetFindHandler()
		{
			return Implementation.GetFindHandler();
		}

		protected internal override CefFocusHandler GetFocusHandler()
		{
			return Implementation.GetFocusHandler();
		}

		protected internal override CefJSDialogHandler GetJSDialogHandler()
		{
			return Implementation.GetJSDialogHandler();
		}

		protected internal override CefKeyboardHandler GetKeyboardHandler()
		{
			return Implementation.GetKeyboardHandler();
		}

		protected override CefLifeSpanHandler GetLifeSpanHandler()
		{
			return Implementation.GetLifeSpanHandler();
		}

		protected internal override CefLoadHandler GetLoadHandler()
		{
			return Implementation.GetLoadHandler();
		}

		protected internal override CefRenderHandler GetRenderHandler()
		{
			return Implementation.GetRenderHandler();
		}

		protected internal override CefRequestHandler GetRequestHandler()
		{
			return Implementation.GetRequestHandler();
		}

		protected internal override bool OnProcessMessageReceived(CefBrowser browser, CefFrame frame,
			CefProcessId sourceProcess, CefProcessMessage message)
		{
			return Implementation.OnProcessMessageReceived(browser, frame, sourceProcess, message);
		}
	}
}