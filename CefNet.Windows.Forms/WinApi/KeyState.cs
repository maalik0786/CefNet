using System;

namespace CefNet.WinApi
{
	[Flags]
	internal enum KeyState : ushort
	{
		None = 0,
		Pressed = 0x8000,
		Toggled = 0x0001
	}
}