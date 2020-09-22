using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using CefNet;
using CefNet.WinApi;

namespace WinFormsCoreApp
{
	internal sealed class WebViewTabControl : TabControl
	{
		private const int TCM_ADJUSTRECT = 0x1328;
		private const int TCM_GETITEMRECT = 0x1300 + 10;
		private const int WM_PAINT = 0x000F;

		private Rectangle? activeCloseButtonRect;

		protected override unsafe void WndProc(ref Message m)
		{
			switch (m.Msg)
			{
				case TCM_ADJUSTRECT:
					// https://stackoverflow.com/a/32055608
					var rect = (RECT*) m.LParam;
					rect->Left = rect->Left - 1;
					rect->Top = rect->Top;
					rect->Right = rect->Right + 4;
					rect->Bottom = rect->Bottom + 4;
					break;
				case WM_PAINT:
					DefWndProc(ref m);

					var mousePos = PointToClient(MousePosition);
					var activeTabIndex = SelectedIndex;
					using (var g = CreateGraphics())
					using (var normalPen = new Pen(Brushes.LightGray, 2))
					using (var selectedPen = new Pen(Brushes.Black, 2))
					{
						var scale = g.DpiX / 96f;
						g.SmoothingMode = SmoothingMode.AntiAlias;
						for (var index = 0; index < TabCount; index++)
						{
							var pen = normalPen;
							float dy = index == activeTabIndex ? -1 : 2;
							if (TryGetTabRect(index, out var r))
							{
								var size = 14 * scale;
								var closeEllipseRect = new RectangleF(r.Right - 17 * scale,
									r.Top + (r.Bottom - r.Top - size) / 2f + dy, size, size);
								if (closeEllipseRect.Contains(mousePos))
								{
									pen = selectedPen;
									g.FillEllipse(Brushes.LightGray, closeEllipseRect);
								}

								size = 5 * scale;
								var x0 = closeEllipseRect.X + (closeEllipseRect.Width - size) / 2f;
								var x1 = x0 + size;
								var y0 = r.Top + (r.Bottom - r.Top - size) / 2f + dy;
								var y1 = y0 + size;
								g.DrawLine(pen, x0, y0, x1, y1);
								g.DrawLine(pen, x0, y1, x1, y0);
							}
						}
					}

					return;
			}

			base.WndProc(ref m);
		}


		private bool TryGetActiveCloseButton(MouseEventArgs e, out int index, out Rectangle rect)
		{
			float scale;
			using (var g = CreateGraphics())
			{
				scale = g.DpiX / 96f;
			}

			var size = 14 * scale;
			for (var i = 0; i < TabCount; i++)
				if (TryGetTabRect(i, out var r))
				{
					var closeButton = new RectangleF(r.Right - 17 * scale, r.Top + (r.Bottom - r.Top - size) / 2f, size,
						size);
					if (closeButton.Contains(e.Location))
					{
						rect = Rectangle.Ceiling(closeButton);
						index = i;
						return true;
					}
				}

			index = 0;
			rect = Rectangle.Empty;
			return false;
		}

		private void ActivateCloseButton(Rectangle closeButtonRect)
		{
			activeCloseButtonRect = closeButtonRect;
			closeButtonRect.Inflate(1, 1);
			Invalidate(closeButtonRect, false);
		}

		public bool CloseAllTabs(bool force)
		{
			TabPage tab;
			while ((tab = SelectedTab) != null)
			{
				var ea = new TabPageCloseEventArgs(tab, force);
				OnCloseTab(ea);
				if (ea.Cancel)
					return false;
			}

			return true;
		}

		private void DeactivateCloseButton()
		{
			var closeButtonRect = activeCloseButtonRect;
			activeCloseButtonRect = null;
			if (closeButtonRect.HasValue)
			{
				var r = closeButtonRect.Value;
				r.Inflate(1, 1);
				Invalidate(r, false);
			}
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);

			if (TryGetActiveCloseButton(e, out var index, out var closeButtonRect))
			{
				if (activeCloseButtonRect.GetValueOrDefault() != closeButtonRect) ActivateCloseButton(closeButtonRect);
			}
			else if (activeCloseButtonRect != null)
			{
				DeactivateCloseButton();
			}
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			if (TryGetActiveCloseButton(e, out var index, out var closeButtonRect))
			{
				closeButtonRect.Inflate(-1, -1);
				if (closeButtonRect.Contains(e.Location)) OnCloseTab(new TabPageCloseEventArgs(TabPages[index]));
			}

			base.OnMouseDown(e);
		}

		private void OnCloseTab(TabPageCloseEventArgs e)
		{
			if (e.Force || MessageBox.Show(this, "Do you want to close this tab?", e.Tab.Text, MessageBoxButtons.YesNo,
				MessageBoxIcon.Question) == DialogResult.Yes)
			{
				TabPages.Remove(e.Tab);
				e.Tab.Dispose();
			}
			else
			{
				e.Cancel = true;
			}
		}

		private unsafe bool TryGetTabRect(int tabIndex, out RECT rect)
		{
			fixed (RECT* pRect = &rect)
			{
				var msg = Message.Create(Handle, TCM_GETITEMRECT, new IntPtr(tabIndex), (IntPtr) pRect);
				base.WndProc(ref msg);
				return msg.Result != IntPtr.Zero;
			}
		}

		public void NotifyRootMovedOrResized()
		{
			foreach (TabPage tab in TabPages) (tab as IWebViewTab)?.WebView.NotifyRootMovedOrResized();
		}
	}
}