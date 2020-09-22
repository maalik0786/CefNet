using CefNet.CApi;

namespace CefNet
{
	public unsafe partial class CefResourceBundle
	{
		/// <summary>
		///  Returns the global resource bundle instance.
		/// </summary>
		public static CefResourceBundle GetGlobal()
		{
			return Wrap(Create, CefNativeApi.cef_resource_bundle_get_global());
		}
	}
}