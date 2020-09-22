﻿using System;
using System.Drawing;
using System.Windows.Forms;
using CefNet.Input;
using CefNet.Internal;
using CefNet.WinApi;

namespace CefNet.Windows.Forms
{
	partial class WebView : IWinFormsWebViewPrivate
	{
		private IntPtr _keyboardLayout;
		private CefEventFlags _keydownModifiers;

		/// <summary>
		///  Gets emulated device.
		/// </summary>
		protected VirtualDevice Device { get; private set; }

		/// <summary>
		///  Gets a graphics buffer for off-screen rendering.
		/// </summary>
		protected OffscreenGraphics OffscreenGraphics { get; private set; }

		/// <summary>
		///  Gets and sets a value indicating whether the browser using off-screen rendering.
		/// </summary>
		public bool WindowlessRenderingEnabled
		{
			get => OffscreenGraphics != null;
			set
			{
				SetInitProperty(InitialPropertyKeys.Windowless, value);

				if (value)
				{
					if (OffscreenGraphics == null)
					{
						var device = Device;
						OffscreenGraphics = new OffscreenGraphics {Background = BackColor, Device = device};
						if (device is null)
							OffscreenGraphics.SetSize(Width, Height);
						else
							OffscreenGraphics.SetSize(device.ViewportRect.Width, device.ViewportRect.Height);
					}
				}
				else
				{
					OffscreenGraphics = null;
				}
			}
		}

		protected override Size DefaultSize => new Size(100, 100);


		bool IChromiumWebViewPrivate.GetCefScreenInfo(ref CefScreenInfo screenInfo)
		{
			return GetCefScreenInfo(ref screenInfo);
		}

		bool IChromiumWebViewPrivate.CefPointToScreen(ref CefPoint point)
		{
			return CefPointToScreen(ref point);
		}

		public float GetDevicePixelRatio()
		{
			var device = Device;
			return device != null ? device.DevicePixelRatio : OffscreenGraphics.PixelsPerDip;
		}

		CefRect IChromiumWebViewPrivate.GetCefRootBounds()
		{
			return GetCefRootBounds();
		}

		CefRect IChromiumWebViewPrivate.GetCefViewBounds()
		{
			return OffscreenGraphics.GetBounds();
		}

		void IWinFormsWebViewPrivate.RaiseCefCursorChange(CursorChangeEventArgs e)
		{
			RaiseCrossThreadEvent(OnCursorChange, e, false);
		}

		void IWinFormsWebViewPrivate.CefSetToolTip(string text)
		{
			RaiseCrossThreadEvent(OnSetToolTip, new TooltipEventArgs(text), false);
		}

		void IWinFormsWebViewPrivate.RaiseStartDragging(StartDraggingEventArgs e)
		{
			RaiseCrossThreadEvent(OnStartDragging, e, true);
		}

		/// <summary>
		///  Occurs when the user starts dragging content in the web view.
		/// </summary>
		/// <remarks>
		///  OS APIs that run a system message loop may be used within the StartDragging event handler.
		///  Call <see cref="WebView.DragSourceEndedAt" /> and <see cref="WebView.DragSourceSystemDragEnded" />
		///  either synchronously or asynchronously to inform the web view that the drag operation has ended.
		/// </remarks>
		public event EventHandler<StartDraggingEventArgs> StartDragging;

		/// <summary>
		///  Enable or disable device simulation.
		/// </summary>
		/// <param name="device">The simulated device or null.</param>
		public void SimulateDevice(VirtualDevice device)
		{
			if (IsHandleCreated) VerifyAccess();

			if (Device == device)
				return;

			var offscreenGraphics = OffscreenGraphics;
			if (offscreenGraphics != null)
				offscreenGraphics.Device = device;

			if (IsHandleCreated)
			{
				if (!WindowlessRenderingEnabled)
					throw new InvalidOperationException();
				OnSizeChanged(EventArgs.Empty);
			}
			else
			{
				Device = device;
			}
		}

