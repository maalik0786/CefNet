using System.ComponentModel;

namespace CefNet
{
	public class CreateWindowEventArgs : CancelEventArgs
	{
		public CreateWindowEventArgs(
			CefFrame frame,
			string targetUrl,
			string targetFrameName,
			CefWindowOpenDisposition targetDisposition,
			bool userGesture,
			CefPopupFeatures popupFeatures,
			CefWindowInfo windowInfo,
			CefClient client,
			CefBrowserSettings settings,
			CefDictionaryValue extraInfo,
			bool noJavascriptAccess)
		{
			Frame = frame;
			TargetUrl = targetUrl;
			TargetFrameName = targetFrameName;
			TargetDisposition = targetDisposition;
			UserGesture = userGesture;
			PopupFeatures = popupFeatures;
			Settings = settings;

			WindowInfo = windowInfo;
			Client = client;
			ExtraInfo = extraInfo;
			NoJavaScriptAccess = noJavascriptAccess;
		}

		public CefFrame Frame { get; }

		public string TargetUrl { get; }

		public string TargetFrameName { get; }

		public CefWindowOpenDisposition TargetDisposition { get; }

		public bool UserGesture { get; }

		public CefPopupFeatures PopupFeatures { get; }

		public CefBrowserSettings Settings { get; }

		public CefWindowInfo WindowInfo { get; }

		public CefClient Client { get; set; }

		public CefDictionaryValue ExtraInfo { get; set; }

		public bool NoJavaScriptAccess { get; set; }
	}
}