// --------------------------------------------------------------------------------------------
// Copyright (c) 2019 The CefNet Authors. All rights reserved.
// Licensed under the MIT license.
// See the licence file in the project root for full license information.
// --------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using CppAst;

namespace CefGen
{
	internal sealed class CefApiClass : CppTypeDeclaration, ICppDeclarationContainer, ICppMember, ICppElement,
		ICppContainer
	{
		public CefApiClass(string name)
			: base(CppTypeKind.StructOrClass)
		{
			Name = name;
			Fields = new CppContainerList<CppField>(this);
			Functions = new CppContainerList<CppFunction>(this);
			Enums = new CppContainerList<CppEnum>(this);
			Classes = new CppContainerList<CppClass>(this);
			Typedefs = new CppContainerList<CppTypedef>(this);
		}

		public string ApiHash { get; set; }

		public override int SizeOf { get; set; }

		public CppContainerList<CppField> Fields { get; set; }

		public CppContainerList<CppFunction> Functions { get; set; }

		public CppContainerList<CppEnum> Enums { get; set; }

		public CppContainerList<CppClass> Classes { get; set; }

		public CppContainerList<CppTypedef> Typedefs { get; set; }

		public override IEnumerable<ICppDeclaration> Children()
		{
			foreach (var @enum in Enums)
				yield return @enum;

			foreach (var @class in Classes)
				yield return @class;

			foreach (var typedef in Typedefs)
				yield return typedef;

			foreach (var field in Fields)
				yield return field;

			foreach (var function in Functions.OrderBy(f => f.Name))
				yield return function;
		}

		public string Name { get; set; }

		public override CppType GetCanonicalType()
		{
			return this;
		}
	}
}