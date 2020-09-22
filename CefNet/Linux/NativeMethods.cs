using System;
using System.Runtime.InteropServices;
using CefNet.Input.Linux;

namespace CefNet.Linux
{
	internal static class NativeMethods
	{
		[DllImport("X11", CallingConvention = CallingConvention.Cdecl)]
		public static extern XKeySym XStringToKeysym([MarshalAs(UnmanagedType.LPStr)] string s);

		[DllImport("X11", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr XOpenDisplay(IntPtr display);

		[DllImport("X11", CallingConvention = CallingConvention.Cdecl)]
		public static extern int XCloseDisplay(IntPtr display);

		[DllImport("X11", CallingConvention = CallingConvention.Cdecl)]
		public static extern byte XKeysymToKeycode(IntPtr display, XKeySym keysym);

		[DllImport("X11", CallingConvention = CallingConvention.Cdecl)]
		public static extern XKeySym XKeycodeToKeysym(IntPtr display, byte keycode, int index);
	}
}