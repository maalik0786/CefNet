// --------------------------------------------------------------------------------------------
// Copyright (c) 2019 The CefNet Authors. All rights reserved.
// Licensed under the MIT license.
// See the licence file in the project root for full license information.
// --------------------------------------------------------------------------------------------

using CppAst;

namespace CefGen
{
	public class TypeDesc
	{
		private string _clrType;

		public TypeDesc(string name, CppType typeRef)
		{
			Name = name;
			_clrType = name;
			TypeRef = typeRef;
		}

		public CppType TypeRef { get; }
		public CppFunctionType FunctionTypeRef { get; set; }

		public string Name { get; }

		public string ClrType
		{
			get => IsCallable ? "void*" : _clrType;
			set => _clrType = value;
		}

		public bool IsCallable => FunctionTypeRef != null;

		public bool IsUnsafe => TypeRef is CppPointerType;

		public override string ToString()
		{
			return ClrType;
		}
	}
}