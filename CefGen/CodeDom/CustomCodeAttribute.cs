// --------------------------------------------------------------------------------------------
// Copyright (c) 2019 The CefNet Authors. All rights reserved.
// Licensed under the MIT license.
// See the licence file in the project root for full license information.
// --------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace CefGen.CodeDom
{
	public sealed class CustomCodeAttribute
	{
		public CustomCodeAttribute(Type attribute)
			: this(attribute.Name.EndsWith("Attribute")
				? attribute.Name.Remove(attribute.Name.Length - 9)
				: attribute.Name)
		{
		}

		public CustomCodeAttribute(string name)
		{
			Name = name;
		}

		public string Name { get; }

		public List<string> Parameters { get; } = new List<string>(0);

		public void AddParameter<T>(T value)
		{
			var t = typeof(T);
			if (t.IsPrimitive)
				Parameters.Add(value.ToString());
			Parameters.Add(t.Name + "." + value);
		}

		public override string ToString()
		{
			if (Parameters.Count == 0)
				return Name;
			return Name + "(" + string.Join(", ", Parameters) + ")";
		}
	}
}