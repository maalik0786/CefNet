using System;
using System.Threading;

namespace CefNet.Internal
{
	public sealed class CrossThreadEventMethod<TEventArgs>
		where TEventArgs : class
	{
		private readonly TEventArgs _eventArgs;
		private readonly Action<TEventArgs> _raiseEventAction;

		public CrossThreadEventMethod(Action<TEventArgs> raiseEventAction, TEventArgs eventArgs)
		{
			Invoke = InvokeImpl;
			_raiseEventAction = raiseEventAction;
			_eventArgs = eventArgs;
		}

		public SendOrPostCallback Invoke { get; }

		private void InvokeImpl(object nullState)
		{
			_raiseEventAction(_eventArgs);
		}
	}
}