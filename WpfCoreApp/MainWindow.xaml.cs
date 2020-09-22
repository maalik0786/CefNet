using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using CefNet;
using CefNet.Wpf;

namespace WpfCoreApp
{
	/// <summary>
	///  Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private Style defaultTabsStyle;

		private WindowStyle defaultWindowStyle;
		private bool isFirstLoad = true;

		public MainWindow()
		{
			InitializeComponent();
			Loaded += MainWindow_Loaded;
			EventManager.RegisterClassHandler(typeof(WebView), CustomWebView.FullscreenEvent,
				new EventHandler<FullscreenModeChangeEventArgs>(HandleFullscreenEvent));
		}

		private IChromiumWebView SelectedView => (tabs.SelectedItem as WebViewTab)?.WebView;

		private void HandleFullscreenEvent(object sender, FullscreenModeChangeEventArgs e)
		{
			var tabHeaders = tabs.FindChild<TabPanel>(null);
			if (e.Fullscreen)
			{
				Visibility = Visibility.Collapsed;
				defaultTabsStyle = tabs.ItemContainerStyle;
				defaultWindowStyle = WindowStyle;
				menu.Visibility = Visibility.Collapsed;
				controlsPanel.Visibility = Visibility.Collapsed;
				tabHeaders.Visibility = Visibility.Collapsed;
				WindowStyle = WindowStyle.None;
				WindowState = WindowState.Maximized;
				Topmost = true;
				ResizeMode = ResizeMode.NoResize;
				Visibility = Visibility.Visible;
			}
			else
			{
				tabHeaders.Visibility = Visibility.Collapsed;
				tabs.ItemContainerStyle = defaultTabsStyle;
				menu.Visibility = Visibility.Visible;
				controlsPanel.Visibility = Visibility.Visible;
				tabHeaders.Visibility = Visibility.Visible;
				WindowStyle = defaultWindowStyle;
				WindowState = WindowState.Normal;
				ResizeMode = ResizeMode.CanResize;
				Topmost = false;
			}
		}

		private void MainWindow_Loaded(object sender, RoutedEventArgs e)
		{
			if (!isFirstLoad)
				return;
			isFirstLoad = false;

			AddTab(true);
		}

		private void AddTab(bool useGlobalContext)
		{
			WebViewTab viewTab;
			if (useGlobalContext)
			{
				viewTab = new WebViewTab();
				viewTab.WebView.Navigated += WebView_Navigated;
				tabs.Items.Add(viewTab);
				viewTab.Title = "about:blank";
				tabs.SelectedItem = viewTab;
			}
		}

		private void WebView_Navigated(object sender, NavigatedEventArgs e)
		{
			txtAddress.Text = e.Url;
		}


		private void AddTab_Click(object sender, RoutedEventArgs e)
		{
			AddTab(true);
		}

		private void NavigateButton_Click(object sender, RoutedEventArgs e)
		{
			//SelectedView?.Navigate("http://yandex.ru");
			SelectedView?.Navigate("http://example.com");
		}

		private void txtAddress_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Enter)
				if (Uri.TryCreate(txtAddress.Text, UriKind.Absolute, out var url))
					SelectedView?.Navigate(url.AbsoluteUri);
		}

		private void Window_Closing(object sender, CancelEventArgs e)
		{
			var tabItems = tabs.Items;
			for (var i = tabItems.Count - 1; i >= 0; i--)
				if (tabItems[i] is WebViewTab tab)
					tab.Close();
		}

		private void WebView_TextFound(object sender, ITextFoundEventArgs e)
		{
			if (e.FinalUpdate) SelectedView?.StopFinding(false);
		}

		private void Find_Click(object sender, RoutedEventArgs e)
		{
			SelectedView?.Find(0, "i", true, true, false);
		}
	}
}