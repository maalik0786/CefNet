﻿// --------------------------------------------------------------------------------------------
// Copyright (c) 2019 The CefNet Authors. All rights reserved.
// Licensed under the MIT license.
// See the licence file in the project root for full license information.
// --------------------------------------------------------------------------------------------
// Generated by CefGen
// Source: include/capi/cef_media_router_capi.h
// --------------------------------------------------------------------------------------------﻿
// DO NOT MODIFY! THIS IS AUTOGENERATED FILE!
// --------------------------------------------------------------------------------------------


.namespace CefNet.CApi
{
	.class public cef_media_router_t
	{
		// _cef_registration_t* (*)(_cef_media_router_t* self, _cef_media_observer_t* observer)*
		.method public hidebysig valuetype CefNet.CApi.cef_registration_t* AddObserver(valuetype CefNet.CApi.cef_media_observer_t* observer)
		{
			.maxstack 3
			ldarg.0
			ldarg.1
			ldarg.0
			ldfld void* CefNet.CApi.cef_media_router_t::add_observer
			calli explicit unmanaged
#ifdef WINDOWS
				stdcall
#else
				cdecl
#endif
				valuetype CefNet.CApi.cef_registration_t*(valuetype CefNet.CApi.cef_media_router_t*, valuetype CefNet.CApi.cef_media_observer_t*)
			ret
		}

		// _cef_media_source_t* (*)(_cef_media_router_t* self, const cef_string_t* urn)*
		.method public hidebysig valuetype CefNet.CApi.cef_media_source_t* GetSource(valuetype CefNet.CApi.cef_string_t* urn)
		{
			.maxstack 3
			ldarg.0
			ldarg.1
			ldarg.0
			ldfld void* CefNet.CApi.cef_media_router_t::get_source
			calli explicit unmanaged
#ifdef WINDOWS
				stdcall
#else
				cdecl
#endif
				valuetype CefNet.CApi.cef_media_source_t*(valuetype CefNet.CApi.cef_media_router_t*, valuetype CefNet.CApi.cef_string_t*)
			ret
		}

		// void (*)(_cef_media_router_t* self)*
		.method public hidebysig void NotifyCurrentSinks()
		{
			.maxstack 2
			ldarg.0
			ldarg.0
			ldfld void* CefNet.CApi.cef_media_router_t::notify_current_sinks
			calli explicit unmanaged
#ifdef WINDOWS
				stdcall
#else
				cdecl
#endif
				void(valuetype CefNet.CApi.cef_media_router_t*)
			ret
		}

		// void (*)(_cef_media_router_t* self, _cef_media_source_t* source, _cef_media_sink_t* sink, _cef_media_route_create_callback_t* callback)*
		.method public hidebysig void CreateRoute(valuetype CefNet.CApi.cef_media_source_t* source, valuetype CefNet.CApi.cef_media_sink_t* sink, valuetype CefNet.CApi.cef_media_route_create_callback_t* callback)
		{
			.maxstack 5
			ldarg.0
			ldarg.1
			ldarg.2
			ldarg.3
			ldarg.0
			ldfld void* CefNet.CApi.cef_media_router_t::create_route
			calli explicit unmanaged
#ifdef WINDOWS
				stdcall
#else
				cdecl
#endif
				void(valuetype CefNet.CApi.cef_media_router_t*, valuetype CefNet.CApi.cef_media_source_t*, valuetype CefNet.CApi.cef_media_sink_t*, valuetype CefNet.CApi.cef_media_route_create_callback_t*)
			ret
		}

		// void (*)(_cef_media_router_t* self)*
		.method public hidebysig void NotifyCurrentRoutes()
		{
			.maxstack 2
			ldarg.0
			ldarg.0
			ldfld void* CefNet.CApi.cef_media_router_t::notify_current_routes
			calli explicit unmanaged
#ifdef WINDOWS
				stdcall
#else
				cdecl
#endif
				void(valuetype CefNet.CApi.cef_media_router_t*)
			ret
		}
	}
}

