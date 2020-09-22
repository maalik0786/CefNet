// --------------------------------------------------------------------------------------------
// Copyright (c) 2019 The CefNet Authors. All rights reserved.
// Licensed under the MIT license.
// See the licence file in the project root for full license information.
// --------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using CefGen.CodeDom;
using CppAst;
using Microsoft.CodeAnalysis;

namespace CefGen
{
	internal static class Extensions
	{
		private static readonly char[] WordSplittres = {' ', '\t', '\r', '\n'};

		private static readonly Lazy<string[]> Handlers = new Lazy<string[]>(() =>
			File.ReadAllLines(Path.Combine("Settings", "Handlers.txt"), Encoding.UTF8)
				.Select(s => s.Trim()).Where(s => !string.IsNullOrEmpty(s)).ToArray(), true);

		internal static readonly Dictionary<string, CefSourceKind>
			StructTypes = new Dictionary<string, CefSourceKind>();

		private static readonly Lazy<BoolIntInfo[]> BooleanInt = new Lazy<BoolIntInfo[]>(() =>
		{
			var info = new List<BoolIntInfo>();
			foreach (var s in File.ReadAllLines(Path.Combine("Settings", "BooleanIntParams.txt"), Encoding.UTF8)
				.Select(s => s.Trim()).Where(s => !string.IsNullOrEmpty(s)))
			{
				var startPos = s.IndexOf('(');
				var endPos = s.LastIndexOf(')');
				if (startPos == -1 || endPos == -1 || startPos > endPos)
					continue;
				var methodName = s.Remove(startPos);
				foreach (var arg in s.Substring(startPos + 1, endPos - startPos - 1)
					.Split(',', StringSplitOptions.RemoveEmptyEntries))
				{
					if (string.IsNullOrWhiteSpace(arg))
						continue;
					info.Add(new BoolIntInfo {Method = methodName, Arg = arg.Trim()});
				}
			}

			return info.ToArray();
		}, true);

		private static readonly Lazy<Dictionary<string, string>> Names = new Lazy<Dictionary<string, string>>(() =>
			File.ReadAllLines(Path.Combine("Settings", "NamesSchema.txt"), Encoding.UTF8).Select(s => s.Trim())
				.Select(s => s.Split(':'))
				.Where(a => a.Length == 2).ToDictionary(a => a[0].Trim(), a => a[1].Trim()), true);


		private static readonly string[] Keywords =
		{
			"private", "public", "internal", "protected", "override", "virtual", "base", "this", "event", "params",
			"checked", "string", "object", "delegate"
		};

		private static readonly string[] KeywordsIL =
		{
			"value", "hidebysig", "valuetype", "cdecl", "request", "type", "error", "stream", "handler", "method",
			"filter", "flags", "rethrow"
		};

		private static readonly string[] UpperCaseNames = {"ssl", "cdm", "js", "dom", "ui", "io"};

		public static StringBuilder TrimEnd(this StringBuilder self)
		{
			for (var i = self.Length - 1; i >= 0; i--)
				if (char.IsWhiteSpace(self[i]))
					self.Length = i;
				else
					break;
			return self;
		}

		public static bool StartsWith(this string s, params string[] values)
		{
			foreach (var value in values)
				if (s.StartsWith(value))
					return true;
			return false;
		}

		public static int IndexOf(this string s, Func<char, bool> predicate, int startIndex)
		{
			for (var i = startIndex; i < s.Length; i++)
				if (predicate(s[i]))
					return i;
			return -1;
		}

		public static string ToLowerCamel(this string s)
		{
			s = ToUpperCamel(s);
			if (s.Length == 1)
				return s.ToLowerInvariant();
			return char.ToLowerInvariant(s[0]) + s.Substring(1);
		}

