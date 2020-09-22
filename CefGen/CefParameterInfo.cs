﻿// --------------------------------------------------------------------------------------------
// Copyright (c) 2019 The CefNet Authors. All rights reserved.
// Licensed under the MIT license.
// See the licence file in the project root for full license information.
// --------------------------------------------------------------------------------------------

using CefGen.CodeDom;
using Microsoft.CodeAnalysis;

namespace CefGen
{
	internal sealed class CefParameterInfo
	{
		public CefParameterInfo(ISymbol parameterSymbol)
		{
			Symbol = parameterSymbol;
		}

		public ISymbol Symbol { get; }

		public CodeMethodParameter Parameter { get; set; }

		public bool IsArraySize { get; set; }

		public bool IsArray { get; set; }

		public string NativeTypeName =>
			((IParameterSymbol) Symbol).Type.ToDisplayString(SymbolDisplayFormat.MinimallyQualifiedFormat);
	}
}