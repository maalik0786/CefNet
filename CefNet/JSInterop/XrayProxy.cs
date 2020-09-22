using System;
using System.Runtime.InteropServices;

namespace CefNet.JSInterop
{
	internal sealed class XrayProxy : IDisposable
	{
		private readonly XrayHandle _instance;
		private GCHandle _providerHandle;

		internal XrayProxy(XrayHandle instance, ScriptableObjectProvider provider)
		{
			_instance = instance;
			_providerHandle = GCHandle.Alloc(provider, GCHandleType.Normal);
		}

		internal ScriptableObjectProvider Provider => _providerHandle.Target as ScriptableObjectProvider;

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		~XrayProxy()
		{
			Dispose(false);
		}

		private void Dispose(bool disposing)
		{
			if (_providerHandle.IsAllocated)
			{
				if (!Environment.HasShutdownStarted) Provider?.ReleaseObject(_instance);
				_providerHandle.Free();
			}
		}

		internal bool TryGetHandle(out XrayHandle handle)
		{
			handle = _instance;
			return _providerHandle.IsAllocated;
		}
	}
}