		protected CefRect GetViewportRect()
		{
			CefRect viewportRect;
			var device = Device;
			if (device == null)
			{
				viewportRect = new CefRect(0, 0, Width, Height);
				viewportRect.Scale(OffscreenGraphics.PixelsPerDip);
				return viewportRect;
			}

			return device.GetBounds(OffscreenGraphics.PixelsPerDip);
		}

		protected override void OnBackColorChanged(EventArgs e)
		{
			var offscreenGraphics = OffscreenGraphics;
			if (offscreenGraphics != null)
				offscreenGraphics.Background = BackColor;

			base.OnBackColorChanged(e);
		}

		protected override void OnHandleCreated(EventArgs e)
		{
			if (OffscreenGraphics != null)
				OffscreenGraphics.WidgetHandle = Handle;
			else
				Device = null;

			float devicePixelRatio;
			using (var g = CreateGraphics())
			{
				devicePixelRatio = g.DpiX / 96f;
			}

			if (OffscreenGraphics.PixelsPerDip != devicePixelRatio)
				SetDevicePixelRatio(devicePixelRatio);
			else
				OnSizeChanged(EventArgs.Empty);

			base.OnHandleCreated(e);
		}

		protected override void OnHandleDestroyed(EventArgs e)
		{
			if (GetState(State.Created) && !GetState(State.Closing)) OnDestroyBrowser();

			if (OffscreenGraphics != null)
				OffscreenGraphics.WidgetHandle = IntPtr.Zero;

			base.OnHandleDestroyed(e);
		}

		protected virtual bool GetCefScreenInfo(ref CefScreenInfo screenInfo)
		{
			var device = Device;
			if (device == null)
				return false;
			screenInfo = device.ScreenInfo;
			return true;
		}

		protected virtual bool CefPointToScreen(ref CefPoint point)
		{
			var device = Device;
			if (device == null)
			{
				point.Scale(OffscreenGraphics.PixelsPerDip);
				NativeMethods.MapWindowPoints(OffscreenGraphics.WidgetHandle, IntPtr.Zero, ref point, 1);
				return true;
			}

			return device.PointToScreen(ref point);
		}

		protected virtual CefPoint PointToViewport(CefPoint point)
		{
			var scale = OffscreenGraphics.PixelsPerDip;
			var viewport = Device;
			if (viewport != null) scale = scale * viewport.Scale;
			var viewportRect = GetViewportRect();
			return new CefPoint((int) ((point.X - viewportRect.X) / scale), (int) ((point.Y - viewportRect.Y) / scale));
		}

		protected virtual bool PointInViewport(int x, int y)
		{
			var viewportRect = GetViewportRect();
			return viewportRect.X <= x && x <= viewportRect.Right && viewportRect.Y <= y && y <= viewportRect.Bottom;
		}

		protected virtual unsafe CefRect GetCefRootBounds()
		{
			var device = Device;
			if (device == null)
			{
				const int GA_ROOT = 2;

				RECT windowBounds;
				var hwnd = NativeMethods.GetAncestor(OffscreenGraphics.WidgetHandle, GA_ROOT);
				if (NativeMethods.DwmIsCompositionEnabled() && NativeMethods.DwmGetWindowAttribute(hwnd,
					    DWMWINDOWATTRIBUTE.ExtendedFrameBounds, &windowBounds, sizeof(RECT)) == 0
				    || NativeMethods.GetWindowRect(hwnd, out windowBounds))
				{
					var ppd = OffscreenGraphics.PixelsPerDip;
					if (ppd == 1.0f)
						return windowBounds.ToCefRect();
					return new CefRect(
						(int) (windowBounds.Left / ppd),
						(int) (windowBounds.Top / ppd),
						(int) ((windowBounds.Right - windowBounds.Left) / ppd),
						(int) ((windowBounds.Bottom - windowBounds.Top) / ppd)
					);
				}

				return OffscreenGraphics.GetBounds();
			}

			return device.GetRootBounds();
		}

		private void UpdateOffscreenViewLocation()
		{
			if (OffscreenGraphics is null)
				return;

			var device = Device;
			if (device is null)
			{
				var screenPoint = PointToScreen(default);
				OffscreenGraphics.SetLocation(screenPoint.X, screenPoint.Y);
			}
			else
			{
				CefPoint screenPoint = default;
				device.PointToScreen(ref screenPoint);
				OffscreenGraphics.SetLocation(screenPoint.X, screenPoint.Y);
			}
		}

