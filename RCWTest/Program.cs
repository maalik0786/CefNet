using System;
using CefNet;

namespace RCWTest
{
	internal unsafe class Program
	{
		[STAThread]
		public static void Main(string[] args)
		{
			var key = Test1();
			Console.WriteLine("collect");
			GC.Collect();
			GC.WaitForPendingFinalizers();
			Console.WriteLine("release");
			Test2(key);

			for (var i = 0; i < 5; i++)
			{
				Console.WriteLine("collect");
				GC.Collect();
				GC.WaitForPendingFinalizers();
			}

			Console.ReadKey();
		}

		public static IntPtr Test1()
		{
			var test = new TestClass();
			var app = new CefAppImpl();
			var key = (IntPtr) app.GetNativeInstance();
			app = null;
			test = null;
			return key;
		}

		public static void Test2(IntPtr key)
		{
			var app = (CefAppImpl) CefAppImpl.GetInstance(key);
			app.Release();
		}
	}

	internal sealed class TestClass
	{
		~TestClass()
		{
			Console.WriteLine("finalize TestClass");
		}
	}

	internal sealed class CefAppImpl : CefApp
	{
		~CefAppImpl()
		{
			Console.WriteLine("finalize CefAppImpl");
		}
	}
}