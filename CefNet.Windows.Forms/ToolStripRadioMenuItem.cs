using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace CefNet.Windows.Forms
{
	/// <summary>
	///  See: https://stackoverflow.com/a/52271345
	/// </summary>
	internal sealed class ToolStripRadioMenuItem : ToolStripMenuItem
	{
		private bool mouseDownState;

		private bool mouseHoverState;

		public ToolStripRadioMenuItem()
		{
			Initialize();
		}

		public ToolStripRadioMenuItem(string text)
			: base(text, null, (EventHandler) null)
		{
			Initialize();
		}

		public ToolStripRadioMenuItem(Image image)
			: base(null, image, (EventHandler) null)
		{
			Initialize();
		}

		public ToolStripRadioMenuItem(string text, Image image)
			: base(text, image, (EventHandler) null)
		{
			Initialize();
		}

		public ToolStripRadioMenuItem(string text, Image image, EventHandler onClick)
			: base(text, image, onClick)
		{
			Initialize();
		}

		public ToolStripRadioMenuItem(string text, Image image, EventHandler onClick, string name)
			: base(text, image, onClick, name)
		{
			Initialize();
		}

		public ToolStripRadioMenuItem(string text, Image image, params ToolStripItem[] dropDownItems)
			: base(text, image, dropDownItems)
		{
			Initialize();
		}

		public ToolStripRadioMenuItem(string text, Image image, EventHandler onClick, Keys shortcutKeys)
			: base(text, image, onClick)
		{
			Initialize();
			ShortcutKeys = shortcutKeys;
		}

		// Enable the item only if its parent item is in the checked state 
		// and its Enabled property has not been explicitly set to false. 
		public override bool Enabled
		{
			get
			{
				var ownerMenuItem = OwnerItem as ToolStripMenuItem;

				// Use the base value in design mode to prevent the designer
				// from setting the base value to the calculated value.
				if (!DesignMode && ownerMenuItem != null && ownerMenuItem.CheckOnClick)
					return base.Enabled && ownerMenuItem.Checked;
				return base.Enabled;
			}

			set => base.Enabled = value;
		}

		// Called by all constructors to initialize CheckOnClick.
		private void Initialize()
		{
			CheckOnClick = true;
		}

		protected override void OnCheckedChanged(EventArgs e)
		{
			base.OnCheckedChanged(e);

			// If this item is no longer in the checked state, do nothing.
			if (!Checked)
				return;

			var parent = Parent;
			if (parent == null)
				return;

			// Clear the checked state for all siblings. 
			foreach (ToolStripItem item in parent.Items)
			{
				var radioItem = item as ToolStripRadioMenuItem;
				if (radioItem != null && radioItem != this && radioItem.Checked)
				{
					radioItem.Checked = false;

					// Only one item can be selected at a time, 
					// so there is no need to continue.
					return;
				}
			}
		}

		protected override void OnClick(EventArgs e)
		{
			// If the item is already in the checked state, do not call 
			// the base method, which would toggle the value. 
			if (Checked)
				return;

			base.OnClick(e);
		}

		// Let the item paint itself, and then paint the RadioButton
		// where the check mark is displayed, covering the check mark
		// if it is present.
		protected override void OnPaint(PaintEventArgs e)
		{
			// If the client sets the Image property, the selection behavior
			// remains unchanged, but the RadioButton is not displayed and the
			// selection is indicated only by the selection rectangle. 
			if (Image != null)
			{
				base.OnPaint(e);
				return;
			}

			// Determine the correct state of the RadioButton.
			var buttonState = RadioButtonState.UncheckedNormal;
			if (Enabled)
			{
				if (mouseDownState)
				{
					if (Checked)
						buttonState = RadioButtonState.CheckedPressed;
					else
						buttonState = RadioButtonState.UncheckedPressed;
				}
				else if (mouseHoverState)
				{
					if (Checked)
						buttonState = RadioButtonState.CheckedHot;
					else
						buttonState = RadioButtonState.UncheckedHot;
				}
				else if (Checked)
				{
					buttonState = RadioButtonState.CheckedNormal;
				}
			}
			else if (Checked)
			{
				buttonState = RadioButtonState.CheckedDisabled;
			}
			else
			{
				buttonState = RadioButtonState.UncheckedDisabled;
			}

			// Calculate the rectangle at which to display the RadioButton.
			var glyphSize = RadioButtonRenderer.GetGlyphSize(e.Graphics, buttonState);
			var contentRect = ContentRectangle;
			var imageLocation = contentRect.Location;
			var scale = e.Graphics.DpiX / 96f;
			imageLocation.Offset((int) Math.Round(5f * scale, MidpointRounding.AwayFromZero),
				(contentRect.Height - glyphSize.Height) / 2);

			var renderer = Owner?.Renderer;
			if (renderer != null)
			{
				renderer.DrawMenuItemBackground(new ToolStripItemRenderEventArgs(e.Graphics, this));
				var x = (int) (32 * scale);
				e.Graphics.SetClip(new Rectangle(x, contentRect.Y, Math.Max(contentRect.Width - x, 0),
					contentRect.Height));
				base.OnPaint(e);
				e.Graphics.ResetClip();
			}
			else
			{
				base.OnPaint(e);
			}

			// If the item is selected and the RadioButton paints with partial
			// transparency, such as when theming is enabled, the check mark
			// shows through the RadioButton image. In this case, paint a 
			// non-transparent background first to cover the check mark.
			if (Checked && RadioButtonRenderer.IsBackgroundPartiallyTransparent(buttonState))
				e.Graphics.FillEllipse(SystemBrushes.Control,
					new Rectangle(imageLocation.X, imageLocation.Y, glyphSize.Width - 1, glyphSize.Height - 1));

			RadioButtonRenderer.DrawRadioButton(e.Graphics, imageLocation, buttonState);
		}

		protected override void OnMouseEnter(EventArgs e)
		{
			mouseHoverState = true;

			// Force the item to repaint with the new RadioButton state.
			Invalidate();

			base.OnMouseEnter(e);
		}

		protected override void OnMouseLeave(EventArgs e)
		{
			mouseHoverState = false;
			base.OnMouseLeave(e);
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			mouseDownState = true;

			// Force the item to repaint with the new RadioButton state.
			Invalidate();

			base.OnMouseDown(e);
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			mouseDownState = false;
			base.OnMouseUp(e);
		}

		// When OwnerItem becomes available, if it is a ToolStripMenuItem 
		// with a CheckOnClick property value of true, subscribe to its 
		// CheckedChanged event. 
		protected override void OnOwnerChanged(EventArgs e)
		{
			var ownerMenuItem = OwnerItem as ToolStripMenuItem;

			if (ownerMenuItem != null && ownerMenuItem.CheckOnClick)
				ownerMenuItem.CheckedChanged += OwnerMenuItem_CheckedChanged;

			base.OnOwnerChanged(e);
		}

		// When the checked state of the parent item changes, 
		// repaint the item so that the new Enabled state is displayed. 
		private void OwnerMenuItem_CheckedChanged(object sender, EventArgs e)
		{
			Invalidate();
		}
	}
}