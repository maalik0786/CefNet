﻿using System;
using Avalonia;
using Avalonia.Collections;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace CefNet.Internal
{
	internal sealed class AvaloniaContextMenuRunner
	{
		private readonly MenuModel Model;
		private CefRunContextMenuCallback Callback;
		private ContextMenu Menu;

		public AvaloniaContextMenuRunner(CefMenuModel model, CefRunContextMenuCallback callback)
		{
			Model = MenuModel.FromCefMenu(model);
			Callback = callback;
		}

		public void Build()
		{
			if (Menu != null)
				throw new InvalidOperationException();

			Menu = new ContextMenu();
			Menu.MenuClosed += Menu_Closed;
			Build(Model, (AvaloniaList<object>) Menu.Items);
		}

		private void Menu_Closed(object sender, RoutedEventArgs e)
		{
			Cancel();
		}

		private void MenuItem_Click(object sender, RoutedEventArgs e)
		{
			var clickedItem = sender as MenuItem;
			var cid = clickedItem?.Tag;
			if (cid != null)
			{
				Callback.Continue((int) cid, CefEventFlags.LeftMouseButton);
				Callback = null;
			}
		}

		private void Build(MenuModel model, AvaloniaList<object> menu)
		{
			var count = model.Count;
			for (var i = 0; i < count; i++)
			{
				var isSubmenu = false;
				MenuItem menuItem;
				switch (model.GetTypeAt(i))
				{
					case CefMenuItemType.Separator:
						menu.Add(new Separator());
						continue;
					case CefMenuItemType.Check:
						menuItem = new MenuItem();
						menuItem.Icon = new CheckBox
						{
							IsChecked = model.IsCheckedAt(i),
							Margin = new Thickness(-2, 0, 0, 0),
							BorderThickness = new Thickness()
						};
						break;
					case CefMenuItemType.Radio:
						menuItem = new MenuItem();
						menuItem.Icon = new RadioButton
						{
							IsChecked = model.IsCheckedAt(i),
							Margin = new Thickness(-2, 0, 0, 0),
							BorderThickness = new Thickness()
						};
						break;
					case CefMenuItemType.Command:
						menuItem = new MenuItem();
						break;
					case CefMenuItemType.Submenu:
						isSubmenu = true;
						menuItem = new MenuItem();
						if (model.IsEnabledAt(i)) Build(model.GetSubMenuAt(i), (AvaloniaList<object>) menuItem.Items);
						break;
					default:
						continue;
				}

				if (!isSubmenu)
				{
					menuItem.Click += MenuItem_Click;
					menuItem.Tag = model.GetCommandIdAt(i);
				}

				menuItem.Header = model.GetLabelAt(i).Replace('&', '_');
				menuItem.IsEnabled = model.IsEnabledAt(i);
				//menuItem.Foreground = model.GetColorAt(i, CefMenuColorType.Text, out CefColor color) ? new SolidColorBrush(color.ToColor()) : SystemColors.MenuTextBrush;
				menu.Add(menuItem);
			}
		}

		public void RunMenuAt(Control control, Point point)
		{
			//Menu.PlacementTarget = control;
			//Menu.Placement = PlacementMode.Relative;
			//Menu.HorizontalOffset = point.X;
			//Menu.VerticalOffset = point.Y;
			Menu.Open(control);
		}

		public void Cancel()
		{
			Callback?.Cancel();
			Callback = null;
		}
	}
}