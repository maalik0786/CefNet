namespace CefNet.Internal
{
	internal sealed partial class CefAppGlue
	{
		private readonly CefNetApplication _application;

		public CefAppGlue(CefNetApplication application)
		{
			_application = application;
			RenderProcessGlue = new CefRenderProcessHandlerGlue(this);
			BrowserProcessGlue = new CefBrowserProcessHandlerGlue(this);
		}

		internal CefRenderProcessHandler RenderProcessGlue { get; }

		internal CefBrowserProcessHandler BrowserProcessGlue { get; }
	}
}