		protected virtual void OnCursorChange(CursorChangeEventArgs e)
		{
			Cursor = e.Cursor;
		}

		protected virtual void OnSetToolTip(TooltipEventArgs e)
		{
			var toolTip = ToolTip;
			if (toolTip != null && toolTip.GetToolTip(this) != e.Text) toolTip.SetToolTip(this, e.Text);
		}

		/// <summary>
		///  Raises <see cref="WebView.StartDragging" /> event.
		/// </summary>
		/// <param name="e">The event data.</param>
		protected virtual void OnStartDragging(StartDraggingEventArgs e)
		{
			StartDragging?.Invoke(this, e);
			if (e.Handled)
				return;

			DoDragDrop(new CefNetDragData(this, e.Data), e.AllowedEffects.ToDragDropEffects());
			DragSourceSystemDragEnded();
			e.Handled = true;
		}

		public void CefInvalidate()
		{
			var browserHost = BrowserObject?.Host;
			if (browserHost != null)
			{
				browserHost.Invalidate(CefPaintElementType.View);
				browserHost.Invalidate(CefPaintElementType.Popup);
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			if (DesignMode)
			{
				e.Graphics.DrawString(GetType().Name, Font, Brushes.Black, new PointF(2, 2));
				return;
			}

			SetDevicePixelRatio(e.Graphics.DpiX / 96f);
			if (WindowlessRenderingEnabled)
			{
				var renderBounds = OffscreenGraphics.GetRenderBounds();
				DrawDeviceArea(e.Graphics, e.ClipRectangle);
				OffscreenGraphics.Render(e.Graphics, e.ClipRectangle);

				// redraw background if render has wrong size
				var device = Device;
				if (device != null)
				{
					var deviceBounds = device.GetBounds(OffscreenGraphics.PixelsPerDip);
					if (renderBounds.Width > deviceBounds.Width || renderBounds.Height > deviceBounds.Height)
					{
						e.Graphics.ExcludeClip(deviceBounds.ToRectangle());
						DrawDeviceArea(e.Graphics, ClientRectangle);
					}
				}
			}

			base.OnPaint(e);
		}

		protected virtual void DrawDeviceArea(Graphics graphics, Rectangle rectangle)
		{
			var device = Device;
			if (device != null)
			{
				var deviceBounds = device.GetBounds(OffscreenGraphics.PixelsPerDip);
				var background = BackColor;
				if (background.A > 0)
					using (var brush = new SolidBrush(background))
					{
						graphics.FillRectangle(brush, rectangle);
					}

				graphics.DrawRectangle(Pens.Gray, deviceBounds.X - 1, deviceBounds.Y - 1, deviceBounds.Width + 1,
					deviceBounds.Height + 1);
			}
		}

		/// <summary>
		///  Raises the <see cref="CefPaint" /> event.
		/// </summary>
		/// <param name="e">A <see cref="CefPaintEventArgs" /> that contains event data.</param>
		protected virtual void OnCefPaint(CefPaintEventArgs e)
		{
			CefPaint?.Invoke(this, e);

			if (GetState(State.Closing))
				return;

			var invalidRect = OffscreenGraphics.Draw(e);
			Device?.MoveToDevice(ref invalidRect, OffscreenGraphics.PixelsPerDip);

			if (GetState(State.Closing))
				return;

			try
			{
				if (invalidRect.Width > 0 && invalidRect.Height > 0)
				{
					var useInvalidate = false;

					Graphics graphics = null;
					try
					{
						if (!IsHandleCreated)
							return;
						graphics = CreateGraphics();

						var renderBounds = OffscreenGraphics.GetRenderBounds();
						OffscreenGraphics.Render(graphics, invalidRect.ToRectangle());

						// draw background if render has wrong size
						var device = Device;
						if (device != null)
						{
							var deviceBounds = device.GetBounds(OffscreenGraphics.PixelsPerDip);
							if (renderBounds.Width > deviceBounds.Width || renderBounds.Height > deviceBounds.Height)
							{
								graphics.ExcludeClip(deviceBounds.ToRectangle());
								DrawDeviceArea(graphics, ClientRectangle);
							}
						}
					}
					catch (ObjectDisposedException) { throw; }
					catch { useInvalidate = true; }
					finally
					{
						graphics?.Dispose();
					}

					if (useInvalidate)
					{
						if (!IsHandleCreated)
							return;
						Invalidate(invalidRect.ToRectangle(), false);
					}
				}
				else
				{
					if (!IsHandleCreated)
						return;
					Invalidate();
				}
			}
			catch (ObjectDisposedException) { }
		}

		protected virtual void OnPopupShow(PopupShowEventArgs e)
		{
			var invalidRect = OffscreenGraphics.GetPopupBounds();

			var bounds = e.Bounds;
			var ppd = OffscreenGraphics.PixelsPerDip;
			var device = Device;
			if (device != null)
			{
				invalidRect.Offset((int) (device.X * ppd), (int) (device.Y * ppd));
				device.ScaleToViewport(ref bounds, ppd);
			}
			else
			{
				bounds.Scale(ppd);
			}

			OffscreenGraphics.SetPopup(e.Visible, bounds);
			Invalidate(invalidRect, false);
		}

		/// <summary>
		///  Raises the <see cref="Control.SizeChanged" /> event.
		/// </summary>
		/// <param name="e">An <see cref="EventArgs" /> that contains event data.</param>
		protected override void OnSizeChanged(EventArgs e)
		{
			base.OnSizeChanged(e);

			if (WindowlessRenderingEnabled)
			{
				UpdateOffscreenViewLocation();

				var device = Device;
				if (device is null)
				{
					if (OffscreenGraphics.SetSize(Width, Height)) BrowserObject?.Host.WasResized();
				}
				else
				{
					var viewportRect = device.ViewportRect;
					if (OffscreenGraphics.SetSize(viewportRect.Width, viewportRect.Height))
						BrowserObject?.Host.WasResized();
				}
			}
		}

		protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
		{
			if (specified == BoundsSpecified.All || specified == BoundsSpecified.None)
			{
				if (width == 0 || height == 0)
					return;
			}
			else if (specified == BoundsSpecified.Width && width == 0)
			{
				return;
			}
			else if (specified == BoundsSpecified.Height && height == 0)
			{
				return;
			}

			base.SetBoundsCore(x, y, width, height, specified);
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			if (PointInViewport(e.X, e.Y))
			{
				if (WindowlessRenderingEnabled)
				{
					var modifiers = CefEventFlags.None;
					if (e.Button == MouseButtons.Left)
						modifiers |= CefEventFlags.LeftMouseButton;
					if (e.Button == MouseButtons.Right)
						modifiers |= CefEventFlags.RightMouseButton;
					SendMouseMoveEvent(e.X, e.Y, modifiers);
				}
			}

			base.OnMouseMove(e);
		}

		protected override void OnMouseLeave(EventArgs e)
		{
			if (WindowlessRenderingEnabled) SendMouseLeaveEvent();
			base.OnMouseLeave(e);
		}

		private static CefMouseButtonType GetButton(MouseEventArgs e)
		{
			switch (e.Button)
			{
				case MouseButtons.Right:
					return CefMouseButtonType.Right;
				case MouseButtons.Middle:
					return CefMouseButtonType.Middle;
			}

			return CefMouseButtonType.Left;
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			if (PointInViewport(e.X, e.Y))
				if (WindowlessRenderingEnabled)
					SendMouseDownEvent(e.X, e.Y, GetButton(e), e.Clicks, GetModifierKeys());
			base.OnMouseDown(e);
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			if (PointInViewport(e.X, e.Y))
				if (WindowlessRenderingEnabled)
					SendMouseUpEvent(e.X, e.Y, GetButton(e), e.Clicks, GetModifierKeys());
		}

		protected override void OnMouseWheel(MouseEventArgs e)
		{
			base.OnMouseWheel(e);

			if (!ModifierKeys.HasFlag(Keys.Shift))
			{
				if (PointInViewport(e.X, e.Y))
					if (WindowlessRenderingEnabled)
					{
						SendMouseWheelEvent(e.X, e.Y, 0, e.Delta);
						((HandledMouseEventArgs) e).Handled = true;
					}

				return;
			}

			OnMouseHWheel(e);
		}

		protected virtual void OnMouseHWheel(MouseEventArgs e)
		{
			if (PointInViewport(e.X, e.Y))
				if (WindowlessRenderingEnabled)
					SendMouseWheelEvent(e.X, e.Y, e.Delta, 0);
			((HandledMouseEventArgs) e).Handled = true;
		}

		private void WmMouseHWheel(ref Message m)
		{
			var p = PointToClient(new Point(NativeMethods.LoWord(m.LParam), NativeMethods.HiWord(m.LParam)));
			var delta = -NativeMethods.HiWord(m.WParam);
			if (Math.Abs(delta) < 10) delta = Math.Sign(delta) * 10;
			var handledMouseEventArgs = new HandledMouseEventArgs(MouseButtons.None, 0, p.X, p.Y, delta);
			OnMouseHWheel(handledMouseEventArgs);
			m.Result = new IntPtr(!handledMouseEventArgs.Handled ? 1 : 0);
			if (!handledMouseEventArgs.Handled) DefWndProc(ref m);
		}

		protected override void OnDragEnter(DragEventArgs e)
		{
			base.OnDragEnter(e);

			var mousePos = PointToClient(new Point(e.X, e.Y));
			if (WindowlessRenderingEnabled && PointInViewport(mousePos.X, mousePos.Y))
			{
				SendDragEnterEvent(mousePos.X, mousePos.Y, e.GetModifiers(), e.GetCefDragData(),
					e.AllowedEffect.ToCefDragOperationsMask());
				e.Effect = DragDropEffects.Copy & e.AllowedEffect;
			}
		}

		protected override void OnDragOver(DragEventArgs e)
		{
			base.OnDragOver(e);

			var mousePos = PointToClient(new Point(e.X, e.Y));
			if (WindowlessRenderingEnabled && PointInViewport(mousePos.X, mousePos.Y))
				SendDragOverEvent(mousePos.X, mousePos.Y, e.GetModifiers(), e.AllowedEffect.ToCefDragOperationsMask());
		}

		protected override void OnDragLeave(EventArgs e)
		{
			base.OnDragLeave(e);

			if (!WindowlessRenderingEnabled)
				return;

			SendDragLeaveEvent();
		}

		protected override void OnDragDrop(DragEventArgs e)
		{
			base.OnDragDrop(e);

			if (!WindowlessRenderingEnabled)
				return;

			var mousePos = PointToClient(new Point(e.X, e.Y));
			if (WindowlessRenderingEnabled && PointInViewport(mousePos.X, mousePos.Y))
			{
				SendDragDropEvent(mousePos.X, mousePos.Y, e.GetModifiers());
				if (e.Data.GetDataPresent(nameof(CefNetDragData)))
				{
					var data = (CefNetDragData) e.Data.GetData(nameof(CefNetDragData));
					if (data != null && data.Source == this)
						DragSourceEndedAt(mousePos.X, mousePos.Y, e.AllowedEffect.ToCefDragOperationsMask());
				}
			}
		}

		private bool ProcessWindowlessMessage(ref Message m)
		{
			const int MA_ACTIVATE = 0x1;
			const int WM_MOUSEHWHEEL = 0x20E;
			const int WM_INPUTLANGCHANGE = 0x0051;

			switch (m.Msg)
			{
				case WM_INPUTLANGCHANGE:
					SetKeyboardLayoutForCefUIThreadIfNeeded();
					return false;
				case WM_MOUSEHWHEEL:
					WmMouseHWheel(ref m);
					return true;
				case 0x21: // WM_MOUSEACTIVATE:
					Focus();
					m.Result = new IntPtr(MA_ACTIVATE);
					return true;
				case 0x0083: //	WM_NCCALCSIZE:
					m.Result = IntPtr.Zero;
					return true;
				case 0x114: // WM_HSCROLL:
					short delta;
					switch (m.WParam.ToInt64())
					{
						case 0: // SB_LINELEFT
							delta = -1;
							break;
						case 1: // SB_LINERIGHT
							delta = 1;
							break;
						default:
							base.WndProc(ref m);
							return true;
					}

					var mousePos = MousePosition;
					NativeMethods.PostMessage(m.HWnd, WM_MOUSEHWHEEL, NativeMethods.MakeParam(delta, 0),
						NativeMethods.MakeParam((short) mousePos.Y, (short) mousePos.X));
					m.Result = IntPtr.Zero;
					return true;
				case 0x84: //WM_NCHITTEST
					m.Result = new IntPtr(1); // HTCLIENT
					return true;
			}

			return false;
		}

		protected override bool ProcessCmdKey(ref Message m, Keys keyData)
		{
			const int WM_SYSKEYDOWN = 0x0104;
			const int WM_KEYDOWN = 0x0100;

			if (WindowlessRenderingEnabled)
				if (m.Msg == WM_KEYDOWN || m.Msg == WM_SYSKEYDOWN)
				{
					var key = (Keys) m.WParam.ToInt64();
					if (key >= Keys.PageUp && key <= Keys.Down || key == Keys.Tab)
					{
						var e = new CefKeyEvent();
						e.WindowsKeyCode = (int) m.WParam;
						e.NativeKeyCode = KeycodeConverter.GetWindowsScanCodeFromLParam(m.LParam);
						e.IsSystemKey = m.Msg == WM_SYSKEYDOWN;
						e.Type = CefKeyEventType.RawKeyDown;
						e.Modifiers = (uint) GetCefKeyboardModifiers((Keys) m.WParam.ToInt64(), m.LParam);
						BrowserObject?.Host.SendKeyEvent(e);
						return true;
					}
				}

			return base.ProcessCmdKey(ref m, keyData);
		}

		protected override unsafe bool ProcessKeyEventArgs(ref Message m)
		{
			const int WM_KEYDOWN = 0x0100;
			const int WM_KEYUP = 0x0101;
			const int WM_SYSKEYDOWN = 0x0104;
			const int WM_SYSKEYUP = 0x0105;
			const int WM_SYSCHAR = 0x0106;

			if (WindowlessRenderingEnabled)
			{
				var k = new CefKeyEvent();
				k.WindowsKeyCode = (int) m.WParam;
				k.NativeKeyCode = KeycodeConverter.GetWindowsScanCodeFromLParam(m.LParam);
				k.IsSystemKey = m.Msg >= WM_SYSKEYDOWN && m.Msg <= WM_SYSCHAR;

				CefEventFlags modifiers;
				if (m.Msg == WM_KEYDOWN || m.Msg == WM_SYSKEYDOWN)
				{
					modifiers = GetCefKeyboardModifiers((Keys) m.WParam.ToInt64(), m.LParam);
					_keydownModifiers = modifiers;
					k.Type = CefKeyEventType.RawKeyDown;
					SetKeyboardLayoutForCefUIThreadIfNeeded();
				}
				else if (m.Msg == WM_KEYUP || m.Msg == WM_SYSKEYUP)
				{
					modifiers = GetCefKeyboardModifiers((Keys) m.WParam.ToInt64(), m.LParam);
					if (_keydownModifiers.HasFlag(CefEventFlags.IsRight))
						modifiers = CefEventFlags.IsRight & ~CefEventFlags.IsLeft;
					_keydownModifiers = CefEventFlags.None;
					k.Type = CefKeyEventType.KeyUp;
					SetKeyboardLayoutForCefUIThreadIfNeeded();
				}
				else
				{
					k.Type = CefKeyEventType.Char;
					modifiers = GetCefKeyboardModifiers(
						(Keys) NativeMethods.MapVirtualKey(((uint) m.LParam.ToPointer() >> 16) & 0xFFU,
							MapVirtualKeyType.MAPVK_VSC_TO_VK_EX), m.LParam);
				}

				k.Modifiers = (uint) modifiers;

				BrowserObject?.Host.SendKeyEvent(k);
			}

			return base.ProcessKeyEventArgs(ref m);
		}

		protected static CefEventFlags GetModifierKeys()
		{
			var modifiers = CefEventFlags.None;
			var modKeys = ModifierKeys;
			if (modKeys.HasFlag(Keys.Shift))
				modifiers |= CefEventFlags.ShiftDown;
			if (modKeys.HasFlag(Keys.Control))
				modifiers |= CefEventFlags.ControlDown;
			if (modKeys.HasFlag(Keys.Alt))
				modifiers |= CefEventFlags.AltDown;
			return modifiers;
		}

		protected unsafe CefEventFlags GetCefKeyboardModifiers(Keys key, IntPtr lparam)
		{
			const int KF_EXTENDED = 0x100;

			var modifiers = GetModifierKeys();

			if (IsKeyLocked(Keys.NumLock))
				modifiers |= CefEventFlags.NumLockOn;
			if (IsKeyLocked(Keys.CapsLock))
				modifiers |= CefEventFlags.CapsLockOn;

			switch (key)
			{
				case Keys.Return:
					if ((((uint) lparam.ToPointer() >> 16) & KF_EXTENDED) != 0)
						modifiers |= CefEventFlags.IsKeyPad;
					break;
				case Keys.Insert:
				case Keys.Delete:
				case Keys.Home:
				case Keys.End:
				case Keys.Prior:
				case Keys.Next:
				case Keys.Up:
				case Keys.Down:
				case Keys.Left:
				case Keys.Right:
					if ((((uint) lparam.ToPointer() >> 16) & KF_EXTENDED) == 0)
						modifiers |= CefEventFlags.IsKeyPad;
					break;
				case Keys.NumLock:
				case Keys.NumPad0:
				case Keys.NumPad1:
				case Keys.NumPad2:
				case Keys.NumPad3:
				case Keys.NumPad4:
				case Keys.NumPad5:
				case Keys.NumPad6:
				case Keys.NumPad7:
				case Keys.NumPad8:
				case Keys.NumPad9:
				case Keys.Divide:
				case Keys.Multiply:
				case Keys.Subtract:
				case Keys.Add:
				case Keys.Decimal:
				case Keys.Clear:
					modifiers |= CefEventFlags.IsKeyPad;
					break;
				case Keys.LShiftKey:
				case Keys.LControlKey:
				case Keys.LMenu:
				case Keys.LWin:
					modifiers |= CefEventFlags.IsLeft;
					break;
				case Keys.RShiftKey:
				case Keys.RControlKey:
				case Keys.RMenu:
				case Keys.RWin:
					modifiers |= CefEventFlags.IsLeft;
					break;
				case Keys.ShiftKey:
					if (NativeMethods.GetKeyState(VirtualKeys.RShiftKey).HasFlag(KeyState.Pressed))
						modifiers |= CefEventFlags.IsRight;
					else
						modifiers |= CefEventFlags.IsLeft;
					break;
				case Keys.ControlKey:
					if (NativeMethods.GetKeyState(VirtualKeys.RControlKey).HasFlag(KeyState.Pressed))
						modifiers |= CefEventFlags.IsRight;
					else
						modifiers |= CefEventFlags.IsLeft;
					break;
				case Keys.Menu:
					if (NativeMethods.GetKeyState(VirtualKeys.RMenu).HasFlag(KeyState.Pressed))
						modifiers |= CefEventFlags.IsRight;
					else
						modifiers |= CefEventFlags.IsLeft;
					break;
				default:
					if ((((uint) lparam.ToPointer() >> 16) & KF_EXTENDED) != 0)
						modifiers |= CefEventFlags.IsKeyPad;
					break;
			}

			return modifiers;
		}

		/// <summary>
		///  Sets the current input locale identifier for the UI thread in the browser.
		/// </summary>
		protected void SetKeyboardLayoutForCefUIThreadIfNeeded()
		{
			var hkl = NativeMethods.GetKeyboardLayout(0);
			if (_keyboardLayout == hkl)
				return;

			if (CefApi.CurrentlyOn(CefThreadId.UI))
				_keyboardLayout = hkl;
			else
				CefNetApi.Post(CefThreadId.UI, () =>
				{
					NativeMethods.ActivateKeyboardLayout(hkl, 0);
					_keyboardLayout = hkl;
				});
		}
	}
}