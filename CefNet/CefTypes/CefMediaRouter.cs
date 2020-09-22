using CefNet.CApi;

namespace CefNet
{
	public unsafe partial class CefMediaRouter
	{
		/// <summary>
		///  Gets the <see cref="CefMediaRouter" /> object associated with the global request context.
		/// </summary>
		public static CefMediaRouter Global => Wrap(Create, CefNativeApi.cef_media_router_get_global());
	}
}