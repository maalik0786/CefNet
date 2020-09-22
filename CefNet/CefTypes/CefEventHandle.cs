using System.Runtime.InteropServices;
using CefNet.WinApi;

namespace CefNet
{
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct CefEventHandle
	{
		private readonly void* _instance;

		public ref MSG ToWindowsEvent()
		{
			return ref *(MSG*) _instance;
		}
	}
}