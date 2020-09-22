﻿// --------------------------------------------------------------------------------------------
// Copyright (c) 2019 The CefNet Authors. All rights reserved.
// Licensed under the MIT license.
// See the licence file in the project root for full license information.
// --------------------------------------------------------------------------------------------
// Generated by CefGen
// Source: Generated/Native/Types/cef_size_t.cs
// --------------------------------------------------------------------------------------------﻿
// DO NOT MODIFY! THIS IS AUTOGENERATED FILE!
// --------------------------------------------------------------------------------------------

#pragma warning disable 0169, 1591, 1573

using CefNet.CApi;

namespace CefNet
{
	/// <summary>
	///  Structure representing a size.
	/// </summary>
	/// <remarks>
	///  Role: Proxy
	/// </remarks>
	public partial struct CefSize
	{
		private cef_size_t _instance;

		public int Width
		{
			get => _instance.width;
			set => _instance.width = value;
		}

		public int Height
		{
			get => _instance.height;
			set => _instance.height = value;
		}

		public static implicit operator CefSize(cef_size_t instance)
		{
			return new CefSize {_instance = instance};
		}

		public static implicit operator cef_size_t(CefSize instance)
		{
			return instance._instance;
		}
	}
}