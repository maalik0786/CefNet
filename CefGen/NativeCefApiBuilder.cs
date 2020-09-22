﻿// --------------------------------------------------------------------------------------------
// Copyright (c) 2019 The CefNet Authors. All rights reserved.
// Licensed under the MIT license.
// See the licence file in the project root for full license information.
// --------------------------------------------------------------------------------------------

using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using CefGen.CodeDom;
using CppAst;

namespace CefGen
{
	internal sealed class NativeCefApiBuilder : CefApiBuilderBase
	{
		private readonly bool _onlyStdCall;

		/// <summary>
		/// </summary>
		/// <param name="onlyStdCall">Use STDCALL on linux</param>
		public NativeCefApiBuilder(bool onlyStdCall)
		{
			_onlyStdCall = onlyStdCall;
		}

		protected override MsilCodeGenBase CreateMsilCodeGen()
		{
			return new NativeCefApiMsilCodeGen(_onlyStdCall);
		}

		protected override void BuildTypedef(CodeNamespace ns, CppTypedef typedef)
		{
			var fieldType = GetTypeDesc(typedef.ElementType);
			var baseTypeName = ResolveCefType(fieldType.ToString());
			var aliasTypeName = GetClassName(typedef.Name);
			if (aliasTypeName == baseTypeName)
				throw new InvalidOperationException();

			var decl = new CodeStruct(aliasTypeName);
			decl.Attributes = CodeAttributes.Public | CodeAttributes.Unsafe | CodeAttributes.Partial;
			decl.Comments.AddVSDocComment(typedef.Comment, "summary");

			var attr = new CustomCodeAttribute(typeof(StructLayoutAttribute));
			attr.AddParameter(LayoutKind.Sequential);
			decl.CustomAttributes.Add(attr);


			var field = new CodeField(baseTypeName, "Base");
			field.Attributes = CodeAttributes.Public;
			//field.CustomAttributes.Add(new CustomCodeAttribute(typeof(FieldOffsetAttribute)) { Parameters = { "0" } });
			decl.Members.Add(field);

			ns.Types.Add(decl);
		}

		protected override void BuildEnum(CodeNamespace ns, CppEnum @enum)
		{
			var decl = new CodeEnum(GetClassName(@enum.Name));
			decl.Type = @enum.IntegerType.GetDisplayName();
			if (decl.Type != "int" && decl.Type != "unsigned int")
			{
				Console.WriteLine(decl.Type);
				throw new NotImplementedException();
			}

			decl.Attributes = CodeAttributes.Public;
			decl.Comments.AddVSDocComment(@enum.Comment, "summary");

			//bool first = true;
			//string pattern = @enum.Items.FirstOrDefault()?.Name ?? string.Empty;
			//foreach (CppEnumItem item in @enum.Items)
			//{
			//	while (!item.Name.StartsWith(pattern) && pattern.Length > 0)
			//	{
			//		pattern = pattern.Remove(pattern.Length - 1);
			//	}
			//	if (!first && char.IsDigit(item.Name[pattern.Length]))
			//	{
			//		pattern = null;
			//		break;
			//	}
			//	first = false;
			//}

			var first = true;
			var pattern = @enum.Items.FirstOrDefault()?.Name ?? string.Empty;
			foreach (var item in @enum.Items)
			{
				while (pattern != null && !item.Name.StartsWith(pattern) && pattern.Length > 0)
				{
					//pattern = pattern.Remove(pattern.Length - 1);
					var split = pattern.TrimEnd('_').LastIndexOf('_') + 1;
					if (split == 0)
					{
						pattern = null;
						break;
					}

					pattern = pattern.Remove(split);
				}

				if (pattern != null && !first && char.IsDigit(item.Name[pattern.Length]))
				{
					pattern = null;
					break;
				}

				first = false;
			}

			foreach (var item in @enum.Items)
			{
				var name = pattern != null
					? item.Name.Substring(pattern.Length).ToLowerInvariant().ToUpperCamel()
					: item.Name;
				var value = item.ValueExpression?.ToString();
				value = string.IsNullOrEmpty(value) || value.StartsWith("(") ? item.Value.ToString() : value;
				if (pattern != null)
				{
					var combined = value.Split(' ', StringSplitOptions.RemoveEmptyEntries);
					if (combined.Length > 1)
					{
						for (var i = 0; i < combined.Length; i++)
						{
							var subVal = combined[i];
							if (subVal.StartsWith(pattern))
								combined[i] = subVal.Substring(pattern.Length).ToLowerInvariant().ToUpperCamel();
						}

						value = string.Join(' ', combined);
					}
					else if (value.StartsWith(pattern))
					{
						value = value.Substring(pattern.Length).ToLowerInvariant().ToUpperCamel();
					}
				}

				if (Regex.IsMatch(value, @"\d<<\d"))
					value = value.Replace("<<", " << ");
				var itemDecl = new CodeEnumItem(name, value);
				itemDecl.Comments.AddVSDocComment(item.Comment, "summary");
				decl.Members.Add(itemDecl);
			}

			ns.Types.Add(decl);
		}

