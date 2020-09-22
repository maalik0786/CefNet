// --------------------------------------------------------------------------------------------
// Copyright (c) 2019 The CefNet Authors. All rights reserved.
// Licensed under the MIT license.
// See the licence file in the project root for full license information.
// --------------------------------------------------------------------------------------------

using System.Collections.Generic;
using CefGen.CodeDom;

namespace CefGen
{
	internal abstract class MsilCodeGenBase : CefCodeGenBase
	{
		private readonly Stack<string> _classes = new Stack<string>();
		private readonly Stack<string> _namespaces = new Stack<string>();


		protected virtual string Namespace => string.Join(".", _namespaces);

		protected virtual string ClassName => string.Join(".", _classes);

		protected override void GenerateCommentCode(CodeComment commentDecl)
		{
			if (commentDecl.IsXml)
				return;

			GenerateCommentCode(commentDecl.Text);
		}

		protected virtual void GenerateCommentCode(string commentText)
		{
			foreach (var line in commentText.Split('\n'))
			{
				WriteIndent();
				Output.Write("// ");
				Output.WriteLine(line.TrimEnd('\r'));
			}
		}

		protected virtual void WriteAttributes(CodeAttributes attributes)
		{
			if (attributes.HasFlag(CodeAttributes.Public))
				Output.Write("public ");
			else if (attributes.HasFlag(CodeAttributes.Private))
				Output.Write("private ");
			else if (attributes.HasFlag(CodeAttributes.Internal)) Output.Write("internal ");
		}

		protected override void GenerateNamespaceCode(CodeNamespace namespaceDecl)
		{
			WriteIndent();
			Output.Write(".namespace ");
			Output.Write(namespaceDecl.Name);
			WriteBlockStart(CodeGenBlockType.Namespace);
			_namespaces.Push(namespaceDecl.Name);

			var insertLine = false;
			foreach (var typeDecl in namespaceDecl.Types)
			{
				if (insertLine)
					Output.WriteLine();

				GenerateTypeCode(typeDecl, namespaceDecl.Name);
				insertLine = true;
			}

			_namespaces.Pop();
			WriteBlockEnd(CodeGenBlockType.Namespace);
		}

		protected virtual void GenerateTypeCode(CodeType typeDecl, string typeRef)
		{
			typeRef = typeRef + "." + typeDecl.Name;

			foreach (var commentDecl in typeDecl.Comments) GenerateCommentCode(commentDecl);

			WriteIndent();
			Output.Write(".class ");
			WriteAttributes(typeDecl.Attributes);
			Output.Write(typeDecl.Name);
			WriteBlockStart(CodeGenBlockType.Type);
			_classes.Push(typeDecl.Name);

			var insertLine = false;
			foreach (var memberDecl in typeDecl.Members)
			{
				if (insertLine)
					Output.WriteLine();

				if (memberDecl is CodeType classDecl)
				{
					GenerateTypeCode(classDecl, typeRef);
				}
				else if (memberDecl is CodeMethod methodDecl)
				{
					if (methodDecl.Callee == null)
						continue;
					if (!GenerateMethodCode(methodDecl, typeRef))
						continue;
				}
				else
				{
					insertLine = false;
					continue;
				}

				insertLine = true;
			}

			_classes.Pop();
			WriteBlockEnd(CodeGenBlockType.Type);
		}

		protected abstract bool GenerateMethodCode(CodeMethod methodDecl, string typeRef);

		protected static bool IsNotXmlTagComment(CodeComment c)
		{
			if (!c.IsXml)
				return true;
			var s = c.Text;
			return !(s.StartsWith('<') && s.EndsWith('>'));
		}

		protected static string GetName(string name)
		{
			var lastDot = name.LastIndexOf('.');
			var lastSemi = name.LastIndexOf("::");
			if (lastSemi > lastDot) return name.Substring(lastSemi + 2);
			return name.Substring(lastDot + 1);
		}
	}
}