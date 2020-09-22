using System;
using System.Threading;

namespace CefNet.JSInterop
{
	internal sealed class V8CallTask : CefTask
	{
		private readonly Delegate _method;
		private readonly ManualResetEvent _event;
		private volatile Exception _exception;
		private volatile object _result;

		public V8CallTask(Func<object> func)
		{
			if (func is null)
				throw new ArgumentNullException(nameof(func));

			_event = new ManualResetEvent(false);
			_method = func;
			AddRef();
		}

		public V8CallTask(Action action)
		{
			if (action is null)
				throw new ArgumentNullException(nameof(action));

			_method = action;
		}

		protected internal override void Execute()
		{
			if (_method is Func<object> func)
				try
				{
					_result = func();
				}
				catch (Exception e)
				{
					_exception = e;
				}
				finally
				{
					try { _event.Set(); }
					catch (ObjectDisposedException) { }
				}

			((Action) _method)();
		}

		public object GetResult()
		{
			if (_event != null)
				_event.WaitOne();
			if (_exception != null)
				throw _exception;
			return _result;
		}

		protected override void Dispose(bool disposing)
		{
			_event?.Dispose();
			base.Dispose(disposing);
		}
	}
}