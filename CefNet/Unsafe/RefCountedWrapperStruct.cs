using System;
using System.Runtime.InteropServices;
using CefNet.CApi;

namespace CefNet.Unsafe
{
	[StructLayout(LayoutKind.Sequential)]
#if DEBUG
	public
#endif
		unsafe struct RefCountedWrapperStruct
	{
		public IntPtr type;
		public IntPtr cppObject;
		public IntPtr wrapper;
		public cef_base_ref_counted_t _refcounted;

		public CefWrapperType Type => (CefWrapperType) (type.ToInt64() & 0xFFFFFFFF);

		private static readonly int RefCountedFieldOffset = GetRefCountetFieldOffset();

		private static int GetRefCountetFieldOffset()
		{
			//return (int)Marshal.OffsetOf<RefCountedWrapperStruct>("_refcounted");
			var ws = new RefCountedWrapperStruct();
			return (int) ((byte*) &ws._refcounted - (byte*) &ws);
		}

		public static RefCountedWrapperStruct* FromRefCounted(void* instance)
		{
			return (RefCountedWrapperStruct*) ((byte*) instance - RefCountedFieldOffset);
		}
	}
}