using CefNet.CApi;

namespace CefNet
{
	public unsafe partial class CefDictionaryValue
	{
		/// <summary>
		///  Creates a new object that is not owned by any other object.
		/// </summary>
		public CefDictionaryValue()
			: this(CefNativeApi.cef_dictionary_value_create())
		{
		}
	}
}