		public static string ToUpperCamel(this string s, int argsCount = 0)
		{
			if (string.IsNullOrEmpty(s))
				return s;

			if (s.Length == 1)
				return s.ToUpper();

			if (Names.Value.TryGetValue(s, out var name)) return name;


			if (s.StartsWith("cef_js") && !s.StartsWith("cef_js_") && !s.StartsWith("cef_json_"))
				s = "cef_js_" + s.Substring(6);
			else if (s.StartsWith("cef_v8") && !s.StartsWith("cef_v8_"))
				s = "cef_v8_" + s.Substring(6);
			else if (s.StartsWith("cef_ssl") && !s.StartsWith("cef_ssl_"))
				s = "cef_ssl_" + s.Substring(7);
			else if (s.StartsWith("cef_dom") && !s.StartsWith("cef_dom_"))
				s = "cef_dom_" + s.Substring(7);
			else if (s.StartsWith("cef_x509") && !s.StartsWith("cef_x509_"))
				s = "cef_x509_" + s.Substring(8);
			else if (s.StartsWith("set_value_by") && !s.StartsWith("set_value_by_"))
				s = "set_value_by_" + s.Substring(12);
			else if (s.StartsWith("get_value_by") && !s.StartsWith("get_value_by_"))
				s = "get_value_by_" + s.Substring(12);

			if (s.Contains("url", StringComparison.OrdinalIgnoreCase))
				s = Regex.Replace(s, "(?<url>(_urls?))(?<char>.)", m =>
				{
					var after = m.Groups["char"].Value;
					if (after == "_") after = string.Empty;
					if (after == "s" && m.Value == "_urls")
						return m.Value;
					return m.Groups["url"].Value + "_" + after;
				});

			var parts = s.Split('_');

			var t = "";
			foreach (var part in parts)
				if (part.Length == 1)
					t += part.ToUpper();
				else if (UpperCaseNames.Contains(part))
					t += part.ToUpperInvariant();
				else if (part.StartsWith("js") && !part.StartsWith("json") && part.Length > 2)
					t += "JS" + char.ToUpper(part[2]) + part.Substring(3);
				else if (part == "keydown")
					t += "KeyDown";
				else if (part == "keyup")
					t += "KeyUp";
				else if (part == "rawkeydown")
					t += "RawKeyDown";
				else if (part == "v8context")
					t += "V8Context";
				else if (part == "uint")
					t += "UInt";
				else if (part == "bykey")
					t += "ByKey";
				else if (part == "byindex")
					t += "ByIndex";
				else if (part == "byaccessor")
					t += "ByAccessor";
				else if (part == "byname")
					t += "ByName";
				else if (part == "byqname")
					t += "ByQName";
				else if (part == "bylname")
					t += "ByLName";
				else
					t += char.ToUpper(part[0]) + part.Substring(1);
			if (t == "GetType" && argsCount <= 1) return "GetCefType";
			return t;
		}

		public static string EscapeName(this string s)
		{
			if (Keywords.Contains(s))
				return "@" + s;
			return s;
		}

		public static string UnescapeName(this string s)
		{
			if (s.StartsWith('@'))
				return s.Substring(1);
			return s;
		}

		public static string EscapeILName(this string s)
		{
			s = EscapeName(s);
			if (KeywordsIL.Contains(s))
				return "'" + s + "'";
			return s;
		}

		public static string GetSourceFile(this CppTypeDeclaration cppType)
		{
			if (cppType is CppClass @class)
				return GetSourceFile(@class);
			return cppType.Span.Start.File;
		}

		public static string GetSourceFile(this CppClass @class)
		{
			var field = @class.Fields.FirstOrDefault();
			if (field is null)
				return @class.Span.Start.File;
			return field.Span.Start.File;
		}

		public static bool IsImplementation(this INamedTypeSymbol symbol)
		{
			if (StructTypes.TryGetValue(symbol.Name, out var sourceKind))
				return sourceKind != CefSourceKind.Client;

			throw new NotImplementedException();
		}

		public static string GetComment(this ISymbol symbol)
		{
			var lines = new List<string>();
			foreach (var line in symbol.GetDocumentationCommentXml().Split('\n'))
			{
				var s = line.Trim();
				if (s.StartsWith("<"))
					continue;
				lines.Add(s);
			}

			return string.Join('\n', lines);
		}

		public static bool IsImmutable(this IParameterSymbol symbol)
		{
			return symbol.GetAttributes().Any(attr => attr.AttributeClass.Name == "ImmutableAttribute");
		}

