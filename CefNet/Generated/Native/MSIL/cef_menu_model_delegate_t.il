﻿// --------------------------------------------------------------------------------------------
// Copyright (c) 2019 The CefNet Authors. All rights reserved.
// Licensed under the MIT license.
// See the licence file in the project root for full license information.
// --------------------------------------------------------------------------------------------
// Generated by CefGen
// Source: include/capi/cef_menu_model_delegate_capi.h
// --------------------------------------------------------------------------------------------﻿
// DO NOT MODIFY! THIS IS AUTOGENERATED FILE!
// --------------------------------------------------------------------------------------------


.namespace CefNet.CApi
{
	.class public cef_menu_model_delegate_t
	{
		// void (*)(_cef_menu_model_delegate_t* self, _cef_menu_model_t* menu_model, int command_id, cef_event_flags_t event_flags)*
		.method public hidebysig void ExecuteCommand(valuetype CefNet.CApi.cef_menu_model_t* menu_model, int32 command_id, valuetype CefNet.CefEventFlags event_flags)
		{
			.maxstack 5
			ldarg.0
			ldarg.1
			ldarg.2
			ldarg.3
			ldarg.0
			ldfld void* CefNet.CApi.cef_menu_model_delegate_t::execute_command
			calli explicit unmanaged
#ifdef WINDOWS
				stdcall
#else
				cdecl
#endif
				void(valuetype CefNet.CApi.cef_menu_model_delegate_t*, valuetype CefNet.CApi.cef_menu_model_t*, int32, valuetype CefNet.CefEventFlags)
			ret
		}

		// void (*)(_cef_menu_model_delegate_t* self, _cef_menu_model_t* menu_model, const cef_point_t* screen_point)*
		.method public hidebysig void MouseOutsideMenu(valuetype CefNet.CApi.cef_menu_model_t* menu_model, valuetype CefNet.CApi.cef_point_t* screen_point)
		{
			.maxstack 4
			ldarg.0
			ldarg.1
			ldarg.2
			ldarg.0
			ldfld void* CefNet.CApi.cef_menu_model_delegate_t::mouse_outside_menu
			calli explicit unmanaged
#ifdef WINDOWS
				stdcall
#else
				cdecl
#endif
				void(valuetype CefNet.CApi.cef_menu_model_delegate_t*, valuetype CefNet.CApi.cef_menu_model_t*, valuetype CefNet.CApi.cef_point_t*)
			ret
		}

		// void (*)(_cef_menu_model_delegate_t* self, _cef_menu_model_t* menu_model, int is_rtl)*
		.method public hidebysig void UnhandledOpenSubmenu(valuetype CefNet.CApi.cef_menu_model_t* menu_model, int32 is_rtl)
		{
			.maxstack 4
			ldarg.0
			ldarg.1
			ldarg.2
			ldarg.0
			ldfld void* CefNet.CApi.cef_menu_model_delegate_t::unhandled_open_submenu
			calli explicit unmanaged
#ifdef WINDOWS
				stdcall
#else
				cdecl
#endif
				void(valuetype CefNet.CApi.cef_menu_model_delegate_t*, valuetype CefNet.CApi.cef_menu_model_t*, int32)
			ret
		}

		// void (*)(_cef_menu_model_delegate_t* self, _cef_menu_model_t* menu_model, int is_rtl)*
		.method public hidebysig void UnhandledCloseSubmenu(valuetype CefNet.CApi.cef_menu_model_t* menu_model, int32 is_rtl)
		{
			.maxstack 4
			ldarg.0
			ldarg.1
			ldarg.2
			ldarg.0
			ldfld void* CefNet.CApi.cef_menu_model_delegate_t::unhandled_close_submenu
			calli explicit unmanaged
#ifdef WINDOWS
				stdcall
#else
				cdecl
#endif
				void(valuetype CefNet.CApi.cef_menu_model_delegate_t*, valuetype CefNet.CApi.cef_menu_model_t*, int32)
			ret
		}

		// void (*)(_cef_menu_model_delegate_t* self, _cef_menu_model_t* menu_model)*
		.method public hidebysig void MenuWillShow(valuetype CefNet.CApi.cef_menu_model_t* menu_model)
		{
			.maxstack 3
			ldarg.0
			ldarg.1
			ldarg.0
			ldfld void* CefNet.CApi.cef_menu_model_delegate_t::menu_will_show
			calli explicit unmanaged
#ifdef WINDOWS
				stdcall
#else
				cdecl
#endif
				void(valuetype CefNet.CApi.cef_menu_model_delegate_t*, valuetype CefNet.CApi.cef_menu_model_t*)
			ret
		}

		// void (*)(_cef_menu_model_delegate_t* self, _cef_menu_model_t* menu_model)*
		.method public hidebysig void MenuClosed(valuetype CefNet.CApi.cef_menu_model_t* menu_model)
		{
			.maxstack 3
			ldarg.0
			ldarg.1
			ldarg.0
			ldfld void* CefNet.CApi.cef_menu_model_delegate_t::menu_closed
			calli explicit unmanaged
#ifdef WINDOWS
				stdcall
#else
				cdecl
#endif
				void(valuetype CefNet.CApi.cef_menu_model_delegate_t*, valuetype CefNet.CApi.cef_menu_model_t*)
			ret
		}

		// int (*)(_cef_menu_model_delegate_t* self, _cef_menu_model_t* menu_model, cef_string_t* label)*
		.method public hidebysig int32 FormatLabel(valuetype CefNet.CApi.cef_menu_model_t* menu_model, valuetype CefNet.CApi.cef_string_t* label)
		{
			.maxstack 4
			ldarg.0
			ldarg.1
			ldarg.2
			ldarg.0
			ldfld void* CefNet.CApi.cef_menu_model_delegate_t::format_label
			calli explicit unmanaged
#ifdef WINDOWS
				stdcall
#else
				cdecl
#endif
				int32(valuetype CefNet.CApi.cef_menu_model_delegate_t*, valuetype CefNet.CApi.cef_menu_model_t*, valuetype CefNet.CApi.cef_string_t*)
			ret
		}
	}
}

