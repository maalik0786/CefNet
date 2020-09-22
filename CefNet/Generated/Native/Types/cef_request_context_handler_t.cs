﻿// --------------------------------------------------------------------------------------------
// Copyright (c) 2019 The CefNet Authors. All rights reserved.
// Licensed under the MIT license.
// See the licence file in the project root for full license information.
// --------------------------------------------------------------------------------------------
// Generated by CefGen
// Source: include/capi/cef_request_context_handler_capi.h
// --------------------------------------------------------------------------------------------﻿
// DO NOT MODIFY! THIS IS AUTOGENERATED FILE!
// --------------------------------------------------------------------------------------------

#pragma warning disable 0169, 1591, 1573

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CefNet.CApi
{
	/// <summary>
	///  Implement this structure to provide handler implementations. The handler
	///  instance will not be released until all objects related to the context have
	///  been destroyed.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct cef_request_context_handler_t
	{
		/// <summary>
		///  Base structure.
		/// </summary>
		public cef_base_ref_counted_t @base;

		/// <summary>
		///  void (*)(_cef_request_context_handler_t* self, _cef_request_context_t* request_context)*
		/// </summary>
		public void* on_request_context_initialized;

		/// <summary>
		///  Called on the browser process UI thread immediately after the request
		///  context has been initialized.
		/// </summary>
		[MethodImpl(MethodImplOptions.ForwardRef)]
		[NativeName("on_request_context_initialized")]
		public extern void OnRequestContextInitialized(cef_request_context_t* request_context);

		/// <summary>
		///  int (*)(_cef_request_context_handler_t* self, const cef_string_t* mime_type, const cef_string_t* plugin_url, int
		///  is_main_frame, const cef_string_t* top_origin_url, _cef_web_plugin_info_t* plugin_info, cef_plugin_policy_t*
		///  plugin_policy)*
		/// </summary>
		public void* on_before_plugin_load;

		/// <summary>
		///  Called on multiple browser process threads before a plugin instance is
		///  loaded. |mime_type| is the mime type of the plugin that will be loaded.
		///  |plugin_url| is the content URL that the plugin will load and may be NULL.
		///  |is_main_frame| will be true (1) if the plugin is being loaded in the main
		///  (top-level) frame, |top_origin_url| is the URL for the top-level frame that
		///  contains the plugin when loading a specific plugin instance or NULL when
		///  building the initial list of enabled plugins for &apos;navigator.plugins&apos;
		///  JavaScript state. |plugin_info| includes additional information about the
		///  plugin that will be loaded. |plugin_policy| is the recommended policy.
		///  Modify |plugin_policy| and return true (1) to change the policy. Return
		///  false (0) to use the recommended policy. The default plugin policy can be
		///  set at runtime using the `--plugin-policy=[allow|detect|block]` command-
		///  line flag. Decisions to mark a plugin as disabled by setting
		///  |plugin_policy| to PLUGIN_POLICY_DISABLED may be cached when
		///  |top_origin_url| is NULL. To purge the plugin list cache and potentially
		///  trigger new calls to this function call
		///  cef_request_context_t::PurgePluginListCache.
		/// </summary>
		[NativeName("on_before_plugin_load")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern int OnBeforePluginLoad([Immutable] cef_string_t* mime_type, [Immutable] cef_string_t* plugin_url,
			int is_main_frame, [Immutable] cef_string_t* top_origin_url, cef_web_plugin_info_t* plugin_info,
			CefPluginPolicy* plugin_policy);

		/// <summary>
		///  _cef_resource_request_handler_t* (*)(_cef_request_context_handler_t* self, _cef_browser_t* browser, _cef_frame_t*
		///  frame, _cef_request_t* request, int is_navigation, int is_download, const cef_string_t* request_initiator, int*
		///  disable_default_handling)*
		/// </summary>
		public void* get_resource_request_handler;

		/// <summary>
		///  Called on the browser process IO thread before a resource request is
		///  initiated. The |browser| and |frame| values represent the source of the
		///  request, and may be NULL for requests originating from service workers or
		///  cef_urlrequest_t. |request| represents the request contents and cannot be
		///  modified in this callback. |is_navigation| will be true (1) if the resource
		///  request is a navigation. |is_download| will be true (1) if the resource
		///  request is a download. |request_initiator| is the origin (scheme + domain)
		///  of the page that initiated the request. Set |disable_default_handling| to
		///  true (1) to disable default handling of the request, in which case it will
		///  need to be handled via cef_resource_request_handler_t::GetResourceHandler
		///  or it will be canceled. To allow the resource load to proceed with default
		///  handling return NULL. To specify a handler for the resource return a
		///  cef_resource_request_handler_t object. This function will not be called if
		///  the client associated with |browser| returns a non-NULL value from
		///  cef_request_handler_t::GetResourceRequestHandler for the same request
		///  (identified by cef_request_t::GetIdentifier).
		/// </summary>
		[MethodImpl(MethodImplOptions.ForwardRef)]
		[NativeName("get_resource_request_handler")]
		public extern cef_resource_request_handler_t* GetResourceRequestHandler(cef_browser_t* browser,
			cef_frame_t* frame, cef_request_t* request, int is_navigation, int is_download,
			[Immutable] cef_string_t* request_initiator, int* disable_default_handling);
	}
}