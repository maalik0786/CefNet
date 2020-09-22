using System;
using System.Diagnostics;
using System.Dynamic;

namespace CefNet.JSInterop
{
	[DebuggerNonUserCode]
	public class ScriptableObject : DynamicObject, IEquatable<ScriptableObject>
	{
		private readonly XrayProxy _instance;

		protected internal ScriptableObject(ScriptableObject instance)
		{
			if (instance == null)
				throw new ArgumentNullException(nameof(instance));
			_instance = instance._instance;
		}

		protected internal ScriptableObject(XrayHandle instance, ScriptableObjectProvider provider)
		{
			_instance = new XrayProxy(instance, provider);
		}

		/// <summary>
		///  The number of milliseconds to wait for a response from a renderer process.
		/// </summary>
		public static int Timeout { get; set; } = ScriptableRequestInfo.DefaultTimeout;

		private XrayHandle Instance
		{
			get
			{
				if (_instance.TryGetHandle(out var handle))
					return handle;
				throw new ObjectDisposedException(GetType().Name);
			}
		}

		protected ScriptableObjectProvider Provider
		{
			get
			{
				var provider = _instance.Provider;
				if (provider == null)
					throw new ObjectDisposedException(GetType().Name);
				return provider;
			}
		}

		public bool IsFunction => Instance.dataType == XrayDataType.Function;

		public object this[string name]
		{
			get => WrapResult(Provider.GetProperty(Instance, name));
			set
			{
				var wrapper = value as ScriptableObject;
				if (wrapper != null)
					value = wrapper._instance;
				Provider.SetProperty(Instance, name, value);
			}
		}

		public object this[int index]
		{
			get => WrapResult(Provider.GetProperty(Instance, index));
			set
			{
				var wrapper = value as ScriptableObject;
				if (wrapper != null)
					value = wrapper.Instance;
				Provider.SetProperty(Instance, index, value);
			}
		}

		public bool Equals(ScriptableObject scriptableObject)
		{
			if (scriptableObject is null)
				return false;
			if (ReferenceEquals(this, scriptableObject))
				return true;

			try
			{
				if (Provider.Equals(scriptableObject.Provider)) return scriptableObject.Instance == Instance;
			}
			catch (ObjectDisposedException) { }

			return false;
		}

		public override bool TryGetMember(GetMemberBinder binder, out object result)
		{
			result = GetMember(binder.Name);
			return true;
		}

		private object GetMember(string name)
		{
			return WrapResult(Provider.GetProperty(Instance, name));
		}

		public override bool TrySetMember(SetMemberBinder binder, object value)
		{
			var wrapper = value as ScriptableObject;
			if (wrapper != null)
				value = wrapper.Instance;
			Provider.SetProperty(Instance, binder.Name, value);
			return true;
		}

		public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
		{
			return TryInvokeMember(binder.Name, args, out result);
		}

		protected virtual bool TryInvokeMember(string name, object[] args, out object result)
		{
			try
			{
				result = WrapResult(Provider.InvokeMember(Instance, name, args));
			}
			catch (InvalidOperationException)
			{
				result = null;
				return false;
			}

			//throw new MissingMethodException();
			return true;
		}

		public override bool TryInvoke(InvokeBinder binder, object[] args, out object result)
		{
			if (Instance.dataType != XrayDataType.Function)
			{
				result = null;
				return false;
			}

			result = WrapResult(Provider.Invoke(Instance, args));
			return true;
		}


		protected virtual object WrapResult(object value)
		{
			if (value is XrayHandle v8obj) return new ScriptableObject(v8obj, Provider);
			return value;
		}

		public override bool Equals(object obj)
		{
			return Equals(obj as ScriptableObject);
		}

		public override int GetHashCode()
		{
			return Instance.GetHashCode();
		}

		public static bool operator ==(ScriptableObject a, ScriptableObject b)
		{
			if (a is null)
				return b is null;
			return a.Equals(b);
		}

		public static bool operator !=(ScriptableObject a, ScriptableObject b)
		{
			if (a is null)
				return !(b is null);
			return !a.Equals(b);
		}

		public static explicit operator XrayHandle(ScriptableObject me)
		{
			return me.Instance;
		}
	}
}