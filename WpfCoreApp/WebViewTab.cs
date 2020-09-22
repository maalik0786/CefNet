using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using CefNet;
using CefNet.Wpf;

namespace WpfCoreApp
{
	public class WebViewTab : TabItem
	{
		public WebViewTab()
			: this(new CustomWebView())
		{
		}

		//public WebViewTab(CefBrowserSettings settings, CefRequestContext requestContext)
		//	: this(new WebView(settings, requestContext))
		//{

		//}

		private WebViewTab(WebView webview)
		{
			//webview.Dock = DockStyle.Fill;
			webview.CreateWindow += Webview_CreateWindow;
			webview.DocumentTitleChanged += HandleDocumentTitleChanged;
			WebView = webview;
			Header = new WebViewTabTitle(this);
			//this.Controls.Add(webview);
		}

		public string Title
		{
			get => ((WebViewTabTitle) Header).Text;
			set => ((WebViewTabTitle) Header).Text = value;
		}

		public IChromiumWebView WebView { get; protected set; }

		protected override void OnInitialized(EventArgs e)
		{
			base.OnInitialized(e);
			Content = WebView;
		}

		public void Close()
		{
			WebView.Close();

			var tabs = Parent as TabControl;
			if (tabs == null)
				return;
			tabs.Items.Remove(this);
		}

		private void HandleDocumentTitleChanged(object sender, DocumentTitleChangedEventArgs e)
		{
			Title = e.Title;
			//this.ToolTipText = e.Title;
		}

		private void Webview_CreateWindow(object sender, CreateWindowEventArgs e)
		{
			var tabs = this.FindTabControl();
			if (tabs == null)
			{
				e.Cancel = true;
				return;
			}

			var wpfwindow = Window.GetWindow(this);
			if (wpfwindow == null)
				throw new InvalidOperationException("Window not found!");

			var webview = new CustomWebView((WebView) WebView);
			e.WindowInfo.SetAsWindowless(new WindowInteropHelper(wpfwindow).Handle);
			e.Client = webview.Client;
			OnCreateWindow(webview);
		}


		protected void OnCreateWindow(WebView webview)
		{
			var tab = new WebViewTab(webview);
			var tabs = this.FindTabControl();
			tabs.Items.Add(tab);
			tabs.SelectedItem = tab;
		}

		private class WebViewTabTitle : Control
		{
			private readonly WebViewTab _tab;
			private FormattedText _xButton;
			private Brush _xbuttonBrush;

			public WebViewTabTitle(WebViewTab tab)
			{
				_tab = tab;
			}

			public string Text
			{
				get => FormattedText?.Text;
				set
				{
					if (string.IsNullOrWhiteSpace(value))
					{
						FormattedText = null;
						InvalidateMeasure();
						return;
					}

					FormattedText = new FormattedText(value, CultureInfo.CurrentUICulture, FlowDirection.LeftToRight,
						new Typeface(FontFamily, FontStyle, FontWeight, FontStretch), FontSize, Brushes.Black,
						VisualTreeHelper.GetDpi(this).PixelsPerDip);
					InvalidateMeasure();
				}
			}

			private FormattedText FormattedText { get; set; }

			private FormattedText XButton
			{
				get
				{
					if (_xButton == null)
						_xButton = new FormattedText("x", CultureInfo.CurrentUICulture, FlowDirection.LeftToRight,
							new Typeface(FontFamily, FontStyle, FontWeights.Bold, FontStretch), FontSize, Brushes.Gray,
							VisualTreeHelper.GetDpi(this).PixelsPerDip);
					return _xButton;
				}
			}

			protected override Size MeasureOverride(Size constraint)
			{
				var ft = FormattedText;
				if (ft == null)
					return base.MeasureOverride(constraint);
				return new Size(ft.Width + XButton.Width + 4, ft.Height);
			}

			protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
			{
				if (GetXButtonRect().Contains(e.GetPosition(this))) _tab.Close();
			}

			private Rect GetXButtonRect()
			{
				return new Rect(ActualWidth - XButton.Width, 0, XButton.Width, XButton.Height);
			}

			protected override void OnMouseMove(MouseEventArgs e)
			{
				SetXButtonBrush(GetXButtonRect().Contains(e.GetPosition(this)) ? Brushes.Black : Brushes.Gray);
				base.OnMouseMove(e);
			}

			protected override void OnMouseLeave(MouseEventArgs e)
			{
				SetXButtonBrush(Brushes.Gray);
				base.OnMouseLeave(e);
			}

			private void SetXButtonBrush(Brush brush)
			{
				if (brush != _xbuttonBrush)
				{
					_xbuttonBrush = brush;
					XButton.SetForegroundBrush(brush);
					InvalidateVisual();
				}
			}

			protected override void OnRender(DrawingContext drawingContext)
			{
				var formattedText = FormattedText;
				if (formattedText == null)
					return;
				drawingContext.DrawText(formattedText, new Point());
				drawingContext.DrawText(XButton, new Point(ActualWidth - XButton.Width, 0));
			}
		}
	}
}