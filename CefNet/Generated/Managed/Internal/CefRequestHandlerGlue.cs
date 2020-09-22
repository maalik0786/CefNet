﻿// --------------------------------------------------------------------------------------------
// Copyright (c) 2019 The CefNet Authors. All rights reserved.
// Licensed under the MIT license.
// See the licence file in the project root for full license information.
// --------------------------------------------------------------------------------------------
// Generated by CefGen
// Source: Generated/Native/Types/cef_request_handler_t.cs
// --------------------------------------------------------------------------------------------﻿
// DO NOT MODIFY! THIS IS AUTOGENERATED FILE!
// --------------------------------------------------------------------------------------------

#pragma warning disable 0169, 1591, 1573

namespace CefNet.Internal
{
	internal sealed class CefRequestHandlerGlue : CefRequestHandler, ICefRequestHandlerPrivate
	{
		private readonly WebViewGlue _implementation;

		public CefRequestHandlerGlue(WebViewGlue impl)
		{
			_implementation = impl;
		}

		bool ICefRequestHandlerPrivate.AvoidOnBeforeBrowse()
		{
			return _implementation.AvoidOnBeforeBrowse();
		}

		bool ICefRequestHandlerPrivate.AvoidOnOpenUrlFromTab()
		{
			return _implementation.AvoidOnOpenUrlFromTab();
		}

		bool ICefRequestHandlerPrivate.AvoidGetResourceRequestHandler()
		{
			return _implementation.AvoidGetResourceRequestHandler();
		}

		bool ICefRequestHandlerPrivate.AvoidGetAuthCredentials()
		{
			return _implementation.AvoidGetAuthCredentials();
		}

		bool ICefRequestHandlerPrivate.AvoidOnQuotaRequest()
		{
			return _implementation.AvoidOnQuotaRequest();
		}

		bool ICefRequestHandlerPrivate.AvoidOnCertificateError()
		{
			return _implementation.AvoidOnCertificateError();
		}

		bool ICefRequestHandlerPrivate.AvoidOnSelectClientCertificate()
		{
			return _implementation.AvoidOnSelectClientCertificate();
		}

		bool ICefRequestHandlerPrivate.AvoidOnPluginCrashed()
		{
			return _implementation.AvoidOnPluginCrashed();
		}

		bool ICefRequestHandlerPrivate.AvoidOnRenderViewReady()
		{
			return _implementation.AvoidOnRenderViewReady();
		}

		bool ICefRequestHandlerPrivate.AvoidOnRenderProcessTerminated()
		{
			return _implementation.AvoidOnRenderProcessTerminated();
		}

		bool ICefRequestHandlerPrivate.AvoidOnDocumentAvailableInMainFrame()
		{
			return _implementation.AvoidOnDocumentAvailableInMainFrame();
		}

		protected internal override bool OnBeforeBrowse(CefBrowser browser, CefFrame frame, CefRequest request,
			bool userGesture, bool isRedirect)
		{
			return _implementation.OnBeforeBrowse(browser, frame, request, userGesture, isRedirect);
		}

		protected internal override bool OnOpenUrlFromTab(CefBrowser browser, CefFrame frame, string targetUrl,
			CefWindowOpenDisposition targetDisposition, bool userGesture)
		{
			return _implementation.OnOpenUrlFromTab(browser, frame, targetUrl, targetDisposition, userGesture);
		}

		protected internal override CefResourceRequestHandler GetResourceRequestHandler(CefBrowser browser,
			CefFrame frame, CefRequest request, bool isNavigation, bool isDownload, string requestInitiator,
			ref int disableDefaultHandling)
		{
			return _implementation.GetResourceRequestHandler(browser, frame, request, isNavigation, isDownload,
				requestInitiator, ref disableDefaultHandling);
		}

		protected internal override bool GetAuthCredentials(CefBrowser browser, string originUrl, bool isProxy,
			string host, int port, string realm, string scheme, CefAuthCallback callback)
		{
			return _implementation.GetAuthCredentials(browser, originUrl, isProxy, host, port, realm, scheme, callback);
		}

		protected internal override bool OnQuotaRequest(CefBrowser browser, string originUrl, long newSize,
			CefRequestCallback callback)
		{
			return _implementation.OnQuotaRequest(browser, originUrl, newSize, callback);
		}

		protected internal override bool OnCertificateError(CefBrowser browser, CefErrorCode certError,
			string requestUrl, CefSSLInfo sSLInfo, CefRequestCallback callback)
		{
			return _implementation.OnCertificateError(browser, certError, requestUrl, sSLInfo, callback);
		}

		protected internal override bool OnSelectClientCertificate(CefBrowser browser, bool isProxy, string host,
			int port, CefX509Certificate[] certificates, CefSelectClientCertificateCallback callback)
		{
			return _implementation.OnSelectClientCertificate(browser, isProxy, host, port, certificates, callback);
		}

		protected internal override void OnPluginCrashed(CefBrowser browser, string pluginPath)
		{
			_implementation.OnPluginCrashed(browser, pluginPath);
		}

		protected internal override void OnRenderViewReady(CefBrowser browser)
		{
			_implementation.OnRenderViewReady(browser);
		}

		protected internal override void OnRenderProcessTerminated(CefBrowser browser, CefTerminationStatus status)
		{
			_implementation.OnRenderProcessTerminated(browser, status);
		}

		protected internal override void OnDocumentAvailableInMainFrame(CefBrowser browser)
		{
			_implementation.OnDocumentAvailableInMainFrame(browser);
		}
	}
}