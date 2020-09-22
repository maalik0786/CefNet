﻿using System;
using System.ComponentModel;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using CefNet.WinApi;

namespace CefNet.Internal
{
	internal delegate IntPtr WindowsWindowProcDelegate(IntPtr hwnd, int message, IntPtr wParam, IntPtr lParam,
		ref bool handled);

	internal sealed class WindowsHwndSource : CriticalFinalizerObject, IDisposable
	{
		private readonly WindowProc fnWndProcHook;


		private bool _disposed;
		private IntPtr hWndProcHook;

		private WindowsHwndSource(IntPtr hwnd)
		{
			hWndProcHook = IntPtr.Zero;
			Handle = hwnd;
			fnWndProcHook = WndProcHook;
		}

		public IntPtr Handle { get; }

		public WindowsWindowProcDelegate WndProcCallback { get; set; }

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}


		public static WindowsHwndSource FromHwnd(IntPtr hwnd)
		{
			const int GWLP_WNDPROC = -4;

			var tid = NativeMethods.GetWindowThreadProcessId(hwnd, IntPtr.Zero);
			if (tid == 0)
				throw new Win32Exception(Marshal.GetLastWin32Error());

			var source = new WindowsHwndSource(hwnd);
			source.hWndProcHook = NativeMethods.SetWindowLong(hwnd, GWLP_WNDPROC,
				Marshal.GetFunctionPointerForDelegate(source.fnWndProcHook));
			if (source.hWndProcHook == IntPtr.Zero)
				throw new Win32Exception(Marshal.GetLastWin32Error());

			return source;
		}

		~WindowsHwndSource()
		{
			Dispose(false);
		}

		private void Dispose(bool disposing)
		{
			if (_disposed)
				return;

			if (hWndProcHook != IntPtr.Zero)
			{
				const int GWLP_WNDPROC = -4;
				NativeMethods.SetWindowLong(Handle, GWLP_WNDPROC, hWndProcHook);
			}

			_disposed = true;
		}

		private IntPtr WndProcHook(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam)
		{
			var retval = IntPtr.Zero;
			var wndproc = WndProcCallback;
			if (wndproc != null)
			{
				var handled = false;
				retval = wndproc(hwnd, msg, wParam, lParam, ref handled);
				if (handled)
					return retval;
			}

			return NativeMethods.CallWindowProc(hWndProcHook, hwnd, msg, wParam, lParam);
		}

		private delegate IntPtr WindowProc(IntPtr hwnd, int message, IntPtr wParam, IntPtr lParam);
	}
}