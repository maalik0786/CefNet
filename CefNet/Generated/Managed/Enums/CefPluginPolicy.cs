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

namespace CefNet
{
	/// <summary>
	///  Plugin policies supported by CefRequestContextHandler::OnBeforePluginLoad.
	/// </summary>
	public enum CefPluginPolicy
	{
		/// <summary>
		///  Allow the content.
		/// </summary>
		Allow = 0,

		/// <summary>
		///  Allow important content and block unimportant content based on heuristics.
		///  The user can manually load blocked content.
		/// </summary>
		DetectImportant = 1,

		/// <summary>
		///  Block the content. The user can manually load blocked content.
		/// </summary>
		Block = 2,

		/// <summary>
		///  Disable the content. The user cannot load disabled content.
		/// </summary>
		Disable = 3
	}
}