		public static bool IsBool(this IParameterSymbol parameter)
		{
			if (parameter.Type.Name != "Int32")
				return false;

			var name = parameter.Name;
			var method = (IMethodSymbol) parameter.ContainingSymbol;
			var nativeNameAttribute = method.GetAttributes()
				.FirstOrDefault(attr => attr.AttributeClass.Name == "NativeNameAttribute");
			var methodNativeName = nativeNameAttribute?.ConstructorArguments[0].Value as string;
			if (methodNativeName != null)
			{
				var methodName = (method.ContainingType.Name + "::" + methodNativeName).TrimStart('_');
				foreach (var boolInt in BooleanInt.Value)
					if (boolInt.Method == methodName && boolInt.Arg == name)
						return true;
			}

			var comment = method.GetComment();

			if (name.StartsWith("is") && name.Length > 2 && (name[2] == '_' || char.IsUpper(name[2])))
				return true;
			if ((name.StartsWith("can") || name.StartsWith("has")) && name.Length > 3 &&
			    (name[3] == '_' || char.IsUpper(name[3])))
				return true;

			var namePattern = "|" + name + "|";
			var startPos = 0;
			while (true)
			{
				startPos = comment.IndexOf(namePattern, startPos + 1);
				if (startPos == -1)
					return false;

				var endPos = comment.IndexOf('.', startPos);
				if (endPos == -1)
					endPos = comment.Length;

				foreach (var word in comment.Substring(startPos, endPos - startPos)
					.Split(WordSplittres, 5, StringSplitOptions.RemoveEmptyEntries).Skip(1))
				{
					if (word.StartsWith('|') && word.EndsWith('|'))
						break; // found another parameter
					if (word.StartsWith("true") || word.StartsWith("false"))
						return true;
				}
			}
		}

		public static bool IsBool(this IMethodSymbol method)
		{
			if (method.ReturnType.Name != "Int32")
				return false;
			var comment = method.GetComment();
			if (comment == null)
				return false;
			if (comment.StartsWith("True if "))
				return true;
			if (comment.StartsWith("Return a bool"))
				return true;

			return Regex.IsMatch(comment, @"returns?\s+true", RegexOptions.IgnoreCase)
			       || Regex.IsMatch(comment, @"returns?\s+false", RegexOptions.IgnoreCase);
		}

		public static bool IsBool(this IFieldSymbol field)
		{
			if (field.Type.Name != "Int32")
				return false;
			var comment = field.GetComment();
			if (comment == null)
				return false;

			return comment.Contains("true", StringComparison.OrdinalIgnoreCase)
			       || comment.Contains("false", StringComparison.OrdinalIgnoreCase);
		}

		public static void AddVSDocComment(this IList<CodeComment> comments, string commentText, string name)
		{
			if (commentText == null)
				return;

			comments.Add(new CodeComment("<" + name + ">", true));
			comments.Add(new CodeComment(SecurityElement.Escape(commentText.Trim()), true));
			comments.Add(new CodeComment("</" + name + ">", true));
		}

		public static void AddVSDocComment(this IList<CodeComment> comments, CppComment comment, string name)
		{
			if (comment == null)
				return;

			AddVSDocComment(comments, comment.ChildrenToString(), name);
		}

		public static void AddComment(this IList<CodeComment> comments, string commentText)
		{
			if (commentText == null)
				return;

			commentText = commentText.Trim();
			comments.Add(new CodeComment(commentText));
		}

		public static void AddSymbolComment(this IList<CodeComment> comments, ISymbol symbol)
		{
			var commentXml = symbol.GetDocumentationCommentXml();
			if (string.IsNullOrWhiteSpace(commentXml))
				return;
			var lines = new List<string>();
			foreach (var line in commentXml.Trim().Split('\n'))
			{
				var s = line.Trim();
				if (s.StartsWith("<member ") || s.StartsWith("</member>"))
					continue;
				lines.Add(s);
			}

			comments.Add(new CodeComment(string.Join("\n", lines), true));
		}

		public static void AddDllImportfAttribute(this IList<CustomCodeAttribute> list,
			CallingConvention callingConvention)
		{
			var attr = new CustomCodeAttribute(typeof(DllImportAttribute));
			attr.Parameters.Add("\"libcef\"");
			attr.Parameters.Add("CallingConvention = CallingConvention." + callingConvention);
			list.Add(attr);
		}

		public static void AddUnmanagedFunctionPointerAttribute(this IList<CustomCodeAttribute> list,
			CallingConvention callingConvention)
		{
			var attr = new CustomCodeAttribute(typeof(UnmanagedFunctionPointerAttribute));
			attr.Parameters.Add(nameof(CallingConvention) + "." + callingConvention);
			list.Add(attr);
		}

		public static void AddUnmanagedFunctionPointerAttribute(this IList<CustomCodeAttribute> list,
			string callingConvention)
		{
			var attr = new CustomCodeAttribute(typeof(UnmanagedFunctionPointerAttribute));
			attr.Parameters.Add(callingConvention);
			list.Add(attr);
		}

		public static void AddMethodImplForwardRefAttribute(this IList<CustomCodeAttribute> list)
		{
			var attr = new CustomCodeAttribute(typeof(MethodImplAttribute));
			attr.AddParameter(MethodImplOptions.ForwardRef);
			list.Add(attr);
		}

		private struct BoolIntInfo
		{
			public string Method;
			public string Arg;
		}
	}
}