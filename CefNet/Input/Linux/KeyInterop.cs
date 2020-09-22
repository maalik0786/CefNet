﻿using CefNet.WinApi;
using System.Diagnostics;

namespace CefNet.Input.Linux
{
	public static class KeyInterop
	{
		/// <summary>
		///  Converts a Virtual Key into a X KeySym.
		/// </summary>
		/// <param name="key">The virtual key to convert.</param>
		/// <param name="shift">The Shift modifier state.</param>
		/// <returns>The <see cref="XKeySym" />.</returns>
		public static XKeySym VirtualKeyToXKeySym(VirtualKeys key, bool shift)
		{
			// From ui/events/keycodes/keyboard_code_conversion_x.cc.
			// TODO: this method might be incomplete.

			switch (key)
			{
				case VirtualKeys.NumPad0:
					return XKeySym.KP0;
				case VirtualKeys.NumPad1:
					return XKeySym.KP1;
				case VirtualKeys.NumPad2:
					return XKeySym.KP2;
				case VirtualKeys.NumPad3:
					return XKeySym.KP3;
				case VirtualKeys.NumPad4:
					return XKeySym.KP4;
				case VirtualKeys.NumPad5:
					return XKeySym.KP5;
				case VirtualKeys.NumPad6:
					return XKeySym.KP6;
				case VirtualKeys.NumPad7:
					return XKeySym.KP7;
				case VirtualKeys.NumPad8:
					return XKeySym.KP8;
				case VirtualKeys.NumPad9:
					return XKeySym.KP9;
				case VirtualKeys.Multiply:
					return XKeySym.KPMultiply;
				case VirtualKeys.Add:
					return XKeySym.KPAdd;
				case VirtualKeys.Subtract:
					return XKeySym.KPSubtract;
				case VirtualKeys.Decimal:
					return XKeySym.KPDecimal;
				case VirtualKeys.Divide:
					return XKeySym.KPDivide;
				case VirtualKeys.Back:
					return XKeySym.BackSpace;
				case VirtualKeys.Tab:
					return shift ? XKeySym.ISOLeftTab : XKeySym.Tab;
				case VirtualKeys.Clear:
					return XKeySym.Clear;
				case VirtualKeys.Return:
					return XKeySym.Return;
				case VirtualKeys.Shift:
					return XKeySym.ShiftL;
				case VirtualKeys.Control:
					return XKeySym.ControlL;
				case VirtualKeys.Menu:
					return XKeySym.AltL;
				case VirtualKeys.Apps:
					return XKeySym.Menu;
				case VirtualKeys.AltGr:
					return XKeySym.ISOLevel3Shift;
				case VirtualKeys.Compose:
					return XKeySym.MultiKey;
				case VirtualKeys.Pause:
					return XKeySym.Pause;
				case VirtualKeys.Capital:
					return XKeySym.CapsLock;
				case VirtualKeys.KanaMode:
					return XKeySym.KanaLock;
				case VirtualKeys.HanjaMode:
					return XKeySym.HangulHanja;
				case VirtualKeys.IMEConvert:
					return XKeySym.Henkan;
				case VirtualKeys.IMENonconvert:
					return XKeySym.Muhenkan;
				case VirtualKeys.DbeSbcsChar:
					return XKeySym.ZenkakuHankaku;
				case VirtualKeys.DbeDbcsChar:
					return XKeySym.ZenkakuHankaku;
				case VirtualKeys.Escape:
					return XKeySym.Escape;
				case VirtualKeys.Space:
					return XKeySym.Space;
				case VirtualKeys.Prior:
					return XKeySym.PageUp;
				case VirtualKeys.Next:
					return XKeySym.PageDown;
				case VirtualKeys.End:
					return XKeySym.End;
				case VirtualKeys.Home:
					return XKeySym.Home;
				case VirtualKeys.Left:
					return XKeySym.Left;
				case VirtualKeys.Up:
					return XKeySym.Up;
				case VirtualKeys.Right:
					return XKeySym.Right;
				case VirtualKeys.Down:
					return XKeySym.Down;
				case VirtualKeys.Select:
					return XKeySym.Select;
				case VirtualKeys.Print:
					return XKeySym.Print;
				case VirtualKeys.Execute:
					return XKeySym.Execute;
				case VirtualKeys.Insert:
					return XKeySym.Insert;
				case VirtualKeys.Delete:
					return XKeySym.Delete;
				case VirtualKeys.Help:
					return XKeySym.Help;
				case VirtualKeys.D0:
					return shift ? XKeySym.Parenright : XKeySym.D0;
				case VirtualKeys.D1:
					return shift ? XKeySym.Exclam : XKeySym.D1;
				case VirtualKeys.D2:
					return shift ? XKeySym.At : XKeySym.D2;
				case VirtualKeys.D3:
					return shift ? XKeySym.Numbersign : XKeySym.D3;
				case VirtualKeys.D4:
					return shift ? XKeySym.Dollar : XKeySym.D4;
				case VirtualKeys.D5:
					return shift ? XKeySym.Percent : XKeySym.D5;
				case VirtualKeys.D6:
					return shift ? XKeySym.Asciicircum : XKeySym.D6;
				case VirtualKeys.D7:
					return shift ? XKeySym.Ampersand : XKeySym.D7;
				case VirtualKeys.D8:
					return shift ? XKeySym.Asterisk : XKeySym.D8;
				case VirtualKeys.D9:
					return shift ? XKeySym.Parenleft : XKeySym.D9;
				case VirtualKeys.A:
				case VirtualKeys.B:
				case VirtualKeys.C:
				case VirtualKeys.D:
				case VirtualKeys.E:
				case VirtualKeys.F:
				case VirtualKeys.G:
				case VirtualKeys.H:
				case VirtualKeys.I:
				case VirtualKeys.J:
				case VirtualKeys.K:
				case VirtualKeys.L:
				case VirtualKeys.M:
				case VirtualKeys.N:
				case VirtualKeys.O:
				case VirtualKeys.P:
				case VirtualKeys.Q:
				case VirtualKeys.R:
				case VirtualKeys.S:
				case VirtualKeys.T:
				case VirtualKeys.U:
				case VirtualKeys.V:
				case VirtualKeys.W:
				case VirtualKeys.X:
				case VirtualKeys.Y:
				case VirtualKeys.Z:
					return (shift ? XKeySym.A : XKeySym.a) + (key - VirtualKeys.A);
				case VirtualKeys.LWin:
					return XKeySym.SuperL;
				case VirtualKeys.RWin:
					return XKeySym.SuperR;
				case VirtualKeys.NumLock:
					return XKeySym.NumLock;
				case VirtualKeys.Scroll:
					return XKeySym.ScrollLock;
				case VirtualKeys.Oem1:
					return shift ? XKeySym.Colon : XKeySym.Semicolon;
				case VirtualKeys.OemPlus:
					return shift ? XKeySym.Plus : XKeySym.Equal;
				case VirtualKeys.OemComma:
					return shift ? XKeySym.Less : XKeySym.Comma;
				case VirtualKeys.OemMinus:
					return shift ? XKeySym.Underscore : XKeySym.Minus;
				case VirtualKeys.OemPeriod:
					return shift ? XKeySym.Greater : XKeySym.Period;
				case VirtualKeys.Oem2:
					return shift ? XKeySym.Question : XKeySym.Slash;
				case VirtualKeys.Oem3:
					return shift ? XKeySym.Asciitilde : XKeySym.Grave;
				case VirtualKeys.Oem4:
					return shift ? XKeySym.Braceleft : XKeySym.Bracketleft;
				case VirtualKeys.Oem5:
					return shift ? XKeySym.Bar : XKeySym.Backslash;
				case VirtualKeys.Oem6:
					return shift ? XKeySym.Braceright : XKeySym.Bracketright;
				case VirtualKeys.Oem7:
					return shift ? XKeySym.Quotedbl : XKeySym.Apostrophe;
				case VirtualKeys.Oem8:
					return XKeySym.ISOLevel5Shift;
				case VirtualKeys.Oem102:
					return shift ? XKeySym.Guillemotleft : XKeySym.Guillemotright;
				case VirtualKeys.F1:
				case VirtualKeys.F2:
				case VirtualKeys.F3:
				case VirtualKeys.F4:
				case VirtualKeys.F5:
				case VirtualKeys.F6:
				case VirtualKeys.F7:
				case VirtualKeys.F8:
				case VirtualKeys.F9:
				case VirtualKeys.F10:
				case VirtualKeys.F11:
				case VirtualKeys.F12:
				case VirtualKeys.F13:
				case VirtualKeys.F14:
				case VirtualKeys.F15:
				case VirtualKeys.F16:
				case VirtualKeys.F17:
				case VirtualKeys.F18:
				case VirtualKeys.F19:
				case VirtualKeys.F20:
				case VirtualKeys.F21:
				case VirtualKeys.F22:
				case VirtualKeys.F23:
				case VirtualKeys.F24:
					return XKeySym.F1 + (key - VirtualKeys.F1);
				case VirtualKeys.BrowserBack:
					return XKeySym.Back;
				case VirtualKeys.BrowserForward:
					return XKeySym.Forward;
				case VirtualKeys.BrowserRefresh:
					return XKeySym.Reload;
				case VirtualKeys.BrowserStop:
					return XKeySym.Stop;
				case VirtualKeys.BrowserSearch:
					return XKeySym.Search;
				case VirtualKeys.BrowserFavorites:
					return XKeySym.Favorites;
				case VirtualKeys.BrowserHome:
					return XKeySym.HomePage;
				case VirtualKeys.VolumeMute:
					return XKeySym.AudioMute;
				case VirtualKeys.VolumeDown:
					return XKeySym.AudioLowerVolume;
				case VirtualKeys.VolumeUp:
					return XKeySym.AudioRaiseVolume;
				case VirtualKeys.MediaNextTrack:
					return XKeySym.AudioNext;
				case VirtualKeys.MediaPreviousTrack:
					return XKeySym.AudioPrev;
				case VirtualKeys.MediaStop:
					return XKeySym.AudioStop;
				case VirtualKeys.MediaPlayPause:
					return XKeySym.AudioPlay;
				case VirtualKeys.LaunchMail:
					return XKeySym.Mail;
				case VirtualKeys.LaunchApplication1:
					return XKeySym.LaunchA;
				case VirtualKeys.LaunchApplication2:
					return XKeySym.LaunchB;
				case VirtualKeys.WirelessLan:
					return XKeySym.WLAN;
				case VirtualKeys.Power:
					return XKeySym.PowerOff;
				case VirtualKeys.BrightnessDown:
					return XKeySym.MonBrightnessDown;
				case VirtualKeys.BrightnessUp:
					return XKeySym.MonBrightnessUp;
				case VirtualKeys.KbdBrightnessDown:
					return XKeySym.KbdBrightnessDown;
				case VirtualKeys.KbdBrightnessUp:
					return XKeySym.KbdBrightnessUp;
				default:
					Debug.Print("Unknown virtual key: {0}", key);
					return XKeySym.None;
			}
		}

