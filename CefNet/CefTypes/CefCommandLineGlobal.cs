using System;
using CefNet.CApi;

namespace CefNet
{
	internal unsafe class CefCommandLineGlobal : CefCommandLine
	{
		internal CefCommandLineGlobal()
			: base(CefNativeApi.cef_command_line_get_global())
		{
		}

		public override string Program
		{
			get => base.Program;
			set => throw new NotSupportedException();
		}

		public override void AppendArgument(string argument)
		{
			throw new NotSupportedException();
		}

		public override void AppendSwitch(string name)
		{
			throw new NotSupportedException();
		}

		public override void AppendSwitchWithValue(string name, string value)
		{
			throw new NotSupportedException();
		}

		public override void InitFromArgv(int argc, IntPtr argv)
		{
			throw new NotSupportedException();
		}

		public override void InitFromString(string command_line)
		{
			throw new NotSupportedException();
		}

		public override void PrependWrapper(string wrapper)
		{
			throw new NotSupportedException();
		}

		public override void Reset()
		{
			throw new NotSupportedException();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
				return;
			base.Dispose(disposing);
		}
	}
}