		protected override void BuildClass(CodeNamespace ns, CppClass @class)
		{
			if (@class.TypeKind != CppTypeKind.StructOrClass
			    || @class.ClassKind != CppClassKind.Struct)
			{
				if (@class.Name == "CefStringBase")
					return;
				//if (@class.ClassKind == CppClassKind.Class)
				//	return;
				Console.WriteLine(@class.Name);
				throw new NotImplementedException();
			}

			var className = GetClassName(@class.Name);

			var sourceFile = @class.GetSourceFile();

			if (sourceFile.EndsWith("_capi.h"))
			{
				var fname = Path.GetFileName(sourceFile);
				fname = Path.Combine(Path.GetDirectoryName(Path.GetDirectoryName(sourceFile)),
					fname.Remove(fname.Length - 7) + ".h");
				if (File.Exists(fname))
				{
					var cppClassName = className.EndsWith("_t")
						? className.Remove(className.Length - 2).ToUpperCamel()
						: className.ToUpperCamel();
					string prevLine = null;
					foreach (var line in File.ReadLines(fname))
					{
						if (line.IndexOf("class " + cppClassName + " ", StringComparison.OrdinalIgnoreCase) != -1)
						{
							if (prevLine.Contains("source=library"))
								Extensions.StructTypes.Add(className, CefSourceKind.Library);
							else if (prevLine.Contains("source=client"))
								Extensions.StructTypes.Add(className, CefSourceKind.Client);
							break;
						}

						prevLine = line;
					}
				}
			}

			var decl = new CodeStruct(className);
			decl.Attributes = CodeAttributes.Public | CodeAttributes.Unsafe | CodeAttributes.Partial;
			decl.Comments.AddVSDocComment(@class.Comment, "summary");

			var attr = new CustomCodeAttribute(typeof(StructLayoutAttribute));
			attr.AddParameter(LayoutKind.Sequential);
			decl.CustomAttributes.Add(attr);


			//CLSCompliant

			if (@class.Functions.Count > 0)
			{
				if (@class.Fields.Count > 0)
					throw new NotSupportedException();

				foreach (var fn in @class.Functions) DefineFunction(decl, fn);
			}

			foreach (var field in @class.Fields) DefineField(decl, field);

			ns.Types.Add(decl);
		}

		protected override void BuildCefApi(CodeNamespace ns, CefApiClass @class)
		{
			var decl = new CodeClass(GetClassName(@class.Name));
			decl.Attributes = CodeAttributes.Public | CodeAttributes.Static | CodeAttributes.Partial;
			decl.Comments.AddVSDocComment(@class.Comment, "summary");
			decl.Members.Add(new CodeField("string", "ApiHash")
			{
				Value = "\"" + @class.ApiHash + "\"",
				Attributes = CodeAttributes.Public | CodeAttributes.Static | CodeAttributes.ReadOnly
			});

			foreach (var fn in @class.Functions.OrderBy(f => f.Name))
			{
				if (fn.Name == "cef_get_xdisplay")
					continue;
				if (fn.Name == "cef_get_current_platform_thread_handle")
					continue;
				DefineFunction(decl, fn);
			}

			ns.Types.Add(decl);
		}

