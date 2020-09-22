// --------------------------------------------------------------------------------------------
// Copyright (c) 2019 The CefNet Authors. All rights reserved.
// Licensed under the MIT license.
// See the licence file in the project root for full license information.
// --------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace CefGen.CodeDom
{
	internal class CodeNamespace
	{
		public CodeNamespace(string name)
		{
			Name = name;
		}

		public string Name { get; }

		public List<CodeNamespaceImport> Imports { get; } = new List<CodeNamespaceImport>(0);

		//public List<CodeComment> Comments { get; } = new List<CodeComment>(0);

		public List<CodeType> Types { get; } = new List<CodeType>(0);
	}
}