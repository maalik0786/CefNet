﻿// --------------------------------------------------------------------------------------------
// Copyright (c) 2019 The CefNet Authors. All rights reserved.
// Licensed under the MIT license.
// See the licence file in the project root for full license information.
// --------------------------------------------------------------------------------------------
// Generated by CefGen
// Source: Generated/Native/Types/cef_extension_t.cs
// --------------------------------------------------------------------------------------------﻿
// DO NOT MODIFY! THIS IS AUTOGENERATED FILE!
// --------------------------------------------------------------------------------------------

#pragma warning disable 0169, 1591, 1573

using System;
using CefNet.CApi;

namespace CefNet
{
	/// <summary>
	///  Object representing an extension. Methods may be called on any thread unless
	///  otherwise indicated.
	/// </summary>
	/// <remarks>
	///  Role: Proxy
	/// </remarks>
	public unsafe partial class CefExtension : CefBaseRefCounted<cef_extension_t>
	{
		public CefExtension(cef_extension_t* instance)
			: base((cef_base_ref_counted_t*) instance)
		{
		}

		/// <summary>
		///  Gets the unique extension identifier. This is calculated based on the
		///  extension public key, if available, or on the extension path. See
		///  https://developer.chrome.com/extensions/manifest/key for details.
		///  The resulting string must be freed by calling cef_string_userfree_free().
		/// </summary>
		public virtual string Identifier => SafeCall(CefString.ReadAndFree(NativeInstance->GetIdentifier()));

		/// <summary>
		///  Gets the absolute path to the extension directory on disk. This value
		///  will be prefixed with PK_DIR_RESOURCES if a relative path was passed to
		///  cef_request_context_t::LoadExtension.
		///  The resulting string must be freed by calling cef_string_userfree_free().
		/// </summary>
		public virtual string Path => SafeCall(CefString.ReadAndFree(NativeInstance->GetPath()));

		/// <summary>
		///  Gets the extension manifest contents as a cef_dictionary_value_t object.
		///  See https://developer.chrome.com/extensions/manifest for details.
		/// </summary>
		public virtual CefDictionaryValue Manifest =>
			SafeCall(CefDictionaryValue.Wrap(CefDictionaryValue.Create, NativeInstance->GetManifest()));

		/// <summary>
		///  Gets the handler for this extension. Will return NULL for internal
		///  extensions or if no handler was passed to
		///  cef_request_context_t::LoadExtension.
		/// </summary>
		public virtual CefExtensionHandler Handler =>
			SafeCall(CefExtensionHandler.Wrap(CefExtensionHandler.Create, NativeInstance->GetHandler()));

		/// <summary>
		///  Gets the request context that loaded this extension. Will return NULL
		///  for internal extensions or if the extension has been unloaded. See the
		///  cef_request_context_t::LoadExtension documentation for more information
		///  about loader contexts. Must be called on the browser process UI thread.
		/// </summary>
		public virtual CefRequestContext LoaderContext =>
			SafeCall(CefRequestContext.Wrap(CefRequestContext.Create, NativeInstance->GetLoaderContext()));

		/// <summary>
		///  Gets a value indicating whether this extension is currently loaded. Must be called on
		///  the browser process UI thread.
		/// </summary>
		public virtual bool IsLoaded => SafeCall(NativeInstance->IsLoaded() != 0);

		internal static CefExtension Create(IntPtr instance)
		{
			return new CefExtension((cef_extension_t*) instance);
		}

		/// <summary>
		///  Returns true (1) if this object is the same extension as |that| object.
		///  Extensions are considered the same if identifier, path and loader context
		///  match.
		/// </summary>
		public virtual bool IsSame(CefExtension that)
		{
			return SafeCall(NativeInstance->IsSame(that != null ? that.GetNativeInstance() : null) != 0);
		}

		/// <summary>
		///  Unload this extension if it is not an internal extension and is currently
		///  loaded. Will result in a call to
		///  cef_extension_handler_t::OnExtensionUnloaded on success.
		/// </summary>
		public virtual void Unload()
		{
			NativeInstance->Unload();
			GC.KeepAlive(this);
		}
	}
}