		private void DefineFunction(CodeType typeDecl, CppFunction func)
		{
			if (func.Name == "ArraySizeHelper")
				return;

			if (func.LinkageKind != CppLinkageKind.External)
				throw new NotImplementedException();

			var retType = GetTypeDesc(func.ReturnType);
			var fn = new CodeMethod(func.Name);
			fn.RetVal = new CodeMethodParameter(null) {Type = ResolveCefType(retType.ToString())};
			fn.Attributes = CodeAttributes.Public | CodeAttributes.External | CodeAttributes.Unsafe |
			                CodeAttributes.Static;
			if (func.CallingConvention == CppCallingConvention.C)
				fn.CustomAttributes.AddDllImportfAttribute(CallingConvention.Cdecl);
			else if (func.CallingConvention == CppCallingConvention.X86StdCall)
				fn.CustomAttributes.AddDllImportfAttribute(CallingConvention.StdCall);
			else
				throw new NotImplementedException();

			var filename = func.Span.Start.File;
			filename = Path.GetRelativePath(BaseDirectory, filename).Replace('\\', '/');
			fn.Comments.AddVSDocComment(func.Comment, "summary");
			fn.Comments.AddVSDocComment(string.Format("Defined in {0} as\n{1}", filename, func), "remarks");

			var @params = func.Parameters;
			for (var i = 0; i < @params.Count; i++)
			{
				var arg = @params[i];

				var param = new CodeMethodParameter(arg.Name.EscapeName());
				var paramType = GetTypeDesc(arg.Type);

				var argType = paramType.ToString();
				while (argType.StartsWith("const "))
				{
					argType = argType.Substring(6);
					param.Direction = CodeMethodParameterDirection.In;
				}

				param.Type = ResolveCefType(argType);
				fn.Parameters.Add(param);
			}

			typeDecl.Members.Add(fn);
		}

		private void DefineField(CodeType typeDecl, CppField field)
		{
			CodeMethod caller = null;

			var fieldType = GetTypeDesc(field.Type);
			var fld = new CodeField(ResolveCefType(fieldType.ToString()), field.Name.EscapeName());
			if (fieldType.IsCallable)
			{
				fld.Attributes = CodeAttributes.Public; // | CodeAttributes.ReadOnly;
				fld.Comments.AddVSDocComment(fieldType.Name, "summary");

				var fnType = fieldType.FunctionTypeRef;
				var retType = GetTypeDesc(fnType.ReturnType);
				caller = new CodeMethod(field.Name.ToUpperCamel(fnType.Parameters.Count).EscapeName());
				var rvtype = new CodeMethodParameter(null);
				rvtype.Type = ResolveCefType(retType.ToString());
				if (retType.Name == "char16" || retType.Name == "wchar")
				{
					rvtype.CustomAttributes.Add(new CustomCodeAttribute("return: MarshalAs(UnmanagedType.U2)"));
					throw new NotImplementedException(); // TODO: check it
				}

				caller.RetVal = rvtype;
				caller.Attributes = CodeAttributes.Public | CodeAttributes.External | CodeAttributes.Unsafe;
				caller.CustomAttributes.AddMethodImplForwardRefAttribute();
				caller.CustomAttributes.Add(
					new CustomCodeAttribute("NativeName") {Parameters = {"\"" + field.Name + "\""}});
				caller.Comments.AddVSDocComment(field.Comment, "summary");
				caller.Callee = fld;
				var @params = fnType.Parameters;
				for (var i = 0; i < @params.Count; i++)
				{
					var arg = @params[i];
					if (i == 0 && arg.Name == "self")
					{
						var argTypeName = ResolveCefType(arg.Type.GetDisplayName());
						if (argTypeName == typeDecl.Name + "*")
						{
							caller.HasThisArg = true;
							continue;
						}
					}

					var param = new CodeMethodParameter(arg.Name.EscapeName());
					var paramType = GetTypeDesc(arg.Type);

					var argType = paramType.ToString();
					while (argType.StartsWith("const "))
					{
						argType = argType.Substring(6);
						param.Direction = CodeMethodParameterDirection.In;
					}

					if (param.Direction == CodeMethodParameterDirection.In)
						param.CustomAttributes.Add(new CustomCodeAttribute("Immutable"));
					if (argType == "char16" || argType == "wchar")
					{
						param.CustomAttributes.Add(new CustomCodeAttribute("MarshalAs(UnmanagedType.U2)"));
						throw new NotImplementedException(); // TODO: check it
					}

					param.Type = ResolveCefType(argType);
					caller.Parameters.Add(param);
				}
			}
			else
			{
				fld.Comments.AddVSDocComment(field.Comment, "summary");
				fld.Attributes = CodeAttributes.Public;
				if (fieldType.Name == "char16" || fieldType.Name == "wchar")
					fld.CustomAttributes.Add(new CustomCodeAttribute("MarshalAs(UnmanagedType.U2)"));
			}

			typeDecl.Members.Add(fld);
			if (caller != null) typeDecl.Members.Add(caller);
		}
	}
}