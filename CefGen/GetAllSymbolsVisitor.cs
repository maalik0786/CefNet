// --------------------------------------------------------------------------------------------
// Copyright (c) 2019 The CefNet Authors. All rights reserved.
// Licensed under the MIT license.
// See the licence file in the project root for full license information.
// --------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;

namespace CefGen
{
	public class GetAllSymbolsVisitor : SymbolVisitor
	{
		private readonly List<INamedTypeSymbol> _symbols = new List<INamedTypeSymbol>();

		public override void VisitNamespace(INamespaceSymbol symbol)
		{
			Parallel.ForEach(symbol.GetMembers(), s => s.Accept(this));
		}

		public override void VisitNamedType(INamedTypeSymbol symbol)
		{
			lock (_symbols)
			{
				_symbols.Add(symbol);
			}
		}

		public List<INamedTypeSymbol> GetSymbols()
		{
			return _symbols;
		}
	}
}