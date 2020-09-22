using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using CefNet.CApi;

namespace CefNet
{
	/// <summary>
	///  Structure representing CefExecuteProcess arguments.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct CefMainArgs : IDisposable
	{
		private cef_main_args_t _instance;

		public static CefMainArgs Create(Encoding encoding, string[] args)
		{
			if (PlatformInfo.IsWindows)
				throw new PlatformNotSupportedException();

			if (args != null)
			{
				if (encoding == null)
					throw new ArgumentNullException(nameof(encoding));
				if (args.Any(arg => arg == null))
					throw new ArgumentOutOfRangeException(nameof(args));

				var mainArgs = new CefMainArgs();
				mainArgs._instance.posix.argc = args.Length;
				mainArgs._instance.posix.argv = CreateArgv(encoding, args);
				return mainArgs;
			}

			return new CefMainArgs();
		}

		public static CefMainArgs CreateDefault()
		{
			var mainArgs = new CefMainArgs();
			if (PlatformInfo.IsWindows)
			{
				mainArgs._instance.windows.instance = NativeMethods.GetModuleHandle(null);
			}
			else
			{
				var args = Environment.GetCommandLineArgs();
				mainArgs._instance.posix.argc = args.Length;
				mainArgs._instance.posix.argv = CreateArgv(Encoding.UTF8, args);
			}

			return mainArgs;
		}

		private static byte** CreateArgv(Encoding encoding, string[] args)
		{
			var arraySize = IntPtr.Size * (args.Length + 1);
			var memorySize = arraySize + args.Length;
			foreach (var arg in args) memorySize += encoding.GetByteCount(arg);

			var argv = (byte**) Marshal.AllocHGlobal(memorySize);
			var data = (byte*) argv + arraySize;
			var bufferEnd = (byte*) argv + memorySize;

			for (var i = 0; i < args.Length; i++)
			{
				argv[i] = data;
				var arg = args[i];
				fixed (char* arg_ptr = arg)
				{
					data += encoding.GetBytes(arg_ptr, arg.Length, data, (int) (bufferEnd - data));
				}

				data[0] = 0;
				data++;
			}

			argv[args.Length] = null;
			return argv;
		}

		public void Dispose()
		{
			if (PlatformInfo.IsLinux || PlatformInfo.IsMacOS)
			{
				var argv = _instance.posix.argv;
				if (argv != null)
				{
					Marshal.FreeHGlobal(new IntPtr(_instance.posix.argv));
					_instance.posix.argv = null;
					_instance.posix.argc = 0;
				}
			}
		}

		public static implicit operator CefMainArgs(cef_main_args_t instance)
		{
			return new CefMainArgs {_instance = instance};
		}

		public static implicit operator cef_main_args_t(CefMainArgs instance)
		{
			return instance._instance;
		}
	}
}