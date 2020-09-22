﻿// --------------------------------------------------------------------------------------------
// Copyright (c) 2019 The CefNet Authors. All rights reserved.
// Licensed under the MIT license.
// See the licence file in the project root for full license information.
// --------------------------------------------------------------------------------------------
// Generated by CefGen
// Source: Generated/Native/Types/cef_range_t.cs
// --------------------------------------------------------------------------------------------﻿
// DO NOT MODIFY! THIS IS AUTOGENERATED FILE!
// --------------------------------------------------------------------------------------------

#pragma warning disable 0169, 1591, 1573

using CefNet.CApi;

namespace CefNet
{
	/// <summary>
	///  Structure representing a range.
	/// </summary>
	/// <remarks>
	///  Role: Proxy
	/// </remarks>
	public partial struct CefRange
	{
		private cef_range_t _instance;

		public int From
		{
			get => _instance.from;
			set => _instance.from = value;
		}

		public int To
		{
			get => _instance.to;
			set => _instance.to = value;
		}

		public static implicit operator CefRange(cef_range_t instance)
		{
			return new CefRange {_instance = instance};
		}

		public static implicit operator cef_range_t(CefRange instance)
		{
			return instance._instance;
		}
	}
}