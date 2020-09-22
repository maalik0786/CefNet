using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace CefNet.JSInterop
{
	internal sealed class ScriptableRequestInfo : IDisposable
	{
		internal const int DefaultTimeout = 5000;
		private static int _RequestIndex;

		private static readonly Dictionary<int, ScriptableRequestInfo> _ActiveRequests =
			new Dictionary<int, ScriptableRequestInfo>();

		private ManualResetEvent _event;
		private Exception _exception;
		private object _result;


		public ScriptableRequestInfo()
		{
			_event = new ManualResetEvent(false);
			RequestId = Interlocked.Increment(ref _RequestIndex);
			lock (_ActiveRequests)
			{
				// yes, overwriting is allowed to free too old requests
				_ActiveRequests[RequestId] = this;
			}
		}

		public int RequestId { get; }

		public void Dispose()
		{
			lock (_ActiveRequests)
			{
				_ActiveRequests.Remove(RequestId);
			}

			var ev = _event;
			_event = null;
			if (ev != null) ev.Dispose();
			GC.SuppressFinalize(this);
		}

		~ScriptableRequestInfo()
		{
			_event?.Dispose();
		}

		public static ScriptableRequestInfo Get(int key)
		{
			ScriptableRequestInfo value;
			lock (_ActiveRequests)
			{
				_ActiveRequests.TryGetValue(key, out value);
			}

			return value;
		}

		[DebuggerStepThrough]
		public object GetResult()
		{
			var exception = Volatile.Read(ref _exception);
			if (exception != null)
				throw _exception;
			return Volatile.Read(ref _result);
		}

		public void Wait()
		{
			var timeout = ScriptableObject.Timeout;
			if (timeout <= 0)
				timeout = DefaultTimeout;
			if (_event.WaitOne(timeout))
				return;
			throw new TimeoutException();
		}

		public void Complete(CefValue value)
		{
			Volatile.Write(ref _result, CastToDotnetType(value));
			try
			{
				_event?.Set();
			}
			catch (ObjectDisposedException) { }
		}

		public void Complete(Exception exception)
		{
			Volatile.Write(ref _exception, exception);
			try
			{
				_event?.Set();
			}
			catch (ObjectDisposedException) { }
		}

		private static object CastToDotnetType(CefValue value)
		{
			if (value == null)
				return null;

			if (!value.IsValid)
				throw new InvalidCastException();

			switch (value.Type)
			{
				case CefValueType.String:
					return value.GetString();
				case CefValueType.Int:
					return value.GetInt();
				case CefValueType.Bool:
					return value.GetBool();
				case CefValueType.Null:
					return null;
				case CefValueType.Double:
					return value.GetDouble();
				case CefValueType.Binary:
					var v = value.GetBinary();
					if (v.Size == 1)
						return V8Undefined.Value;
					return XrayHandle.FromCfxBinaryValue(v).ToObject();
			}

			throw new NotImplementedException();
		}
	}
}