using System;

namespace CefNet
{
	[AttributeUsage(AttributeTargets.Method, Inherited = false)]
	internal sealed class NativeNameAttribute : Attribute
	{
		public NativeNameAttribute(string name) { }
	}
}