		/// <summary>
		///  Converts a character into a X KeySym.
		/// </summary>
		/// <param name="c">The character to convert.</param>
		/// <returns>The <see cref="XKeySym" />.</returns>
		public static XKeySym CharToXKeySym(char c)
		{
			switch ((int) c)
			{
				case 0x0020:
					return XKeySym.Space;
				case 0x0021:
					return XKeySym.Exclam;
				case 0x0022:
					return XKeySym.Quotedbl;
				case 0x0023:
					return XKeySym.Numbersign;
				case 0x0024:
					return XKeySym.Dollar;
				case 0x0025:
					return XKeySym.Percent;
				case 0x0026:
					return XKeySym.Ampersand;
				case 0x0027:
					return XKeySym.Apostrophe;
				case 0x0028:
					return XKeySym.Parenleft;
				case 0x0029:
					return XKeySym.Parenright;
				case 0x002A:
					return XKeySym.Asterisk;
				case 0x002B:
					return XKeySym.Plus;
				case 0x002C:
					return XKeySym.Comma;
				case 0x002D:
					return XKeySym.Minus;
				case 0x002E:
					return XKeySym.Period;
				case 0x002F:
					return XKeySym.Slash;
				case 0x0030:
					return XKeySym.D0;
				case 0x0031:
					return XKeySym.D1;
				case 0x0032:
					return XKeySym.D2;
				case 0x0033:
					return XKeySym.D3;
				case 0x0034:
					return XKeySym.D4;
				case 0x0035:
					return XKeySym.D5;
				case 0x0036:
					return XKeySym.D6;
				case 0x0037:
					return XKeySym.D7;
				case 0x0038:
					return XKeySym.D8;
				case 0x0039:
					return XKeySym.D9;
				case 0x003A:
					return XKeySym.Colon;
				case 0x003B:
					return XKeySym.Semicolon;
				case 0x003C:
					return XKeySym.Less;
				case 0x003D:
					return XKeySym.Equal;
				case 0x003E:
					return XKeySym.Greater;
				case 0x003F:
					return XKeySym.Question;
				case 0x0040:
					return XKeySym.At;
				case 0x0041:
					return XKeySym.A;
				case 0x0042:
					return XKeySym.B;
				case 0x0043:
					return XKeySym.C;
				case 0x0044:
					return XKeySym.D;
				case 0x0045:
					return XKeySym.E;
				case 0x0046:
					return XKeySym.F;
				case 0x0047:
					return XKeySym.G;
				case 0x0048:
					return XKeySym.H;
				case 0x0049:
					return XKeySym.I;
				case 0x004A:
					return XKeySym.J;
				case 0x004B:
					return XKeySym.K;
				case 0x004C:
					return XKeySym.L;
				case 0x004D:
					return XKeySym.M;
				case 0x004E:
					return XKeySym.N;
				case 0x004F:
					return XKeySym.O;
				case 0x0050:
					return XKeySym.P;
				case 0x0051:
					return XKeySym.Q;
				case 0x0052:
					return XKeySym.R;
				case 0x0053:
					return XKeySym.S;
				case 0x0054:
					return XKeySym.T;
				case 0x0055:
					return XKeySym.U;
				case 0x0056:
					return XKeySym.V;
				case 0x0057:
					return XKeySym.W;
				case 0x0058:
					return XKeySym.X;
				case 0x0059:
					return XKeySym.Y;
				case 0x005A:
					return XKeySym.Z;
				case 0x005B:
					return XKeySym.Bracketleft;
				case 0x005C:
					return XKeySym.Backslash;
				case 0x005D:
					return XKeySym.Bracketright;
				case 0x005E:
					return XKeySym.Asciicircum;
				case 0x005F:
					return XKeySym.Underscore;
				case 0x0060:
					return XKeySym.Grave;
				case 0x0061:
					return XKeySym.a;
				case 0x0062:
					return XKeySym.b;
				case 0x0063:
					return XKeySym.c;
				case 0x0064:
					return XKeySym.d;
				case 0x0065:
					return XKeySym.e;
				case 0x0066:
					return XKeySym.f;
				case 0x0067:
					return XKeySym.g;
				case 0x0068:
					return XKeySym.h;
				case 0x0069:
					return XKeySym.i;
				case 0x006A:
					return XKeySym.j;
				case 0x006B:
					return XKeySym.k;
				case 0x006C:
					return XKeySym.l;
				case 0x006D:
					return XKeySym.m;
				case 0x006E:
					return XKeySym.n;
				case 0x006F:
					return XKeySym.o;
				case 0x0070:
					return XKeySym.p;
				case 0x0071:
					return XKeySym.q;
				case 0x0072:
					return XKeySym.r;
				case 0x0073:
					return XKeySym.s;
				case 0x0074:
					return XKeySym.t;
				case 0x0075:
					return XKeySym.u;
				case 0x0076:
					return XKeySym.v;
				case 0x0077:
					return XKeySym.w;
				case 0x0078:
					return XKeySym.x;
				case 0x0079:
					return XKeySym.y;
				case 0x007A:
					return XKeySym.z;
				case 0x007B:
					return XKeySym.Braceleft;
				case 0x007C:
					return XKeySym.Bar;
				case 0x007D:
					return XKeySym.Braceright;
				case 0x007E:
					return XKeySym.Asciitilde;
				case 0x00A0:
					return XKeySym.Nobreakspace;
				case 0x00A1:
					return XKeySym.Exclamdown;
				case 0x00A2:
					return XKeySym.Cent;
				case 0x00A3:
					return XKeySym.Sterling;
				case 0x00A4:
					return XKeySym.Currency;
				case 0x00A5:
					return XKeySym.Yen;
				case 0x00A6:
					return XKeySym.Brokenbar;
				case 0x00A7:
					return XKeySym.Section;
				case 0x00A8:
					return XKeySym.Diaeresis;
				case 0x00A9:
					return XKeySym.Copyright;
				case 0x00AA:
					return XKeySym.Ordfeminine;
				case 0x00AB:
					return XKeySym.Guillemotleft;
				case 0x00AC:
					return XKeySym.Notsign;
				case 0x00AD:
					return XKeySym.Hyphen;
				case 0x00AE:
					return XKeySym.Registered;
				case 0x00AF:
					return XKeySym.Macron;
				case 0x00B0:
					return XKeySym.Degree;
				case 0x00B1:
					return XKeySym.Plusminus;
				case 0x00B2:
					return XKeySym.Twosuperior;
				case 0x00B3:
					return XKeySym.Threesuperior;
				case 0x00B4:
					return XKeySym.Acute;
				case 0x00B5:
					return XKeySym.Mu;
				case 0x00B6:
					return XKeySym.Paragraph;
				case 0x00B7:
					return XKeySym.Periodcentered;
				case 0x00B8:
					return XKeySym.Cedilla;
				case 0x00B9:
					return XKeySym.Onesuperior;
				case 0x00BA:
					return XKeySym.Masculine;
				case 0x00BB:
					return XKeySym.Guillemotright;
				case 0x00BC:
					return XKeySym.Onequarter;
				case 0x00BD:
					return XKeySym.Onehalf;
				case 0x00BE:
					return XKeySym.Threequarters;
				case 0x00BF:
					return XKeySym.Questiondown;
				case 0x00C0:
					return XKeySym.Agrave;
				case 0x00C1:
					return XKeySym.Aacute;
				case 0x00C2:
					return XKeySym.Acircumflex;
				case 0x00C3:
					return XKeySym.Atilde;
				case 0x00C4:
					return XKeySym.Adiaeresis;
				case 0x00C5:
					return XKeySym.Aring;
				case 0x00C6:
					return XKeySym.AE;
				case 0x00C7:
					return XKeySym.Ccedilla;
				case 0x00C8:
					return XKeySym.Egrave;
				case 0x00C9:
					return XKeySym.Eacute;
				case 0x00CA:
					return XKeySym.Ecircumflex;
				case 0x00CB:
					return XKeySym.Ediaeresis;
				case 0x00CC:
					return XKeySym.Igrave;
				case 0x00CD:
					return XKeySym.Iacute;
				case 0x00CE:
					return XKeySym.Icircumflex;
				case 0x00CF:
					return XKeySym.Idiaeresis;
				case 0x00D0:
					return XKeySym.ETH;
				case 0x00D1:
					return XKeySym.Ntilde;
				case 0x00D2:
					return XKeySym.Ograve;
				case 0x00D3:
					return XKeySym.Oacute;
				case 0x00D4:
					return XKeySym.Ocircumflex;
				case 0x00D5:
					return XKeySym.Otilde;
				case 0x00D6:
					return XKeySym.Odiaeresis;
				case 0x00D7:
					return XKeySym.Multiply;
				case 0x00D8:
					return XKeySym.Oslash;
				case 0x00D9:
					return XKeySym.Ugrave;
				case 0x00DA:
					return XKeySym.Uacute;
				case 0x00DB:
					return XKeySym.Ucircumflex;
				case 0x00DC:
					return XKeySym.Udiaeresis;
				case 0x00DD:
					return XKeySym.Yacute;
				case 0x00DE:
					return XKeySym.THORN;
				case 0x00DF:
					return XKeySym.ssharp;
				case 0x00E0:
					return XKeySym.agrave;
				case 0x00E1:
					return XKeySym.aacute;
				case 0x00E2:
					return XKeySym.acircumflex;
				case 0x00E3:
					return XKeySym.atilde;
				case 0x00E4:
					return XKeySym.adiaeresis;
				case 0x00E5:
					return XKeySym.aring;
				case 0x00E6:
					return XKeySym.ae;
				case 0x00E7:
					return XKeySym.ccedilla;
				case 0x00E8:
					return XKeySym.egrave;
				case 0x00E9:
					return XKeySym.eacute;
				case 0x00EA:
					return XKeySym.ecircumflex;
				case 0x00EB:
					return XKeySym.ediaeresis;
				case 0x00EC:
					return XKeySym.igrave;
				case 0x00ED:
					return XKeySym.iacute;
				case 0x00EE:
					return XKeySym.icircumflex;
				case 0x00EF:
					return XKeySym.idiaeresis;
				case 0x00F0:
					return XKeySym.eth;
				case 0x00F1:
					return XKeySym.ntilde;
				case 0x00F2:
					return XKeySym.ograve;
				case 0x00F3:
					return XKeySym.oacute;
				case 0x00F4:
					return XKeySym.ocircumflex;
				case 0x00F5:
					return XKeySym.otilde;
				case 0x00F6:
					return XKeySym.odiaeresis;
				case 0x00F7:
					return XKeySym.Division;
				case 0x00F8:
					return XKeySym.oslash;
				case 0x00F9:
					return XKeySym.ugrave;
				case 0x00FA:
					return XKeySym.uacute;
				case 0x00FB:
					return XKeySym.ucircumflex;
				case 0x00FC:
					return XKeySym.udiaeresis;
				case 0x00FD:
					return XKeySym.yacute;
				case 0x00FE:
					return XKeySym.thorn;
				case 0x00FF:
					return XKeySym.ydiaeresis;
				case 0x0104:
					return XKeySym.Aogonek;
				case 0x02D8:
					return XKeySym.Breve;
				case 0x0141:
					return XKeySym.Lstroke;
				case 0x013D:
					return XKeySym.Lcaron;
				case 0x015A:
					return XKeySym.Sacute;
				case 0x0160:
					return XKeySym.Scaron;
				case 0x015E:
					return XKeySym.Scedilla;
				case 0x0164:
					return XKeySym.Tcaron;
				case 0x0179:
					return XKeySym.Zacute;
				case 0x017D:
					return XKeySym.Zcaron;
				case 0x017B:
					return XKeySym.Zabovedot;
				case 0x0105:
					return XKeySym.aogonek;
				case 0x02DB:
					return XKeySym.Ogonek;
				case 0x0142:
					return XKeySym.lstroke;
				case 0x013E:
					return XKeySym.lcaron;
				case 0x015B:
					return XKeySym.sacute;
				case 0x02C7:
					return XKeySym.Caron;
				case 0x0161:
					return XKeySym.scaron;
				case 0x015F:
					return XKeySym.scedilla;
				case 0x0165:
					return XKeySym.tcaron;
				case 0x017A:
					return XKeySym.zacute;
				case 0x02DD:
					return XKeySym.Doubleacute;
				case 0x017E:
					return XKeySym.zcaron;
				case 0x017C:
					return XKeySym.zabovedot;
				case 0x0154:
					return XKeySym.Racute;
				case 0x0102:
					return XKeySym.Abreve;
				case 0x0139:
					return XKeySym.Lacute;
				case 0x0106:
					return XKeySym.Cacute;
				case 0x010C:
					return XKeySym.Ccaron;
				case 0x0118:
					return XKeySym.Eogonek;
				case 0x011A:
					return XKeySym.Ecaron;
				case 0x010E:
					return XKeySym.Dcaron;
				case 0x0110:
					return XKeySym.Dstroke;
				case 0x0143:
					return XKeySym.Nacute;
				case 0x0147:
					return XKeySym.Ncaron;
				case 0x0150:
					return XKeySym.Odoubleacute;
				case 0x0158:
					return XKeySym.Rcaron;
				case 0x016E:
					return XKeySym.Uring;
				case 0x0170:
					return XKeySym.Udoubleacute;
				case 0x0162:
					return XKeySym.Tcedilla;
				case 0x0155:
					return XKeySym.racute;
				case 0x0103:
					return XKeySym.abreve;
				case 0x013A:
					return XKeySym.lacute;
				case 0x0107:
					return XKeySym.cacute;
				case 0x010D:
					return XKeySym.ccaron;
				case 0x0119:
					return XKeySym.eogonek;
				case 0x011B:
					return XKeySym.ecaron;
				case 0x010F:
					return XKeySym.dcaron;
				case 0x0111:
					return XKeySym.dstroke;
				case 0x0144:
					return XKeySym.nacute;
				case 0x0148:
					return XKeySym.ncaron;
				case 0x0151:
					return XKeySym.odoubleacute;
				case 0x0159:
					return XKeySym.rcaron;
				case 0x016F:
					return XKeySym.uring;
				case 0x0171:
					return XKeySym.udoubleacute;
				case 0x0163:
					return XKeySym.tcedilla;
				case 0x02D9:
					return XKeySym.Abovedot;
				case 0x0126:
					return XKeySym.Hstroke;
				case 0x0124:
					return XKeySym.Hcircumflex;
				case 0x0130:
					return XKeySym.Iabovedot;
				case 0x011E:
					return XKeySym.Gbreve;
				case 0x0134:
					return XKeySym.Jcircumflex;
				case 0x0127:
					return XKeySym.hstroke;
				case 0x0125:
					return XKeySym.hcircumflex;
				case 0x0131:
					return XKeySym.idotless;
				case 0x011F:
					return XKeySym.gbreve;
				case 0x0135:
					return XKeySym.jcircumflex;
				case 0x010A:
					return XKeySym.Cabovedot;
				case 0x0108:
					return XKeySym.Ccircumflex;
				case 0x0120:
					return XKeySym.Gabovedot;
				case 0x011C:
					return XKeySym.Gcircumflex;
				case 0x016C:
					return XKeySym.Ubreve;
				case 0x015C:
					return XKeySym.Scircumflex;
				case 0x010B:
					return XKeySym.cabovedot;
				case 0x0109:
					return XKeySym.ccircumflex;
				case 0x0121:
					return XKeySym.gabovedot;
				case 0x011D:
					return XKeySym.gcircumflex;
				case 0x016D:
					return XKeySym.ubreve;
				case 0x015D:
					return XKeySym.scircumflex;
				case 0x0138:
					return XKeySym.kra;
				case 0x0156:
					return XKeySym.Rcedilla;
				case 0x0128:
					return XKeySym.Itilde;
				case 0x013B:
					return XKeySym.Lcedilla;
				case 0x0112:
					return XKeySym.Emacron;
				case 0x0122:
					return XKeySym.Gcedilla;
				case 0x0166:
					return XKeySym.Tslash;
				case 0x0157:
					return XKeySym.rcedilla;
				case 0x0129:
					return XKeySym.itilde;
				case 0x013C:
					return XKeySym.lcedilla;
				case 0x0113:
					return XKeySym.emacron;
				case 0x0123:
					return XKeySym.gcedilla;
				case 0x0167:
					return XKeySym.tslash;
				case 0x014A:
					return XKeySym.ENG;
				case 0x014B:
					return XKeySym.eng;
				case 0x0100:
					return XKeySym.Amacron;
				case 0x012E:
					return XKeySym.Iogonek;
				case 0x0116:
					return XKeySym.Eabovedot;
				case 0x012A:
					return XKeySym.Imacron;
				case 0x0145:
					return XKeySym.Ncedilla;
				case 0x014C:
					return XKeySym.Omacron;
				case 0x0136:
					return XKeySym.Kcedilla;
				case 0x0172:
					return XKeySym.Uogonek;
				case 0x0168:
					return XKeySym.Utilde;
				case 0x016A:
					return XKeySym.Umacron;
				case 0x0101:
					return XKeySym.amacron;
				case 0x012F:
					return XKeySym.iogonek;
				case 0x0117:
					return XKeySym.eabovedot;
				case 0x012B:
					return XKeySym.imacron;
				case 0x0146:
					return XKeySym.ncedilla;
				case 0x014D:
					return XKeySym.omacron;
				case 0x0137:
					return XKeySym.kcedilla;
				case 0x0173:
					return XKeySym.uogonek;
				case 0x0169:
					return XKeySym.utilde;
				case 0x016B:
					return XKeySym.umacron;
				case 0x0174:
					return XKeySym.Wcircumflex;
				case 0x0175:
					return XKeySym.wcircumflex;
				case 0x0176:
					return XKeySym.Ycircumflex;
				case 0x0177:
					return XKeySym.ycircumflex;
				case 0x1E02:
					return XKeySym.Babovedot;
				case 0x1E03:
					return XKeySym.babovedot;
				case 0x1E0A:
					return XKeySym.Dabovedot;
				case 0x1E0B:
					return XKeySym.dabovedot;
				case 0x1E1E:
					return XKeySym.Fabovedot;
				case 0x1E1F:
					return XKeySym.fabovedot;
				case 0x1E40:
					return XKeySym.Mabovedot;
				case 0x1E41:
					return XKeySym.mabovedot;
				case 0x1E56:
					return XKeySym.Pabovedot;
				case 0x1E57:
					return XKeySym.pabovedot;
				case 0x1E60:
					return XKeySym.Sabovedot;
				case 0x1E61:
					return XKeySym.sabovedot;
				case 0x1E6A:
					return XKeySym.Tabovedot;
				case 0x1E6B:
					return XKeySym.tabovedot;
				case 0x1E80:
					return XKeySym.Wgrave;
				case 0x1E81:
					return XKeySym.wgrave;
				case 0x1E82:
					return XKeySym.Wacute;
				case 0x1E83:
					return XKeySym.wacute;
				case 0x1E84:
					return XKeySym.Wdiaeresis;
				case 0x1E85:
					return XKeySym.wdiaeresis;
				case 0x1EF2:
					return XKeySym.Ygrave;
				case 0x1EF3:
					return XKeySym.ygrave;
				case 0x0152:
					return XKeySym.OE;
				case 0x0153:
					return XKeySym.oe;
				case 0x0178:
					return XKeySym.Ydiaeresis;
				case 0x203E:
					return XKeySym.Overline;
				case 0x3002:
					return XKeySym.KanaFullstop;
				case 0x300C:
					return XKeySym.KanaOpeningbracket;
				case 0x300D:
					return XKeySym.KanaClosingbracket;
				case 0x3001:
					return XKeySym.KanaComma;
				case 0x30FB:
					return XKeySym.KanaConjunctive;
				case 0x30F2:
					return XKeySym.KanaWO;
				case 0x30A1:
					return XKeySym.kanaA;
				case 0x30A3:
					return XKeySym.kanaI;
				case 0x30A5:
					return XKeySym.kanaU;
				case 0x30A7:
					return XKeySym.kanaE;
				case 0x30A9:
					return XKeySym.kanaO;
				case 0x30E3:
					return XKeySym.kanaYa;
				case 0x30E5:
					return XKeySym.kanaYu;
				case 0x30E7:
					return XKeySym.kanaYo;
				case 0x30C3:
					return XKeySym.kanaTsu;
				case 0x30FC:
					return XKeySym.Prolongedsound;
				case 0x30A2:
					return XKeySym.KanaA;
				case 0x30A4:
					return XKeySym.KanaI;
				case 0x30A6:
					return XKeySym.KanaU;
				case 0x30A8:
					return XKeySym.KanaE;
				case 0x30AA:
					return XKeySym.KanaO;
				case 0x30AB:
					return XKeySym.KanaKA;
				case 0x30AD:
					return XKeySym.KanaKI;
				case 0x30AF:
					return XKeySym.KanaKU;
				case 0x30B1:
					return XKeySym.KanaKE;
				case 0x30B3:
					return XKeySym.KanaKO;
				case 0x30B5:
					return XKeySym.KanaSA;
				case 0x30B7:
					return XKeySym.KanaSHI;
				case 0x30B9:
					return XKeySym.KanaSU;
				case 0x30BB:
					return XKeySym.KanaSE;
				case 0x30BD:
					return XKeySym.KanaSO;
				case 0x30BF:
					return XKeySym.KanaTA;
				case 0x30C1:
					return XKeySym.KanaCHI;
				case 0x30C4:
					return XKeySym.KanaTSU;
				case 0x30C6:
					return XKeySym.KanaTE;
				case 0x30C8:
					return XKeySym.KanaTO;
				case 0x30CA:
					return XKeySym.KanaNA;
				case 0x30CB:
					return XKeySym.KanaNI;
				case 0x30CC:
					return XKeySym.KanaNU;
				case 0x30CD:
					return XKeySym.KanaNE;
				case 0x30CE:
					return XKeySym.KanaNO;
				case 0x30CF:
					return XKeySym.KanaHA;
				case 0x30D2:
					return XKeySym.KanaHI;
				case 0x30D5:
					return XKeySym.KanaFU;
				case 0x30D8:
					return XKeySym.KanaHE;
				case 0x30DB:
					return XKeySym.KanaHO;
				case 0x30DE:
					return XKeySym.KanaMA;
				case 0x30DF:
					return XKeySym.KanaMI;
				case 0x30E0:
					return XKeySym.KanaMU;
				case 0x30E1:
					return XKeySym.KanaME;
				case 0x30E2:
					return XKeySym.KanaMO;
				case 0x30E4:
					return XKeySym.KanaYA;
				case 0x30E6:
					return XKeySym.KanaYU;
				case 0x30E8:
					return XKeySym.KanaYO;
				case 0x30E9:
					return XKeySym.KanaRA;
				case 0x30EA:
					return XKeySym.KanaRI;
				case 0x30EB:
					return XKeySym.KanaRU;
				case 0x30EC:
					return XKeySym.KanaRE;
				case 0x30ED:
					return XKeySym.KanaRO;
				case 0x30EF:
					return XKeySym.KanaWA;
				case 0x30F3:
					return XKeySym.KanaN;
				case 0x309B:
					return XKeySym.Voicedsound;
				case 0x309C:
					return XKeySym.Semivoicedsound;
				case 0x06F0:
					return XKeySym.Farsi0;
				case 0x06F1:
					return XKeySym.Farsi1;
				case 0x06F2:
					return XKeySym.Farsi2;
				case 0x06F3:
					return XKeySym.Farsi3;
				case 0x06F4:
					return XKeySym.Farsi4;
				case 0x06F5:
					return XKeySym.Farsi5;
				case 0x06F6:
					return XKeySym.Farsi6;
				case 0x06F7:
					return XKeySym.Farsi7;
				case 0x06F8:
					return XKeySym.Farsi8;
				case 0x06F9:
					return XKeySym.Farsi9;
				case 0x066A:
					return XKeySym.ArabicPercent;
				case 0x0670:
					return XKeySym.ArabicSuperscriptAlef;
				case 0x0679:
					return XKeySym.ArabicTteh;
				case 0x067E:
					return XKeySym.ArabicPeh;
				case 0x0686:
					return XKeySym.ArabicTcheh;
				case 0x0688:
					return XKeySym.ArabicDdal;
				case 0x0691:
					return XKeySym.ArabicRreh;
				case 0x060C:
					return XKeySym.ArabicComma;
				case 0x06D4:
					return XKeySym.ArabicFullstop;
				case 0x0660:
					return XKeySym.Arabic0;
				case 0x0661:
					return XKeySym.Arabic1;
				case 0x0662:
					return XKeySym.Arabic2;
				case 0x0663:
					return XKeySym.Arabic3;
				case 0x0664:
					return XKeySym.Arabic4;
				case 0x0665:
					return XKeySym.Arabic5;
				case 0x0666:
					return XKeySym.Arabic6;
				case 0x0667:
					return XKeySym.Arabic7;
				case 0x0668:
					return XKeySym.Arabic8;
				case 0x0669:
					return XKeySym.Arabic9;
				case 0x061B:
					return XKeySym.ArabicSemicolon;
				case 0x061F:
					return XKeySym.ArabicQuestionMark;
				case 0x0621:
					return XKeySym.ArabicHamza;
				case 0x0622:
					return XKeySym.ArabicMaddaonalef;
				case 0x0623:
					return XKeySym.ArabicHamzaonalef;
				case 0x0624:
					return XKeySym.ArabicHamzaonwaw;
				case 0x0625:
					return XKeySym.ArabicHamzaunderalef;
				case 0x0626:
					return XKeySym.ArabicHamzaonyeh;
				case 0x0627:
					return XKeySym.ArabicAlef;
				case 0x0628:
					return XKeySym.ArabicBeh;
				case 0x0629:
					return XKeySym.ArabicTehmarbuta;
				case 0x062A:
					return XKeySym.ArabicTeh;
				case 0x062B:
					return XKeySym.ArabicTheh;
				case 0x062C:
					return XKeySym.ArabicJeem;
				case 0x062D:
					return XKeySym.ArabicHah;
				case 0x062E:
					return XKeySym.ArabicKhah;
				case 0x062F:
					return XKeySym.ArabicDal;
				case 0x0630:
					return XKeySym.ArabicThal;
				case 0x0631:
					return XKeySym.ArabicRa;
				case 0x0632:
					return XKeySym.ArabicZain;
				case 0x0633:
					return XKeySym.ArabicSeen;
				case 0x0634:
					return XKeySym.ArabicSheen;
				case 0x0635:
					return XKeySym.ArabicSad;
				case 0x0636:
					return XKeySym.ArabicDad;
				case 0x0637:
					return XKeySym.ArabicTah;
				case 0x0638:
					return XKeySym.ArabicZah;
				case 0x0639:
					return XKeySym.ArabicAin;
				case 0x063A:
					return XKeySym.ArabicGhain;
				case 0x0640:
					return XKeySym.ArabicTatweel;
				case 0x0641:
					return XKeySym.ArabicFeh;
				case 0x0642:
					return XKeySym.ArabicQaf;
				case 0x0643:
					return XKeySym.ArabicKaf;
				case 0x0644:
					return XKeySym.ArabicLam;
				case 0x0645:
					return XKeySym.ArabicMeem;
				case 0x0646:
					return XKeySym.ArabicNoon;
				case 0x0647:
					return XKeySym.ArabicHa;
				case 0x0648:
					return XKeySym.ArabicWaw;
				case 0x0649:
					return XKeySym.ArabicAlefmaksura;
				case 0x064A:
					return XKeySym.ArabicYeh;
				case 0x064B:
					return XKeySym.ArabicFathatan;
				case 0x064C:
					return XKeySym.ArabicDammatan;
				case 0x064D:
					return XKeySym.ArabicKasratan;
				case 0x064E:
					return XKeySym.ArabicFatha;
				case 0x064F:
					return XKeySym.ArabicDamma;
				case 0x0650:
					return XKeySym.ArabicKasra;
				case 0x0651:
					return XKeySym.ArabicShadda;
				case 0x0652:
					return XKeySym.ArabicSukun;
				case 0x0653:
					return XKeySym.ArabicMaddaAbove;
				case 0x0654:
					return XKeySym.ArabicHamzaAbove;
				case 0x0655:
					return XKeySym.ArabicHamzaBelow;
				case 0x0698:
					return XKeySym.ArabicJeh;
				case 0x06A4:
					return XKeySym.ArabicVeh;
				case 0x06A9:
					return XKeySym.ArabicKeheh;
				case 0x06AF:
					return XKeySym.ArabicGaf;
				case 0x06BA:
					return XKeySym.ArabicNoonGhunna;
				case 0x06BE:
					return XKeySym.ArabicHehDoachashmee;
				case 0x06CC:
					return XKeySym.FarsiYeh;
				case 0x06D2:
					return XKeySym.ArabicYehBaree;
				case 0x06C1:
					return XKeySym.ArabicHehGoal;
				case 0x0492:
					return XKeySym.CyrillicGHEBar;
				case 0x0493:
					return XKeySym.cyrillicGheBar;
				case 0x0496:
					return XKeySym.CyrillicZHEDescender;
				case 0x0497:
					return XKeySym.cyrillicZheDescender;
				case 0x049A:
					return XKeySym.CyrillicKADescender;
				case 0x049B:
					return XKeySym.cyrillicKaDescender;
				case 0x049C:
					return XKeySym.CyrillicKAVertstroke;
				case 0x049D:
					return XKeySym.cyrillicKaVertstroke;
				case 0x04A2:
					return XKeySym.CyrillicENDescender;
				case 0x04A3:
					return XKeySym.cyrillicEnDescender;
				case 0x04AE:
					return XKeySym.CyrillicUStraight;
				case 0x04AF:
					return XKeySym.cyrillicUStraight;
				case 0x04B0:
					return XKeySym.CyrillicUStraightBar;
				case 0x04B1:
					return XKeySym.cyrillicUStraightBar;
				case 0x04B2:
					return XKeySym.CyrillicHADescender;
				case 0x04B3:
					return XKeySym.cyrillicHaDescender;
				case 0x04B6:
					return XKeySym.CyrillicCHEDescender;
				case 0x04B7:
					return XKeySym.cyrillicCheDescender;
				case 0x04B8:
					return XKeySym.CyrillicCHEVertstroke;
				case 0x04B9:
					return XKeySym.cyrillicCheVertstroke;
				case 0x04BA:
					return XKeySym.CyrillicSHHA;
				case 0x04BB:
					return XKeySym.cyrillicShha;
				case 0x04D8:
					return XKeySym.CyrillicSCHWA;
				case 0x04D9:
					return XKeySym.cyrillicSchwa;
				case 0x04E2:
					return XKeySym.CyrillicIMacron;
				case 0x04E3:
					return XKeySym.cyrillicIMacron;
				case 0x04E8:
					return XKeySym.CyrillicOBar;
				case 0x04E9:
					return XKeySym.cyrillicOBar;
				case 0x04EE:
					return XKeySym.CyrillicUMacron;
				case 0x04EF:
					return XKeySym.cyrillicUMacron;
				case 0x0452:
					return XKeySym.serbianDje;
				case 0x0453:
					return XKeySym.macedoniaGje;
				case 0x0451:
					return XKeySym.cyrillicIo;
				case 0x0454:
					return XKeySym.ukrainianIe;
				case 0x0455:
					return XKeySym.macedoniaDse;
				case 0x0456:
					return XKeySym.ukrainianI;
				case 0x0457:
					return XKeySym.ukrainianYi;
				case 0x0458:
					return XKeySym.cyrillicJe;
				case 0x0459:
					return XKeySym.cyrillicLje;
				case 0x045A:
					return XKeySym.cyrillicNje;
				case 0x045B:
					return XKeySym.serbianTshe;
				case 0x045C:
					return XKeySym.macedoniaKje;
				case 0x0491:
					return XKeySym.ukrainianGheWithUpturn;
				case 0x045E:
					return XKeySym.byelorussianShortu;
				case 0x045F:
					return XKeySym.cyrillicDzhe;
				case 0x2116:
					return XKeySym.Numerosign;
				case 0x0402:
					return XKeySym.SerbianDJE;
				case 0x0403:
					return XKeySym.MacedoniaGJE;
				case 0x0401:
					return XKeySym.CyrillicIO;
				case 0x0404:
					return XKeySym.UkrainianIE;
				case 0x0405:
					return XKeySym.MacedoniaDSE;
				case 0x0406:
					return XKeySym.UkrainianI;
				case 0x0407:
					return XKeySym.UkrainianYI;
				case 0x0408:
					return XKeySym.CyrillicJE;
				case 0x0409:
					return XKeySym.CyrillicLJE;
				case 0x040A:
					return XKeySym.CyrillicNJE;
				case 0x040B:
					return XKeySym.SerbianTSHE;
				case 0x040C:
					return XKeySym.MacedoniaKJE;
				case 0x0490:
					return XKeySym.UkrainianGHEWITHUPTURN;
				case 0x040E:
					return XKeySym.ByelorussianSHORTU;
				case 0x040F:
					return XKeySym.CyrillicDZHE;
				case 0x044E:
					return XKeySym.cyrillicYu;
				case 0x0430:
					return XKeySym.cyrillicA;
				case 0x0431:
					return XKeySym.cyrillicBe;
				case 0x0446:
					return XKeySym.cyrillicTse;
				case 0x0434:
					return XKeySym.cyrillicDe;
				case 0x0435:
					return XKeySym.cyrillicIe;
				case 0x0444:
					return XKeySym.cyrillicEf;
				case 0x0433:
					return XKeySym.cyrillicGhe;
				case 0x0445:
					return XKeySym.cyrillicHa;
				case 0x0438:
					return XKeySym.cyrillicI;
				case 0x0439:
					return XKeySym.cyrillicShorti;
				case 0x043A:
					return XKeySym.cyrillicKa;
				case 0x043B:
					return XKeySym.cyrillicEl;
				case 0x043C:
					return XKeySym.cyrillicEm;
				case 0x043D:
					return XKeySym.cyrillicEn;
				case 0x043E:
					return XKeySym.cyrillicO;
				case 0x043F:
					return XKeySym.cyrillicPe;
				case 0x044F:
					return XKeySym.cyrillicYa;
				case 0x0440:
					return XKeySym.cyrillicEr;
				case 0x0441:
					return XKeySym.cyrillicEs;
				case 0x0442:
					return XKeySym.cyrillicTe;
				case 0x0443:
					return XKeySym.cyrillicU;
				case 0x0436:
					return XKeySym.cyrillicZhe;
				case 0x0432:
					return XKeySym.cyrillicVe;
				case 0x044C:
					return XKeySym.cyrillicSoftsign;
				case 0x044B:
					return XKeySym.cyrillicYeru;
				case 0x0437:
					return XKeySym.cyrillicZe;
				case 0x0448:
					return XKeySym.cyrillicSha;
				case 0x044D:
					return XKeySym.cyrillicE;
				case 0x0449:
					return XKeySym.cyrillicShcha;
				case 0x0447:
					return XKeySym.cyrillicChe;
				case 0x044A:
					return XKeySym.cyrillicHardsign;
				case 0x042E:
					return XKeySym.CyrillicYU;
				case 0x0410:
					return XKeySym.CyrillicA;
				case 0x0411:
					return XKeySym.CyrillicBE;
				case 0x0426:
					return XKeySym.CyrillicTSE;
				case 0x0414:
					return XKeySym.CyrillicDE;
				case 0x0415:
					return XKeySym.CyrillicIE;
				case 0x0424:
					return XKeySym.CyrillicEF;
				case 0x0413:
					return XKeySym.CyrillicGHE;
				case 0x0425:
					return XKeySym.CyrillicHA;
				case 0x0418:
					return XKeySym.CyrillicI;
				case 0x0419:
					return XKeySym.CyrillicSHORTI;
				case 0x041A:
					return XKeySym.CyrillicKA;
				case 0x041B:
					return XKeySym.CyrillicEL;
				case 0x041C:
					return XKeySym.CyrillicEM;
				case 0x041D:
					return XKeySym.CyrillicEN;
				case 0x041E:
					return XKeySym.CyrillicO;
				case 0x041F:
					return XKeySym.CyrillicPE;
				case 0x042F:
					return XKeySym.CyrillicYA;
				case 0x0420:
					return XKeySym.CyrillicER;
				case 0x0421:
					return XKeySym.CyrillicES;
				case 0x0422:
					return XKeySym.CyrillicTE;
				case 0x0423:
					return XKeySym.CyrillicU;
				case 0x0416:
					return XKeySym.CyrillicZHE;
				case 0x0412:
					return XKeySym.CyrillicVE;
				case 0x042C:
					return XKeySym.CyrillicSOFTSIGN;
				case 0x042B:
					return XKeySym.CyrillicYERU;
				case 0x0417:
					return XKeySym.CyrillicZE;
				case 0x0428:
					return XKeySym.CyrillicSHA;
				case 0x042D:
					return XKeySym.CyrillicE;
				case 0x0429:
					return XKeySym.CyrillicSHCHA;
				case 0x0427:
					return XKeySym.CyrillicCHE;
				case 0x042A:
					return XKeySym.CyrillicHARDSIGN;
				case 0x0386:
					return XKeySym.GreekALPHAaccent;
				case 0x0388:
					return XKeySym.GreekEPSILONaccent;
				case 0x0389:
					return XKeySym.GreekETAaccent;
				case 0x038A:
					return XKeySym.GreekIOTAaccent;
				case 0x03AA:
					return XKeySym.GreekIOTAdieresis;
				case 0x038C:
					return XKeySym.GreekOMICRONaccent;
				case 0x038E:
					return XKeySym.GreekUPSILONaccent;
				case 0x03AB:
					return XKeySym.GreekUPSILONdieresis;
				case 0x038F:
					return XKeySym.GreekOMEGAaccent;
				case 0x0385:
					return XKeySym.GreekAccentdieresis;
				case 0x2015:
					return XKeySym.GreekHorizbar;
				case 0x03AC:
					return XKeySym.greekAlphaaccent;
				case 0x03AD:
					return XKeySym.greekEpsilonaccent;
				case 0x03AE:
					return XKeySym.greekEtaaccent;
				case 0x03AF:
					return XKeySym.greekIotaaccent;
				case 0x03CA:
					return XKeySym.greekIotadieresis;
				case 0x0390:
					return XKeySym.greekIotaaccentdieresis;
				case 0x03CC:
					return XKeySym.greekOmicronaccent;
				case 0x03CD:
					return XKeySym.greekUpsilonaccent;
				case 0x03CB:
					return XKeySym.greekUpsilondieresis;
				case 0x03B0:
					return XKeySym.greekUpsilonaccentdieresis;
				case 0x03CE:
					return XKeySym.greekOmegaaccent;
				case 0x0391:
					return XKeySym.GreekALPHA;
				case 0x0392:
					return XKeySym.GreekBETA;
				case 0x0393:
					return XKeySym.GreekGAMMA;
				case 0x0394:
					return XKeySym.GreekDELTA;
				case 0x0395:
					return XKeySym.GreekEPSILON;
				case 0x0396:
					return XKeySym.GreekZETA;
				case 0x0397:
					return XKeySym.GreekETA;
				case 0x0398:
					return XKeySym.GreekTHETA;
				case 0x0399:
					return XKeySym.GreekIOTA;
				case 0x039A:
					return XKeySym.GreekKAPPA;
				case 0x039B:
					return XKeySym.GreekLAMDA;
				case 0x039C:
					return XKeySym.GreekMU;
				case 0x039D:
					return XKeySym.GreekNU;
				case 0x039E:
					return XKeySym.GreekXI;
				case 0x039F:
					return XKeySym.GreekOMICRON;
				case 0x03A0:
					return XKeySym.GreekPI;
				case 0x03A1:
					return XKeySym.GreekRHO;
				case 0x03A3:
					return XKeySym.GreekSIGMA;
				case 0x03A4:
					return XKeySym.GreekTAU;
				case 0x03A5:
					return XKeySym.GreekUPSILON;
				case 0x03A6:
					return XKeySym.GreekPHI;
				case 0x03A7:
					return XKeySym.GreekCHI;
				case 0x03A8:
					return XKeySym.GreekPSI;
				case 0x03A9:
					return XKeySym.GreekOMEGA;
				case 0x03B1:
					return XKeySym.greekAlpha;
				case 0x03B2:
					return XKeySym.greekBeta;
				case 0x03B3:
					return XKeySym.greekGamma;
				case 0x03B4:
					return XKeySym.greekDelta;
				case 0x03B5:
					return XKeySym.greekEpsilon;
				case 0x03B6:
					return XKeySym.greekZeta;
				case 0x03B7:
					return XKeySym.greekEta;
				case 0x03B8:
					return XKeySym.greekTheta;
				case 0x03B9:
					return XKeySym.greekIota;
				case 0x03BA:
					return XKeySym.greekKappa;
				case 0x03BB:
					return XKeySym.greekLamda;
				case 0x03BC:
					return XKeySym.greekMu;
				case 0x03BD:
					return XKeySym.greekNu;
				case 0x03BE:
					return XKeySym.greekXi;
				case 0x03BF:
					return XKeySym.greekOmicron;
				case 0x03C0:
					return XKeySym.greekPi;
				case 0x03C1:
					return XKeySym.greekRho;
				case 0x03C3:
					return XKeySym.greekSigma;
				case 0x03C2:
					return XKeySym.greekFinalsmallsigma;
				case 0x03C4:
					return XKeySym.greekTau;
				case 0x03C5:
					return XKeySym.greekUpsilon;
				case 0x03C6:
					return XKeySym.greekPhi;
				case 0x03C7:
					return XKeySym.greekChi;
				case 0x03C8:
					return XKeySym.greekPsi;
				case 0x03C9:
					return XKeySym.greekOmega;
				case 0x23B7:
					return XKeySym.Leftradical;
				case 0x2320:
					return XKeySym.Topintegral;
				case 0x2321:
					return XKeySym.Botintegral;
				case 0x23A1:
					return XKeySym.Topleftsqbracket;
				case 0x23A3:
					return XKeySym.botleftsqbracket;
				case 0x23A4:
					return XKeySym.Toprightsqbracket;
				case 0x23A6:
					return XKeySym.botrightsqbracket;
				case 0x239B:
					return XKeySym.Topleftparens;
				case 0x239D:
					return XKeySym.botleftparens;
				case 0x239E:
					return XKeySym.Toprightparens;
				case 0x23A0:
					return XKeySym.botrightparens;
				case 0x23A8:
					return XKeySym.Leftmiddlecurlybrace;
				case 0x23AC:
					return XKeySym.Rightmiddlecurlybrace;
				case 0x2264:
					return XKeySym.Lessthanequal;
				case 0x2260:
					return XKeySym.Notequal;
				case 0x2265:
					return XKeySym.Greaterthanequal;
				case 0x222B:
					return XKeySym.Integral;
				case 0x2234:
					return XKeySym.Therefore;
				case 0x221D:
					return XKeySym.Variation;
				case 0x221E:
					return XKeySym.Infinity;
				case 0x2207:
					return XKeySym.Nabla;
				case 0x223C:
					return XKeySym.Approximate;
				case 0x2243:
					return XKeySym.Similarequal;
				case 0x21D4:
					return XKeySym.Ifonlyif;
				case 0x21D2:
					return XKeySym.Implies;
				case 0x2261:
					return XKeySym.Identical;
				case 0x2282:
					return XKeySym.Includedin;
				case 0x2283:
					return XKeySym.Includes;
				case 0x2229:
					return XKeySym.Intersection;
				case 0x222A:
					return XKeySym.Union;
				case 0x2227:
					return XKeySym.Logicaland;
				case 0x2228:
					return XKeySym.Logicalor;
				case 0x2202:
					return XKeySym.Partialderivative;
				case 0x0192:
					return XKeySym.function;
				case 0x2190:
					return XKeySym.Leftarrow;
				case 0x2191:
					return XKeySym.Uparrow;
				case 0x2192:
					return XKeySym.Rightarrow;
				case 0x2193:
					return XKeySym.Downarrow;
				case 0x25C6:
					return XKeySym.Soliddiamond;
				case 0x2592:
					return XKeySym.Checkerboard;
				case 0x2409:
					return XKeySym.Ht;
				case 0x240C:
					return XKeySym.Ff;
				case 0x240D:
					return XKeySym.Cr;
				case 0x240A:
					return XKeySym.Lf;
				case 0x2424:
					return XKeySym.Nl;
				case 0x240B:
					return XKeySym.Vt;
				case 0x2518:
					return XKeySym.Lowrightcorner;
				case 0x2510:
					return XKeySym.Uprightcorner;
				case 0x250C:
					return XKeySym.Upleftcorner;
				case 0x2514:
					return XKeySym.Lowleftcorner;
				case 0x253C:
					return XKeySym.Crossinglines;
				case 0x23BA:
					return XKeySym.Horizlinescan1;
				case 0x23BB:
					return XKeySym.Horizlinescan3;
				case 0x2500:
					return XKeySym.Horizlinescan5;
				case 0x23BC:
					return XKeySym.Horizlinescan7;
				case 0x23BD:
					return XKeySym.Horizlinescan9;
				case 0x251C:
					return XKeySym.Leftt;
				case 0x2524:
					return XKeySym.Rightt;
				case 0x2534:
					return XKeySym.Bott;
				case 0x252C:
					return XKeySym.Topt;
				case 0x2502:
					return XKeySym.Vertbar;
				case 0x2003:
					return XKeySym.Emspace;
				case 0x2002:
					return XKeySym.Enspace;
				case 0x2004:
					return XKeySym.Em3space;
				case 0x2005:
					return XKeySym.Em4space;
				case 0x2007:
					return XKeySym.Digitspace;
				case 0x2008:
					return XKeySym.Punctspace;
				case 0x2009:
					return XKeySym.Thinspace;
				case 0x200A:
					return XKeySym.Hairspace;
				case 0x2014:
					return XKeySym.Emdash;
				case 0x2013:
					return XKeySym.Endash;
				case 0x2026:
					return XKeySym.Ellipsis;
				case 0x2025:
					return XKeySym.Doubbaselinedot;
				case 0x2153:
					return XKeySym.Onethird;
				case 0x2154:
					return XKeySym.Twothirds;
				case 0x2155:
					return XKeySym.Onefifth;
				case 0x2156:
					return XKeySym.Twofifths;
				case 0x2157:
					return XKeySym.Threefifths;
				case 0x2158:
					return XKeySym.Fourfifths;
				case 0x2159:
					return XKeySym.Onesixth;
				case 0x215A:
					return XKeySym.Fivesixths;
				case 0x2105:
					return XKeySym.Careof;
				case 0x2012:
					return XKeySym.Figdash;
				case 0x215B:
					return XKeySym.Oneeighth;
				case 0x215C:
					return XKeySym.Threeeighths;
				case 0x215D:
					return XKeySym.Fiveeighths;
				case 0x215E:
					return XKeySym.Seveneighths;
				case 0x2122:
					return XKeySym.Trademark;
				case 0x2018:
					return XKeySym.Leftsinglequotemark;
				case 0x2019:
					return XKeySym.Rightsinglequotemark;
				case 0x201C:
					return XKeySym.Leftdoublequotemark;
				case 0x201D:
					return XKeySym.Rightdoublequotemark;
				case 0x211E:
					return XKeySym.Prescription;
				case 0x2030:
					return XKeySym.Permille;
				case 0x2032:
					return XKeySym.Minutes;
				case 0x2033:
					return XKeySym.Seconds;
				case 0x271D:
					return XKeySym.Latincross;
				case 0x2663:
					return XKeySym.Club;
				case 0x2666:
					return XKeySym.Diamond;
				case 0x2665:
					return XKeySym.Heart;
				case 0x2720:
					return XKeySym.Maltesecross;
				case 0x2020:
					return XKeySym.Dagger;
				case 0x2021:
					return XKeySym.Doubledagger;
				case 0x2713:
					return XKeySym.Checkmark;
				case 0x2717:
					return XKeySym.Ballotcross;
				case 0x266F:
					return XKeySym.Musicalsharp;
				case 0x266D:
					return XKeySym.Musicalflat;
				case 0x2642:
					return XKeySym.Malesymbol;
				case 0x2640:
					return XKeySym.Femalesymbol;
				case 0x260E:
					return XKeySym.Telephone;
				case 0x2315:
					return XKeySym.Telephonerecorder;
				case 0x2117:
					return XKeySym.Phonographcopyright;
				case 0x2038:
					return XKeySym.Caret;
				case 0x201A:
					return XKeySym.Singlelowquotemark;
				case 0x201E:
					return XKeySym.Doublelowquotemark;
				case 0x22A4:
					return XKeySym.Downtack;
				case 0x230A:
					return XKeySym.Downstile;
				case 0x2218:
					return XKeySym.Jot;
				case 0x2395:
					return XKeySym.Quad;
				case 0x22A5:
					return XKeySym.Uptack;
				case 0x25CB:
					return XKeySym.Circle;
				case 0x2308:
					return XKeySym.Upstile;
				case 0x22A3:
					return XKeySym.Lefttack;
				case 0x22A2:
					return XKeySym.Righttack;
				case 0x2017:
					return XKeySym.HebrewDoublelowline;
				case 0x05D0:
					return XKeySym.HebrewAleph;
				case 0x05D1:
					return XKeySym.HebrewBet;
				case 0x05D2:
					return XKeySym.HebrewGimel;
				case 0x05D3:
					return XKeySym.HebrewDalet;
				case 0x05D4:
					return XKeySym.HebrewHe;
				case 0x05D5:
					return XKeySym.HebrewWaw;
				case 0x05D6:
					return XKeySym.HebrewZain;
				case 0x05D7:
					return XKeySym.HebrewChet;
				case 0x05D8:
					return XKeySym.HebrewTet;
				case 0x05D9:
					return XKeySym.HebrewYod;
				case 0x05DA:
					return XKeySym.HebrewFinalkaph;
				case 0x05DB:
					return XKeySym.HebrewKaph;
				case 0x05DC:
					return XKeySym.HebrewLamed;
				case 0x05DD:
					return XKeySym.HebrewFinalmem;
				case 0x05DE:
					return XKeySym.HebrewMem;
				case 0x05DF:
					return XKeySym.HebrewFinalnun;
				case 0x05E0:
					return XKeySym.HebrewNun;
				case 0x05E1:
					return XKeySym.HebrewSamech;
				case 0x05E2:
					return XKeySym.HebrewAyin;
				case 0x05E3:
					return XKeySym.HebrewFinalpe;
				case 0x05E4:
					return XKeySym.HebrewPe;
				case 0x05E5:
					return XKeySym.HebrewFinalzade;
				case 0x05E6:
					return XKeySym.HebrewZade;
				case 0x05E7:
					return XKeySym.HebrewQoph;
				case 0x05E8:
					return XKeySym.HebrewResh;
				case 0x05E9:
					return XKeySym.HebrewShin;
				case 0x05EA:
					return XKeySym.HebrewTaw;
				case 0x0E01:
					return XKeySym.ThaiKokai;
				case 0x0E02:
					return XKeySym.ThaiKhokhai;
				case 0x0E03:
					return XKeySym.ThaiKhokhuat;
				case 0x0E04:
					return XKeySym.ThaiKhokhwai;
				case 0x0E05:
					return XKeySym.ThaiKhokhon;
				case 0x0E06:
					return XKeySym.ThaiKhorakhang;
				case 0x0E07:
					return XKeySym.ThaiNgongu;
				case 0x0E08:
					return XKeySym.ThaiChochan;
				case 0x0E09:
					return XKeySym.ThaiChoching;
				case 0x0E0A:
					return XKeySym.ThaiChochang;
				case 0x0E0B:
					return XKeySym.ThaiSoso;
				case 0x0E0C:
					return XKeySym.ThaiChochoe;
				case 0x0E0D:
					return XKeySym.ThaiYoying;
				case 0x0E0E:
					return XKeySym.ThaiDochada;
				case 0x0E0F:
					return XKeySym.ThaiTopatak;
				case 0x0E10:
					return XKeySym.ThaiThothan;
				case 0x0E11:
					return XKeySym.ThaiThonangmontho;
				case 0x0E12:
					return XKeySym.ThaiThophuthao;
				case 0x0E13:
					return XKeySym.ThaiNonen;
				case 0x0E14:
					return XKeySym.ThaiDodek;
				case 0x0E15:
					return XKeySym.ThaiTotao;
				case 0x0E16:
					return XKeySym.ThaiThothung;
				case 0x0E17:
					return XKeySym.ThaiThothahan;
				case 0x0E18:
					return XKeySym.ThaiThothong;
				case 0x0E19:
					return XKeySym.ThaiNonu;
				case 0x0E1A:
					return XKeySym.ThaiBobaimai;
				case 0x0E1B:
					return XKeySym.ThaiPopla;
				case 0x0E1C:
					return XKeySym.ThaiPhophung;
				case 0x0E1D:
					return XKeySym.ThaiFofa;
				case 0x0E1E:
					return XKeySym.ThaiPhophan;
				case 0x0E1F:
					return XKeySym.ThaiFofan;
				case 0x0E20:
					return XKeySym.ThaiPhosamphao;
				case 0x0E21:
					return XKeySym.ThaiMoma;
				case 0x0E22:
					return XKeySym.ThaiYoyak;
				case 0x0E23:
					return XKeySym.ThaiRorua;
				case 0x0E24:
					return XKeySym.ThaiRu;
				case 0x0E25:
					return XKeySym.ThaiLoling;
				case 0x0E26:
					return XKeySym.ThaiLu;
				case 0x0E27:
					return XKeySym.ThaiWowaen;
				case 0x0E28:
					return XKeySym.ThaiSosala;
				case 0x0E29:
					return XKeySym.ThaiSorusi;
				case 0x0E2A:
					return XKeySym.ThaiSosua;
				case 0x0E2B:
					return XKeySym.ThaiHohip;
				case 0x0E2C:
					return XKeySym.ThaiLochula;
				case 0x0E2D:
					return XKeySym.ThaiOang;
				case 0x0E2E:
					return XKeySym.ThaiHonokhuk;
				case 0x0E2F:
					return XKeySym.ThaiPaiyannoi;
				case 0x0E30:
					return XKeySym.ThaiSaraa;
				case 0x0E31:
					return XKeySym.ThaiMaihanakat;
				case 0x0E32:
					return XKeySym.ThaiSaraaa;
				case 0x0E33:
					return XKeySym.ThaiSaraam;
				case 0x0E34:
					return XKeySym.ThaiSarai;
				case 0x0E35:
					return XKeySym.ThaiSaraii;
				case 0x0E36:
					return XKeySym.ThaiSaraue;
				case 0x0E37:
					return XKeySym.ThaiSarauee;
				case 0x0E38:
					return XKeySym.ThaiSarau;
				case 0x0E39:
					return XKeySym.ThaiSarauu;
				case 0x0E3A:
					return XKeySym.ThaiPhinthu;
				case 0x0E3F:
					return XKeySym.ThaiBaht;
				case 0x0E40:
					return XKeySym.ThaiSarae;
				case 0x0E41:
					return XKeySym.ThaiSaraae;
				case 0x0E42:
					return XKeySym.ThaiSarao;
				case 0x0E43:
					return XKeySym.ThaiSaraaimaimuan;
				case 0x0E44:
					return XKeySym.ThaiSaraaimaimalai;
				case 0x0E45:
					return XKeySym.ThaiLakkhangyao;
				case 0x0E46:
					return XKeySym.ThaiMaiyamok;
				case 0x0E47:
					return XKeySym.ThaiMaitaikhu;
				case 0x0E48:
					return XKeySym.ThaiMaiek;
				case 0x0E49:
					return XKeySym.ThaiMaitho;
				case 0x0E4A:
					return XKeySym.ThaiMaitri;
				case 0x0E4B:
					return XKeySym.ThaiMaichattawa;
				case 0x0E4C:
					return XKeySym.ThaiThanthakhat;
				case 0x0E4D:
					return XKeySym.ThaiNikhahit;
				case 0x0E50:
					return XKeySym.ThaiLeksun;
				case 0x0E51:
					return XKeySym.ThaiLeknung;
				case 0x0E52:
					return XKeySym.ThaiLeksong;
				case 0x0E53:
					return XKeySym.ThaiLeksam;
				case 0x0E54:
					return XKeySym.ThaiLeksi;
				case 0x0E55:
					return XKeySym.ThaiLekha;
				case 0x0E56:
					return XKeySym.ThaiLekhok;
				case 0x0E57:
					return XKeySym.ThaiLekchet;
				case 0x0E58:
					return XKeySym.ThaiLekpaet;
				case 0x0E59:
					return XKeySym.ThaiLekkao;
				case 0x0587:
					return XKeySym.armenianLigatureEw;
				case 0x0589:
					return XKeySym.ArmenianFullStop;
				case 0x055D:
					return XKeySym.ArmenianSeparationMark;
				case 0x058A:
					return XKeySym.ArmenianHyphen;
				case 0x055C:
					return XKeySym.ArmenianExclam;
				case 0x055B:
					return XKeySym.ArmenianAccent;
				case 0x055E:
					return XKeySym.ArmenianQuestion;
				case 0x0531:
					return XKeySym.ArmenianAYB;
				case 0x0561:
					return XKeySym.armenianAyb;
				case 0x0532:
					return XKeySym.ArmenianBEN;
				case 0x0562:
					return XKeySym.armenianBen;
				case 0x0533:
					return XKeySym.ArmenianGIM;
				case 0x0563:
					return XKeySym.armenianGim;
				case 0x0534:
					return XKeySym.ArmenianDA;
				case 0x0564:
					return XKeySym.armenianDa;
				case 0x0535:
					return XKeySym.ArmenianYECH;
				case 0x0565:
					return XKeySym.armenianYech;
				case 0x0536:
					return XKeySym.ArmenianZA;
				case 0x0566:
					return XKeySym.armenianZa;
				case 0x0537:
					return XKeySym.ArmenianE;
				case 0x0567:
					return XKeySym.armenianE;
				case 0x0538:
					return XKeySym.ArmenianAT;
				case 0x0568:
					return XKeySym.armenianAt;
				case 0x0539:
					return XKeySym.ArmenianTO;
				case 0x0569:
					return XKeySym.armenianTo;
				case 0x053A:
					return XKeySym.ArmenianZHE;
				case 0x056A:
					return XKeySym.armenianZhe;
				case 0x053B:
					return XKeySym.ArmenianINI;
				case 0x056B:
					return XKeySym.armenianIni;
				case 0x053C:
					return XKeySym.ArmenianLYUN;
				case 0x056C:
					return XKeySym.armenianLyun;
				case 0x053D:
					return XKeySym.ArmenianKHE;
				case 0x056D:
					return XKeySym.armenianKhe;
				case 0x053E:
					return XKeySym.ArmenianTSA;
				case 0x056E:
					return XKeySym.armenianTsa;
				case 0x053F:
					return XKeySym.ArmenianKEN;
				case 0x056F:
					return XKeySym.armenianKen;
				case 0x0540:
					return XKeySym.ArmenianHO;
				case 0x0570:
					return XKeySym.armenianHo;
				case 0x0541:
					return XKeySym.ArmenianDZA;
				case 0x0571:
					return XKeySym.armenianDza;
				case 0x0542:
					return XKeySym.ArmenianGHAT;
				case 0x0572:
					return XKeySym.armenianGhat;
				case 0x0543:
					return XKeySym.ArmenianTCHE;
				case 0x0573:
					return XKeySym.armenianTche;
				case 0x0544:
					return XKeySym.ArmenianMEN;
				case 0x0574:
					return XKeySym.armenianMen;
				case 0x0545:
					return XKeySym.ArmenianHI;
				case 0x0575:
					return XKeySym.armenianHi;
				case 0x0546:
					return XKeySym.ArmenianNU;
				case 0x0576:
					return XKeySym.armenianNu;
				case 0x0547:
					return XKeySym.ArmenianSHA;
				case 0x0577:
					return XKeySym.armenianSha;
				case 0x0548:
					return XKeySym.ArmenianVO;
				case 0x0578:
					return XKeySym.armenianVo;
				case 0x0549:
					return XKeySym.ArmenianCHA;
				case 0x0579:
					return XKeySym.armenianCha;
				case 0x054A:
					return XKeySym.ArmenianPE;
				case 0x057A:
					return XKeySym.armenianPe;
				case 0x054B:
					return XKeySym.ArmenianJE;
				case 0x057B:
					return XKeySym.armenianJe;
				case 0x054C:
					return XKeySym.ArmenianRA;
				case 0x057C:
					return XKeySym.armenianRa;
				case 0x054D:
					return XKeySym.ArmenianSE;
				case 0x057D:
					return XKeySym.armenianSe;
				case 0x054E:
					return XKeySym.ArmenianVEV;
				case 0x057E:
					return XKeySym.armenianVev;
				case 0x054F:
					return XKeySym.ArmenianTYUN;
				case 0x057F:
					return XKeySym.armenianTyun;
				case 0x0550:
					return XKeySym.ArmenianRE;
				case 0x0580:
					return XKeySym.armenianRe;
				case 0x0551:
					return XKeySym.ArmenianTSO;
				case 0x0581:
					return XKeySym.armenianTso;
				case 0x0552:
					return XKeySym.ArmenianVYUN;
				case 0x0582:
					return XKeySym.armenianVyun;
				case 0x0553:
					return XKeySym.ArmenianPYUR;
				case 0x0583:
					return XKeySym.armenianPyur;
				case 0x0554:
					return XKeySym.ArmenianKE;
				case 0x0584:
					return XKeySym.armenianKe;
				case 0x0555:
					return XKeySym.ArmenianO;
				case 0x0585:
					return XKeySym.armenianO;
				case 0x0556:
					return XKeySym.ArmenianFE;
				case 0x0586:
					return XKeySym.armenianFe;
				case 0x055A:
					return XKeySym.ArmenianApostrophe;
				case 0x10D0:
					return XKeySym.GeorgianAn;
				case 0x10D1:
					return XKeySym.GeorgianBan;
				case 0x10D2:
					return XKeySym.GeorgianGan;
				case 0x10D3:
					return XKeySym.GeorgianDon;
				case 0x10D4:
					return XKeySym.GeorgianEn;
				case 0x10D5:
					return XKeySym.GeorgianVin;
				case 0x10D6:
					return XKeySym.GeorgianZen;
				case 0x10D7:
					return XKeySym.GeorgianTan;
				case 0x10D8:
					return XKeySym.GeorgianIn;
				case 0x10D9:
					return XKeySym.GeorgianKan;
				case 0x10DA:
					return XKeySym.GeorgianLas;
				case 0x10DB:
					return XKeySym.GeorgianMan;
				case 0x10DC:
					return XKeySym.GeorgianNar;
				case 0x10DD:
					return XKeySym.GeorgianOn;
				case 0x10DE:
					return XKeySym.GeorgianPar;
				case 0x10DF:
					return XKeySym.GeorgianZhar;
				case 0x10E0:
					return XKeySym.GeorgianRae;
				case 0x10E1:
					return XKeySym.GeorgianSan;
				case 0x10E2:
					return XKeySym.GeorgianTar;
				case 0x10E3:
					return XKeySym.GeorgianUn;
				case 0x10E4:
					return XKeySym.GeorgianPhar;
				case 0x10E5:
					return XKeySym.GeorgianKhar;
				case 0x10E6:
					return XKeySym.GeorgianGhan;
				case 0x10E7:
					return XKeySym.GeorgianQar;
				case 0x10E8:
					return XKeySym.GeorgianShin;
				case 0x10E9:
					return XKeySym.GeorgianChin;
				case 0x10EA:
					return XKeySym.GeorgianCan;
				case 0x10EB:
					return XKeySym.GeorgianJil;
				case 0x10EC:
					return XKeySym.GeorgianCil;
				case 0x10ED:
					return XKeySym.GeorgianChar;
				case 0x10EE:
					return XKeySym.GeorgianXan;
				case 0x10EF:
					return XKeySym.GeorgianJhan;
				case 0x10F0:
					return XKeySym.GeorgianHae;
				case 0x10F1:
					return XKeySym.GeorgianHe;
				case 0x10F2:
					return XKeySym.GeorgianHie;
				case 0x10F3:
					return XKeySym.GeorgianWe;
				case 0x10F4:
					return XKeySym.GeorgianHar;
				case 0x10F5:
					return XKeySym.GeorgianHoe;
				case 0x10F6:
					return XKeySym.GeorgianFi;
				case 0x1E8A:
					return XKeySym.Xabovedot;
				case 0x012C:
					return XKeySym.Ibreve;
				case 0x01B5:
					return XKeySym.Zstroke;
				case 0x01E6:
					return XKeySym.Gcaron;
				case 0x01D2:
					return XKeySym.Ocaron;
				case 0x019F:
					return XKeySym.Obarred;
				case 0x1E8B:
					return XKeySym.xabovedot;
				case 0x012D:
					return XKeySym.ibreve;
				case 0x01B6:
					return XKeySym.zstroke;
				case 0x01E7:
					return XKeySym.gcaron;
				case 0x0275:
					return XKeySym.obarred;
				case 0x018F:
					return XKeySym.SCHWA;
				case 0x0259:
					return XKeySym.schwa;
				case 0x01B7:
					return XKeySym.EZH;
				case 0x0292:
					return XKeySym.ezh;
				case 0x1E36:
					return XKeySym.Lbelowdot;
				case 0x1E37:
					return XKeySym.lbelowdot;
				case 0x1EA0:
					return XKeySym.Abelowdot;
				case 0x1EA1:
					return XKeySym.abelowdot;
				case 0x1EA2:
					return XKeySym.Ahook;
				case 0x1EA3:
					return XKeySym.ahook;
				case 0x1EA4:
					return XKeySym.Acircumflexacute;
				case 0x1EA5:
					return XKeySym.acircumflexacute;
				case 0x1EA6:
					return XKeySym.Acircumflexgrave;
				case 0x1EA7:
					return XKeySym.acircumflexgrave;
				case 0x1EA8:
					return XKeySym.Acircumflexhook;
				case 0x1EA9:
					return XKeySym.acircumflexhook;
				case 0x1EAA:
					return XKeySym.Acircumflextilde;
				case 0x1EAB:
					return XKeySym.acircumflextilde;
				case 0x1EAC:
					return XKeySym.Acircumflexbelowdot;
				case 0x1EAD:
					return XKeySym.acircumflexbelowdot;
				case 0x1EAE:
					return XKeySym.Abreveacute;
				case 0x1EAF:
					return XKeySym.abreveacute;
				case 0x1EB0:
					return XKeySym.Abrevegrave;
				case 0x1EB1:
					return XKeySym.abrevegrave;
				case 0x1EB2:
					return XKeySym.Abrevehook;
				case 0x1EB3:
					return XKeySym.abrevehook;
				case 0x1EB4:
					return XKeySym.Abrevetilde;
				case 0x1EB5:
					return XKeySym.abrevetilde;
				case 0x1EB6:
					return XKeySym.Abrevebelowdot;
				case 0x1EB7:
					return XKeySym.abrevebelowdot;
				case 0x1EB8:
					return XKeySym.Ebelowdot;
				case 0x1EB9:
					return XKeySym.ebelowdot;
				case 0x1EBA:
					return XKeySym.Ehook;
				case 0x1EBB:
					return XKeySym.ehook;
				case 0x1EBC:
					return XKeySym.Etilde;
				case 0x1EBD:
					return XKeySym.etilde;
				case 0x1EBE:
					return XKeySym.Ecircumflexacute;
				case 0x1EBF:
					return XKeySym.ecircumflexacute;
				case 0x1EC0:
					return XKeySym.Ecircumflexgrave;
				case 0x1EC1:
					return XKeySym.ecircumflexgrave;
				case 0x1EC2:
					return XKeySym.Ecircumflexhook;
				case 0x1EC3:
					return XKeySym.ecircumflexhook;
				case 0x1EC4:
					return XKeySym.Ecircumflextilde;
				case 0x1EC5:
					return XKeySym.ecircumflextilde;
				case 0x1EC6:
					return XKeySym.Ecircumflexbelowdot;
				case 0x1EC7:
					return XKeySym.ecircumflexbelowdot;
				case 0x1EC8:
					return XKeySym.Ihook;
				case 0x1EC9:
					return XKeySym.ihook;
				case 0x1ECA:
					return XKeySym.Ibelowdot;
				case 0x1ECB:
					return XKeySym.ibelowdot;
				case 0x1ECC:
					return XKeySym.Obelowdot;
				case 0x1ECD:
					return XKeySym.obelowdot;
				case 0x1ECE:
					return XKeySym.Ohook;
				case 0x1ECF:
					return XKeySym.ohook;
				case 0x1ED0:
					return XKeySym.Ocircumflexacute;
				case 0x1ED1:
					return XKeySym.ocircumflexacute;
				case 0x1ED2:
					return XKeySym.Ocircumflexgrave;
				case 0x1ED3:
					return XKeySym.ocircumflexgrave;
				case 0x1ED4:
					return XKeySym.Ocircumflexhook;
				case 0x1ED5:
					return XKeySym.ocircumflexhook;
				case 0x1ED6:
					return XKeySym.Ocircumflextilde;
				case 0x1ED7:
					return XKeySym.ocircumflextilde;
				case 0x1ED8:
					return XKeySym.Ocircumflexbelowdot;
				case 0x1ED9:
					return XKeySym.ocircumflexbelowdot;
				case 0x1EDA:
					return XKeySym.Ohornacute;
				case 0x1EDB:
					return XKeySym.ohornacute;
				case 0x1EDC:
					return XKeySym.Ohorngrave;
				case 0x1EDD:
					return XKeySym.ohorngrave;
				case 0x1EDE:
					return XKeySym.Ohornhook;
				case 0x1EDF:
					return XKeySym.ohornhook;
				case 0x1EE0:
					return XKeySym.Ohorntilde;
				case 0x1EE1:
					return XKeySym.ohorntilde;
				case 0x1EE2:
					return XKeySym.Ohornbelowdot;
				case 0x1EE3:
					return XKeySym.ohornbelowdot;
				case 0x1EE4:
					return XKeySym.Ubelowdot;
				case 0x1EE5:
					return XKeySym.ubelowdot;
				case 0x1EE6:
					return XKeySym.Uhook;
				case 0x1EE7:
					return XKeySym.uhook;
				case 0x1EE8:
					return XKeySym.Uhornacute;
				case 0x1EE9:
					return XKeySym.uhornacute;
				case 0x1EEA:
					return XKeySym.Uhorngrave;
				case 0x1EEB:
					return XKeySym.uhorngrave;
				case 0x1EEC:
					return XKeySym.Uhornhook;
				case 0x1EED:
					return XKeySym.uhornhook;
				case 0x1EEE:
					return XKeySym.Uhorntilde;
				case 0x1EEF:
					return XKeySym.uhorntilde;
				case 0x1EF0:
					return XKeySym.Uhornbelowdot;
				case 0x1EF1:
					return XKeySym.uhornbelowdot;
				case 0x1EF4:
					return XKeySym.Ybelowdot;
				case 0x1EF5:
					return XKeySym.ybelowdot;
				case 0x1EF6:
					return XKeySym.Yhook;
				case 0x1EF7:
					return XKeySym.yhook;
				case 0x1EF8:
					return XKeySym.Ytilde;
				case 0x1EF9:
					return XKeySym.ytilde;
				case 0x01A0:
					return XKeySym.Ohorn;
				case 0x01A1:
					return XKeySym.ohorn;
				case 0x01AF:
					return XKeySym.Uhorn;
				case 0x01B0:
					return XKeySym.uhorn;
				case 0x20A0:
					return XKeySym.EcuSign;
				case 0x20A1:
					return XKeySym.ColonSign;
				case 0x20A2:
					return XKeySym.CruzeiroSign;
				case 0x20A3:
					return XKeySym.FFrancSign;
				case 0x20A4:
					return XKeySym.LiraSign;
				case 0x20A5:
					return XKeySym.MillSign;
				case 0x20A6:
					return XKeySym.NairaSign;
				case 0x20A7:
					return XKeySym.PesetaSign;
				case 0x20A8:
					return XKeySym.RupeeSign;
				case 0x20A9:
					return XKeySym.WonSign;
				case 0x20AA:
					return XKeySym.NewSheqelSign;
				case 0x20AB:
					return XKeySym.DongSign;
				case 0x20AC:
					return XKeySym.EuroSign;
				case 0x2070:
					return XKeySym.Zerosuperior;
				case 0x2074:
					return XKeySym.Foursuperior;
				case 0x2075:
					return XKeySym.Fivesuperior;
				case 0x2076:
					return XKeySym.Sixsuperior;
				case 0x2077:
					return XKeySym.Sevensuperior;
				case 0x2078:
					return XKeySym.Eightsuperior;
				case 0x2079:
					return XKeySym.Ninesuperior;
				case 0x2080:
					return XKeySym.Zerosubscript;
				case 0x2081:
					return XKeySym.Onesubscript;
				case 0x2082:
					return XKeySym.Twosubscript;
				case 0x2083:
					return XKeySym.Threesubscript;
				case 0x2084:
					return XKeySym.Foursubscript;
				case 0x2085:
					return XKeySym.Fivesubscript;
				case 0x2086:
					return XKeySym.Sixsubscript;
				case 0x2087:
					return XKeySym.Sevensubscript;
				case 0x2088:
					return XKeySym.Eightsubscript;
				case 0x2089:
					return XKeySym.Ninesubscript;
				case 0x2205:
					return XKeySym.Emptyset;
				case 0x2208:
					return XKeySym.Elementof;
				case 0x2209:
					return XKeySym.Notelementof;
				case 0x220B:
					return XKeySym.Containsas;
				case 0x221A:
					return XKeySym.Squareroot;
				case 0x221B:
					return XKeySym.Cuberoot;
				case 0x221C:
					return XKeySym.Fourthroot;
				case 0x222C:
					return XKeySym.Dintegral;
				case 0x222D:
					return XKeySym.Tintegral;
				case 0x2235:
					return XKeySym.Because;
				case 0x2245:
					return XKeySym.Approxeq;
				case 0x2247:
					return XKeySym.Notapproxeq;
				case 0x2262:
					return XKeySym.Notidentical;
				case 0x2263:
					return XKeySym.Stricteq;
				case 0x2800:
					return XKeySym.BrailleBlank;
				case 0x2801:
					return XKeySym.BrailleDots1;
				case 0x2802:
					return XKeySym.BrailleDots2;
				case 0x2803:
					return XKeySym.BrailleDots12;
				case 0x2804:
					return XKeySym.BrailleDots3;
				case 0x2805:
					return XKeySym.BrailleDots13;
				case 0x2806:
					return XKeySym.BrailleDots23;
				case 0x2807:
					return XKeySym.BrailleDots123;
				case 0x2808:
					return XKeySym.BrailleDots4;
				case 0x2809:
					return XKeySym.BrailleDots14;
				case 0x280a:
					return XKeySym.BrailleDots24;
				case 0x280b:
					return XKeySym.BrailleDots124;
				case 0x280c:
					return XKeySym.BrailleDots34;
				case 0x280d:
					return XKeySym.BrailleDots134;
				case 0x280e:
					return XKeySym.BrailleDots234;
				case 0x280f:
					return XKeySym.BrailleDots1234;
				case 0x2810:
					return XKeySym.BrailleDots5;
				case 0x2811:
					return XKeySym.BrailleDots15;
				case 0x2812:
					return XKeySym.BrailleDots25;
				case 0x2813:
					return XKeySym.BrailleDots125;
				case 0x2814:
					return XKeySym.BrailleDots35;
				case 0x2815:
					return XKeySym.BrailleDots135;
				case 0x2816:
					return XKeySym.BrailleDots235;
				case 0x2817:
					return XKeySym.BrailleDots1235;
				case 0x2818:
					return XKeySym.BrailleDots45;
				case 0x2819:
					return XKeySym.BrailleDots145;
				case 0x281a:
					return XKeySym.BrailleDots245;
				case 0x281b:
					return XKeySym.BrailleDots1245;
				case 0x281c:
					return XKeySym.BrailleDots345;
				case 0x281d:
					return XKeySym.BrailleDots1345;
				case 0x281e:
					return XKeySym.BrailleDots2345;
				case 0x281f:
					return XKeySym.BrailleDots12345;
				case 0x2820:
					return XKeySym.BrailleDots6;
				case 0x2821:
					return XKeySym.BrailleDots16;
				case 0x2822:
					return XKeySym.BrailleDots26;
				case 0x2823:
					return XKeySym.BrailleDots126;
				case 0x2824:
					return XKeySym.BrailleDots36;
				case 0x2825:
					return XKeySym.BrailleDots136;
				case 0x2826:
					return XKeySym.BrailleDots236;
				case 0x2827:
					return XKeySym.BrailleDots1236;
				case 0x2828:
					return XKeySym.BrailleDots46;
				case 0x2829:
					return XKeySym.BrailleDots146;
				case 0x282a:
					return XKeySym.BrailleDots246;
				case 0x282b:
					return XKeySym.BrailleDots1246;
				case 0x282c:
					return XKeySym.BrailleDots346;
				case 0x282d:
					return XKeySym.BrailleDots1346;
				case 0x282e:
					return XKeySym.BrailleDots2346;
				case 0x282f:
					return XKeySym.BrailleDots12346;
				case 0x2830:
					return XKeySym.BrailleDots56;
				case 0x2831:
					return XKeySym.BrailleDots156;
				case 0x2832:
					return XKeySym.BrailleDots256;
				case 0x2833:
					return XKeySym.BrailleDots1256;
				case 0x2834:
					return XKeySym.BrailleDots356;
				case 0x2835:
					return XKeySym.BrailleDots1356;
				case 0x2836:
					return XKeySym.BrailleDots2356;
				case 0x2837:
					return XKeySym.BrailleDots12356;
				case 0x2838:
					return XKeySym.BrailleDots456;
				case 0x2839:
					return XKeySym.BrailleDots1456;
				case 0x283a:
					return XKeySym.BrailleDots2456;
				case 0x283b:
					return XKeySym.BrailleDots12456;
				case 0x283c:
					return XKeySym.BrailleDots3456;
				case 0x283d:
					return XKeySym.BrailleDots13456;
				case 0x283e:
					return XKeySym.BrailleDots23456;
				case 0x283f:
					return XKeySym.BrailleDots123456;
				case 0x2840:
					return XKeySym.BrailleDots7;
				case 0x2841:
					return XKeySym.BrailleDots17;
				case 0x2842:
					return XKeySym.BrailleDots27;
				case 0x2843:
					return XKeySym.BrailleDots127;
				case 0x2844:
					return XKeySym.BrailleDots37;
				case 0x2845:
					return XKeySym.BrailleDots137;
				case 0x2846:
					return XKeySym.BrailleDots237;
				case 0x2847:
					return XKeySym.BrailleDots1237;
				case 0x2848:
					return XKeySym.BrailleDots47;
				case 0x2849:
					return XKeySym.BrailleDots147;
				case 0x284a:
					return XKeySym.BrailleDots247;
				case 0x284b:
					return XKeySym.BrailleDots1247;
				case 0x284c:
					return XKeySym.BrailleDots347;
				case 0x284d:
					return XKeySym.BrailleDots1347;
				case 0x284e:
					return XKeySym.BrailleDots2347;
				case 0x284f:
					return XKeySym.BrailleDots12347;
				case 0x2850:
					return XKeySym.BrailleDots57;
				case 0x2851:
					return XKeySym.BrailleDots157;
				case 0x2852:
					return XKeySym.BrailleDots257;
				case 0x2853:
					return XKeySym.BrailleDots1257;
				case 0x2854:
					return XKeySym.BrailleDots357;
				case 0x2855:
					return XKeySym.BrailleDots1357;
				case 0x2856:
					return XKeySym.BrailleDots2357;
				case 0x2857:
					return XKeySym.BrailleDots12357;
				case 0x2858:
					return XKeySym.BrailleDots457;
				case 0x2859:
					return XKeySym.BrailleDots1457;
				case 0x285a:
					return XKeySym.BrailleDots2457;
				case 0x285b:
					return XKeySym.BrailleDots12457;
				case 0x285c:
					return XKeySym.BrailleDots3457;
				case 0x285d:
					return XKeySym.BrailleDots13457;
				case 0x285e:
					return XKeySym.BrailleDots23457;
				case 0x285f:
					return XKeySym.BrailleDots123457;
				case 0x2860:
					return XKeySym.BrailleDots67;
				case 0x2861:
					return XKeySym.BrailleDots167;
				case 0x2862:
					return XKeySym.BrailleDots267;
				case 0x2863:
					return XKeySym.BrailleDots1267;
				case 0x2864:
					return XKeySym.BrailleDots367;
				case 0x2865:
					return XKeySym.BrailleDots1367;
				case 0x2866:
					return XKeySym.BrailleDots2367;
				case 0x2867:
					return XKeySym.BrailleDots12367;
				case 0x2868:
					return XKeySym.BrailleDots467;
				case 0x2869:
					return XKeySym.BrailleDots1467;
				case 0x286a:
					return XKeySym.BrailleDots2467;
				case 0x286b:
					return XKeySym.BrailleDots12467;
				case 0x286c:
					return XKeySym.BrailleDots3467;
				case 0x286d:
					return XKeySym.BrailleDots13467;
				case 0x286e:
					return XKeySym.BrailleDots23467;
				case 0x286f:
					return XKeySym.BrailleDots123467;
				case 0x2870:
					return XKeySym.BrailleDots567;
				case 0x2871:
					return XKeySym.BrailleDots1567;
				case 0x2872:
					return XKeySym.BrailleDots2567;
				case 0x2873:
					return XKeySym.BrailleDots12567;
				case 0x2874:
					return XKeySym.BrailleDots3567;
				case 0x2875:
					return XKeySym.BrailleDots13567;
				case 0x2876:
					return XKeySym.BrailleDots23567;
				case 0x2877:
					return XKeySym.BrailleDots123567;
				case 0x2878:
					return XKeySym.BrailleDots4567;
				case 0x2879:
					return XKeySym.BrailleDots14567;
				case 0x287a:
					return XKeySym.BrailleDots24567;
				case 0x287b:
					return XKeySym.BrailleDots124567;
				case 0x287c:
					return XKeySym.BrailleDots34567;
				case 0x287d:
					return XKeySym.BrailleDots134567;
				case 0x287e:
					return XKeySym.BrailleDots234567;
				case 0x287f:
					return XKeySym.BrailleDots1234567;
				case 0x2880:
					return XKeySym.BrailleDots8;
				case 0x2881:
					return XKeySym.BrailleDots18;
				case 0x2882:
					return XKeySym.BrailleDots28;
				case 0x2883:
					return XKeySym.BrailleDots128;
				case 0x2884:
					return XKeySym.BrailleDots38;
				case 0x2885:
					return XKeySym.BrailleDots138;
				case 0x2886:
					return XKeySym.BrailleDots238;
				case 0x2887:
					return XKeySym.BrailleDots1238;
				case 0x2888:
					return XKeySym.BrailleDots48;
				case 0x2889:
					return XKeySym.BrailleDots148;
				case 0x288a:
					return XKeySym.BrailleDots248;
				case 0x288b:
					return XKeySym.BrailleDots1248;
				case 0x288c:
					return XKeySym.BrailleDots348;
				case 0x288d:
					return XKeySym.BrailleDots1348;
				case 0x288e:
					return XKeySym.BrailleDots2348;
				case 0x288f:
					return XKeySym.BrailleDots12348;
				case 0x2890:
					return XKeySym.BrailleDots58;
				case 0x2891:
					return XKeySym.BrailleDots158;
				case 0x2892:
					return XKeySym.BrailleDots258;
				case 0x2893:
					return XKeySym.BrailleDots1258;
				case 0x2894:
					return XKeySym.BrailleDots358;
				case 0x2895:
					return XKeySym.BrailleDots1358;
				case 0x2896:
					return XKeySym.BrailleDots2358;
				case 0x2897:
					return XKeySym.BrailleDots12358;
				case 0x2898:
					return XKeySym.BrailleDots458;
				case 0x2899:
					return XKeySym.BrailleDots1458;
				case 0x289a:
					return XKeySym.BrailleDots2458;
				case 0x289b:
					return XKeySym.BrailleDots12458;
				case 0x289c:
					return XKeySym.BrailleDots3458;
				case 0x289d:
					return XKeySym.BrailleDots13458;
				case 0x289e:
					return XKeySym.BrailleDots23458;
				case 0x289f:
					return XKeySym.BrailleDots123458;
				case 0x28a0:
					return XKeySym.BrailleDots68;
				case 0x28a1:
					return XKeySym.BrailleDots168;
				case 0x28a2:
					return XKeySym.BrailleDots268;
				case 0x28a3:
					return XKeySym.BrailleDots1268;
				case 0x28a4:
					return XKeySym.BrailleDots368;
				case 0x28a5:
					return XKeySym.BrailleDots1368;
				case 0x28a6:
					return XKeySym.BrailleDots2368;
				case 0x28a7:
					return XKeySym.BrailleDots12368;
				case 0x28a8:
					return XKeySym.BrailleDots468;
				case 0x28a9:
					return XKeySym.BrailleDots1468;
				case 0x28aa:
					return XKeySym.BrailleDots2468;
				case 0x28ab:
					return XKeySym.BrailleDots12468;
				case 0x28ac:
					return XKeySym.BrailleDots3468;
				case 0x28ad:
					return XKeySym.BrailleDots13468;
				case 0x28ae:
					return XKeySym.BrailleDots23468;
				case 0x28af:
					return XKeySym.BrailleDots123468;
				case 0x28b0:
					return XKeySym.BrailleDots568;
				case 0x28b1:
					return XKeySym.BrailleDots1568;
				case 0x28b2:
					return XKeySym.BrailleDots2568;
				case 0x28b3:
					return XKeySym.BrailleDots12568;
				case 0x28b4:
					return XKeySym.BrailleDots3568;
				case 0x28b5:
					return XKeySym.BrailleDots13568;
				case 0x28b6:
					return XKeySym.BrailleDots23568;
				case 0x28b7:
					return XKeySym.BrailleDots123568;
				case 0x28b8:
					return XKeySym.BrailleDots4568;
				case 0x28b9:
					return XKeySym.BrailleDots14568;
				case 0x28ba:
					return XKeySym.BrailleDots24568;
				case 0x28bb:
					return XKeySym.BrailleDots124568;
				case 0x28bc:
					return XKeySym.BrailleDots34568;
				case 0x28bd:
					return XKeySym.BrailleDots134568;
				case 0x28be:
					return XKeySym.BrailleDots234568;
				case 0x28bf:
					return XKeySym.BrailleDots1234568;
				case 0x28c0:
					return XKeySym.BrailleDots78;
				case 0x28c1:
					return XKeySym.BrailleDots178;
				case 0x28c2:
					return XKeySym.BrailleDots278;
				case 0x28c3:
					return XKeySym.BrailleDots1278;
				case 0x28c4:
					return XKeySym.BrailleDots378;
				case 0x28c5:
					return XKeySym.BrailleDots1378;
				case 0x28c6:
					return XKeySym.BrailleDots2378;
				case 0x28c7:
					return XKeySym.BrailleDots12378;
				case 0x28c8:
					return XKeySym.BrailleDots478;
				case 0x28c9:
					return XKeySym.BrailleDots1478;
				case 0x28ca:
					return XKeySym.BrailleDots2478;
				case 0x28cb:
					return XKeySym.BrailleDots12478;
				case 0x28cc:
					return XKeySym.BrailleDots3478;
				case 0x28cd:
					return XKeySym.BrailleDots13478;
				case 0x28ce:
					return XKeySym.BrailleDots23478;
				case 0x28cf:
					return XKeySym.BrailleDots123478;
				case 0x28d0:
					return XKeySym.BrailleDots578;
				case 0x28d1:
					return XKeySym.BrailleDots1578;
				case 0x28d2:
					return XKeySym.BrailleDots2578;
				case 0x28d3:
					return XKeySym.BrailleDots12578;
				case 0x28d4:
					return XKeySym.BrailleDots3578;
				case 0x28d5:
					return XKeySym.BrailleDots13578;
				case 0x28d6:
					return XKeySym.BrailleDots23578;
				case 0x28d7:
					return XKeySym.BrailleDots123578;
				case 0x28d8:
					return XKeySym.BrailleDots4578;
				case 0x28d9:
					return XKeySym.BrailleDots14578;
				case 0x28da:
					return XKeySym.BrailleDots24578;
				case 0x28db:
					return XKeySym.BrailleDots124578;
				case 0x28dc:
					return XKeySym.BrailleDots34578;
				case 0x28dd:
					return XKeySym.BrailleDots134578;
				case 0x28de:
					return XKeySym.BrailleDots234578;
				case 0x28df:
					return XKeySym.BrailleDots1234578;
				case 0x28e0:
					return XKeySym.BrailleDots678;
				case 0x28e1:
					return XKeySym.BrailleDots1678;
				case 0x28e2:
					return XKeySym.BrailleDots2678;
				case 0x28e3:
					return XKeySym.BrailleDots12678;
				case 0x28e4:
					return XKeySym.BrailleDots3678;
				case 0x28e5:
					return XKeySym.BrailleDots13678;
				case 0x28e6:
					return XKeySym.BrailleDots23678;
				case 0x28e7:
					return XKeySym.BrailleDots123678;
				case 0x28e8:
					return XKeySym.BrailleDots4678;
				case 0x28e9:
					return XKeySym.BrailleDots14678;
				case 0x28ea:
					return XKeySym.BrailleDots24678;
				case 0x28eb:
					return XKeySym.BrailleDots124678;
				case 0x28ec:
					return XKeySym.BrailleDots34678;
				case 0x28ed:
					return XKeySym.BrailleDots134678;
				case 0x28ee:
					return XKeySym.BrailleDots234678;
				case 0x28ef:
					return XKeySym.BrailleDots1234678;
				case 0x28f0:
					return XKeySym.BrailleDots5678;
				case 0x28f1:
					return XKeySym.BrailleDots15678;
				case 0x28f2:
					return XKeySym.BrailleDots25678;
				case 0x28f3:
					return XKeySym.BrailleDots125678;
				case 0x28f4:
					return XKeySym.BrailleDots35678;
				case 0x28f5:
					return XKeySym.BrailleDots135678;
				case 0x28f6:
					return XKeySym.BrailleDots235678;
				case 0x28f7:
					return XKeySym.BrailleDots1235678;
				case 0x28f8:
					return XKeySym.BrailleDots45678;
				case 0x28f9:
					return XKeySym.BrailleDots145678;
				case 0x28fa:
					return XKeySym.BrailleDots245678;
				case 0x28fb:
					return XKeySym.BrailleDots1245678;
				case 0x28fc:
					return XKeySym.BrailleDots345678;
				case 0x28fd:
					return XKeySym.BrailleDots1345678;
				case 0x28fe:
					return XKeySym.BrailleDots2345678;
				case 0x28ff:
					return XKeySym.BrailleDots12345678;
				case 0x0D82:
					return XKeySym.SinhNg;
				case 0x0D83:
					return XKeySym.SinhH2;
				case 0x0D85:
					return XKeySym.SinhA;
				case 0x0D86:
					return XKeySym.SinhAa;
				case 0x0D87:
					return XKeySym.SinhAe;
				case 0x0D88:
					return XKeySym.SinhAee;
				case 0x0D89:
					return XKeySym.SinhI;
				case 0x0D8A:
					return XKeySym.SinhIi;
				case 0x0D8B:
					return XKeySym.SinhU;
				case 0x0D8C:
					return XKeySym.SinhUu;
				case 0x0D8D:
					return XKeySym.SinhRi;
				case 0x0D8E:
					return XKeySym.SinhRii;
				case 0x0D8F:
					return XKeySym.SinhLu;
				case 0x0D90:
					return XKeySym.SinhLuu;
				case 0x0D91:
					return XKeySym.SinhE;
				case 0x0D92:
					return XKeySym.SinhEe;
				case 0x0D93:
					return XKeySym.SinhAi;
				case 0x0D94:
					return XKeySym.SinhO;
				case 0x0D95:
					return XKeySym.SinhOo;
				case 0x0D96:
					return XKeySym.SinhAu;
				case 0x0D9A:
					return XKeySym.SinhKa;
				case 0x0D9B:
					return XKeySym.SinhKha;
				case 0x0D9C:
					return XKeySym.SinhGa;
				case 0x0D9D:
					return XKeySym.SinhGha;
				case 0x0D9E:
					return XKeySym.SinhNg2;
				case 0x0D9F:
					return XKeySym.SinhNga;
				case 0x0DA0:
					return XKeySym.SinhCa;
				case 0x0DA1:
					return XKeySym.SinhCha;
				case 0x0DA2:
					return XKeySym.SinhJa;
				case 0x0DA3:
					return XKeySym.SinhJha;
				case 0x0DA4:
					return XKeySym.SinhNya;
				case 0x0DA5:
					return XKeySym.SinhJnya;
				case 0x0DA6:
					return XKeySym.SinhNja;
				case 0x0DA7:
					return XKeySym.SinhTta;
				case 0x0DA8:
					return XKeySym.SinhTtha;
				case 0x0DA9:
					return XKeySym.SinhDda;
				case 0x0DAA:
					return XKeySym.SinhDdha;
				case 0x0DAB:
					return XKeySym.SinhNna;
				case 0x0DAC:
					return XKeySym.SinhNdda;
				case 0x0DAD:
					return XKeySym.SinhTha;
				case 0x0DAE:
					return XKeySym.SinhThha;
				case 0x0DAF:
					return XKeySym.SinhDha;
				case 0x0DB0:
					return XKeySym.SinhDhha;
				case 0x0DB1:
					return XKeySym.SinhNa;
				case 0x0DB3:
					return XKeySym.SinhNdha;
				case 0x0DB4:
					return XKeySym.SinhPa;
				case 0x0DB5:
					return XKeySym.SinhPha;
				case 0x0DB6:
					return XKeySym.SinhBa;
				case 0x0DB7:
					return XKeySym.SinhBha;
				case 0x0DB8:
					return XKeySym.SinhMa;
				case 0x0DB9:
					return XKeySym.SinhMba;
				case 0x0DBA:
					return XKeySym.SinhYa;
				case 0x0DBB:
					return XKeySym.SinhRa;
				case 0x0DBD:
					return XKeySym.SinhLa;
				case 0x0DC0:
					return XKeySym.SinhVa;
				case 0x0DC1:
					return XKeySym.SinhSha;
				case 0x0DC2:
					return XKeySym.SinhSsha;
				case 0x0DC3:
					return XKeySym.SinhSa;
				case 0x0DC4:
					return XKeySym.SinhHa;
				case 0x0DC5:
					return XKeySym.SinhLla;
				case 0x0DC6:
					return XKeySym.SinhFa;
				case 0x0DCA:
					return XKeySym.SinhAl;
				case 0x0DCF:
					return XKeySym.SinhAa2;
				case 0x0DD0:
					return XKeySym.SinhAe2;
				case 0x0DD1:
					return XKeySym.SinhAee2;
				case 0x0DD2:
					return XKeySym.SinhI2;
				case 0x0DD3:
					return XKeySym.SinhIi2;
				case 0x0DD4:
					return XKeySym.SinhU2;
				case 0x0DD6:
					return XKeySym.SinhUu2;
				case 0x0DD8:
					return XKeySym.SinhRu2;
				case 0x0DD9:
					return XKeySym.SinhE2;
				case 0x0DDA:
					return XKeySym.SinhEe2;
				case 0x0DDB:
					return XKeySym.SinhAi2;
				case 0x0DDC:
					return XKeySym.SinhO2;
				case 0x0DDD:
					return XKeySym.SinhOo2;
				case 0x0DDE:
					return XKeySym.SinhAu2;
				case 0x0DDF:
					return XKeySym.SinhLu2;
				case 0x0DF2:
					return XKeySym.SinhRuu2;
				case 0x0DF3:
					return XKeySym.SinhLuu2;
				case 0x0DF4:
					return XKeySym.SinhKunddaliya;

				default:
					return XKeySym.None;
			}
		}

