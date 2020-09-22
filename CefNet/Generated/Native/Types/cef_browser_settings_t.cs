﻿// --------------------------------------------------------------------------------------------
// Copyright (c) 2019 The CefNet Authors. All rights reserved.
// Licensed under the MIT license.
// See the licence file in the project root for full license information.
// --------------------------------------------------------------------------------------------
// Generated by CefGen
// Source: include/internal/cef_types.h
// --------------------------------------------------------------------------------------------﻿
// DO NOT MODIFY! THIS IS AUTOGENERATED FILE!
// --------------------------------------------------------------------------------------------

#pragma warning disable 0169, 1591, 1573

using System;
using System.Runtime.InteropServices;

namespace CefNet.CApi
{
	/// <summary>
	///  Browser initialization settings. Specify NULL or 0 to get the recommended
	///  default values. The consequences of using custom values may not be well
	///  tested. Many of these and other settings can also configured using command-
	///  line switches.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct cef_browser_settings_t
	{
		/// <summary>
		///  Size of this structure.
		/// </summary>
		public UIntPtr size;

		/// <summary>
		///  The maximum rate in frames per second (fps) that CefRenderHandler::OnPaint
		///  will be called for a windowless browser. The actual fps may be lower if
		///  the browser cannot generate frames at the requested rate. The minimum
		///  value is 1 and the maximum value is 60 (default 30). This value can also be
		///  changed dynamically via CefBrowserHost::SetWindowlessFrameRate.
		/// </summary>
		public int windowless_frame_rate;

		/// <summary>
		///  Font settings.
		/// </summary>
		public cef_string_t standard_font_family;

		public cef_string_t fixed_font_family;

		public cef_string_t serif_font_family;

		public cef_string_t sans_serif_font_family;

		public cef_string_t cursive_font_family;

		public cef_string_t fantasy_font_family;

		public int default_font_size;

		public int default_fixed_font_size;

		public int minimum_font_size;

		public int minimum_logical_font_size;

		/// <summary>
		///  Default encoding for Web content. If empty &quot;ISO-8859-1&quot; will be used. Also
		///  configurable using the &quot;default-encoding&quot; command-line switch.
		/// </summary>
		public cef_string_t default_encoding;

		/// <summary>
		///  Controls the loading of fonts from remote sources. Also configurable using
		///  the &quot;disable-remote-fonts&quot; command-line switch.
		/// </summary>
		public CefState remote_fonts;

		/// <summary>
		///  Controls whether JavaScript can be executed. Also configurable using the
		///  &quot;disable-javascript&quot; command-line switch.
		/// </summary>
		public CefState javascript;

		/// <summary>
		///  Controls whether JavaScript can be used to close windows that were not
		///  opened via JavaScript. JavaScript can still be used to close windows that
		///  were opened via JavaScript or that have no back/forward history. Also
		///  configurable using the &quot;disable-javascript-close-windows&quot; command-line
		///  switch.
		/// </summary>
		public CefState javascript_close_windows;

		/// <summary>
		///  Controls whether JavaScript can access the clipboard. Also configurable
		///  using the &quot;disable-javascript-access-clipboard&quot; command-line switch.
		/// </summary>
		public CefState javascript_access_clipboard;

		/// <summary>
		///  Controls whether DOM pasting is supported in the editor via
		///  execCommand(&quot;paste&quot;). The |javascript_access_clipboard| setting must also
		///  be enabled. Also configurable using the &quot;disable-javascript-dom-paste&quot;
		///  command-line switch.
		/// </summary>
		public CefState javascript_dom_paste;

		/// <summary>
		///  Controls whether any plugins will be loaded. Also configurable using the
		///  &quot;disable-plugins&quot; command-line switch.
		/// </summary>
		public CefState plugins;

		/// <summary>
		///  Controls whether file URLs will have access to all URLs. Also configurable
		///  using the &quot;allow-universal-access-from-files&quot; command-line switch.
		/// </summary>
		public CefState universal_access_from_file_urls;

		/// <summary>
		///  Controls whether file URLs will have access to other file URLs. Also
		///  configurable using the &quot;allow-access-from-files&quot; command-line switch.
		/// </summary>
		public CefState file_access_from_file_urls;

		/// <summary>
		///  Controls whether web security restrictions (same-origin policy) will be
		///  enforced. Disabling this setting is not recommend as it will allow risky
		///  security behavior such as cross-site scripting (XSS). Also configurable
		///  using the &quot;disable-web-security&quot; command-line switch.
		/// </summary>
		public CefState web_security;

		/// <summary>
		///  Controls whether image URLs will be loaded from the network. A cached image
		///  will still be rendered if requested. Also configurable using the
		///  &quot;disable-image-loading&quot; command-line switch.
		/// </summary>
		public CefState image_loading;

		/// <summary>
		///  Controls whether standalone images will be shrunk to fit the page. Also
		///  configurable using the &quot;image-shrink-standalone-to-fit&quot; command-line
		///  switch.
		/// </summary>
		public CefState image_shrink_standalone_to_fit;

		/// <summary>
		///  Controls whether text areas can be resized. Also configurable using the
		///  &quot;disable-text-area-resize&quot; command-line switch.
		/// </summary>
		public CefState text_area_resize;

		/// <summary>
		///  Controls whether the tab key can advance focus to links. Also configurable
		///  using the &quot;disable-tab-to-links&quot; command-line switch.
		/// </summary>
		public CefState tab_to_links;

		/// <summary>
		///  Controls whether local storage can be used. Also configurable using the
		///  &quot;disable-local-storage&quot; command-line switch.
		/// </summary>
		public CefState local_storage;

		/// <summary>
		///  Controls whether databases can be used. Also configurable using the
		///  &quot;disable-databases&quot; command-line switch.
		/// </summary>
		public CefState databases;

		/// <summary>
		///  Controls whether the application cache can be used. Also configurable using
		///  the &quot;disable-application-cache&quot; command-line switch.
		/// </summary>
		public CefState application_cache;

		/// <summary>
		///  Controls whether WebGL can be used. Note that WebGL requires hardware
		///  support and may not work on all systems even when enabled. Also
		///  configurable using the &quot;disable-webgl&quot; command-line switch.
		/// </summary>
		public CefState webgl;

		/// <summary>
		///  Background color used for the browser before a document is loaded and when
		///  no document color is specified. The alpha component must be either fully
		///  opaque (0xFF) or fully transparent (0x00). If the alpha component is fully
		///  opaque then the RGB components will be used as the background color. If the
		///  alpha component is fully transparent for a windowed browser then the
		///  CefSettings.background_color value will be used. If the alpha component is
		///  fully transparent for a windowless (off-screen) browser then transparent
		///  painting will be enabled.
		/// </summary>
		public cef_color_t background_color;

		/// <summary>
		///  Comma delimited ordered list of language codes without any whitespace that
		///  will be used in the &quot;Accept-Language&quot; HTTP header. May be set globally
		///  using the CefBrowserSettings.accept_language_list value. If both values are
		///  empty then &quot;en-US,en&quot; will be used.
		/// </summary>
		public cef_string_t accept_language_list;
	}
}