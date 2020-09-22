// --------------------------------------------------------------------------------------------
// Copyright (c) 2019 The CefNet Authors. All rights reserved.
// Licensed under the MIT license.
// See the licence file in the project root for full license information.
// --------------------------------------------------------------------------------------------

using System;
using System.IO;
using CefGen.CodeDom;

namespace CefGen
{
	internal abstract class CefCodeGenBase : CodeGenBase
	{
		public event EventHandler<ResolveTypeNameEventArgs> ResolveTypeName;

		public void GenerateCode(CodeFile fileDecl, TextWriter output)
		{
			ResetIndent();

			Output = output;
			try
			{
				foreach (var commentDecl in fileDecl.Comments) GenerateCommentCode(commentDecl);

				GenerateGlobalDirectivesCode();

				var insertline = true;
				foreach (var importDecl in fileDecl.Imports)
				{
					if (insertline) Output.WriteLine();
					GenerateNamespaceImportCode(importDecl);
					insertline = false;
				}

				foreach (var nsDecl in fileDecl.Namespaces)
				{
					Output.WriteLine();
					GenerateNamespaceCode(nsDecl);
				}
			}
			finally
			{
				Output = null;
			}
		}

		protected abstract void GenerateCommentCode(CodeComment commentDecl);

		protected virtual void GenerateNamespaceImportCode(CodeNamespaceImport importDecl) { }

		protected abstract void GenerateNamespaceCode(CodeNamespace namespaceDecl);

		protected string ResolveType(string type)
		{
			var ea = new ResolveTypeNameEventArgs(type);
			ResolveTypeName?.Invoke(this, ea);
			return ea.Result;
		}
	}
}