		/// <summary>
		///  Converts a X KeySym into character.
		/// </summary>
		/// <param name="keysym">The <see cref="XKeySym" /> to convert.</param>
		/// <returns>The character value.</returns>
		public static char XKeySymToChar(XKeySym keysym)
		{
			switch (keysym)
			{
				case XKeySym.Space:
					return (char) 0x0020;
				case XKeySym.Exclam:
					return (char) 0x0021;
				case XKeySym.Quotedbl:
					return (char) 0x0022;
				case XKeySym.Numbersign:
					return (char) 0x0023;
				case XKeySym.Dollar:
					return (char) 0x0024;
				case XKeySym.Percent:
					return (char) 0x0025;
				case XKeySym.Ampersand:
					return (char) 0x0026;
				case XKeySym.Apostrophe:
					return (char) 0x0027;
				case XKeySym.Parenleft:
					return (char) 0x0028;
				case XKeySym.Parenright:
					return (char) 0x0029;
				case XKeySym.Asterisk:
					return (char) 0x002A;
				case XKeySym.Plus:
					return (char) 0x002B;
				case XKeySym.Comma:
					return (char) 0x002C;
				case XKeySym.Minus:
					return (char) 0x002D;
				case XKeySym.Period:
					return (char) 0x002E;
				case XKeySym.Slash:
					return (char) 0x002F;
				case XKeySym.D0:
					return (char) 0x0030;
				case XKeySym.D1:
					return (char) 0x0031;
				case XKeySym.D2:
					return (char) 0x0032;
				case XKeySym.D3:
					return (char) 0x0033;
				case XKeySym.D4:
					return (char) 0x0034;
				case XKeySym.D5:
					return (char) 0x0035;
				case XKeySym.D6:
					return (char) 0x0036;
				case XKeySym.D7:
					return (char) 0x0037;
				case XKeySym.D8:
					return (char) 0x0038;
				case XKeySym.D9:
					return (char) 0x0039;
				case XKeySym.Colon:
					return (char) 0x003A;
				case XKeySym.Semicolon:
					return (char) 0x003B;
				case XKeySym.Less:
					return (char) 0x003C;
				case XKeySym.Equal:
					return (char) 0x003D;
				case XKeySym.Greater:
					return (char) 0x003E;
				case XKeySym.Question:
					return (char) 0x003F;
				case XKeySym.At:
					return (char) 0x0040;
				case XKeySym.A:
					return (char) 0x0041;
				case XKeySym.B:
					return (char) 0x0042;
				case XKeySym.C:
					return (char) 0x0043;
				case XKeySym.D:
					return (char) 0x0044;
				case XKeySym.E:
					return (char) 0x0045;
				case XKeySym.F:
					return (char) 0x0046;
				case XKeySym.G:
					return (char) 0x0047;
				case XKeySym.H:
					return (char) 0x0048;
				case XKeySym.I:
					return (char) 0x0049;
				case XKeySym.J:
					return (char) 0x004A;
				case XKeySym.K:
					return (char) 0x004B;
				case XKeySym.L:
					return (char) 0x004C;
				case XKeySym.M:
					return (char) 0x004D;
				case XKeySym.N:
					return (char) 0x004E;
				case XKeySym.O:
					return (char) 0x004F;
				case XKeySym.P:
					return (char) 0x0050;
				case XKeySym.Q:
					return (char) 0x0051;
				case XKeySym.R:
					return (char) 0x0052;
				case XKeySym.S:
					return (char) 0x0053;
				case XKeySym.T:
					return (char) 0x0054;
				case XKeySym.U:
					return (char) 0x0055;
				case XKeySym.V:
					return (char) 0x0056;
				case XKeySym.W:
					return (char) 0x0057;
				case XKeySym.X:
					return (char) 0x0058;
				case XKeySym.Y:
					return (char) 0x0059;
				case XKeySym.Z:
					return (char) 0x005A;
				case XKeySym.Bracketleft:
					return (char) 0x005B;
				case XKeySym.Backslash:
					return (char) 0x005C;
				case XKeySym.Bracketright:
					return (char) 0x005D;
				case XKeySym.Asciicircum:
					return (char) 0x005E;
				case XKeySym.Underscore:
					return (char) 0x005F;
				case XKeySym.Grave:
					return (char) 0x0060;
				case XKeySym.a:
					return (char) 0x0061;
				case XKeySym.b:
					return (char) 0x0062;
				case XKeySym.c:
					return (char) 0x0063;
				case XKeySym.d:
					return (char) 0x0064;
				case XKeySym.e:
					return (char) 0x0065;
				case XKeySym.f:
					return (char) 0x0066;
				case XKeySym.g:
					return (char) 0x0067;
				case XKeySym.h:
					return (char) 0x0068;
				case XKeySym.i:
					return (char) 0x0069;
				case XKeySym.j:
					return (char) 0x006A;
				case XKeySym.k:
					return (char) 0x006B;
				case XKeySym.l:
					return (char) 0x006C;
				case XKeySym.m:
					return (char) 0x006D;
				case XKeySym.n:
					return (char) 0x006E;
				case XKeySym.o:
					return (char) 0x006F;
				case XKeySym.p:
					return (char) 0x0070;
				case XKeySym.q:
					return (char) 0x0071;
				case XKeySym.r:
					return (char) 0x0072;
				case XKeySym.s:
					return (char) 0x0073;
				case XKeySym.t:
					return (char) 0x0074;
				case XKeySym.u:
					return (char) 0x0075;
				case XKeySym.v:
					return (char) 0x0076;
				case XKeySym.w:
					return (char) 0x0077;
				case XKeySym.x:
					return (char) 0x0078;
				case XKeySym.y:
					return (char) 0x0079;
				case XKeySym.z:
					return (char) 0x007A;
				case XKeySym.Braceleft:
					return (char) 0x007B;
				case XKeySym.Bar:
					return (char) 0x007C;
				case XKeySym.Braceright:
					return (char) 0x007D;
				case XKeySym.Asciitilde:
					return (char) 0x007E;
				case XKeySym.Nobreakspace:
					return (char) 0x00A0;
				case XKeySym.Exclamdown:
					return (char) 0x00A1;
				case XKeySym.Cent:
					return (char) 0x00A2;
				case XKeySym.Sterling:
					return (char) 0x00A3;
				case XKeySym.Currency:
					return (char) 0x00A4;
				case XKeySym.Yen:
					return (char) 0x00A5;
				case XKeySym.Brokenbar:
					return (char) 0x00A6;
				case XKeySym.Section:
					return (char) 0x00A7;
				case XKeySym.Diaeresis:
					return (char) 0x00A8;
				case XKeySym.Copyright:
					return (char) 0x00A9;
				case XKeySym.Ordfeminine:
					return (char) 0x00AA;
				case XKeySym.Guillemotleft:
					return (char) 0x00AB;
				case XKeySym.Notsign:
					return (char) 0x00AC;
				case XKeySym.Hyphen:
					return (char) 0x00AD;
				case XKeySym.Registered:
					return (char) 0x00AE;
				case XKeySym.Macron:
					return (char) 0x00AF;
				case XKeySym.Degree:
					return (char) 0x00B0;
				case XKeySym.Plusminus:
					return (char) 0x00B1;
				case XKeySym.Twosuperior:
					return (char) 0x00B2;
				case XKeySym.Threesuperior:
					return (char) 0x00B3;
				case XKeySym.Acute:
					return (char) 0x00B4;
				case XKeySym.Mu:
					return (char) 0x00B5;
				case XKeySym.Paragraph:
					return (char) 0x00B6;
				case XKeySym.Periodcentered:
					return (char) 0x00B7;
				case XKeySym.Cedilla:
					return (char) 0x00B8;
				case XKeySym.Onesuperior:
					return (char) 0x00B9;
				case XKeySym.Masculine:
					return (char) 0x00BA;
				case XKeySym.Guillemotright:
					return (char) 0x00BB;
				case XKeySym.Onequarter:
					return (char) 0x00BC;
				case XKeySym.Onehalf:
					return (char) 0x00BD;
				case XKeySym.Threequarters:
					return (char) 0x00BE;
				case XKeySym.Questiondown:
					return (char) 0x00BF;
				case XKeySym.Agrave:
					return (char) 0x00C0;
				case XKeySym.Aacute:
					return (char) 0x00C1;
				case XKeySym.Acircumflex:
					return (char) 0x00C2;
				case XKeySym.Atilde:
					return (char) 0x00C3;
				case XKeySym.Adiaeresis:
					return (char) 0x00C4;
				case XKeySym.Aring:
					return (char) 0x00C5;
				case XKeySym.AE:
					return (char) 0x00C6;
				case XKeySym.Ccedilla:
					return (char) 0x00C7;
				case XKeySym.Egrave:
					return (char) 0x00C8;
				case XKeySym.Eacute:
					return (char) 0x00C9;
				case XKeySym.Ecircumflex:
					return (char) 0x00CA;
				case XKeySym.Ediaeresis:
					return (char) 0x00CB;
				case XKeySym.Igrave:
					return (char) 0x00CC;
				case XKeySym.Iacute:
					return (char) 0x00CD;
				case XKeySym.Icircumflex:
					return (char) 0x00CE;
				case XKeySym.Idiaeresis:
					return (char) 0x00CF;
				case XKeySym.ETH:
					return (char) 0x00D0;
				case XKeySym.Ntilde:
					return (char) 0x00D1;
				case XKeySym.Ograve:
					return (char) 0x00D2;
				case XKeySym.Oacute:
					return (char) 0x00D3;
				case XKeySym.Ocircumflex:
					return (char) 0x00D4;
				case XKeySym.Otilde:
					return (char) 0x00D5;
				case XKeySym.Odiaeresis:
					return (char) 0x00D6;
				case XKeySym.Multiply:
					return (char) 0x00D7;
				case XKeySym.Oslash:
					return (char) 0x00D8;
				case XKeySym.Ugrave:
					return (char) 0x00D9;
				case XKeySym.Uacute:
					return (char) 0x00DA;
				case XKeySym.Ucircumflex:
					return (char) 0x00DB;
				case XKeySym.Udiaeresis:
					return (char) 0x00DC;
				case XKeySym.Yacute:
					return (char) 0x00DD;
				case XKeySym.THORN:
					return (char) 0x00DE;
				case XKeySym.ssharp:
					return (char) 0x00DF;
				case XKeySym.agrave:
					return (char) 0x00E0;
				case XKeySym.aacute:
					return (char) 0x00E1;
				case XKeySym.acircumflex:
					return (char) 0x00E2;
				case XKeySym.atilde:
					return (char) 0x00E3;
				case XKeySym.adiaeresis:
					return (char) 0x00E4;
				case XKeySym.aring:
					return (char) 0x00E5;
				case XKeySym.ae:
					return (char) 0x00E6;
				case XKeySym.ccedilla:
					return (char) 0x00E7;
				case XKeySym.egrave:
					return (char) 0x00E8;
				case XKeySym.eacute:
					return (char) 0x00E9;
				case XKeySym.ecircumflex:
					return (char) 0x00EA;
				case XKeySym.ediaeresis:
					return (char) 0x00EB;
				case XKeySym.igrave:
					return (char) 0x00EC;
				case XKeySym.iacute:
					return (char) 0x00ED;
				case XKeySym.icircumflex:
					return (char) 0x00EE;
				case XKeySym.idiaeresis:
					return (char) 0x00EF;
				case XKeySym.eth:
					return (char) 0x00F0;
				case XKeySym.ntilde:
					return (char) 0x00F1;
				case XKeySym.ograve:
					return (char) 0x00F2;
				case XKeySym.oacute:
					return (char) 0x00F3;
				case XKeySym.ocircumflex:
					return (char) 0x00F4;
				case XKeySym.otilde:
					return (char) 0x00F5;
				case XKeySym.odiaeresis:
					return (char) 0x00F6;
				case XKeySym.Division:
					return (char) 0x00F7;
				case XKeySym.oslash:
					return (char) 0x00F8;
				case XKeySym.ugrave:
					return (char) 0x00F9;
				case XKeySym.uacute:
					return (char) 0x00FA;
				case XKeySym.ucircumflex:
					return (char) 0x00FB;
				case XKeySym.udiaeresis:
					return (char) 0x00FC;
				case XKeySym.yacute:
					return (char) 0x00FD;
				case XKeySym.thorn:
					return (char) 0x00FE;
				case XKeySym.ydiaeresis:
					return (char) 0x00FF;
				case XKeySym.Aogonek:
					return (char) 0x0104;
				case XKeySym.Breve:
					return (char) 0x02D8;
				case XKeySym.Lstroke:
					return (char) 0x0141;
				case XKeySym.Lcaron:
					return (char) 0x013D;
				case XKeySym.Sacute:
					return (char) 0x015A;
				case XKeySym.Scaron:
					return (char) 0x0160;
				case XKeySym.Scedilla:
					return (char) 0x015E;
				case XKeySym.Tcaron:
					return (char) 0x0164;
				case XKeySym.Zacute:
					return (char) 0x0179;
				case XKeySym.Zcaron:
					return (char) 0x017D;
				case XKeySym.Zabovedot:
					return (char) 0x017B;
				case XKeySym.aogonek:
					return (char) 0x0105;
				case XKeySym.Ogonek:
					return (char) 0x02DB;
				case XKeySym.lstroke:
					return (char) 0x0142;
				case XKeySym.lcaron:
					return (char) 0x013E;
				case XKeySym.sacute:
					return (char) 0x015B;
				case XKeySym.Caron:
					return (char) 0x02C7;
				case XKeySym.scaron:
					return (char) 0x0161;
				case XKeySym.scedilla:
					return (char) 0x015F;
				case XKeySym.tcaron:
					return (char) 0x0165;
				case XKeySym.zacute:
					return (char) 0x017A;
				case XKeySym.Doubleacute:
					return (char) 0x02DD;
				case XKeySym.zcaron:
					return (char) 0x017E;
				case XKeySym.zabovedot:
					return (char) 0x017C;
				case XKeySym.Racute:
					return (char) 0x0154;
				case XKeySym.Abreve:
					return (char) 0x0102;
				case XKeySym.Lacute:
					return (char) 0x0139;
				case XKeySym.Cacute:
					return (char) 0x0106;
				case XKeySym.Ccaron:
					return (char) 0x010C;
				case XKeySym.Eogonek:
					return (char) 0x0118;
				case XKeySym.Ecaron:
					return (char) 0x011A;
				case XKeySym.Dcaron:
					return (char) 0x010E;
				case XKeySym.Dstroke:
					return (char) 0x0110;
				case XKeySym.Nacute:
					return (char) 0x0143;
				case XKeySym.Ncaron:
					return (char) 0x0147;
				case XKeySym.Odoubleacute:
					return (char) 0x0150;
				case XKeySym.Rcaron:
					return (char) 0x0158;
				case XKeySym.Uring:
					return (char) 0x016E;
				case XKeySym.Udoubleacute:
					return (char) 0x0170;
				case XKeySym.Tcedilla:
					return (char) 0x0162;
				case XKeySym.racute:
					return (char) 0x0155;
				case XKeySym.abreve:
					return (char) 0x0103;
				case XKeySym.lacute:
					return (char) 0x013A;
				case XKeySym.cacute:
					return (char) 0x0107;
				case XKeySym.ccaron:
					return (char) 0x010D;
				case XKeySym.eogonek:
					return (char) 0x0119;
				case XKeySym.ecaron:
					return (char) 0x011B;
				case XKeySym.dcaron:
					return (char) 0x010F;
				case XKeySym.dstroke:
					return (char) 0x0111;
				case XKeySym.nacute:
					return (char) 0x0144;
				case XKeySym.ncaron:
					return (char) 0x0148;
				case XKeySym.odoubleacute:
					return (char) 0x0151;
				case XKeySym.rcaron:
					return (char) 0x0159;
				case XKeySym.uring:
					return (char) 0x016F;
				case XKeySym.udoubleacute:
					return (char) 0x0171;
				case XKeySym.tcedilla:
					return (char) 0x0163;
				case XKeySym.Abovedot:
					return (char) 0x02D9;
				case XKeySym.Hstroke:
					return (char) 0x0126;
				case XKeySym.Hcircumflex:
					return (char) 0x0124;
				case XKeySym.Iabovedot:
					return (char) 0x0130;
				case XKeySym.Gbreve:
					return (char) 0x011E;
				case XKeySym.Jcircumflex:
					return (char) 0x0134;
				case XKeySym.hstroke:
					return (char) 0x0127;
				case XKeySym.hcircumflex:
					return (char) 0x0125;
				case XKeySym.idotless:
					return (char) 0x0131;
				case XKeySym.gbreve:
					return (char) 0x011F;
				case XKeySym.jcircumflex:
					return (char) 0x0135;
				case XKeySym.Cabovedot:
					return (char) 0x010A;
				case XKeySym.Ccircumflex:
					return (char) 0x0108;
				case XKeySym.Gabovedot:
					return (char) 0x0120;
				case XKeySym.Gcircumflex:
					return (char) 0x011C;
				case XKeySym.Ubreve:
					return (char) 0x016C;
				case XKeySym.Scircumflex:
					return (char) 0x015C;
				case XKeySym.cabovedot:
					return (char) 0x010B;
				case XKeySym.ccircumflex:
					return (char) 0x0109;
				case XKeySym.gabovedot:
					return (char) 0x0121;
				case XKeySym.gcircumflex:
					return (char) 0x011D;
				case XKeySym.ubreve:
					return (char) 0x016D;
				case XKeySym.scircumflex:
					return (char) 0x015D;
				case XKeySym.kra:
					return (char) 0x0138;
				case XKeySym.Rcedilla:
					return (char) 0x0156;
				case XKeySym.Itilde:
					return (char) 0x0128;
				case XKeySym.Lcedilla:
					return (char) 0x013B;
				case XKeySym.Emacron:
					return (char) 0x0112;
				case XKeySym.Gcedilla:
					return (char) 0x0122;
				case XKeySym.Tslash:
					return (char) 0x0166;
				case XKeySym.rcedilla:
					return (char) 0x0157;
				case XKeySym.itilde:
					return (char) 0x0129;
				case XKeySym.lcedilla:
					return (char) 0x013C;
				case XKeySym.emacron:
					return (char) 0x0113;
				case XKeySym.gcedilla:
					return (char) 0x0123;
				case XKeySym.tslash:
					return (char) 0x0167;
				case XKeySym.ENG:
					return (char) 0x014A;
				case XKeySym.eng:
					return (char) 0x014B;
				case XKeySym.Amacron:
					return (char) 0x0100;
				case XKeySym.Iogonek:
					return (char) 0x012E;
				case XKeySym.Eabovedot:
					return (char) 0x0116;
				case XKeySym.Imacron:
					return (char) 0x012A;
				case XKeySym.Ncedilla:
					return (char) 0x0145;
				case XKeySym.Omacron:
					return (char) 0x014C;
				case XKeySym.Kcedilla:
					return (char) 0x0136;
				case XKeySym.Uogonek:
					return (char) 0x0172;
				case XKeySym.Utilde:
					return (char) 0x0168;
				case XKeySym.Umacron:
					return (char) 0x016A;
				case XKeySym.amacron:
					return (char) 0x0101;
				case XKeySym.iogonek:
					return (char) 0x012F;
				case XKeySym.eabovedot:
					return (char) 0x0117;
				case XKeySym.imacron:
					return (char) 0x012B;
				case XKeySym.ncedilla:
					return (char) 0x0146;
				case XKeySym.omacron:
					return (char) 0x014D;
				case XKeySym.kcedilla:
					return (char) 0x0137;
				case XKeySym.uogonek:
					return (char) 0x0173;
				case XKeySym.utilde:
					return (char) 0x0169;
				case XKeySym.umacron:
					return (char) 0x016B;
				case XKeySym.Wcircumflex:
					return (char) 0x0174;
				case XKeySym.wcircumflex:
					return (char) 0x0175;
				case XKeySym.Ycircumflex:
					return (char) 0x0176;
				case XKeySym.ycircumflex:
					return (char) 0x0177;
				case XKeySym.Babovedot:
					return (char) 0x1E02;
				case XKeySym.babovedot:
					return (char) 0x1E03;
				case XKeySym.Dabovedot:
					return (char) 0x1E0A;
				case XKeySym.dabovedot:
					return (char) 0x1E0B;
				case XKeySym.Fabovedot:
					return (char) 0x1E1E;
				case XKeySym.fabovedot:
					return (char) 0x1E1F;
				case XKeySym.Mabovedot:
					return (char) 0x1E40;
				case XKeySym.mabovedot:
					return (char) 0x1E41;
				case XKeySym.Pabovedot:
					return (char) 0x1E56;
				case XKeySym.pabovedot:
					return (char) 0x1E57;
				case XKeySym.Sabovedot:
					return (char) 0x1E60;
				case XKeySym.sabovedot:
					return (char) 0x1E61;
				case XKeySym.Tabovedot:
					return (char) 0x1E6A;
				case XKeySym.tabovedot:
					return (char) 0x1E6B;
				case XKeySym.Wgrave:
					return (char) 0x1E80;
				case XKeySym.wgrave:
					return (char) 0x1E81;
				case XKeySym.Wacute:
					return (char) 0x1E82;
				case XKeySym.wacute:
					return (char) 0x1E83;
				case XKeySym.Wdiaeresis:
					return (char) 0x1E84;
				case XKeySym.wdiaeresis:
					return (char) 0x1E85;
				case XKeySym.Ygrave:
					return (char) 0x1EF2;
				case XKeySym.ygrave:
					return (char) 0x1EF3;
				case XKeySym.OE:
					return (char) 0x0152;
				case XKeySym.oe:
					return (char) 0x0153;
				case XKeySym.Ydiaeresis:
					return (char) 0x0178;
				case XKeySym.Overline:
					return (char) 0x203E;
				case XKeySym.KanaFullstop:
					return (char) 0x3002;
				case XKeySym.KanaOpeningbracket:
					return (char) 0x300C;
				case XKeySym.KanaClosingbracket:
					return (char) 0x300D;
				case XKeySym.KanaComma:
					return (char) 0x3001;
				case XKeySym.KanaConjunctive:
					return (char) 0x30FB;
				case XKeySym.KanaWO:
					return (char) 0x30F2;
				case XKeySym.kanaA:
					return (char) 0x30A1;
				case XKeySym.kanaI:
					return (char) 0x30A3;
				case XKeySym.kanaU:
					return (char) 0x30A5;
				case XKeySym.kanaE:
					return (char) 0x30A7;
				case XKeySym.kanaO:
					return (char) 0x30A9;
				case XKeySym.kanaYa:
					return (char) 0x30E3;
				case XKeySym.kanaYu:
					return (char) 0x30E5;
				case XKeySym.kanaYo:
					return (char) 0x30E7;
				case XKeySym.kanaTsu:
					return (char) 0x30C3;
				case XKeySym.Prolongedsound:
					return (char) 0x30FC;
				case XKeySym.KanaA:
					return (char) 0x30A2;
				case XKeySym.KanaI:
					return (char) 0x30A4;
				case XKeySym.KanaU:
					return (char) 0x30A6;
				case XKeySym.KanaE:
					return (char) 0x30A8;
				case XKeySym.KanaO:
					return (char) 0x30AA;
				case XKeySym.KanaKA:
					return (char) 0x30AB;
				case XKeySym.KanaKI:
					return (char) 0x30AD;
				case XKeySym.KanaKU:
					return (char) 0x30AF;
				case XKeySym.KanaKE:
					return (char) 0x30B1;
				case XKeySym.KanaKO:
					return (char) 0x30B3;
				case XKeySym.KanaSA:
					return (char) 0x30B5;
				case XKeySym.KanaSHI:
					return (char) 0x30B7;
				case XKeySym.KanaSU:
					return (char) 0x30B9;
				case XKeySym.KanaSE:
					return (char) 0x30BB;
				case XKeySym.KanaSO:
					return (char) 0x30BD;
				case XKeySym.KanaTA:
					return (char) 0x30BF;
				case XKeySym.KanaCHI:
					return (char) 0x30C1;
				case XKeySym.KanaTSU:
					return (char) 0x30C4;
				case XKeySym.KanaTE:
					return (char) 0x30C6;
				case XKeySym.KanaTO:
					return (char) 0x30C8;
				case XKeySym.KanaNA:
					return (char) 0x30CA;
				case XKeySym.KanaNI:
					return (char) 0x30CB;
				case XKeySym.KanaNU:
					return (char) 0x30CC;
				case XKeySym.KanaNE:
					return (char) 0x30CD;
				case XKeySym.KanaNO:
					return (char) 0x30CE;
				case XKeySym.KanaHA:
					return (char) 0x30CF;
				case XKeySym.KanaHI:
					return (char) 0x30D2;
				case XKeySym.KanaFU:
					return (char) 0x30D5;
				case XKeySym.KanaHE:
					return (char) 0x30D8;
				case XKeySym.KanaHO:
					return (char) 0x30DB;
				case XKeySym.KanaMA:
					return (char) 0x30DE;
				case XKeySym.KanaMI:
					return (char) 0x30DF;
				case XKeySym.KanaMU:
					return (char) 0x30E0;
				case XKeySym.KanaME:
					return (char) 0x30E1;
				case XKeySym.KanaMO:
					return (char) 0x30E2;
				case XKeySym.KanaYA:
					return (char) 0x30E4;
				case XKeySym.KanaYU:
					return (char) 0x30E6;
				case XKeySym.KanaYO:
					return (char) 0x30E8;
				case XKeySym.KanaRA:
					return (char) 0x30E9;
				case XKeySym.KanaRI:
					return (char) 0x30EA;
				case XKeySym.KanaRU:
					return (char) 0x30EB;
				case XKeySym.KanaRE:
					return (char) 0x30EC;
				case XKeySym.KanaRO:
					return (char) 0x30ED;
				case XKeySym.KanaWA:
					return (char) 0x30EF;
				case XKeySym.KanaN:
					return (char) 0x30F3;
				case XKeySym.Voicedsound:
					return (char) 0x309B;
				case XKeySym.Semivoicedsound:
					return (char) 0x309C;
				case XKeySym.Farsi0:
					return (char) 0x06F0;
				case XKeySym.Farsi1:
					return (char) 0x06F1;
				case XKeySym.Farsi2:
					return (char) 0x06F2;
				case XKeySym.Farsi3:
					return (char) 0x06F3;
				case XKeySym.Farsi4:
					return (char) 0x06F4;
				case XKeySym.Farsi5:
					return (char) 0x06F5;
				case XKeySym.Farsi6:
					return (char) 0x06F6;
				case XKeySym.Farsi7:
					return (char) 0x06F7;
				case XKeySym.Farsi8:
					return (char) 0x06F8;
				case XKeySym.Farsi9:
					return (char) 0x06F9;
				case XKeySym.ArabicPercent:
					return (char) 0x066A;
				case XKeySym.ArabicSuperscriptAlef:
					return (char) 0x0670;
				case XKeySym.ArabicTteh:
					return (char) 0x0679;
				case XKeySym.ArabicPeh:
					return (char) 0x067E;
				case XKeySym.ArabicTcheh:
					return (char) 0x0686;
				case XKeySym.ArabicDdal:
					return (char) 0x0688;
				case XKeySym.ArabicRreh:
					return (char) 0x0691;
				case XKeySym.ArabicComma:
					return (char) 0x060C;
				case XKeySym.ArabicFullstop:
					return (char) 0x06D4;
				case XKeySym.Arabic0:
					return (char) 0x0660;
				case XKeySym.Arabic1:
					return (char) 0x0661;
				case XKeySym.Arabic2:
					return (char) 0x0662;
				case XKeySym.Arabic3:
					return (char) 0x0663;
				case XKeySym.Arabic4:
					return (char) 0x0664;
				case XKeySym.Arabic5:
					return (char) 0x0665;
				case XKeySym.Arabic6:
					return (char) 0x0666;
				case XKeySym.Arabic7:
					return (char) 0x0667;
				case XKeySym.Arabic8:
					return (char) 0x0668;
				case XKeySym.Arabic9:
					return (char) 0x0669;
				case XKeySym.ArabicSemicolon:
					return (char) 0x061B;
				case XKeySym.ArabicQuestionMark:
					return (char) 0x061F;
				case XKeySym.ArabicHamza:
					return (char) 0x0621;
				case XKeySym.ArabicMaddaonalef:
					return (char) 0x0622;
				case XKeySym.ArabicHamzaonalef:
					return (char) 0x0623;
				case XKeySym.ArabicHamzaonwaw:
					return (char) 0x0624;
				case XKeySym.ArabicHamzaunderalef:
					return (char) 0x0625;
				case XKeySym.ArabicHamzaonyeh:
					return (char) 0x0626;
				case XKeySym.ArabicAlef:
					return (char) 0x0627;
				case XKeySym.ArabicBeh:
					return (char) 0x0628;
				case XKeySym.ArabicTehmarbuta:
					return (char) 0x0629;
				case XKeySym.ArabicTeh:
					return (char) 0x062A;
				case XKeySym.ArabicTheh:
					return (char) 0x062B;
				case XKeySym.ArabicJeem:
					return (char) 0x062C;
				case XKeySym.ArabicHah:
					return (char) 0x062D;
				case XKeySym.ArabicKhah:
					return (char) 0x062E;
				case XKeySym.ArabicDal:
					return (char) 0x062F;
				case XKeySym.ArabicThal:
					return (char) 0x0630;
				case XKeySym.ArabicRa:
					return (char) 0x0631;
				case XKeySym.ArabicZain:
					return (char) 0x0632;
				case XKeySym.ArabicSeen:
					return (char) 0x0633;
				case XKeySym.ArabicSheen:
					return (char) 0x0634;
				case XKeySym.ArabicSad:
					return (char) 0x0635;
				case XKeySym.ArabicDad:
					return (char) 0x0636;
				case XKeySym.ArabicTah:
					return (char) 0x0637;
				case XKeySym.ArabicZah:
					return (char) 0x0638;
				case XKeySym.ArabicAin:
					return (char) 0x0639;
				case XKeySym.ArabicGhain:
					return (char) 0x063A;
				case XKeySym.ArabicTatweel:
					return (char) 0x0640;
				case XKeySym.ArabicFeh:
					return (char) 0x0641;
				case XKeySym.ArabicQaf:
					return (char) 0x0642;
				case XKeySym.ArabicKaf:
					return (char) 0x0643;
				case XKeySym.ArabicLam:
					return (char) 0x0644;
				case XKeySym.ArabicMeem:
					return (char) 0x0645;
				case XKeySym.ArabicNoon:
					return (char) 0x0646;
				case XKeySym.ArabicHa:
					return (char) 0x0647;
				case XKeySym.ArabicWaw:
					return (char) 0x0648;
				case XKeySym.ArabicAlefmaksura:
					return (char) 0x0649;
				case XKeySym.ArabicYeh:
					return (char) 0x064A;
				case XKeySym.ArabicFathatan:
					return (char) 0x064B;
				case XKeySym.ArabicDammatan:
					return (char) 0x064C;
				case XKeySym.ArabicKasratan:
					return (char) 0x064D;
				case XKeySym.ArabicFatha:
					return (char) 0x064E;
				case XKeySym.ArabicDamma:
					return (char) 0x064F;
				case XKeySym.ArabicKasra:
					return (char) 0x0650;
				case XKeySym.ArabicShadda:
					return (char) 0x0651;
				case XKeySym.ArabicSukun:
					return (char) 0x0652;
				case XKeySym.ArabicMaddaAbove:
					return (char) 0x0653;
				case XKeySym.ArabicHamzaAbove:
					return (char) 0x0654;
				case XKeySym.ArabicHamzaBelow:
					return (char) 0x0655;
				case XKeySym.ArabicJeh:
					return (char) 0x0698;
				case XKeySym.ArabicVeh:
					return (char) 0x06A4;
				case XKeySym.ArabicKeheh:
					return (char) 0x06A9;
				case XKeySym.ArabicGaf:
					return (char) 0x06AF;
				case XKeySym.ArabicNoonGhunna:
					return (char) 0x06BA;
				case XKeySym.ArabicHehDoachashmee:
					return (char) 0x06BE;
				case XKeySym.FarsiYeh:
					return (char) 0x06CC;
				case XKeySym.ArabicYehBaree:
					return (char) 0x06D2;
				case XKeySym.ArabicHehGoal:
					return (char) 0x06C1;
				case XKeySym.CyrillicGHEBar:
					return (char) 0x0492;
				case XKeySym.cyrillicGheBar:
					return (char) 0x0493;
				case XKeySym.CyrillicZHEDescender:
					return (char) 0x0496;
				case XKeySym.cyrillicZheDescender:
					return (char) 0x0497;
				case XKeySym.CyrillicKADescender:
					return (char) 0x049A;
				case XKeySym.cyrillicKaDescender:
					return (char) 0x049B;
				case XKeySym.CyrillicKAVertstroke:
					return (char) 0x049C;
				case XKeySym.cyrillicKaVertstroke:
					return (char) 0x049D;
				case XKeySym.CyrillicENDescender:
					return (char) 0x04A2;
				case XKeySym.cyrillicEnDescender:
					return (char) 0x04A3;
				case XKeySym.CyrillicUStraight:
					return (char) 0x04AE;
				case XKeySym.cyrillicUStraight:
					return (char) 0x04AF;
				case XKeySym.CyrillicUStraightBar:
					return (char) 0x04B0;
				case XKeySym.cyrillicUStraightBar:
					return (char) 0x04B1;
				case XKeySym.CyrillicHADescender:
					return (char) 0x04B2;
				case XKeySym.cyrillicHaDescender:
					return (char) 0x04B3;
				case XKeySym.CyrillicCHEDescender:
					return (char) 0x04B6;
				case XKeySym.cyrillicCheDescender:
					return (char) 0x04B7;
				case XKeySym.CyrillicCHEVertstroke:
					return (char) 0x04B8;
				case XKeySym.cyrillicCheVertstroke:
					return (char) 0x04B9;
				case XKeySym.CyrillicSHHA:
					return (char) 0x04BA;
				case XKeySym.cyrillicShha:
					return (char) 0x04BB;
				case XKeySym.CyrillicSCHWA:
					return (char) 0x04D8;
				case XKeySym.cyrillicSchwa:
					return (char) 0x04D9;
				case XKeySym.CyrillicIMacron:
					return (char) 0x04E2;
				case XKeySym.cyrillicIMacron:
					return (char) 0x04E3;
				case XKeySym.CyrillicOBar:
					return (char) 0x04E8;
				case XKeySym.cyrillicOBar:
					return (char) 0x04E9;
				case XKeySym.CyrillicUMacron:
					return (char) 0x04EE;
				case XKeySym.cyrillicUMacron:
					return (char) 0x04EF;
				case XKeySym.serbianDje:
					return (char) 0x0452;
				case XKeySym.macedoniaGje:
					return (char) 0x0453;
				case XKeySym.cyrillicIo:
					return (char) 0x0451;
				case XKeySym.ukrainianIe:
					return (char) 0x0454;
				case XKeySym.macedoniaDse:
					return (char) 0x0455;
				case XKeySym.ukrainianI:
					return (char) 0x0456;
				case XKeySym.ukrainianYi:
					return (char) 0x0457;
				case XKeySym.cyrillicJe:
					return (char) 0x0458;
				case XKeySym.cyrillicLje:
					return (char) 0x0459;
				case XKeySym.cyrillicNje:
					return (char) 0x045A;
				case XKeySym.serbianTshe:
					return (char) 0x045B;
				case XKeySym.macedoniaKje:
					return (char) 0x045C;
				case XKeySym.ukrainianGheWithUpturn:
					return (char) 0x0491;
				case XKeySym.byelorussianShortu:
					return (char) 0x045E;
				case XKeySym.cyrillicDzhe:
					return (char) 0x045F;
				case XKeySym.Numerosign:
					return (char) 0x2116;
				case XKeySym.SerbianDJE:
					return (char) 0x0402;
				case XKeySym.MacedoniaGJE:
					return (char) 0x0403;
				case XKeySym.CyrillicIO:
					return (char) 0x0401;
				case XKeySym.UkrainianIE:
					return (char) 0x0404;
				case XKeySym.MacedoniaDSE:
					return (char) 0x0405;
				case XKeySym.UkrainianI:
					return (char) 0x0406;
				case XKeySym.UkrainianYI:
					return (char) 0x0407;
				case XKeySym.CyrillicJE:
					return (char) 0x0408;
				case XKeySym.CyrillicLJE:
					return (char) 0x0409;
				case XKeySym.CyrillicNJE:
					return (char) 0x040A;
				case XKeySym.SerbianTSHE:
					return (char) 0x040B;
				case XKeySym.MacedoniaKJE:
					return (char) 0x040C;
				case XKeySym.UkrainianGHEWITHUPTURN:
					return (char) 0x0490;
				case XKeySym.ByelorussianSHORTU:
					return (char) 0x040E;
				case XKeySym.CyrillicDZHE:
					return (char) 0x040F;
				case XKeySym.cyrillicYu:
					return (char) 0x044E;
				case XKeySym.cyrillicA:
					return (char) 0x0430;
				case XKeySym.cyrillicBe:
					return (char) 0x0431;
				case XKeySym.cyrillicTse:
					return (char) 0x0446;
				case XKeySym.cyrillicDe:
					return (char) 0x0434;
				case XKeySym.cyrillicIe:
					return (char) 0x0435;
				case XKeySym.cyrillicEf:
					return (char) 0x0444;
				case XKeySym.cyrillicGhe:
					return (char) 0x0433;
				case XKeySym.cyrillicHa:
					return (char) 0x0445;
				case XKeySym.cyrillicI:
					return (char) 0x0438;
				case XKeySym.cyrillicShorti:
					return (char) 0x0439;
				case XKeySym.cyrillicKa:
					return (char) 0x043A;
				case XKeySym.cyrillicEl:
					return (char) 0x043B;
				case XKeySym.cyrillicEm:
					return (char) 0x043C;
				case XKeySym.cyrillicEn:
					return (char) 0x043D;
				case XKeySym.cyrillicO:
					return (char) 0x043E;
				case XKeySym.cyrillicPe:
					return (char) 0x043F;
				case XKeySym.cyrillicYa:
					return (char) 0x044F;
				case XKeySym.cyrillicEr:
					return (char) 0x0440;
				case XKeySym.cyrillicEs:
					return (char) 0x0441;
				case XKeySym.cyrillicTe:
					return (char) 0x0442;
				case XKeySym.cyrillicU:
					return (char) 0x0443;
				case XKeySym.cyrillicZhe:
					return (char) 0x0436;
				case XKeySym.cyrillicVe:
					return (char) 0x0432;
				case XKeySym.cyrillicSoftsign:
					return (char) 0x044C;
				case XKeySym.cyrillicYeru:
					return (char) 0x044B;
				case XKeySym.cyrillicZe:
					return (char) 0x0437;
				case XKeySym.cyrillicSha:
					return (char) 0x0448;
				case XKeySym.cyrillicE:
					return (char) 0x044D;
				case XKeySym.cyrillicShcha:
					return (char) 0x0449;
				case XKeySym.cyrillicChe:
					return (char) 0x0447;
				case XKeySym.cyrillicHardsign:
					return (char) 0x044A;
				case XKeySym.CyrillicYU:
					return (char) 0x042E;
				case XKeySym.CyrillicA:
					return (char) 0x0410;
				case XKeySym.CyrillicBE:
					return (char) 0x0411;
				case XKeySym.CyrillicTSE:
					return (char) 0x0426;
				case XKeySym.CyrillicDE:
					return (char) 0x0414;
				case XKeySym.CyrillicIE:
					return (char) 0x0415;
				case XKeySym.CyrillicEF:
					return (char) 0x0424;
				case XKeySym.CyrillicGHE:
					return (char) 0x0413;
				case XKeySym.CyrillicHA:
					return (char) 0x0425;
				case XKeySym.CyrillicI:
					return (char) 0x0418;
				case XKeySym.CyrillicSHORTI:
					return (char) 0x0419;
				case XKeySym.CyrillicKA:
					return (char) 0x041A;
				case XKeySym.CyrillicEL:
					return (char) 0x041B;
				case XKeySym.CyrillicEM:
					return (char) 0x041C;
				case XKeySym.CyrillicEN:
					return (char) 0x041D;
				case XKeySym.CyrillicO:
					return (char) 0x041E;
				case XKeySym.CyrillicPE:
					return (char) 0x041F;
				case XKeySym.CyrillicYA:
					return (char) 0x042F;
				case XKeySym.CyrillicER:
					return (char) 0x0420;
				case XKeySym.CyrillicES:
					return (char) 0x0421;
				case XKeySym.CyrillicTE:
					return (char) 0x0422;
				case XKeySym.CyrillicU:
					return (char) 0x0423;
				case XKeySym.CyrillicZHE:
					return (char) 0x0416;
				case XKeySym.CyrillicVE:
					return (char) 0x0412;
				case XKeySym.CyrillicSOFTSIGN:
					return (char) 0x042C;
				case XKeySym.CyrillicYERU:
					return (char) 0x042B;
				case XKeySym.CyrillicZE:
					return (char) 0x0417;
				case XKeySym.CyrillicSHA:
					return (char) 0x0428;
				case XKeySym.CyrillicE:
					return (char) 0x042D;
				case XKeySym.CyrillicSHCHA:
					return (char) 0x0429;
				case XKeySym.CyrillicCHE:
					return (char) 0x0427;
				case XKeySym.CyrillicHARDSIGN:
					return (char) 0x042A;
				case XKeySym.GreekALPHAaccent:
					return (char) 0x0386;
				case XKeySym.GreekEPSILONaccent:
					return (char) 0x0388;
				case XKeySym.GreekETAaccent:
					return (char) 0x0389;
				case XKeySym.GreekIOTAaccent:
					return (char) 0x038A;
				case XKeySym.GreekIOTAdieresis:
					return (char) 0x03AA;
				case XKeySym.GreekOMICRONaccent:
					return (char) 0x038C;
				case XKeySym.GreekUPSILONaccent:
					return (char) 0x038E;
				case XKeySym.GreekUPSILONdieresis:
					return (char) 0x03AB;
				case XKeySym.GreekOMEGAaccent:
					return (char) 0x038F;
				case XKeySym.GreekAccentdieresis:
					return (char) 0x0385;
				case XKeySym.GreekHorizbar:
					return (char) 0x2015;
				case XKeySym.greekAlphaaccent:
					return (char) 0x03AC;
				case XKeySym.greekEpsilonaccent:
					return (char) 0x03AD;
				case XKeySym.greekEtaaccent:
					return (char) 0x03AE;
				case XKeySym.greekIotaaccent:
					return (char) 0x03AF;
				case XKeySym.greekIotadieresis:
					return (char) 0x03CA;
				case XKeySym.greekIotaaccentdieresis:
					return (char) 0x0390;
				case XKeySym.greekOmicronaccent:
					return (char) 0x03CC;
				case XKeySym.greekUpsilonaccent:
					return (char) 0x03CD;
				case XKeySym.greekUpsilondieresis:
					return (char) 0x03CB;
				case XKeySym.greekUpsilonaccentdieresis:
					return (char) 0x03B0;
				case XKeySym.greekOmegaaccent:
					return (char) 0x03CE;
				case XKeySym.GreekALPHA:
					return (char) 0x0391;
				case XKeySym.GreekBETA:
					return (char) 0x0392;
				case XKeySym.GreekGAMMA:
					return (char) 0x0393;
				case XKeySym.GreekDELTA:
					return (char) 0x0394;
				case XKeySym.GreekEPSILON:
					return (char) 0x0395;
				case XKeySym.GreekZETA:
					return (char) 0x0396;
				case XKeySym.GreekETA:
					return (char) 0x0397;
				case XKeySym.GreekTHETA:
					return (char) 0x0398;
				case XKeySym.GreekIOTA:
					return (char) 0x0399;
				case XKeySym.GreekKAPPA:
					return (char) 0x039A;
				case XKeySym.GreekLAMDA:
					return (char) 0x039B;
				case XKeySym.GreekMU:
					return (char) 0x039C;
				case XKeySym.GreekNU:
					return (char) 0x039D;
				case XKeySym.GreekXI:
					return (char) 0x039E;
				case XKeySym.GreekOMICRON:
					return (char) 0x039F;
				case XKeySym.GreekPI:
					return (char) 0x03A0;
				case XKeySym.GreekRHO:
					return (char) 0x03A1;
				case XKeySym.GreekSIGMA:
					return (char) 0x03A3;
				case XKeySym.GreekTAU:
					return (char) 0x03A4;
				case XKeySym.GreekUPSILON:
					return (char) 0x03A5;
				case XKeySym.GreekPHI:
					return (char) 0x03A6;
				case XKeySym.GreekCHI:
					return (char) 0x03A7;
				case XKeySym.GreekPSI:
					return (char) 0x03A8;
				case XKeySym.GreekOMEGA:
					return (char) 0x03A9;
				case XKeySym.greekAlpha:
					return (char) 0x03B1;
				case XKeySym.greekBeta:
					return (char) 0x03B2;
				case XKeySym.greekGamma:
					return (char) 0x03B3;
				case XKeySym.greekDelta:
					return (char) 0x03B4;
				case XKeySym.greekEpsilon:
					return (char) 0x03B5;
				case XKeySym.greekZeta:
					return (char) 0x03B6;
				case XKeySym.greekEta:
					return (char) 0x03B7;
				case XKeySym.greekTheta:
					return (char) 0x03B8;
				case XKeySym.greekIota:
					return (char) 0x03B9;
				case XKeySym.greekKappa:
					return (char) 0x03BA;
				case XKeySym.greekLamda:
					return (char) 0x03BB;
				case XKeySym.greekMu:
					return (char) 0x03BC;
				case XKeySym.greekNu:
					return (char) 0x03BD;
				case XKeySym.greekXi:
					return (char) 0x03BE;
				case XKeySym.greekOmicron:
					return (char) 0x03BF;
				case XKeySym.greekPi:
					return (char) 0x03C0;
				case XKeySym.greekRho:
					return (char) 0x03C1;
				case XKeySym.greekSigma:
					return (char) 0x03C3;
				case XKeySym.greekFinalsmallsigma:
					return (char) 0x03C2;
				case XKeySym.greekTau:
					return (char) 0x03C4;
				case XKeySym.greekUpsilon:
					return (char) 0x03C5;
				case XKeySym.greekPhi:
					return (char) 0x03C6;
				case XKeySym.greekChi:
					return (char) 0x03C7;
				case XKeySym.greekPsi:
					return (char) 0x03C8;
				case XKeySym.greekOmega:
					return (char) 0x03C9;
				case XKeySym.Leftradical:
					return (char) 0x23B7;
				case XKeySym.Topintegral:
					return (char) 0x2320;
				case XKeySym.Botintegral:
					return (char) 0x2321;
				case XKeySym.Topleftsqbracket:
					return (char) 0x23A1;
				case XKeySym.botleftsqbracket:
					return (char) 0x23A3;
				case XKeySym.Toprightsqbracket:
					return (char) 0x23A4;
				case XKeySym.botrightsqbracket:
					return (char) 0x23A6;
				case XKeySym.Topleftparens:
					return (char) 0x239B;
				case XKeySym.botleftparens:
					return (char) 0x239D;
				case XKeySym.Toprightparens:
					return (char) 0x239E;
				case XKeySym.botrightparens:
					return (char) 0x23A0;
				case XKeySym.Leftmiddlecurlybrace:
					return (char) 0x23A8;
				case XKeySym.Rightmiddlecurlybrace:
					return (char) 0x23AC;
				case XKeySym.Lessthanequal:
					return (char) 0x2264;
				case XKeySym.Notequal:
					return (char) 0x2260;
				case XKeySym.Greaterthanequal:
					return (char) 0x2265;
				case XKeySym.Integral:
					return (char) 0x222B;
				case XKeySym.Therefore:
					return (char) 0x2234;
				case XKeySym.Variation:
					return (char) 0x221D;
				case XKeySym.Infinity:
					return (char) 0x221E;
				case XKeySym.Nabla:
					return (char) 0x2207;
				case XKeySym.Approximate:
					return (char) 0x223C;
				case XKeySym.Similarequal:
					return (char) 0x2243;
				case XKeySym.Ifonlyif:
					return (char) 0x21D4;
				case XKeySym.Implies:
					return (char) 0x21D2;
				case XKeySym.Identical:
					return (char) 0x2261;
				case XKeySym.Includedin:
					return (char) 0x2282;
				case XKeySym.Includes:
					return (char) 0x2283;
				case XKeySym.Intersection:
					return (char) 0x2229;
				case XKeySym.Union:
					return (char) 0x222A;
				case XKeySym.Logicaland:
					return (char) 0x2227;
				case XKeySym.Logicalor:
					return (char) 0x2228;
				case XKeySym.Partialderivative:
					return (char) 0x2202;
				case XKeySym.function:
					return (char) 0x0192;
				case XKeySym.Leftarrow:
					return (char) 0x2190;
				case XKeySym.Uparrow:
					return (char) 0x2191;
				case XKeySym.Rightarrow:
					return (char) 0x2192;
				case XKeySym.Downarrow:
					return (char) 0x2193;
				case XKeySym.Soliddiamond:
					return (char) 0x25C6;
				case XKeySym.Checkerboard:
					return (char) 0x2592;
				case XKeySym.Ht:
					return (char) 0x2409;
				case XKeySym.Ff:
					return (char) 0x240C;
				case XKeySym.Cr:
					return (char) 0x240D;
				case XKeySym.Lf:
					return (char) 0x240A;
				case XKeySym.Nl:
					return (char) 0x2424;
				case XKeySym.Vt:
					return (char) 0x240B;
				case XKeySym.Lowrightcorner:
					return (char) 0x2518;
				case XKeySym.Uprightcorner:
					return (char) 0x2510;
				case XKeySym.Upleftcorner:
					return (char) 0x250C;
				case XKeySym.Lowleftcorner:
					return (char) 0x2514;
				case XKeySym.Crossinglines:
					return (char) 0x253C;
				case XKeySym.Horizlinescan1:
					return (char) 0x23BA;
				case XKeySym.Horizlinescan3:
					return (char) 0x23BB;
				case XKeySym.Horizlinescan5:
					return (char) 0x2500;
				case XKeySym.Horizlinescan7:
					return (char) 0x23BC;
				case XKeySym.Horizlinescan9:
					return (char) 0x23BD;
				case XKeySym.Leftt:
					return (char) 0x251C;
				case XKeySym.Rightt:
					return (char) 0x2524;
				case XKeySym.Bott:
					return (char) 0x2534;
				case XKeySym.Topt:
					return (char) 0x252C;
				case XKeySym.Vertbar:
					return (char) 0x2502;
				case XKeySym.Emspace:
					return (char) 0x2003;
				case XKeySym.Enspace:
					return (char) 0x2002;
				case XKeySym.Em3space:
					return (char) 0x2004;
				case XKeySym.Em4space:
					return (char) 0x2005;
				case XKeySym.Digitspace:
					return (char) 0x2007;
				case XKeySym.Punctspace:
					return (char) 0x2008;
				case XKeySym.Thinspace:
					return (char) 0x2009;
				case XKeySym.Hairspace:
					return (char) 0x200A;
				case XKeySym.Emdash:
					return (char) 0x2014;
				case XKeySym.Endash:
					return (char) 0x2013;
				case XKeySym.Ellipsis:
					return (char) 0x2026;
				case XKeySym.Doubbaselinedot:
					return (char) 0x2025;
				case XKeySym.Onethird:
					return (char) 0x2153;
				case XKeySym.Twothirds:
					return (char) 0x2154;
				case XKeySym.Onefifth:
					return (char) 0x2155;
				case XKeySym.Twofifths:
					return (char) 0x2156;
				case XKeySym.Threefifths:
					return (char) 0x2157;
				case XKeySym.Fourfifths:
					return (char) 0x2158;
				case XKeySym.Onesixth:
					return (char) 0x2159;
				case XKeySym.Fivesixths:
					return (char) 0x215A;
				case XKeySym.Careof:
					return (char) 0x2105;
				case XKeySym.Figdash:
					return (char) 0x2012;
				case XKeySym.Oneeighth:
					return (char) 0x215B;
				case XKeySym.Threeeighths:
					return (char) 0x215C;
				case XKeySym.Fiveeighths:
					return (char) 0x215D;
				case XKeySym.Seveneighths:
					return (char) 0x215E;
				case XKeySym.Trademark:
					return (char) 0x2122;
				case XKeySym.Leftsinglequotemark:
					return (char) 0x2018;
				case XKeySym.Rightsinglequotemark:
					return (char) 0x2019;
				case XKeySym.Leftdoublequotemark:
					return (char) 0x201C;
				case XKeySym.Rightdoublequotemark:
					return (char) 0x201D;
				case XKeySym.Prescription:
					return (char) 0x211E;
				case XKeySym.Permille:
					return (char) 0x2030;
				case XKeySym.Minutes:
					return (char) 0x2032;
				case XKeySym.Seconds:
					return (char) 0x2033;
				case XKeySym.Latincross:
					return (char) 0x271D;
				case XKeySym.Club:
					return (char) 0x2663;
				case XKeySym.Diamond:
					return (char) 0x2666;
				case XKeySym.Heart:
					return (char) 0x2665;
				case XKeySym.Maltesecross:
					return (char) 0x2720;
				case XKeySym.Dagger:
					return (char) 0x2020;
				case XKeySym.Doubledagger:
					return (char) 0x2021;
				case XKeySym.Checkmark:
					return (char) 0x2713;
				case XKeySym.Ballotcross:
					return (char) 0x2717;
				case XKeySym.Musicalsharp:
					return (char) 0x266F;
				case XKeySym.Musicalflat:
					return (char) 0x266D;
				case XKeySym.Malesymbol:
					return (char) 0x2642;
				case XKeySym.Femalesymbol:
					return (char) 0x2640;
				case XKeySym.Telephone:
					return (char) 0x260E;
				case XKeySym.Telephonerecorder:
					return (char) 0x2315;
				case XKeySym.Phonographcopyright:
					return (char) 0x2117;
				case XKeySym.Caret:
					return (char) 0x2038;
				case XKeySym.Singlelowquotemark:
					return (char) 0x201A;
				case XKeySym.Doublelowquotemark:
					return (char) 0x201E;
				case XKeySym.Downtack:
					return (char) 0x22A4;
				case XKeySym.Downstile:
					return (char) 0x230A;
				case XKeySym.Jot:
					return (char) 0x2218;
				case XKeySym.Quad:
					return (char) 0x2395;
				case XKeySym.Uptack:
					return (char) 0x22A5;
				case XKeySym.Circle:
					return (char) 0x25CB;
				case XKeySym.Upstile:
					return (char) 0x2308;
				case XKeySym.Lefttack:
					return (char) 0x22A3;
				case XKeySym.Righttack:
					return (char) 0x22A2;
				case XKeySym.HebrewDoublelowline:
					return (char) 0x2017;
				case XKeySym.HebrewAleph:
					return (char) 0x05D0;
				case XKeySym.HebrewBet:
					return (char) 0x05D1;
				case XKeySym.HebrewGimel:
					return (char) 0x05D2;
				case XKeySym.HebrewDalet:
					return (char) 0x05D3;
				case XKeySym.HebrewHe:
					return (char) 0x05D4;
				case XKeySym.HebrewWaw:
					return (char) 0x05D5;
				case XKeySym.HebrewZain:
					return (char) 0x05D6;
				case XKeySym.HebrewChet:
					return (char) 0x05D7;
				case XKeySym.HebrewTet:
					return (char) 0x05D8;
				case XKeySym.HebrewYod:
					return (char) 0x05D9;
				case XKeySym.HebrewFinalkaph:
					return (char) 0x05DA;
				case XKeySym.HebrewKaph:
					return (char) 0x05DB;
				case XKeySym.HebrewLamed:
					return (char) 0x05DC;
				case XKeySym.HebrewFinalmem:
					return (char) 0x05DD;
				case XKeySym.HebrewMem:
					return (char) 0x05DE;
				case XKeySym.HebrewFinalnun:
					return (char) 0x05DF;
				case XKeySym.HebrewNun:
					return (char) 0x05E0;
				case XKeySym.HebrewSamech:
					return (char) 0x05E1;
				case XKeySym.HebrewAyin:
					return (char) 0x05E2;
				case XKeySym.HebrewFinalpe:
					return (char) 0x05E3;
				case XKeySym.HebrewPe:
					return (char) 0x05E4;
				case XKeySym.HebrewFinalzade:
					return (char) 0x05E5;
				case XKeySym.HebrewZade:
					return (char) 0x05E6;
				case XKeySym.HebrewQoph:
					return (char) 0x05E7;
				case XKeySym.HebrewResh:
					return (char) 0x05E8;
				case XKeySym.HebrewShin:
					return (char) 0x05E9;
				case XKeySym.HebrewTaw:
					return (char) 0x05EA;
				case XKeySym.ThaiKokai:
					return (char) 0x0E01;
				case XKeySym.ThaiKhokhai:
					return (char) 0x0E02;
				case XKeySym.ThaiKhokhuat:
					return (char) 0x0E03;
				case XKeySym.ThaiKhokhwai:
					return (char) 0x0E04;
				case XKeySym.ThaiKhokhon:
					return (char) 0x0E05;
				case XKeySym.ThaiKhorakhang:
					return (char) 0x0E06;
				case XKeySym.ThaiNgongu:
					return (char) 0x0E07;
				case XKeySym.ThaiChochan:
					return (char) 0x0E08;
				case XKeySym.ThaiChoching:
					return (char) 0x0E09;
				case XKeySym.ThaiChochang:
					return (char) 0x0E0A;
				case XKeySym.ThaiSoso:
					return (char) 0x0E0B;
				case XKeySym.ThaiChochoe:
					return (char) 0x0E0C;
				case XKeySym.ThaiYoying:
					return (char) 0x0E0D;
				case XKeySym.ThaiDochada:
					return (char) 0x0E0E;
				case XKeySym.ThaiTopatak:
					return (char) 0x0E0F;
				case XKeySym.ThaiThothan:
					return (char) 0x0E10;
				case XKeySym.ThaiThonangmontho:
					return (char) 0x0E11;
				case XKeySym.ThaiThophuthao:
					return (char) 0x0E12;
				case XKeySym.ThaiNonen:
					return (char) 0x0E13;
				case XKeySym.ThaiDodek:
					return (char) 0x0E14;
				case XKeySym.ThaiTotao:
					return (char) 0x0E15;
				case XKeySym.ThaiThothung:
					return (char) 0x0E16;
				case XKeySym.ThaiThothahan:
					return (char) 0x0E17;
				case XKeySym.ThaiThothong:
					return (char) 0x0E18;
				case XKeySym.ThaiNonu:
					return (char) 0x0E19;
				case XKeySym.ThaiBobaimai:
					return (char) 0x0E1A;
				case XKeySym.ThaiPopla:
					return (char) 0x0E1B;
				case XKeySym.ThaiPhophung:
					return (char) 0x0E1C;
				case XKeySym.ThaiFofa:
					return (char) 0x0E1D;
				case XKeySym.ThaiPhophan:
					return (char) 0x0E1E;
				case XKeySym.ThaiFofan:
					return (char) 0x0E1F;
				case XKeySym.ThaiPhosamphao:
					return (char) 0x0E20;
				case XKeySym.ThaiMoma:
					return (char) 0x0E21;
				case XKeySym.ThaiYoyak:
					return (char) 0x0E22;
				case XKeySym.ThaiRorua:
					return (char) 0x0E23;
				case XKeySym.ThaiRu:
					return (char) 0x0E24;
				case XKeySym.ThaiLoling:
					return (char) 0x0E25;
				case XKeySym.ThaiLu:
					return (char) 0x0E26;
				case XKeySym.ThaiWowaen:
					return (char) 0x0E27;
				case XKeySym.ThaiSosala:
					return (char) 0x0E28;
				case XKeySym.ThaiSorusi:
					return (char) 0x0E29;
				case XKeySym.ThaiSosua:
					return (char) 0x0E2A;
				case XKeySym.ThaiHohip:
					return (char) 0x0E2B;
				case XKeySym.ThaiLochula:
					return (char) 0x0E2C;
				case XKeySym.ThaiOang:
					return (char) 0x0E2D;
				case XKeySym.ThaiHonokhuk:
					return (char) 0x0E2E;
				case XKeySym.ThaiPaiyannoi:
					return (char) 0x0E2F;
				case XKeySym.ThaiSaraa:
					return (char) 0x0E30;
				case XKeySym.ThaiMaihanakat:
					return (char) 0x0E31;
				case XKeySym.ThaiSaraaa:
					return (char) 0x0E32;
				case XKeySym.ThaiSaraam:
					return (char) 0x0E33;
				case XKeySym.ThaiSarai:
					return (char) 0x0E34;
				case XKeySym.ThaiSaraii:
					return (char) 0x0E35;
				case XKeySym.ThaiSaraue:
					return (char) 0x0E36;
				case XKeySym.ThaiSarauee:
					return (char) 0x0E37;
				case XKeySym.ThaiSarau:
					return (char) 0x0E38;
				case XKeySym.ThaiSarauu:
					return (char) 0x0E39;
				case XKeySym.ThaiPhinthu:
					return (char) 0x0E3A;
				case XKeySym.ThaiBaht:
					return (char) 0x0E3F;
				case XKeySym.ThaiSarae:
					return (char) 0x0E40;
				case XKeySym.ThaiSaraae:
					return (char) 0x0E41;
				case XKeySym.ThaiSarao:
					return (char) 0x0E42;
				case XKeySym.ThaiSaraaimaimuan:
					return (char) 0x0E43;
				case XKeySym.ThaiSaraaimaimalai:
					return (char) 0x0E44;
				case XKeySym.ThaiLakkhangyao:
					return (char) 0x0E45;
				case XKeySym.ThaiMaiyamok:
					return (char) 0x0E46;
				case XKeySym.ThaiMaitaikhu:
					return (char) 0x0E47;
				case XKeySym.ThaiMaiek:
					return (char) 0x0E48;
				case XKeySym.ThaiMaitho:
					return (char) 0x0E49;
				case XKeySym.ThaiMaitri:
					return (char) 0x0E4A;
				case XKeySym.ThaiMaichattawa:
					return (char) 0x0E4B;
				case XKeySym.ThaiThanthakhat:
					return (char) 0x0E4C;
				case XKeySym.ThaiNikhahit:
					return (char) 0x0E4D;
				case XKeySym.ThaiLeksun:
					return (char) 0x0E50;
				case XKeySym.ThaiLeknung:
					return (char) 0x0E51;
				case XKeySym.ThaiLeksong:
					return (char) 0x0E52;
				case XKeySym.ThaiLeksam:
					return (char) 0x0E53;
				case XKeySym.ThaiLeksi:
					return (char) 0x0E54;
				case XKeySym.ThaiLekha:
					return (char) 0x0E55;
				case XKeySym.ThaiLekhok:
					return (char) 0x0E56;
				case XKeySym.ThaiLekchet:
					return (char) 0x0E57;
				case XKeySym.ThaiLekpaet:
					return (char) 0x0E58;
				case XKeySym.ThaiLekkao:
					return (char) 0x0E59;
				case XKeySym.armenianLigatureEw:
					return (char) 0x0587;
				case XKeySym.ArmenianFullStop:
					return (char) 0x0589;
				case XKeySym.ArmenianSeparationMark:
					return (char) 0x055D;
				case XKeySym.ArmenianHyphen:
					return (char) 0x058A;
				case XKeySym.ArmenianExclam:
					return (char) 0x055C;
				case XKeySym.ArmenianAccent:
					return (char) 0x055B;
				case XKeySym.ArmenianQuestion:
					return (char) 0x055E;
				case XKeySym.ArmenianAYB:
					return (char) 0x0531;
				case XKeySym.armenianAyb:
					return (char) 0x0561;
				case XKeySym.ArmenianBEN:
					return (char) 0x0532;
				case XKeySym.armenianBen:
					return (char) 0x0562;
				case XKeySym.ArmenianGIM:
					return (char) 0x0533;
				case XKeySym.armenianGim:
					return (char) 0x0563;
				case XKeySym.ArmenianDA:
					return (char) 0x0534;
				case XKeySym.armenianDa:
					return (char) 0x0564;
				case XKeySym.ArmenianYECH:
					return (char) 0x0535;
				case XKeySym.armenianYech:
					return (char) 0x0565;
				case XKeySym.ArmenianZA:
					return (char) 0x0536;
				case XKeySym.armenianZa:
					return (char) 0x0566;
				case XKeySym.ArmenianE:
					return (char) 0x0537;
				case XKeySym.armenianE:
					return (char) 0x0567;
				case XKeySym.ArmenianAT:
					return (char) 0x0538;
				case XKeySym.armenianAt:
					return (char) 0x0568;
				case XKeySym.ArmenianTO:
					return (char) 0x0539;
				case XKeySym.armenianTo:
					return (char) 0x0569;
				case XKeySym.ArmenianZHE:
					return (char) 0x053A;
				case XKeySym.armenianZhe:
					return (char) 0x056A;
				case XKeySym.ArmenianINI:
					return (char) 0x053B;
				case XKeySym.armenianIni:
					return (char) 0x056B;
				case XKeySym.ArmenianLYUN:
					return (char) 0x053C;
				case XKeySym.armenianLyun:
					return (char) 0x056C;
				case XKeySym.ArmenianKHE:
					return (char) 0x053D;
				case XKeySym.armenianKhe:
					return (char) 0x056D;
				case XKeySym.ArmenianTSA:
					return (char) 0x053E;
				case XKeySym.armenianTsa:
					return (char) 0x056E;
				case XKeySym.ArmenianKEN:
					return (char) 0x053F;
				case XKeySym.armenianKen:
					return (char) 0x056F;
				case XKeySym.ArmenianHO:
					return (char) 0x0540;
				case XKeySym.armenianHo:
					return (char) 0x0570;
				case XKeySym.ArmenianDZA:
					return (char) 0x0541;
				case XKeySym.armenianDza:
					return (char) 0x0571;
				case XKeySym.ArmenianGHAT:
					return (char) 0x0542;
				case XKeySym.armenianGhat:
					return (char) 0x0572;
				case XKeySym.ArmenianTCHE:
					return (char) 0x0543;
				case XKeySym.armenianTche:
					return (char) 0x0573;
				case XKeySym.ArmenianMEN:
					return (char) 0x0544;
				case XKeySym.armenianMen:
					return (char) 0x0574;
				case XKeySym.ArmenianHI:
					return (char) 0x0545;
				case XKeySym.armenianHi:
					return (char) 0x0575;
				case XKeySym.ArmenianNU:
					return (char) 0x0546;
				case XKeySym.armenianNu:
					return (char) 0x0576;
				case XKeySym.ArmenianSHA:
					return (char) 0x0547;
				case XKeySym.armenianSha:
					return (char) 0x0577;
				case XKeySym.ArmenianVO:
					return (char) 0x0548;
				case XKeySym.armenianVo:
					return (char) 0x0578;
				case XKeySym.ArmenianCHA:
					return (char) 0x0549;
				case XKeySym.armenianCha:
					return (char) 0x0579;
				case XKeySym.ArmenianPE:
					return (char) 0x054A;
				case XKeySym.armenianPe:
					return (char) 0x057A;
				case XKeySym.ArmenianJE:
					return (char) 0x054B;
				case XKeySym.armenianJe:
					return (char) 0x057B;
				case XKeySym.ArmenianRA:
					return (char) 0x054C;
				case XKeySym.armenianRa:
					return (char) 0x057C;
				case XKeySym.ArmenianSE:
					return (char) 0x054D;
				case XKeySym.armenianSe:
					return (char) 0x057D;
				case XKeySym.ArmenianVEV:
					return (char) 0x054E;
				case XKeySym.armenianVev:
					return (char) 0x057E;
				case XKeySym.ArmenianTYUN:
					return (char) 0x054F;
				case XKeySym.armenianTyun:
					return (char) 0x057F;
				case XKeySym.ArmenianRE:
					return (char) 0x0550;
				case XKeySym.armenianRe:
					return (char) 0x0580;
				case XKeySym.ArmenianTSO:
					return (char) 0x0551;
				case XKeySym.armenianTso:
					return (char) 0x0581;
				case XKeySym.ArmenianVYUN:
					return (char) 0x0552;
				case XKeySym.armenianVyun:
					return (char) 0x0582;
				case XKeySym.ArmenianPYUR:
					return (char) 0x0553;
				case XKeySym.armenianPyur:
					return (char) 0x0583;
				case XKeySym.ArmenianKE:
					return (char) 0x0554;
				case XKeySym.armenianKe:
					return (char) 0x0584;
				case XKeySym.ArmenianO:
					return (char) 0x0555;
				case XKeySym.armenianO:
					return (char) 0x0585;
				case XKeySym.ArmenianFE:
					return (char) 0x0556;
				case XKeySym.armenianFe:
					return (char) 0x0586;
				case XKeySym.ArmenianApostrophe:
					return (char) 0x055A;
				case XKeySym.GeorgianAn:
					return (char) 0x10D0;
				case XKeySym.GeorgianBan:
					return (char) 0x10D1;
				case XKeySym.GeorgianGan:
					return (char) 0x10D2;
				case XKeySym.GeorgianDon:
					return (char) 0x10D3;
				case XKeySym.GeorgianEn:
					return (char) 0x10D4;
				case XKeySym.GeorgianVin:
					return (char) 0x10D5;
				case XKeySym.GeorgianZen:
					return (char) 0x10D6;
				case XKeySym.GeorgianTan:
					return (char) 0x10D7;
				case XKeySym.GeorgianIn:
					return (char) 0x10D8;
				case XKeySym.GeorgianKan:
					return (char) 0x10D9;
				case XKeySym.GeorgianLas:
					return (char) 0x10DA;
				case XKeySym.GeorgianMan:
					return (char) 0x10DB;
				case XKeySym.GeorgianNar:
					return (char) 0x10DC;
				case XKeySym.GeorgianOn:
					return (char) 0x10DD;
				case XKeySym.GeorgianPar:
					return (char) 0x10DE;
				case XKeySym.GeorgianZhar:
					return (char) 0x10DF;
				case XKeySym.GeorgianRae:
					return (char) 0x10E0;
				case XKeySym.GeorgianSan:
					return (char) 0x10E1;
				case XKeySym.GeorgianTar:
					return (char) 0x10E2;
				case XKeySym.GeorgianUn:
					return (char) 0x10E3;
				case XKeySym.GeorgianPhar:
					return (char) 0x10E4;
				case XKeySym.GeorgianKhar:
					return (char) 0x10E5;
				case XKeySym.GeorgianGhan:
					return (char) 0x10E6;
				case XKeySym.GeorgianQar:
					return (char) 0x10E7;
				case XKeySym.GeorgianShin:
					return (char) 0x10E8;
				case XKeySym.GeorgianChin:
					return (char) 0x10E9;
				case XKeySym.GeorgianCan:
					return (char) 0x10EA;
				case XKeySym.GeorgianJil:
					return (char) 0x10EB;
				case XKeySym.GeorgianCil:
					return (char) 0x10EC;
				case XKeySym.GeorgianChar:
					return (char) 0x10ED;
				case XKeySym.GeorgianXan:
					return (char) 0x10EE;
				case XKeySym.GeorgianJhan:
					return (char) 0x10EF;
				case XKeySym.GeorgianHae:
					return (char) 0x10F0;
				case XKeySym.GeorgianHe:
					return (char) 0x10F1;
				case XKeySym.GeorgianHie:
					return (char) 0x10F2;
				case XKeySym.GeorgianWe:
					return (char) 0x10F3;
				case XKeySym.GeorgianHar:
					return (char) 0x10F4;
				case XKeySym.GeorgianHoe:
					return (char) 0x10F5;
				case XKeySym.GeorgianFi:
					return (char) 0x10F6;
				case XKeySym.Xabovedot:
					return (char) 0x1E8A;
				case XKeySym.Ibreve:
					return (char) 0x012C;
				case XKeySym.Zstroke:
					return (char) 0x01B5;
				case XKeySym.Gcaron:
					return (char) 0x01E6;
				case XKeySym.Ocaron:
					return (char) 0x01D2;
				case XKeySym.Obarred:
					return (char) 0x019F;
				case XKeySym.xabovedot:
					return (char) 0x1E8B;
				case XKeySym.ibreve:
					return (char) 0x012D;
				case XKeySym.zstroke:
					return (char) 0x01B6;
				case XKeySym.gcaron:
					return (char) 0x01E7;
				case XKeySym.obarred:
					return (char) 0x0275;
				case XKeySym.SCHWA:
					return (char) 0x018F;
				case XKeySym.schwa:
					return (char) 0x0259;
				case XKeySym.EZH:
					return (char) 0x01B7;
				case XKeySym.ezh:
					return (char) 0x0292;
				case XKeySym.Lbelowdot:
					return (char) 0x1E36;
				case XKeySym.lbelowdot:
					return (char) 0x1E37;
				case XKeySym.Abelowdot:
					return (char) 0x1EA0;
				case XKeySym.abelowdot:
					return (char) 0x1EA1;
				case XKeySym.Ahook:
					return (char) 0x1EA2;
				case XKeySym.ahook:
					return (char) 0x1EA3;
				case XKeySym.Acircumflexacute:
					return (char) 0x1EA4;
				case XKeySym.acircumflexacute:
					return (char) 0x1EA5;
				case XKeySym.Acircumflexgrave:
					return (char) 0x1EA6;
				case XKeySym.acircumflexgrave:
					return (char) 0x1EA7;
				case XKeySym.Acircumflexhook:
					return (char) 0x1EA8;
				case XKeySym.acircumflexhook:
					return (char) 0x1EA9;
				case XKeySym.Acircumflextilde:
					return (char) 0x1EAA;
				case XKeySym.acircumflextilde:
					return (char) 0x1EAB;
				case XKeySym.Acircumflexbelowdot:
					return (char) 0x1EAC;
				case XKeySym.acircumflexbelowdot:
					return (char) 0x1EAD;
				case XKeySym.Abreveacute:
					return (char) 0x1EAE;
				case XKeySym.abreveacute:
					return (char) 0x1EAF;
				case XKeySym.Abrevegrave:
					return (char) 0x1EB0;
				case XKeySym.abrevegrave:
					return (char) 0x1EB1;
				case XKeySym.Abrevehook:
					return (char) 0x1EB2;
				case XKeySym.abrevehook:
					return (char) 0x1EB3;
				case XKeySym.Abrevetilde:
					return (char) 0x1EB4;
				case XKeySym.abrevetilde:
					return (char) 0x1EB5;
				case XKeySym.Abrevebelowdot:
					return (char) 0x1EB6;
				case XKeySym.abrevebelowdot:
					return (char) 0x1EB7;
				case XKeySym.Ebelowdot:
					return (char) 0x1EB8;
				case XKeySym.ebelowdot:
					return (char) 0x1EB9;
				case XKeySym.Ehook:
					return (char) 0x1EBA;
				case XKeySym.ehook:
					return (char) 0x1EBB;
				case XKeySym.Etilde:
					return (char) 0x1EBC;
				case XKeySym.etilde:
					return (char) 0x1EBD;
				case XKeySym.Ecircumflexacute:
					return (char) 0x1EBE;
				case XKeySym.ecircumflexacute:
					return (char) 0x1EBF;
				case XKeySym.Ecircumflexgrave:
					return (char) 0x1EC0;
				case XKeySym.ecircumflexgrave:
					return (char) 0x1EC1;
				case XKeySym.Ecircumflexhook:
					return (char) 0x1EC2;
				case XKeySym.ecircumflexhook:
					return (char) 0x1EC3;
				case XKeySym.Ecircumflextilde:
					return (char) 0x1EC4;
				case XKeySym.ecircumflextilde:
					return (char) 0x1EC5;
				case XKeySym.Ecircumflexbelowdot:
					return (char) 0x1EC6;
				case XKeySym.ecircumflexbelowdot:
					return (char) 0x1EC7;
				case XKeySym.Ihook:
					return (char) 0x1EC8;
				case XKeySym.ihook:
					return (char) 0x1EC9;
				case XKeySym.Ibelowdot:
					return (char) 0x1ECA;
				case XKeySym.ibelowdot:
					return (char) 0x1ECB;
				case XKeySym.Obelowdot:
					return (char) 0x1ECC;
				case XKeySym.obelowdot:
					return (char) 0x1ECD;
				case XKeySym.Ohook:
					return (char) 0x1ECE;
				case XKeySym.ohook:
					return (char) 0x1ECF;
				case XKeySym.Ocircumflexacute:
					return (char) 0x1ED0;
				case XKeySym.ocircumflexacute:
					return (char) 0x1ED1;
				case XKeySym.Ocircumflexgrave:
					return (char) 0x1ED2;
				case XKeySym.ocircumflexgrave:
					return (char) 0x1ED3;
				case XKeySym.Ocircumflexhook:
					return (char) 0x1ED4;
				case XKeySym.ocircumflexhook:
					return (char) 0x1ED5;
				case XKeySym.Ocircumflextilde:
					return (char) 0x1ED6;
				case XKeySym.ocircumflextilde:
					return (char) 0x1ED7;
				case XKeySym.Ocircumflexbelowdot:
					return (char) 0x1ED8;
				case XKeySym.ocircumflexbelowdot:
					return (char) 0x1ED9;
				case XKeySym.Ohornacute:
					return (char) 0x1EDA;
				case XKeySym.ohornacute:
					return (char) 0x1EDB;
				case XKeySym.Ohorngrave:
					return (char) 0x1EDC;
				case XKeySym.ohorngrave:
					return (char) 0x1EDD;
				case XKeySym.Ohornhook:
					return (char) 0x1EDE;
				case XKeySym.ohornhook:
					return (char) 0x1EDF;
				case XKeySym.Ohorntilde:
					return (char) 0x1EE0;
				case XKeySym.ohorntilde:
					return (char) 0x1EE1;
				case XKeySym.Ohornbelowdot:
					return (char) 0x1EE2;
				case XKeySym.ohornbelowdot:
					return (char) 0x1EE3;
				case XKeySym.Ubelowdot:
					return (char) 0x1EE4;
				case XKeySym.ubelowdot:
					return (char) 0x1EE5;
				case XKeySym.Uhook:
					return (char) 0x1EE6;
				case XKeySym.uhook:
					return (char) 0x1EE7;
				case XKeySym.Uhornacute:
					return (char) 0x1EE8;
				case XKeySym.uhornacute:
					return (char) 0x1EE9;
				case XKeySym.Uhorngrave:
					return (char) 0x1EEA;
				case XKeySym.uhorngrave:
					return (char) 0x1EEB;
				case XKeySym.Uhornhook:
					return (char) 0x1EEC;
				case XKeySym.uhornhook:
					return (char) 0x1EED;
				case XKeySym.Uhorntilde:
					return (char) 0x1EEE;
				case XKeySym.uhorntilde:
					return (char) 0x1EEF;
				case XKeySym.Uhornbelowdot:
					return (char) 0x1EF0;
				case XKeySym.uhornbelowdot:
					return (char) 0x1EF1;
				case XKeySym.Ybelowdot:
					return (char) 0x1EF4;
				case XKeySym.ybelowdot:
					return (char) 0x1EF5;
				case XKeySym.Yhook:
					return (char) 0x1EF6;
				case XKeySym.yhook:
					return (char) 0x1EF7;
				case XKeySym.Ytilde:
					return (char) 0x1EF8;
				case XKeySym.ytilde:
					return (char) 0x1EF9;
				case XKeySym.Ohorn:
					return (char) 0x01A0;
				case XKeySym.ohorn:
					return (char) 0x01A1;
				case XKeySym.Uhorn:
					return (char) 0x01AF;
				case XKeySym.uhorn:
					return (char) 0x01B0;
				case XKeySym.EcuSign:
					return (char) 0x20A0;
				case XKeySym.ColonSign:
					return (char) 0x20A1;
				case XKeySym.CruzeiroSign:
					return (char) 0x20A2;
				case XKeySym.FFrancSign:
					return (char) 0x20A3;
				case XKeySym.LiraSign:
					return (char) 0x20A4;
				case XKeySym.MillSign:
					return (char) 0x20A5;
				case XKeySym.NairaSign:
					return (char) 0x20A6;
				case XKeySym.PesetaSign:
					return (char) 0x20A7;
				case XKeySym.RupeeSign:
					return (char) 0x20A8;
				case XKeySym.WonSign:
					return (char) 0x20A9;
				case XKeySym.NewSheqelSign:
					return (char) 0x20AA;
				case XKeySym.DongSign:
					return (char) 0x20AB;
				case XKeySym.EuroSign:
					return (char) 0x20AC;
				case XKeySym.Zerosuperior:
					return (char) 0x2070;
				case XKeySym.Foursuperior:
					return (char) 0x2074;
				case XKeySym.Fivesuperior:
					return (char) 0x2075;
				case XKeySym.Sixsuperior:
					return (char) 0x2076;
				case XKeySym.Sevensuperior:
					return (char) 0x2077;
				case XKeySym.Eightsuperior:
					return (char) 0x2078;
				case XKeySym.Ninesuperior:
					return (char) 0x2079;
				case XKeySym.Zerosubscript:
					return (char) 0x2080;
				case XKeySym.Onesubscript:
					return (char) 0x2081;
				case XKeySym.Twosubscript:
					return (char) 0x2082;
				case XKeySym.Threesubscript:
					return (char) 0x2083;
				case XKeySym.Foursubscript:
					return (char) 0x2084;
				case XKeySym.Fivesubscript:
					return (char) 0x2085;
				case XKeySym.Sixsubscript:
					return (char) 0x2086;
				case XKeySym.Sevensubscript:
					return (char) 0x2087;
				case XKeySym.Eightsubscript:
					return (char) 0x2088;
				case XKeySym.Ninesubscript:
					return (char) 0x2089;
				case XKeySym.Emptyset:
					return (char) 0x2205;
				case XKeySym.Elementof:
					return (char) 0x2208;
				case XKeySym.Notelementof:
					return (char) 0x2209;
				case XKeySym.Containsas:
					return (char) 0x220B;
				case XKeySym.Squareroot:
					return (char) 0x221A;
				case XKeySym.Cuberoot:
					return (char) 0x221B;
				case XKeySym.Fourthroot:
					return (char) 0x221C;
				case XKeySym.Dintegral:
					return (char) 0x222C;
				case XKeySym.Tintegral:
					return (char) 0x222D;
				case XKeySym.Because:
					return (char) 0x2235;
				case XKeySym.Approxeq:
					return (char) 0x2245;
				case XKeySym.Notapproxeq:
					return (char) 0x2247;
				case XKeySym.Notidentical:
					return (char) 0x2262;
				case XKeySym.Stricteq:
					return (char) 0x2263;
				case XKeySym.BrailleBlank:
					return (char) 0x2800;
				case XKeySym.BrailleDots1:
					return (char) 0x2801;
				case XKeySym.BrailleDots2:
					return (char) 0x2802;
				case XKeySym.BrailleDots12:
					return (char) 0x2803;
				case XKeySym.BrailleDots3:
					return (char) 0x2804;
				case XKeySym.BrailleDots13:
					return (char) 0x2805;
				case XKeySym.BrailleDots23:
					return (char) 0x2806;
				case XKeySym.BrailleDots123:
					return (char) 0x2807;
				case XKeySym.BrailleDots4:
					return (char) 0x2808;
				case XKeySym.BrailleDots14:
					return (char) 0x2809;
				case XKeySym.BrailleDots24:
					return (char) 0x280a;
				case XKeySym.BrailleDots124:
					return (char) 0x280b;
				case XKeySym.BrailleDots34:
					return (char) 0x280c;
				case XKeySym.BrailleDots134:
					return (char) 0x280d;
				case XKeySym.BrailleDots234:
					return (char) 0x280e;
				case XKeySym.BrailleDots1234:
					return (char) 0x280f;
				case XKeySym.BrailleDots5:
					return (char) 0x2810;
				case XKeySym.BrailleDots15:
					return (char) 0x2811;
				case XKeySym.BrailleDots25:
					return (char) 0x2812;
				case XKeySym.BrailleDots125:
					return (char) 0x2813;
				case XKeySym.BrailleDots35:
					return (char) 0x2814;
				case XKeySym.BrailleDots135:
					return (char) 0x2815;
				case XKeySym.BrailleDots235:
					return (char) 0x2816;
				case XKeySym.BrailleDots1235:
					return (char) 0x2817;
				case XKeySym.BrailleDots45:
					return (char) 0x2818;
				case XKeySym.BrailleDots145:
					return (char) 0x2819;
				case XKeySym.BrailleDots245:
					return (char) 0x281a;
				case XKeySym.BrailleDots1245:
					return (char) 0x281b;
				case XKeySym.BrailleDots345:
					return (char) 0x281c;
				case XKeySym.BrailleDots1345:
					return (char) 0x281d;
				case XKeySym.BrailleDots2345:
					return (char) 0x281e;
				case XKeySym.BrailleDots12345:
					return (char) 0x281f;
				case XKeySym.BrailleDots6:
					return (char) 0x2820;
				case XKeySym.BrailleDots16:
					return (char) 0x2821;
				case XKeySym.BrailleDots26:
					return (char) 0x2822;
				case XKeySym.BrailleDots126:
					return (char) 0x2823;
				case XKeySym.BrailleDots36:
					return (char) 0x2824;
				case XKeySym.BrailleDots136:
					return (char) 0x2825;
				case XKeySym.BrailleDots236:
					return (char) 0x2826;
				case XKeySym.BrailleDots1236:
					return (char) 0x2827;
				case XKeySym.BrailleDots46:
					return (char) 0x2828;
				case XKeySym.BrailleDots146:
					return (char) 0x2829;
				case XKeySym.BrailleDots246:
					return (char) 0x282a;
				case XKeySym.BrailleDots1246:
					return (char) 0x282b;
				case XKeySym.BrailleDots346:
					return (char) 0x282c;
				case XKeySym.BrailleDots1346:
					return (char) 0x282d;
				case XKeySym.BrailleDots2346:
					return (char) 0x282e;
				case XKeySym.BrailleDots12346:
					return (char) 0x282f;
				case XKeySym.BrailleDots56:
					return (char) 0x2830;
				case XKeySym.BrailleDots156:
					return (char) 0x2831;
				case XKeySym.BrailleDots256:
					return (char) 0x2832;
				case XKeySym.BrailleDots1256:
					return (char) 0x2833;
				case XKeySym.BrailleDots356:
					return (char) 0x2834;
				case XKeySym.BrailleDots1356:
					return (char) 0x2835;
				case XKeySym.BrailleDots2356:
					return (char) 0x2836;
				case XKeySym.BrailleDots12356:
					return (char) 0x2837;
				case XKeySym.BrailleDots456:
					return (char) 0x2838;
				case XKeySym.BrailleDots1456:
					return (char) 0x2839;
				case XKeySym.BrailleDots2456:
					return (char) 0x283a;
				case XKeySym.BrailleDots12456:
					return (char) 0x283b;
				case XKeySym.BrailleDots3456:
					return (char) 0x283c;
				case XKeySym.BrailleDots13456:
					return (char) 0x283d;
				case XKeySym.BrailleDots23456:
					return (char) 0x283e;
				case XKeySym.BrailleDots123456:
					return (char) 0x283f;
				case XKeySym.BrailleDots7:
					return (char) 0x2840;
				case XKeySym.BrailleDots17:
					return (char) 0x2841;
				case XKeySym.BrailleDots27:
					return (char) 0x2842;
				case XKeySym.BrailleDots127:
					return (char) 0x2843;
				case XKeySym.BrailleDots37:
					return (char) 0x2844;
				case XKeySym.BrailleDots137:
					return (char) 0x2845;
				case XKeySym.BrailleDots237:
					return (char) 0x2846;
				case XKeySym.BrailleDots1237:
					return (char) 0x2847;
				case XKeySym.BrailleDots47:
					return (char) 0x2848;
				case XKeySym.BrailleDots147:
					return (char) 0x2849;
				case XKeySym.BrailleDots247:
					return (char) 0x284a;
				case XKeySym.BrailleDots1247:
					return (char) 0x284b;
				case XKeySym.BrailleDots347:
					return (char) 0x284c;
				case XKeySym.BrailleDots1347:
					return (char) 0x284d;
				case XKeySym.BrailleDots2347:
					return (char) 0x284e;
				case XKeySym.BrailleDots12347:
					return (char) 0x284f;
				case XKeySym.BrailleDots57:
					return (char) 0x2850;
				case XKeySym.BrailleDots157:
					return (char) 0x2851;
				case XKeySym.BrailleDots257:
					return (char) 0x2852;
				case XKeySym.BrailleDots1257:
					return (char) 0x2853;
				case XKeySym.BrailleDots357:
					return (char) 0x2854;
				case XKeySym.BrailleDots1357:
					return (char) 0x2855;
				case XKeySym.BrailleDots2357:
					return (char) 0x2856;
				case XKeySym.BrailleDots12357:
					return (char) 0x2857;
				case XKeySym.BrailleDots457:
					return (char) 0x2858;
				case XKeySym.BrailleDots1457:
					return (char) 0x2859;
				case XKeySym.BrailleDots2457:
					return (char) 0x285a;
				case XKeySym.BrailleDots12457:
					return (char) 0x285b;
				case XKeySym.BrailleDots3457:
					return (char) 0x285c;
				case XKeySym.BrailleDots13457:
					return (char) 0x285d;
				case XKeySym.BrailleDots23457:
					return (char) 0x285e;
				case XKeySym.BrailleDots123457:
					return (char) 0x285f;
				case XKeySym.BrailleDots67:
					return (char) 0x2860;
				case XKeySym.BrailleDots167:
					return (char) 0x2861;
				case XKeySym.BrailleDots267:
					return (char) 0x2862;
				case XKeySym.BrailleDots1267:
					return (char) 0x2863;
				case XKeySym.BrailleDots367:
					return (char) 0x2864;
				case XKeySym.BrailleDots1367:
					return (char) 0x2865;
				case XKeySym.BrailleDots2367:
					return (char) 0x2866;
				case XKeySym.BrailleDots12367:
					return (char) 0x2867;
				case XKeySym.BrailleDots467:
					return (char) 0x2868;
				case XKeySym.BrailleDots1467:
					return (char) 0x2869;
				case XKeySym.BrailleDots2467:
					return (char) 0x286a;
				case XKeySym.BrailleDots12467:
					return (char) 0x286b;
				case XKeySym.BrailleDots3467:
					return (char) 0x286c;
				case XKeySym.BrailleDots13467:
					return (char) 0x286d;
				case XKeySym.BrailleDots23467:
					return (char) 0x286e;
				case XKeySym.BrailleDots123467:
					return (char) 0x286f;
				case XKeySym.BrailleDots567:
					return (char) 0x2870;
				case XKeySym.BrailleDots1567:
					return (char) 0x2871;
				case XKeySym.BrailleDots2567:
					return (char) 0x2872;
				case XKeySym.BrailleDots12567:
					return (char) 0x2873;
				case XKeySym.BrailleDots3567:
					return (char) 0x2874;
				case XKeySym.BrailleDots13567:
					return (char) 0x2875;
				case XKeySym.BrailleDots23567:
					return (char) 0x2876;
				case XKeySym.BrailleDots123567:
					return (char) 0x2877;
				case XKeySym.BrailleDots4567:
					return (char) 0x2878;
				case XKeySym.BrailleDots14567:
					return (char) 0x2879;
				case XKeySym.BrailleDots24567:
					return (char) 0x287a;
				case XKeySym.BrailleDots124567:
					return (char) 0x287b;
				case XKeySym.BrailleDots34567:
					return (char) 0x287c;
				case XKeySym.BrailleDots134567:
					return (char) 0x287d;
				case XKeySym.BrailleDots234567:
					return (char) 0x287e;
				case XKeySym.BrailleDots1234567:
					return (char) 0x287f;
				case XKeySym.BrailleDots8:
					return (char) 0x2880;
				case XKeySym.BrailleDots18:
					return (char) 0x2881;
				case XKeySym.BrailleDots28:
					return (char) 0x2882;
				case XKeySym.BrailleDots128:
					return (char) 0x2883;
				case XKeySym.BrailleDots38:
					return (char) 0x2884;
				case XKeySym.BrailleDots138:
					return (char) 0x2885;
				case XKeySym.BrailleDots238:
					return (char) 0x2886;
				case XKeySym.BrailleDots1238:
					return (char) 0x2887;
				case XKeySym.BrailleDots48:
					return (char) 0x2888;
				case XKeySym.BrailleDots148:
					return (char) 0x2889;
				case XKeySym.BrailleDots248:
					return (char) 0x288a;
				case XKeySym.BrailleDots1248:
					return (char) 0x288b;
				case XKeySym.BrailleDots348:
					return (char) 0x288c;
				case XKeySym.BrailleDots1348:
					return (char) 0x288d;
				case XKeySym.BrailleDots2348:
					return (char) 0x288e;
				case XKeySym.BrailleDots12348:
					return (char) 0x288f;
				case XKeySym.BrailleDots58:
					return (char) 0x2890;
				case XKeySym.BrailleDots158:
					return (char) 0x2891;
				case XKeySym.BrailleDots258:
					return (char) 0x2892;
				case XKeySym.BrailleDots1258:
					return (char) 0x2893;
				case XKeySym.BrailleDots358:
					return (char) 0x2894;
				case XKeySym.BrailleDots1358:
					return (char) 0x2895;
				case XKeySym.BrailleDots2358:
					return (char) 0x2896;
				case XKeySym.BrailleDots12358:
					return (char) 0x2897;
				case XKeySym.BrailleDots458:
					return (char) 0x2898;
				case XKeySym.BrailleDots1458:
					return (char) 0x2899;
				case XKeySym.BrailleDots2458:
					return (char) 0x289a;
				case XKeySym.BrailleDots12458:
					return (char) 0x289b;
				case XKeySym.BrailleDots3458:
					return (char) 0x289c;
				case XKeySym.BrailleDots13458:
					return (char) 0x289d;
				case XKeySym.BrailleDots23458:
					return (char) 0x289e;
				case XKeySym.BrailleDots123458:
					return (char) 0x289f;
				case XKeySym.BrailleDots68:
					return (char) 0x28a0;
				case XKeySym.BrailleDots168:
					return (char) 0x28a1;
				case XKeySym.BrailleDots268:
					return (char) 0x28a2;
				case XKeySym.BrailleDots1268:
					return (char) 0x28a3;
				case XKeySym.BrailleDots368:
					return (char) 0x28a4;
				case XKeySym.BrailleDots1368:
					return (char) 0x28a5;
				case XKeySym.BrailleDots2368:
					return (char) 0x28a6;
				case XKeySym.BrailleDots12368:
					return (char) 0x28a7;
				case XKeySym.BrailleDots468:
					return (char) 0x28a8;
				case XKeySym.BrailleDots1468:
					return (char) 0x28a9;
				case XKeySym.BrailleDots2468:
					return (char) 0x28aa;
				case XKeySym.BrailleDots12468:
					return (char) 0x28ab;
				case XKeySym.BrailleDots3468:
					return (char) 0x28ac;
				case XKeySym.BrailleDots13468:
					return (char) 0x28ad;
				case XKeySym.BrailleDots23468:
					return (char) 0x28ae;
				case XKeySym.BrailleDots123468:
					return (char) 0x28af;
				case XKeySym.BrailleDots568:
					return (char) 0x28b0;
				case XKeySym.BrailleDots1568:
					return (char) 0x28b1;
				case XKeySym.BrailleDots2568:
					return (char) 0x28b2;
				case XKeySym.BrailleDots12568:
					return (char) 0x28b3;
				case XKeySym.BrailleDots3568:
					return (char) 0x28b4;
				case XKeySym.BrailleDots13568:
					return (char) 0x28b5;
				case XKeySym.BrailleDots23568:
					return (char) 0x28b6;
				case XKeySym.BrailleDots123568:
					return (char) 0x28b7;
				case XKeySym.BrailleDots4568:
					return (char) 0x28b8;
				case XKeySym.BrailleDots14568:
					return (char) 0x28b9;
				case XKeySym.BrailleDots24568:
					return (char) 0x28ba;
				case XKeySym.BrailleDots124568:
					return (char) 0x28bb;
				case XKeySym.BrailleDots34568:
					return (char) 0x28bc;
				case XKeySym.BrailleDots134568:
					return (char) 0x28bd;
				case XKeySym.BrailleDots234568:
					return (char) 0x28be;
				case XKeySym.BrailleDots1234568:
					return (char) 0x28bf;
				case XKeySym.BrailleDots78:
					return (char) 0x28c0;
				case XKeySym.BrailleDots178:
					return (char) 0x28c1;
				case XKeySym.BrailleDots278:
					return (char) 0x28c2;
				case XKeySym.BrailleDots1278:
					return (char) 0x28c3;
				case XKeySym.BrailleDots378:
					return (char) 0x28c4;
				case XKeySym.BrailleDots1378:
					return (char) 0x28c5;
				case XKeySym.BrailleDots2378:
					return (char) 0x28c6;
				case XKeySym.BrailleDots12378:
					return (char) 0x28c7;
				case XKeySym.BrailleDots478:
					return (char) 0x28c8;
				case XKeySym.BrailleDots1478:
					return (char) 0x28c9;
				case XKeySym.BrailleDots2478:
					return (char) 0x28ca;
				case XKeySym.BrailleDots12478:
					return (char) 0x28cb;
				case XKeySym.BrailleDots3478:
					return (char) 0x28cc;
				case XKeySym.BrailleDots13478:
					return (char) 0x28cd;
				case XKeySym.BrailleDots23478:
					return (char) 0x28ce;
				case XKeySym.BrailleDots123478:
					return (char) 0x28cf;
				case XKeySym.BrailleDots578:
					return (char) 0x28d0;
				case XKeySym.BrailleDots1578:
					return (char) 0x28d1;
				case XKeySym.BrailleDots2578:
					return (char) 0x28d2;
				case XKeySym.BrailleDots12578:
					return (char) 0x28d3;
				case XKeySym.BrailleDots3578:
					return (char) 0x28d4;
				case XKeySym.BrailleDots13578:
					return (char) 0x28d5;
				case XKeySym.BrailleDots23578:
					return (char) 0x28d6;
				case XKeySym.BrailleDots123578:
					return (char) 0x28d7;
				case XKeySym.BrailleDots4578:
					return (char) 0x28d8;
				case XKeySym.BrailleDots14578:
					return (char) 0x28d9;
				case XKeySym.BrailleDots24578:
					return (char) 0x28da;
				case XKeySym.BrailleDots124578:
					return (char) 0x28db;
				case XKeySym.BrailleDots34578:
					return (char) 0x28dc;
				case XKeySym.BrailleDots134578:
					return (char) 0x28dd;
				case XKeySym.BrailleDots234578:
					return (char) 0x28de;
				case XKeySym.BrailleDots1234578:
					return (char) 0x28df;
				case XKeySym.BrailleDots678:
					return (char) 0x28e0;
				case XKeySym.BrailleDots1678:
					return (char) 0x28e1;
				case XKeySym.BrailleDots2678:
					return (char) 0x28e2;
				case XKeySym.BrailleDots12678:
					return (char) 0x28e3;
				case XKeySym.BrailleDots3678:
					return (char) 0x28e4;
				case XKeySym.BrailleDots13678:
					return (char) 0x28e5;
				case XKeySym.BrailleDots23678:
					return (char) 0x28e6;
				case XKeySym.BrailleDots123678:
					return (char) 0x28e7;
				case XKeySym.BrailleDots4678:
					return (char) 0x28e8;
				case XKeySym.BrailleDots14678:
					return (char) 0x28e9;
				case XKeySym.BrailleDots24678:
					return (char) 0x28ea;
				case XKeySym.BrailleDots124678:
					return (char) 0x28eb;
				case XKeySym.BrailleDots34678:
					return (char) 0x28ec;
				case XKeySym.BrailleDots134678:
					return (char) 0x28ed;
				case XKeySym.BrailleDots234678:
					return (char) 0x28ee;
				case XKeySym.BrailleDots1234678:
					return (char) 0x28ef;
				case XKeySym.BrailleDots5678:
					return (char) 0x28f0;
				case XKeySym.BrailleDots15678:
					return (char) 0x28f1;
				case XKeySym.BrailleDots25678:
					return (char) 0x28f2;
				case XKeySym.BrailleDots125678:
					return (char) 0x28f3;
				case XKeySym.BrailleDots35678:
					return (char) 0x28f4;
				case XKeySym.BrailleDots135678:
					return (char) 0x28f5;
				case XKeySym.BrailleDots235678:
					return (char) 0x28f6;
				case XKeySym.BrailleDots1235678:
					return (char) 0x28f7;
				case XKeySym.BrailleDots45678:
					return (char) 0x28f8;
				case XKeySym.BrailleDots145678:
					return (char) 0x28f9;
				case XKeySym.BrailleDots245678:
					return (char) 0x28fa;
				case XKeySym.BrailleDots1245678:
					return (char) 0x28fb;
				case XKeySym.BrailleDots345678:
					return (char) 0x28fc;
				case XKeySym.BrailleDots1345678:
					return (char) 0x28fd;
				case XKeySym.BrailleDots2345678:
					return (char) 0x28fe;
				case XKeySym.BrailleDots12345678:
					return (char) 0x28ff;
				case XKeySym.SinhNg:
					return (char) 0x0D82;
				case XKeySym.SinhH2:
					return (char) 0x0D83;
				case XKeySym.SinhA:
					return (char) 0x0D85;
				case XKeySym.SinhAa:
					return (char) 0x0D86;
				case XKeySym.SinhAe:
					return (char) 0x0D87;
				case XKeySym.SinhAee:
					return (char) 0x0D88;
				case XKeySym.SinhI:
					return (char) 0x0D89;
				case XKeySym.SinhIi:
					return (char) 0x0D8A;
				case XKeySym.SinhU:
					return (char) 0x0D8B;
				case XKeySym.SinhUu:
					return (char) 0x0D8C;
				case XKeySym.SinhRi:
					return (char) 0x0D8D;
				case XKeySym.SinhRii:
					return (char) 0x0D8E;
				case XKeySym.SinhLu:
					return (char) 0x0D8F;
				case XKeySym.SinhLuu:
					return (char) 0x0D90;
				case XKeySym.SinhE:
					return (char) 0x0D91;
				case XKeySym.SinhEe:
					return (char) 0x0D92;
				case XKeySym.SinhAi:
					return (char) 0x0D93;
				case XKeySym.SinhO:
					return (char) 0x0D94;
				case XKeySym.SinhOo:
					return (char) 0x0D95;
				case XKeySym.SinhAu:
					return (char) 0x0D96;
				case XKeySym.SinhKa:
					return (char) 0x0D9A;
				case XKeySym.SinhKha:
					return (char) 0x0D9B;
				case XKeySym.SinhGa:
					return (char) 0x0D9C;
				case XKeySym.SinhGha:
					return (char) 0x0D9D;
				case XKeySym.SinhNg2:
					return (char) 0x0D9E;
				case XKeySym.SinhNga:
					return (char) 0x0D9F;
				case XKeySym.SinhCa:
					return (char) 0x0DA0;
				case XKeySym.SinhCha:
					return (char) 0x0DA1;
				case XKeySym.SinhJa:
					return (char) 0x0DA2;
				case XKeySym.SinhJha:
					return (char) 0x0DA3;
				case XKeySym.SinhNya:
					return (char) 0x0DA4;
				case XKeySym.SinhJnya:
					return (char) 0x0DA5;
				case XKeySym.SinhNja:
					return (char) 0x0DA6;
				case XKeySym.SinhTta:
					return (char) 0x0DA7;
				case XKeySym.SinhTtha:
					return (char) 0x0DA8;
				case XKeySym.SinhDda:
					return (char) 0x0DA9;
				case XKeySym.SinhDdha:
					return (char) 0x0DAA;
				case XKeySym.SinhNna:
					return (char) 0x0DAB;
				case XKeySym.SinhNdda:
					return (char) 0x0DAC;
				case XKeySym.SinhTha:
					return (char) 0x0DAD;
				case XKeySym.SinhThha:
					return (char) 0x0DAE;
				case XKeySym.SinhDha:
					return (char) 0x0DAF;
				case XKeySym.SinhDhha:
					return (char) 0x0DB0;
				case XKeySym.SinhNa:
					return (char) 0x0DB1;
				case XKeySym.SinhNdha:
					return (char) 0x0DB3;
				case XKeySym.SinhPa:
					return (char) 0x0DB4;
				case XKeySym.SinhPha:
					return (char) 0x0DB5;
				case XKeySym.SinhBa:
					return (char) 0x0DB6;
				case XKeySym.SinhBha:
					return (char) 0x0DB7;
				case XKeySym.SinhMa:
					return (char) 0x0DB8;
				case XKeySym.SinhMba:
					return (char) 0x0DB9;
				case XKeySym.SinhYa:
					return (char) 0x0DBA;
				case XKeySym.SinhRa:
					return (char) 0x0DBB;
				case XKeySym.SinhLa:
					return (char) 0x0DBD;
				case XKeySym.SinhVa:
					return (char) 0x0DC0;
				case XKeySym.SinhSha:
					return (char) 0x0DC1;
				case XKeySym.SinhSsha:
					return (char) 0x0DC2;
				case XKeySym.SinhSa:
					return (char) 0x0DC3;
				case XKeySym.SinhHa:
					return (char) 0x0DC4;
				case XKeySym.SinhLla:
					return (char) 0x0DC5;
				case XKeySym.SinhFa:
					return (char) 0x0DC6;
				case XKeySym.SinhAl:
					return (char) 0x0DCA;
				case XKeySym.SinhAa2:
					return (char) 0x0DCF;
				case XKeySym.SinhAe2:
					return (char) 0x0DD0;
				case XKeySym.SinhAee2:
					return (char) 0x0DD1;
				case XKeySym.SinhI2:
					return (char) 0x0DD2;
				case XKeySym.SinhIi2:
					return (char) 0x0DD3;
				case XKeySym.SinhU2:
					return (char) 0x0DD4;
				case XKeySym.SinhUu2:
					return (char) 0x0DD6;
				case XKeySym.SinhRu2:
					return (char) 0x0DD8;
				case XKeySym.SinhE2:
					return (char) 0x0DD9;
				case XKeySym.SinhEe2:
					return (char) 0x0DDA;
				case XKeySym.SinhAi2:
					return (char) 0x0DDB;
				case XKeySym.SinhO2:
					return (char) 0x0DDC;
				case XKeySym.SinhOo2:
					return (char) 0x0DDD;
				case XKeySym.SinhAu2:
					return (char) 0x0DDE;
				case XKeySym.SinhLu2:
					return (char) 0x0DDF;
				case XKeySym.SinhRuu2:
					return (char) 0x0DF2;
				case XKeySym.SinhLuu2:
					return (char) 0x0DF3;
				case XKeySym.SinhKunddaliya:
					return (char) 0x0DF4;

				default:
					return char.MinValue;
			}
		}

