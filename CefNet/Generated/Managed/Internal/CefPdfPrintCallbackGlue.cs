﻿// --------------------------------------------------------------------------------------------
// Copyright (c) 2019 The CefNet Authors. All rights reserved.
// Licensed under the MIT license.
// See the licence file in the project root for full license information.
// --------------------------------------------------------------------------------------------
// Generated by CefGen
// Source: Generated/Native/Types/cef_pdf_print_callback_t.cs
// --------------------------------------------------------------------------------------------﻿
// DO NOT MODIFY! THIS IS AUTOGENERATED FILE!
// --------------------------------------------------------------------------------------------

#pragma warning disable 0169, 1591, 1573

namespace CefNet.Internal
{
	sealed partial class CefPdfPrintCallbackGlue : CefPdfPrintCallback, ICefPdfPrintCallbackPrivate
	{
		private readonly WebViewGlue _implementation;

		public CefPdfPrintCallbackGlue(WebViewGlue impl)
		{
			_implementation = impl;
		}

		bool ICefPdfPrintCallbackPrivate.AvoidOnPdfPrintFinished()
		{
			return _implementation.AvoidOnPdfPrintFinished();
		}

		protected internal override void OnPdfPrintFinished(string path, bool ok)
		{
			_implementation.OnPdfPrintFinished(path, ok);
		}
	}
}