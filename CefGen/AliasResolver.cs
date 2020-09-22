// --------------------------------------------------------------------------------------------
// Copyright (c) 2019 The CefNet Authors. All rights reserved.
// Licensed under the MIT license.
// See the licence file in the project root for full license information.
// --------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using CppAst;

namespace CefGen
{
	internal sealed class AliasResolver
	{
		private readonly Dictionary<string, string> Aliases;

		public AliasResolver(CppCompilation compilation)
		{
			Aliases = new Dictionary<string, string>();

			foreach (var typedef in compilation.Typedefs)
			{
				var name = typedef.ElementType.GetDisplayName();
				if (name.StartsWith("_"))
					Aliases.Add(name, typedef.Name);
				else if (typedef.Name == "cef_platform_thread_id_t"
				         || typedef.Name == "cef_platform_thread_handle_t")
					Aliases.Add(typedef.Name, name);
			}

			foreach (var enumType in compilation.Enums)
			{
				var enumName = enumType.Name;
				if (!enumName.EndsWith("_t"))
					throw new NotImplementedException();

				Aliases.Add(enumName, enumName.Remove(enumName.Length - 2).ToUpperCamel());
			}
		}

		public void HandleResolveEvent(object sender, ResolveTypeNameEventArgs e)
		{
			if (TryResolve(e.Type, out var type))
				e.Result = type;
		}

		public bool TryResolve(string intype, out string outtype)
		{
			return Aliases.TryGetValue(intype, out outtype);
		}

		public string ResolveNonFail(string type)
		{
			if (TryResolve(type, out var outtype))
				return outtype;
			return type;
		}
	}
}