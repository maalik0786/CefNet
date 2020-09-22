﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace CefNet.JSInterop
{
	public static class V8Extensions
	{
		public static Task<ScriptableObject> GetScriptableObjectAsync(this CefFrame self,
			CancellationToken cancellationToken)
		{
			if (self is null)
				throw new ArgumentNullException(nameof(self));

			if (CefApi.CurrentlyOn(CefThreadId.Renderer))
				return Task.FromResult(GetScriptableObject(self));

			return Task.Run(() => GetScriptableObject(self));
		}

		private static ScriptableObject GetScriptableObject(CefFrame frame)
		{
			var provider = new ScriptableObjectProvider(frame);
			return new ScriptableObject(provider.GetGlobal(), provider);
		}
	}
}