		/// <summary>
		///  Converts a X KeySym into a Virtual Key.
		/// </summary>
		/// <param name="keysym">The <see cref="XKeySym" /> to convert.</param>
		/// <returns>The Virtual Key.</returns>
		public static VirtualKeys XKeySymToVirtualKey(XKeySym keysym)
		{
			// TODO(sad): Have |keysym| go through the X map list?
			switch (keysym)
			{
				case XKeySym.BackSpace:
					return VirtualKeys.Back;
				case XKeySym.Delete:
				case XKeySym.KPDelete:
					return VirtualKeys.Delete;
				case XKeySym.Tab:
				case XKeySym.KPTab:
				case XKeySym.ISOLeftTab:
				case XKeySym.XK3270BackTab:
					return VirtualKeys.Tab;
				case XKeySym.Linefeed:
				case XKeySym.Return:
				case XKeySym.KPEnter:
				case XKeySym.ISOEnter:
					return VirtualKeys.Return;
				case XKeySym.Clear:
				case XKeySym.KPBegin: // NumPad 5 without Num Lock, for crosbug.com/29169.
					return VirtualKeys.Clear;
				case XKeySym.KPSpace:
				case XKeySym.Space:
					return VirtualKeys.Space;
				case XKeySym.Home:
				case XKeySym.KPHome:
					return VirtualKeys.Home;
				case XKeySym.End:
				case XKeySym.KPEnd:
					return VirtualKeys.End;
				case XKeySym.PageUp:
				case XKeySym.KPPageUp: // aka XKeysym.KP_Prior
					return VirtualKeys.Prior;
				case XKeySym.PageDown:
				case XKeySym.KPPageDown: // aka XKeysym.KP_Next
					return VirtualKeys.Next;
				case XKeySym.Left:
				case XKeySym.KPLeft:
					return VirtualKeys.Left;
				case XKeySym.Right:
				case XKeySym.KPRight:
					return VirtualKeys.Right;
				case XKeySym.Down:
				case XKeySym.KPDown:
					return VirtualKeys.Down;
				case XKeySym.Up:
				case XKeySym.KPUp:
					return VirtualKeys.Up;
				case XKeySym.Escape:
					return VirtualKeys.Escape;
				case XKeySym.KanaLock:
				case XKeySym.KanaShift:
					return VirtualKeys.KanaMode;
				case XKeySym.Hangul:
					return VirtualKeys.HangulMode;
				case XKeySym.HangulHanja:
					return VirtualKeys.HanjaMode;
				case XKeySym.Kanji:
					return VirtualKeys.KanjiMode;
				case XKeySym.Henkan:
					return VirtualKeys.IMEConvert;
				case XKeySym.Muhenkan:
					return VirtualKeys.IMENonconvert;
				case XKeySym.ZenkakuHankaku:
					return VirtualKeys.DbeDbcsChar;
				case XKeySym.A:
				case XKeySym.a:
					return VirtualKeys.A;
				case XKeySym.B:
				case XKeySym.b:
					return VirtualKeys.B;
				case XKeySym.C:
				case XKeySym.c:
					return VirtualKeys.C;
				case XKeySym.D:
				case XKeySym.d:
					return VirtualKeys.D;
				case XKeySym.E:
				case XKeySym.e:
					return VirtualKeys.E;
				case XKeySym.F:
				case XKeySym.f:
					return VirtualKeys.F;
				case XKeySym.G:
				case XKeySym.g:
					return VirtualKeys.G;
				case XKeySym.H:
				case XKeySym.h:
					return VirtualKeys.H;
				case XKeySym.I:
				case XKeySym.i:
					return VirtualKeys.I;
				case XKeySym.J:
				case XKeySym.j:
					return VirtualKeys.J;
				case XKeySym.K:
				case XKeySym.k:
					return VirtualKeys.K;
				case XKeySym.L:
				case XKeySym.l:
					return VirtualKeys.L;
				case XKeySym.M:
				case XKeySym.m:
					return VirtualKeys.M;
				case XKeySym.N:
				case XKeySym.n:
					return VirtualKeys.N;
				case XKeySym.O:
				case XKeySym.o:
					return VirtualKeys.O;
				case XKeySym.P:
				case XKeySym.p:
					return VirtualKeys.P;
				case XKeySym.Q:
				case XKeySym.q:
					return VirtualKeys.Q;
				case XKeySym.R:
				case XKeySym.r:
					return VirtualKeys.R;
				case XKeySym.S:
				case XKeySym.s:
					return VirtualKeys.S;
				case XKeySym.T:
				case XKeySym.t:
					return VirtualKeys.T;
				case XKeySym.U:
				case XKeySym.u:
					return VirtualKeys.U;
				case XKeySym.V:
				case XKeySym.v:
					return VirtualKeys.V;
				case XKeySym.W:
				case XKeySym.w:
					return VirtualKeys.W;
				case XKeySym.X:
				case XKeySym.x:
					return VirtualKeys.X;
				case XKeySym.Y:
				case XKeySym.y:
					return VirtualKeys.Y;
				case XKeySym.Z:
				case XKeySym.z:
					return VirtualKeys.Z;
				case XKeySym.D0:
				case XKeySym.D1:
				case XKeySym.D2:
				case XKeySym.D3:
				case XKeySym.D4:
				case XKeySym.D5:
				case XKeySym.D6:
				case XKeySym.D7:
				case XKeySym.D8:
				case XKeySym.D9:
					return VirtualKeys.D0 + (keysym - XKeySym.D0);
				case XKeySym.Parenright:
					return VirtualKeys.D0;
				case XKeySym.Exclam:
					return VirtualKeys.D1;
				case XKeySym.At:
					return VirtualKeys.D2;
				case XKeySym.Numbersign:
					return VirtualKeys.D3;
				case XKeySym.Dollar:
					return VirtualKeys.D4;
				case XKeySym.Percent:
					return VirtualKeys.D5;
				case XKeySym.Asciicircum:
					return VirtualKeys.D6;
				case XKeySym.Ampersand:
					return VirtualKeys.D7;
				case XKeySym.Asterisk:
					return VirtualKeys.D8;
				case XKeySym.Parenleft:
					return VirtualKeys.D9;
				case XKeySym.KP0:
				case XKeySym.KP1:
				case XKeySym.KP2:
				case XKeySym.KP3:
				case XKeySym.KP4:
				case XKeySym.KP5:
				case XKeySym.KP6:
				case XKeySym.KP7:
				case XKeySym.KP8:
				case XKeySym.KP9:
					return VirtualKeys.NumPad0 + (keysym - XKeySym.KP0);
				case XKeySym.Multiply:
				case XKeySym.KPMultiply:
					return VirtualKeys.Multiply;
				case XKeySym.KPAdd:
					return VirtualKeys.Add;
				case XKeySym.KPSeparator:
					return VirtualKeys.Separator;
				case XKeySym.KPSubtract:
					return VirtualKeys.Subtract;
				case XKeySym.KPDecimal:
					return VirtualKeys.Decimal;
				case XKeySym.KPDivide:
					return VirtualKeys.Divide;
				case XKeySym.KPEqual:
				case XKeySym.Equal:
				case XKeySym.Plus:
					return VirtualKeys.OemPlus;
				case XKeySym.Comma:
				case XKeySym.Less:
					return VirtualKeys.OemComma;
				case XKeySym.Minus:
				case XKeySym.Underscore:
					return VirtualKeys.OemMinus;
				case XKeySym.Greater:
				case XKeySym.Period:
					return VirtualKeys.OemPeriod;
				case XKeySym.Colon:
				case XKeySym.Semicolon:
					return VirtualKeys.Oem1;
				case XKeySym.Question:
				case XKeySym.Slash:
					return VirtualKeys.Oem2;
				case XKeySym.Asciitilde:
				case XKeySym.Quoteleft:
					return VirtualKeys.Oem3;
				case XKeySym.Bracketleft:
				case XKeySym.Braceleft:
					return VirtualKeys.Oem4;
				case XKeySym.Backslash:
				case XKeySym.Bar:
					return VirtualKeys.Oem5;
				case XKeySym.Bracketright:
				case XKeySym.Braceright:
					return VirtualKeys.Oem6;
				case XKeySym.Quoteright:
				case XKeySym.Quotedbl:
					return VirtualKeys.Oem7;
				case XKeySym.ISOLevel5Shift:
					return VirtualKeys.Oem8;
				case XKeySym.ShiftL:
				case XKeySym.ShiftR:
					return VirtualKeys.Shift;
				case XKeySym.ControlL:
				case XKeySym.ControlR:
					return VirtualKeys.Control;
				case XKeySym.MetaL:
				case XKeySym.MetaR:
				case XKeySym.AltL:
				case XKeySym.AltR:
					return VirtualKeys.Menu;
				case XKeySym.ISOLevel3Shift:
				case XKeySym.ModeSwitch:
					return VirtualKeys.AltGr;
				case XKeySym.MultiKey:
					return VirtualKeys.Compose;
				case XKeySym.Pause:
					return VirtualKeys.Pause;
				case XKeySym.CapsLock:
					return VirtualKeys.Capital;
				case XKeySym.NumLock:
					return VirtualKeys.NumLock;
				case XKeySym.ScrollLock:
					return VirtualKeys.Scroll;
				case XKeySym.Select:
					return VirtualKeys.Select;
				case XKeySym.Print:
					return VirtualKeys.Snapshot;
				case XKeySym.Execute:
					return VirtualKeys.Execute;
				case XKeySym.Insert:
				case XKeySym.KPInsert:
					return VirtualKeys.Insert;
				case XKeySym.Help:
					return VirtualKeys.Help;
				case XKeySym.SuperL:
					return VirtualKeys.LWin;
				case XKeySym.SuperR:
					return VirtualKeys.RWin;
				case XKeySym.Menu:
					return VirtualKeys.Apps;
				case XKeySym.F1:
				case XKeySym.F2:
				case XKeySym.F3:
				case XKeySym.F4:
				case XKeySym.F5:
				case XKeySym.F6:
				case XKeySym.F7:
				case XKeySym.F8:
				case XKeySym.F9:
				case XKeySym.F10:
				case XKeySym.F11:
				case XKeySym.F12:
				case XKeySym.F13:
				case XKeySym.F14:
				case XKeySym.F15:
				case XKeySym.F16:
				case XKeySym.F17:
				case XKeySym.F18:
				case XKeySym.F19:
				case XKeySym.F20:
				case XKeySym.F21:
				case XKeySym.F22:
				case XKeySym.F23:
				case XKeySym.F24:
					return VirtualKeys.F1 + (keysym - XKeySym.F1);
				case XKeySym.KPF1:
				case XKeySym.KPF2:
				case XKeySym.KPF3:
				case XKeySym.KPF4:
					return VirtualKeys.F1 + (keysym - XKeySym.KPF1);
				case XKeySym.Guillemotleft:
				case XKeySym.Guillemotright:
				case XKeySym.Degree:
				// In the case of canadian multilingual keyboard layout, VirtualKeys.Oem102 is
				// assigned to ugrave key.
				case XKeySym.ugrave:
				case XKeySym.Ugrave:
				case XKeySym.Brokenbar:
					// international backslash key in 102 keyboard.
					// When evdev is in use, /usr/share/X11/xkb/symbols/inet maps F13-18 keys
					// to the special XF86XK symbols to support Microsoft Ergonomic keyboards:
					// https://bugs.freedesktop.org/show_bug.cgi?id=5783
					// In Chrome, we map these X key symbols back to F13-18 since we don't have
					// VKEYs for these XF86XK symbols.				
					return VirtualKeys.Oem102;
				case XKeySym.Tools:
					return VirtualKeys.F13;
				case XKeySym.Launch5:
					return VirtualKeys.F14;
				case XKeySym.Launch6:
					return VirtualKeys.F15;
				case XKeySym.Launch7:
					return VirtualKeys.F16;
				case XKeySym.Launch8:
					return VirtualKeys.F17;
				case XKeySym.Launch9:
					return VirtualKeys.F18;
				// For supporting multimedia buttons on a USB keyboard.
				case XKeySym.Back:
					return VirtualKeys.BrowserBack;
				case XKeySym.Forward:
					return VirtualKeys.BrowserForward;
				case XKeySym.Reload:
					return VirtualKeys.BrowserRefresh;
				case XKeySym.Stop:
					return VirtualKeys.BrowserStop;
				case XKeySym.Search:
					return VirtualKeys.BrowserSearch;
				case XKeySym.Favorites:
					return VirtualKeys.BrowserFavorites;
				case XKeySym.HomePage:
					return VirtualKeys.BrowserHome;
				case XKeySym.AudioMute:
					return VirtualKeys.VolumeMute;
				case XKeySym.AudioLowerVolume:
					return VirtualKeys.VolumeDown;
				case XKeySym.AudioRaiseVolume:
					return VirtualKeys.VolumeUp;
				case XKeySym.AudioNext:
					return VirtualKeys.MediaNextTrack;
				case XKeySym.AudioPrev:
					return VirtualKeys.MediaPreviousTrack;
				case XKeySym.AudioStop:
					return VirtualKeys.MediaStop;
				case XKeySym.AudioPlay:
					return VirtualKeys.MediaPlayPause;
				case XKeySym.Mail:
					return VirtualKeys.LaunchMail;
				case XKeySym.LaunchA: // F3 on an Apple keyboard.
					return VirtualKeys.LaunchApplication1;
				case XKeySym.LaunchB: // F4 on an Apple keyboard.
				case XKeySym.Calculator:
					return VirtualKeys.LaunchApplication2;
				case XKeySym.WLAN:
					return VirtualKeys.WirelessLan;
				case XKeySym.PowerOff:
					return VirtualKeys.Power;
				case XKeySym.Sleep:
					return VirtualKeys.Sleep;
				case XKeySym.MonBrightnessDown:
					return VirtualKeys.BrightnessDown;
				case XKeySym.MonBrightnessUp:
					return VirtualKeys.BrightnessUp;
				case XKeySym.KbdBrightnessDown:
					return VirtualKeys.KbdBrightnessDown;
				case XKeySym.KbdBrightnessUp:
					return VirtualKeys.KbdBrightnessUp;
				// TODO(sad): some keycodes are still missing.
			}

			Debug.Print("Unknown keysym: {0} (0x{0:X})", keysym);
			return VirtualKeys.None;
		}
	}
}