// --------------------------------------------------------------------------------------------
// Copyright (c) 2019 The CefNet Authors. All rights reserved.
// Licensed under the MIT license.
// See the licence file in the project root for full license information.
// --------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using CefGen.CodeDom;

namespace CefGen
{
	internal abstract class ApiBuilderBase
	{
		private static readonly Lazy<string> License = new Lazy<string>(() =>
			File.ReadAllText(Path.Combine("Settings", "LicenseTemplate.txt"), Encoding.UTF8));

		public List<string> Imports { get; } = new List<string>
		{
			"System", "System.Runtime.InteropServices", "System.Runtime.CompilerServices", "CefNet.WinApi"
		};

		protected virtual CodeFile CreateCodeFile(string sources)
		{
			var f = new CodeFile();
			f.Comments.AddComment(string.Format(License.Value, nameof(CefGen), sources));

			foreach (var import in Imports) f.Imports.Add(new CodeNamespaceImport(import));

			return f;
		}
	}
}