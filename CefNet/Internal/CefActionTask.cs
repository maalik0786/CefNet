using System;

namespace CefNet.Internal
{
	internal sealed class CefActionTask : CefTask
	{
		public Action _action;

		public CefActionTask(Action action)
		{
			if (action is null)
				throw new ArgumentNullException(nameof(action));
			_action = action;
		}

		protected internal override void Execute()
		{
			_action();
		}
	}
}