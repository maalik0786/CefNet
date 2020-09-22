﻿// --------------------------------------------------------------------------------------------
// Copyright (c) 2019 The CefNet Authors. All rights reserved.
// Licensed under the MIT license.
// See the licence file in the project root for full license information.
// --------------------------------------------------------------------------------------------
// Generated by CefGen
// Source: include/capi/cef_menu_model_capi.h
// --------------------------------------------------------------------------------------------﻿
// DO NOT MODIFY! THIS IS AUTOGENERATED FILE!
// --------------------------------------------------------------------------------------------

#pragma warning disable 0169, 1591, 1573

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CefNet.CApi
{
	/// <summary>
	///  Supports creation and modification of menus. See cef_menu_id_t for the
	///  command ids that have default implementations. All user-defined command ids
	///  should be between MENU_ID_USER_FIRST and MENU_ID_USER_LAST. The functions of
	///  this structure can only be accessed on the browser process the UI thread.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct cef_menu_model_t
	{
		/// <summary>
		///  Base structure.
		/// </summary>
		public cef_base_ref_counted_t @base;

		/// <summary>
		///  int (*)(_cef_menu_model_t* self)*
		/// </summary>
		public void* is_sub_menu;

		/// <summary>
		///  Returns true (1) if this menu is a submenu.
		/// </summary>
		[NativeName("is_sub_menu")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern int IsSubMenu();

		/// <summary>
		///  int (*)(_cef_menu_model_t* self)*
		/// </summary>
		public void* clear;

		/// <summary>
		///  Clears the menu. Returns true (1) on success.
		/// </summary>
		[NativeName("clear")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern int Clear();

		/// <summary>
		///  int (*)(_cef_menu_model_t* self)*
		/// </summary>
		public void* get_count;

		/// <summary>
		///  Returns the number of items in this menu.
		/// </summary>
		[NativeName("get_count")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern int GetCount();

		/// <summary>
		///  int (*)(_cef_menu_model_t* self)*
		/// </summary>
		public void* add_separator;

		/// <summary>
		///  Add a separator to the menu. Returns true (1) on success.
		/// </summary>
		[NativeName("add_separator")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern int AddSeparator();

		/// <summary>
		///  int (*)(_cef_menu_model_t* self, int command_id, const cef_string_t* label)*
		/// </summary>
		public void* add_item;

		/// <summary>
		///  Add an item to the menu. Returns true (1) on success.
		/// </summary>
		[NativeName("add_item")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern int AddItem(int command_id, [Immutable] cef_string_t* label);

		/// <summary>
		///  int (*)(_cef_menu_model_t* self, int command_id, const cef_string_t* label)*
		/// </summary>
		public void* add_check_item;

		/// <summary>
		///  Add a check item to the menu. Returns true (1) on success.
		/// </summary>
		[NativeName("add_check_item")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern int AddCheckItem(int command_id, [Immutable] cef_string_t* label);

		/// <summary>
		///  int (*)(_cef_menu_model_t* self, int command_id, const cef_string_t* label, int group_id)*
		/// </summary>
		public void* add_radio_item;

		/// <summary>
		///  Add a radio item to the menu. Only a single item with the specified
		///  |group_id| can be checked at a time. Returns true (1) on success.
		/// </summary>
		[NativeName("add_radio_item")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern int AddRadioItem(int command_id, [Immutable] cef_string_t* label, int group_id);

		/// <summary>
		///  _cef_menu_model_t* (*)(_cef_menu_model_t* self, int command_id, const cef_string_t* label)*
		/// </summary>
		public void* add_sub_menu;

		/// <summary>
		///  Add a sub-menu to the menu. The new sub-menu is returned.
		/// </summary>
		[NativeName("add_sub_menu")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern cef_menu_model_t* AddSubMenu(int command_id, [Immutable] cef_string_t* label);

		/// <summary>
		///  int (*)(_cef_menu_model_t* self, int index)*
		/// </summary>
		public void* insert_separator_at;

		/// <summary>
		///  Insert a separator in the menu at the specified |index|. Returns true (1)
		///  on success.
		/// </summary>
		[NativeName("insert_separator_at")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern int InsertSeparatorAt(int index);

		/// <summary>
		///  int (*)(_cef_menu_model_t* self, int index, int command_id, const cef_string_t* label)*
		/// </summary>
		public void* insert_item_at;

		/// <summary>
		///  Insert an item in the menu at the specified |index|. Returns true (1) on
		///  success.
		/// </summary>
		[NativeName("insert_item_at")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern int InsertItemAt(int index, int command_id, [Immutable] cef_string_t* label);

		/// <summary>
		///  int (*)(_cef_menu_model_t* self, int index, int command_id, const cef_string_t* label)*
		/// </summary>
		public void* insert_check_item_at;

		/// <summary>
		///  Insert a check item in the menu at the specified |index|. Returns true (1)
		///  on success.
		/// </summary>
		[NativeName("insert_check_item_at")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern int InsertCheckItemAt(int index, int command_id, [Immutable] cef_string_t* label);

		/// <summary>
		///  int (*)(_cef_menu_model_t* self, int index, int command_id, const cef_string_t* label, int group_id)*
		/// </summary>
		public void* insert_radio_item_at;

		/// <summary>
		///  Insert a radio item in the menu at the specified |index|. Only a single
		///  item with the specified |group_id| can be checked at a time. Returns true
		///  (1) on success.
		/// </summary>
		[NativeName("insert_radio_item_at")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern int InsertRadioItemAt(int index, int command_id, [Immutable] cef_string_t* label, int group_id);

		/// <summary>
		///  _cef_menu_model_t* (*)(_cef_menu_model_t* self, int index, int command_id, const cef_string_t* label)*
		/// </summary>
		public void* insert_sub_menu_at;

		/// <summary>
		///  Insert a sub-menu in the menu at the specified |index|. The new sub-menu is
		///  returned.
		/// </summary>
		[NativeName("insert_sub_menu_at")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern cef_menu_model_t* InsertSubMenuAt(int index, int command_id, [Immutable] cef_string_t* label);

		/// <summary>
		///  int (*)(_cef_menu_model_t* self, int command_id)*
		/// </summary>
		public void* remove;

		/// <summary>
		///  Removes the item with the specified |command_id|. Returns true (1) on
		///  success.
		/// </summary>
		[NativeName("remove")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern int Remove(int command_id);

		/// <summary>
		///  int (*)(_cef_menu_model_t* self, int index)*
		/// </summary>
		public void* remove_at;

		/// <summary>
		///  Removes the item at the specified |index|. Returns true (1) on success.
		/// </summary>
		[NativeName("remove_at")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern int RemoveAt(int index);

		/// <summary>
		///  int (*)(_cef_menu_model_t* self, int command_id)*
		/// </summary>
		public void* get_index_of;

		/// <summary>
		///  Returns the index associated with the specified |command_id| or -1 if not
		///  found due to the command id not existing in the menu.
		/// </summary>
		[NativeName("get_index_of")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern int GetIndexOf(int command_id);

		/// <summary>
		///  int (*)(_cef_menu_model_t* self, int index)*
		/// </summary>
		public void* get_command_id_at;

		/// <summary>
		///  Returns the command id at the specified |index| or -1 if not found due to
		///  invalid range or the index being a separator.
		/// </summary>
		[NativeName("get_command_id_at")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern int GetCommandIdAt(int index);

		/// <summary>
		///  int (*)(_cef_menu_model_t* self, int index, int command_id)*
		/// </summary>
		public void* set_command_id_at;

		/// <summary>
		///  Sets the command id at the specified |index|. Returns true (1) on success.
		/// </summary>
		[NativeName("set_command_id_at")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern int SetCommandIdAt(int index, int command_id);

		/// <summary>
		///  cef_string_userfree_t (*)(_cef_menu_model_t* self, int command_id)*
		/// </summary>
		public void* get_label;

		/// <summary>
		///  Returns the label for the specified |command_id| or NULL if not found.
		///  The resulting string must be freed by calling cef_string_userfree_free().
		/// </summary>
		[NativeName("get_label")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern cef_string_userfree_t GetLabel(int command_id);

		/// <summary>
		///  cef_string_userfree_t (*)(_cef_menu_model_t* self, int index)*
		/// </summary>
		public void* get_label_at;

		/// <summary>
		///  Returns the label at the specified |index| or NULL if not found due to
		///  invalid range or the index being a separator.
		///  The resulting string must be freed by calling cef_string_userfree_free().
		/// </summary>
		[NativeName("get_label_at")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern cef_string_userfree_t GetLabelAt(int index);

		/// <summary>
		///  int (*)(_cef_menu_model_t* self, int command_id, const cef_string_t* label)*
		/// </summary>
		public void* set_label;

		/// <summary>
		///  Sets the label for the specified |command_id|. Returns true (1) on success.
		/// </summary>
		[NativeName("set_label")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern int SetLabel(int command_id, [Immutable] cef_string_t* label);

		/// <summary>
		///  int (*)(_cef_menu_model_t* self, int index, const cef_string_t* label)*
		/// </summary>
		public void* set_label_at;

		/// <summary>
		///  Set the label at the specified |index|. Returns true (1) on success.
		/// </summary>
		[NativeName("set_label_at")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern int SetLabelAt(int index, [Immutable] cef_string_t* label);

		/// <summary>
		///  cef_menu_item_type_t (*)(_cef_menu_model_t* self, int command_id)*
		/// </summary>
		public void* get_type;

		/// <summary>
		///  Returns the item type for the specified |command_id|.
		/// </summary>
		[NativeName("get_type")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern CefMenuItemType GetType(int command_id);

		/// <summary>
		///  cef_menu_item_type_t (*)(_cef_menu_model_t* self, int index)*
		/// </summary>
		public void* get_type_at;

		/// <summary>
		///  Returns the item type at the specified |index|.
		/// </summary>
		[NativeName("get_type_at")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern CefMenuItemType GetTypeAt(int index);

		/// <summary>
		///  int (*)(_cef_menu_model_t* self, int command_id)*
		/// </summary>
		public void* get_group_id;

		/// <summary>
		///  Returns the group id for the specified |command_id| or -1 if invalid.
		/// </summary>
		[NativeName("get_group_id")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern int GetGroupId(int command_id);

		/// <summary>
		///  int (*)(_cef_menu_model_t* self, int index)*
		/// </summary>
		public void* get_group_id_at;

		/// <summary>
		///  Returns the group id at the specified |index| or -1 if invalid.
		/// </summary>
		[NativeName("get_group_id_at")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern int GetGroupIdAt(int index);

		/// <summary>
		///  int (*)(_cef_menu_model_t* self, int command_id, int group_id)*
		/// </summary>
		public void* set_group_id;

		/// <summary>
		///  Sets the group id for the specified |command_id|. Returns true (1) on
		///  success.
		/// </summary>
		[NativeName("set_group_id")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern int SetGroupId(int command_id, int group_id);

		/// <summary>
		///  int (*)(_cef_menu_model_t* self, int index, int group_id)*
		/// </summary>
		public void* set_group_id_at;

		/// <summary>
		///  Sets the group id at the specified |index|. Returns true (1) on success.
		/// </summary>
		[NativeName("set_group_id_at")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern int SetGroupIdAt(int index, int group_id);

		/// <summary>
		///  _cef_menu_model_t* (*)(_cef_menu_model_t* self, int command_id)*
		/// </summary>
		public void* get_sub_menu;

		/// <summary>
		///  Returns the submenu for the specified |command_id| or NULL if invalid.
		/// </summary>
		[NativeName("get_sub_menu")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern cef_menu_model_t* GetSubMenu(int command_id);

		/// <summary>
		///  _cef_menu_model_t* (*)(_cef_menu_model_t* self, int index)*
		/// </summary>
		public void* get_sub_menu_at;

		/// <summary>
		///  Returns the submenu at the specified |index| or NULL if invalid.
		/// </summary>
		[NativeName("get_sub_menu_at")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern cef_menu_model_t* GetSubMenuAt(int index);

		/// <summary>
		///  int (*)(_cef_menu_model_t* self, int command_id)*
		/// </summary>
		public void* is_visible;

		/// <summary>
		///  Returns true (1) if the specified |command_id| is visible.
		/// </summary>
		[NativeName("is_visible")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern int IsVisible(int command_id);

		/// <summary>
		///  int (*)(_cef_menu_model_t* self, int index)*
		/// </summary>
		public void* is_visible_at;

		/// <summary>
		///  Returns true (1) if the specified |index| is visible.
		/// </summary>
		[NativeName("is_visible_at")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern int IsVisibleAt(int index);

		/// <summary>
		///  int (*)(_cef_menu_model_t* self, int command_id, int visible)*
		/// </summary>
		public void* set_visible;

		/// <summary>
		///  Change the visibility of the specified |command_id|. Returns true (1) on
		///  success.
		/// </summary>
		[NativeName("set_visible")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern int SetVisible(int command_id, int visible);

		/// <summary>
		///  int (*)(_cef_menu_model_t* self, int index, int visible)*
		/// </summary>
		public void* set_visible_at;

		/// <summary>
		///  Change the visibility at the specified |index|. Returns true (1) on
		///  success.
		/// </summary>
		[NativeName("set_visible_at")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern int SetVisibleAt(int index, int visible);

		/// <summary>
		///  int (*)(_cef_menu_model_t* self, int command_id)*
		/// </summary>
		public void* is_enabled;

		/// <summary>
		///  Returns true (1) if the specified |command_id| is enabled.
		/// </summary>
		[NativeName("is_enabled")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern int IsEnabled(int command_id);

		/// <summary>
		///  int (*)(_cef_menu_model_t* self, int index)*
		/// </summary>
		public void* is_enabled_at;

		/// <summary>
		///  Returns true (1) if the specified |index| is enabled.
		/// </summary>
		[NativeName("is_enabled_at")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern int IsEnabledAt(int index);

		/// <summary>
		///  int (*)(_cef_menu_model_t* self, int command_id, int enabled)*
		/// </summary>
		public void* set_enabled;

		/// <summary>
		///  Change the enabled status of the specified |command_id|. Returns true (1)
		///  on success.
		/// </summary>
		[NativeName("set_enabled")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern int SetEnabled(int command_id, int enabled);

		/// <summary>
		///  int (*)(_cef_menu_model_t* self, int index, int enabled)*
		/// </summary>
		public void* set_enabled_at;

		/// <summary>
		///  Change the enabled status at the specified |index|. Returns true (1) on
		///  success.
		/// </summary>
		[NativeName("set_enabled_at")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern int SetEnabledAt(int index, int enabled);

		/// <summary>
		///  int (*)(_cef_menu_model_t* self, int command_id)*
		/// </summary>
		public void* is_checked;

		/// <summary>
		///  Returns true (1) if the specified |command_id| is checked. Only applies to
		///  check and radio items.
		/// </summary>
		[NativeName("is_checked")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern int IsChecked(int command_id);

		/// <summary>
		///  int (*)(_cef_menu_model_t* self, int index)*
		/// </summary>
		public void* is_checked_at;

		/// <summary>
		///  Returns true (1) if the specified |index| is checked. Only applies to check
		///  and radio items.
		/// </summary>
		[NativeName("is_checked_at")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern int IsCheckedAt(int index);

		/// <summary>
		///  int (*)(_cef_menu_model_t* self, int command_id, int checked)*
		/// </summary>
		public void* set_checked;

		/// <summary>
		///  Check the specified |command_id|. Only applies to check and radio items.
		///  Returns true (1) on success.
		/// </summary>
		[NativeName("set_checked")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern int SetChecked(int command_id, int @checked);

		/// <summary>
		///  int (*)(_cef_menu_model_t* self, int index, int checked)*
		/// </summary>
		public void* set_checked_at;

		/// <summary>
		///  Check the specified |index|. Only applies to check and radio items. Returns
		///  true (1) on success.
		/// </summary>
		[NativeName("set_checked_at")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern int SetCheckedAt(int index, int @checked);

		/// <summary>
		///  int (*)(_cef_menu_model_t* self, int command_id)*
		/// </summary>
		public void* has_accelerator;

		/// <summary>
		///  Returns true (1) if the specified |command_id| has a keyboard accelerator
		///  assigned.
		/// </summary>
		[NativeName("has_accelerator")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern int HasAccelerator(int command_id);

		/// <summary>
		///  int (*)(_cef_menu_model_t* self, int index)*
		/// </summary>
		public void* has_accelerator_at;

		/// <summary>
		///  Returns true (1) if the specified |index| has a keyboard accelerator
		///  assigned.
		/// </summary>
		[NativeName("has_accelerator_at")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern int HasAcceleratorAt(int index);

		/// <summary>
		///  int (*)(_cef_menu_model_t* self, int command_id, int key_code, int shift_pressed, int ctrl_pressed, int
		///  alt_pressed)*
		/// </summary>
		public void* set_accelerator;

		/// <summary>
		///  Set the keyboard accelerator for the specified |command_id|. |key_code| can
		///  be any virtual key or character value. Returns true (1) on success.
		/// </summary>
		[NativeName("set_accelerator")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern int SetAccelerator(int command_id, int key_code, int shift_pressed, int ctrl_pressed,
			int alt_pressed);

		/// <summary>
		///  int (*)(_cef_menu_model_t* self, int index, int key_code, int shift_pressed, int ctrl_pressed, int alt_pressed)*
		/// </summary>
		public void* set_accelerator_at;

		/// <summary>
		///  Set the keyboard accelerator at the specified |index|. |key_code| can be
		///  any virtual key or character value. Returns true (1) on success.
		/// </summary>
		[NativeName("set_accelerator_at")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern int SetAcceleratorAt(int index, int key_code, int shift_pressed, int ctrl_pressed,
			int alt_pressed);

		/// <summary>
		///  int (*)(_cef_menu_model_t* self, int command_id)*
		/// </summary>
		public void* remove_accelerator;

		/// <summary>
		///  Remove the keyboard accelerator for the specified |command_id|. Returns
		///  true (1) on success.
		/// </summary>
		[NativeName("remove_accelerator")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern int RemoveAccelerator(int command_id);

		/// <summary>
		///  int (*)(_cef_menu_model_t* self, int index)*
		/// </summary>
		public void* remove_accelerator_at;

		/// <summary>
		///  Remove the keyboard accelerator at the specified |index|. Returns true (1)
		///  on success.
		/// </summary>
		[NativeName("remove_accelerator_at")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern int RemoveAcceleratorAt(int index);

		/// <summary>
		///  int (*)(_cef_menu_model_t* self, int command_id, int* key_code, int* shift_pressed, int* ctrl_pressed, int*
		///  alt_pressed)*
		/// </summary>
		public void* get_accelerator;

		/// <summary>
		///  Retrieves the keyboard accelerator for the specified |command_id|. Returns
		///  true (1) on success.
		/// </summary>
		[NativeName("get_accelerator")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern int GetAccelerator(int command_id, int* key_code, int* shift_pressed, int* ctrl_pressed,
			int* alt_pressed);

		/// <summary>
		///  int (*)(_cef_menu_model_t* self, int index, int* key_code, int* shift_pressed, int* ctrl_pressed, int*
		///  alt_pressed)*
		/// </summary>
		public void* get_accelerator_at;

		/// <summary>
		///  Retrieves the keyboard accelerator for the specified |index|. Returns true
		///  (1) on success.
		/// </summary>
		[NativeName("get_accelerator_at")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern int GetAcceleratorAt(int index, int* key_code, int* shift_pressed, int* ctrl_pressed,
			int* alt_pressed);

		/// <summary>
		///  int (*)(_cef_menu_model_t* self, int command_id, cef_menu_color_type_t color_type, cef_color_t color)*
		/// </summary>
		public void* set_color;

		/// <summary>
		///  Set the explicit color for |command_id| and |color_type| to |color|.
		///  Specify a |color| value of 0 to remove the explicit color. If no explicit
		///  color or default color is set for |color_type| then the system color will
		///  be used. Returns true (1) on success.
		/// </summary>
		[NativeName("set_color")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern int SetColor(int command_id, CefMenuColorType color_type, cef_color_t color);

		/// <summary>
		///  int (*)(_cef_menu_model_t* self, int index, cef_menu_color_type_t color_type, cef_color_t color)*
		/// </summary>
		public void* set_color_at;

		/// <summary>
		///  Set the explicit color for |command_id| and |index| to |color|. Specify a
		///  |color| value of 0 to remove the explicit color. Specify an |index| value
		///  of -1 to set the default color for items that do not have an explicit color
		///  set. If no explicit color or default color is set for |color_type| then the
		///  system color will be used. Returns true (1) on success.
		/// </summary>
		[NativeName("set_color_at")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern int SetColorAt(int index, CefMenuColorType color_type, cef_color_t color);

		/// <summary>
		///  int (*)(_cef_menu_model_t* self, int command_id, cef_menu_color_type_t color_type, cef_color_t* color)*
		/// </summary>
		public void* get_color;

		/// <summary>
		///  Returns in |color| the color that was explicitly set for |command_id| and
		///  |color_type|. If a color was not set then 0 will be returned in |color|.
		///  Returns true (1) on success.
		/// </summary>
		[NativeName("get_color")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern int GetColor(int command_id, CefMenuColorType color_type, cef_color_t* color);

		/// <summary>
		///  int (*)(_cef_menu_model_t* self, int index, cef_menu_color_type_t color_type, cef_color_t* color)*
		/// </summary>
		public void* get_color_at;

		/// <summary>
		///  Returns in |color| the color that was explicitly set for |command_id| and
		///  |color_type|. Specify an |index| value of -1 to return the default color in
		///  |color|. If a color was not set then 0 will be returned in |color|. Returns
		///  true (1) on success.
		/// </summary>
		[NativeName("get_color_at")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern int GetColorAt(int index, CefMenuColorType color_type, cef_color_t* color);

		/// <summary>
		///  int (*)(_cef_menu_model_t* self, int command_id, const cef_string_t* font_list)*
		/// </summary>
		public void* set_font_list;

		/// <summary>
		///  Sets the font list for the specified |command_id|. If |font_list| is NULL
		///  the system font will be used. Returns true (1) on success. The format is
		///  &quot;
		///  &lt;FONT
		///  _FAMILY_LIST&gt;,[STYLES]
		///  &lt;SIZE
		///  &gt;&quot;, where: - FONT_FAMILY_LIST is a comma-
		///  separated list of font family names, - STYLES is an optional space-
		///  separated list of style names (case-sensitive
		///  &quot;Bold&quot; and &quot;Italic&quot; are supported), and
		///  - SIZE is an integer font size in pixels with the suffix &quot;px&quot;.
		///  Here are examples of valid font description strings: - &quot;Arial, Helvetica,
		///  Bold Italic 14px&quot; - &quot;Arial, 14px&quot;
		/// </summary>
		[NativeName("set_font_list")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern int SetFontList(int command_id, [Immutable] cef_string_t* font_list);

		/// <summary>
		///  int (*)(_cef_menu_model_t* self, int index, const cef_string_t* font_list)*
		/// </summary>
		public void* set_font_list_at;

		/// <summary>
		///  Sets the font list for the specified |index|. Specify an |index| value of
		///  -1 to set the default font. If |font_list| is NULL the system font will be
		///  used. Returns true (1) on success. The format is
		///  &quot;
		///  &lt;FONT
		///  _FAMILY_LIST&gt;,[STYLES]
		///  &lt;SIZE
		///  &gt;&quot;, where: - FONT_FAMILY_LIST is a comma-
		///  separated list of font family names, - STYLES is an optional space-
		///  separated list of style names (case-sensitive
		///  &quot;Bold&quot; and &quot;Italic&quot; are supported), and
		///  - SIZE is an integer font size in pixels with the suffix &quot;px&quot;.
		///  Here are examples of valid font description strings: - &quot;Arial, Helvetica,
		///  Bold Italic 14px&quot; - &quot;Arial, 14px&quot;
		/// </summary>
		[NativeName("set_font_list_at")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public extern int SetFontListAt(int index, [Immutable] cef_string_t* font_list);
	}
}