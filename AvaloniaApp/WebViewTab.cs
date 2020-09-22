using System;
using Avalonia;
using Avalonia.Collections;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.Media;
using Avalonia.Platform;
using Avalonia.Styling;
using Avalonia.VisualTree;
using CefNet;
using CefNet.Avalonia;

namespace AvaloniaApp
{
	public class WebViewTab : TabItem, IStyleable
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
			webview.CreateWindow += Webview_CreateWindow;
			webview.DocumentTitleChanged += HandleDocumentTitleChanged;
			WebView = webview;
			Header = new WebViewTabTitle(this);
		}

		public string Title
		{
			get => ((WebViewTabTitle) Header).Text;
			set => ((WebViewTabTitle) Header).Text = value;
		}

		public IChromiumWebView WebView { get; protected set; }

		public bool PopupHandlingDisabled { get; set; }

		Type IStyleable.StyleKey => typeof(TabItem);

		protected override void OnInitialized()
		{
			base.OnInitialized();
			Content = WebView;
		}

		public void Close()
		{
			WebView.Close();

			var tabs = Parent as TabControl;
			if (tabs == null)
				return;
			((AvaloniaList<object>) tabs.Items).Remove(this);
		}

		private void HandleDocumentTitleChanged(object sender, DocumentTitleChangedEventArgs e)
		{
			Title = e.Title;
			//this.ToolTipText = e.Title;
		}

		private void Webview_CreateWindow(object sender, CreateWindowEventArgs e)
		{
			if (PopupHandlingDisabled)
				return;

			var tabs = this.FindTabControl();
			if (tabs == null)
			{
				e.Cancel = true;
				return;
			}

			var avaloniaWindow = this.GetVisualRoot() as Window;
			if (avaloniaWindow == null)
				throw new InvalidOperationException("Window not found!");

			var webview = new CustomWebView((WebView) WebView);

			var platformHandle = avaloniaWindow.PlatformImpl.Handle;
			if (platformHandle is IMacOSTopLevelPlatformHandle macOSHandle)
				e.WindowInfo.SetAsWindowless(macOSHandle.GetNSWindowRetained());
			else
				e.WindowInfo.SetAsWindowless(platformHandle.Handle);

			e.Client = webview.Client;
			OnCreateWindow(webview);
		}


		protected void OnCreateWindow(WebView webview)
		{
			var tab = new WebViewTab(webview);
			var tabs = this.FindTabControl();
			((AvaloniaList<object>) tabs.Items).Add(tab);
			tabs.SelectedItem = tab;
		}

		private class ColoredFormattedText : FormattedText
		{
			public IBrush Brush { get; set; }
		}

		private class WebViewTabTitle : TemplatedControl
		{
			private readonly WebViewTab _tab;
			private ColoredFormattedText _xButton;
			private IBrush _xbuttonBrush;

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

					FormattedText = new ColoredFormattedText
					{
						Text = value,
						Typeface = new Typeface(FontFamily, FontSize, FontStyle, FontWeight),
						Brush = Brushes.Black
					};
					InvalidateMeasure();
				}
			}

			private ColoredFormattedText FormattedText { get; set; }

			private ColoredFormattedText XButton
			{
				get
				{
					if (_xButton == null)
						_xButton = new ColoredFormattedText
						{
							Text = "x",
							Typeface = new Typeface(FontFamily, FontSize, FontStyle, FontWeight.Bold),
							Brush = Brushes.Gray
						};
					return _xButton;
				}
			}

			protected override Size MeasureOverride(Size constraint)
			{
				var ft = FormattedText;
				if (ft == null)
					return base.MeasureOverride(constraint);
				var ftbounds = ft.Bounds;
				return new Size(ftbounds.Width + XButton.Bounds.Width + 4, ftbounds.Height);
			}

			protected override void OnPointerReleased(PointerReleasedEventArgs e)
			{
				if (e.InitialPressMouseButton == MouseButton.Left)
					if (GetXButtonRect().Contains(e.GetPosition(this)))
						_tab.Close();
				base.OnPointerReleased(e);
			}

			private Rect GetXButtonRect()
			{
				var xbounds = XButton.Bounds;
				return new Rect(Bounds.Width - xbounds.Width, 0, xbounds.Width, xbounds.Height);
			}

			protected override void OnPointerMoved(PointerEventArgs e)
			{
				SetXButtonBrush(GetXButtonRect().Contains(e.GetPosition(this)) ? Brushes.Black : Brushes.Gray);
				base.OnPointerMoved(e);
			}

			protected override void OnPointerLeave(PointerEventArgs e)
			{
				SetXButtonBrush(Brushes.Gray);
				base.OnPointerLeave(e);
			}

			private void SetXButtonBrush(ISolidColorBrush brush)
			{
				if (brush != _xbuttonBrush)
				{
					_xbuttonBrush = brush;
					XButton.Brush = brush;
					InvalidateVisual();
				}
			}

			public override void Render(DrawingContext drawingContext)
			{
				var formattedText = FormattedText;
				if (formattedText == null)
					return;

				drawingContext.DrawText(formattedText.Brush, new Point(), formattedText);
				drawingContext.DrawText(XButton.Brush, new Point(Bounds.Width - XButton.Bounds.Width, 0), XButton);
			}
		}
	}
}