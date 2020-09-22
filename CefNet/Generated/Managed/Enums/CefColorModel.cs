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
	///  Print job color mode values.
	/// </summary>
	public enum CefColorModel
	{
		Unknown = 0,

		Gray = 1,

		Color = 2,

		Cmyk = 3,

		Cmy = 4,

		Kcmy = 5,

		/// <summary>
		///  CMY_K represents CMY+K.
		/// </summary>
		CmyK = 6,

		Black = 7,

		Grayscale = 8,

		Rgb = 9,

		Rgb16 = 10,

		Rgba = 11,

		/// <summary>
		///  Used in samsung printer ppds.
		/// </summary>
		ColormodeColor = 12,

		/// <summary>
		///  Used in samsung printer ppds.
		/// </summary>
		ColormodeMonochrome = 13,

		/// <summary>
		///  Used in HP color printer ppds.
		/// </summary>
		HpColorColor = 14,

		/// <summary>
		///  Used in HP color printer ppds.
		/// </summary>
		HpColorBlack = 15,

		/// <summary>
		///  Used in foomatic ppds.
		/// </summary>
		PrintoutmodeNormal = 16,

		/// <summary>
		///  Used in foomatic ppds.
		/// </summary>
		PrintoutmodeNormalGray = 17,

		/// <summary>
		///  Used in canon printer ppds.
		/// </summary>
		ProcesscolormodelCmyk = 18,

		/// <summary>
		///  Used in canon printer ppds.
		/// </summary>
		ProcesscolormodelGreyscale = 19,

		/// <summary>
		///  Used in canon printer ppds
		/// </summary>
		ProcesscolormodelRgb = 20
	}
}