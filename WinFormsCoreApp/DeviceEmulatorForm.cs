using System;
using System.ComponentModel;
using System.Windows.Forms;
using CefNet;
using CefNet.Windows.Forms;

namespace WinFormsCoreApp
{
	public partial class DeviceEmulatorForm : Form
	{
		private readonly WebView view;

		public DeviceEmulatorForm()
		{
			InitializeComponent();

			view = new CustomWebView
			{
				RequestContext = new CefRequestContext(new CefRequestContextSettings()),
				WindowlessRenderingEnabled = true,
				InitialUrl = "https://www.mydevice.io/"
			};
			view.SimulateDevice(IPhoneDevice.Create(IPhone.Model7));
			view.Top = txtAddress.Bottom + 2;
			view.Left = 0;
			view.Width = ClientSize.Width;
			view.Height = ClientSize.Height - view.Top;
			view.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;
			view.Navigated += View_Navigated;
			view.CreateWindow += View_CreateWindow;
			Controls.Add(view);
		}

		protected override void OnResizeBegin(EventArgs e)
		{
			SuspendLayout();
			base.OnResizeBegin(e);
		}

		protected override void OnResizeEnd(EventArgs e)
		{
			ResumeLayout(true);
			base.OnResizeEnd(e);
		}

		private void View_CreateWindow(object sender, CreateWindowEventArgs e)
		{
			e.Cancel = true;
		}

		private void View_Navigated(object sender, NavigatedEventArgs e)
		{
			txtAddress.Text = e.Url;
			txtAddress.Select(txtAddress.Text.Length, 0);
		}

		private void txtAddress_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
				if (Uri.TryCreate(txtAddress.Text, UriKind.Absolute, out var url))
					view.Navigate(url.AbsoluteUri);
		}

		protected override void OnClosing(CancelEventArgs e)
		{
			view.Dispose();
			base.OnClosing(e);
		}
	}
}