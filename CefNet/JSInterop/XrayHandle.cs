using System;
using System.Runtime.InteropServices;

namespace CefNet.JSInterop
{
	[StructLayout(LayoutKind.Explicit, Pack = 4, Size = 20)]
	public struct XrayHandle
	{
		[FieldOffset(0)] public long frame;
		[FieldOffset(8)] public XrayDataType dataType;
		[FieldOffset(12)] public IntPtr gcHandle;
		[FieldOffset(12)] public double fRaw;
		[FieldOffset(12)] public long iRaw;

		public XrayHandle(long frameid, IntPtr handle, XrayDataType dataType)
		{
			this.dataType = dataType;
			iRaw = 0;
			fRaw = 0;
			frame = frameid;
			gcHandle = handle;
		}

		public void Release()
		{
			if (gcHandle == IntPtr.Zero)
				return;
			var handle = GCHandle.FromIntPtr(gcHandle);
			gcHandle = IntPtr.Zero;
			if (handle.Target is XrayObject obj)
				obj.ReleaseHandle();
		}

		public XrayObject GetTarget(CefFrame frame)
		{
			if (gcHandle == IntPtr.Zero)
				return null;

			if (frame is null || frame.Identifier != this.frame)
				throw new ObjectDeadException();

			var handle = GCHandle.FromIntPtr(gcHandle);
			return (XrayObject) handle.Target;
		}

		public static readonly XrayHandle Zero;

		public static XrayHandle FromDateTime(DateTime t)
		{
			var h = new XrayHandle();
			h.dataType = XrayDataType.Date;
			h.iRaw = t.ToBinary();
			return h;
		}

		public unsafe CefBinaryValue ToCfxBinaryValue()
		{
			CefBinaryValue value;
			var handle = GCHandle.Alloc(this, GCHandleType.Pinned);
			value = new CefBinaryValue(handle.AddrOfPinnedObject(), sizeof(XrayHandle));
			handle.Free();
			return value;
		}

		public object ToObject()
		{
			switch (dataType)
			{
				case XrayDataType.Date:
					return DateTime.FromBinary(iRaw);
				case XrayDataType.Object:
				case XrayDataType.Function:
				case XrayDataType.CorsRedirect:
					return this;
			}

			throw new NotSupportedException();
		}

		internal CefV8Value ToCefV8Value(CefFrame frame)
		{
			switch (dataType)
			{
				case XrayDataType.Date:
					return new CefV8Value(DateTime.FromBinary(iRaw));
				case XrayDataType.Object:
				case XrayDataType.Function:
					var xray = GetTarget(frame);
					if (xray == null)
						throw new InvalidCastException();
					return xray.Value;
			}

			throw new NotSupportedException();
		}

		//public unsafe string Dump()
		//{
		//	var buffer = new byte[sizeof(XrayHandle)];
		//	fixed(byte* buf = buffer)
		//	{
		//		Marshal.StructureToPtr(this, (IntPtr)buf, false);
		//	}
		//	return string.Join(", ", buffer);
		//}

		public static unsafe XrayHandle FromCfxBinaryValue(CefBinaryValue v)
		{
			var xray = new XrayHandle();
			v.GetData((IntPtr) (&xray), sizeof(XrayHandle), 0);
			return xray;
		}

		public static unsafe bool operator ==(XrayHandle a, XrayHandle b)
		{
			var a64 = (ulong*) &a;
			var b64 = (ulong*) &b;
			var a32 = (uint*) &a;
			var b32 = (uint*) &b;
			return *a64 == *b64 && *(a64 + 1) == *(b64 + 1) && *(a32 + 4) == *(b32 + 4);
		}

		public static bool operator !=(XrayHandle a, XrayHandle b)
		{
			return !(a == b);
		}

		public override bool Equals(object obj)
		{
			if (obj is XrayHandle a)
				return this == a;
			return false;
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
	}
}