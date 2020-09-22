﻿// --------------------------------------------------------------------------------------------
// Copyright (c) 2019 The CefNet Authors. All rights reserved.
// Licensed under the MIT license.
// See the licence file in the project root for full license information.
// --------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using CefNet.CApi;
using CefNet.Unsafe;

namespace CefNet
{
	internal interface ICriticalRefCounted : IDisposable
	{
	}

	internal sealed class RefCountedReference
	{
		public readonly WeakReference<CefBaseRefCounted> Instance;

		private int _count;
		private CefBaseRefCounted Root;

		public RefCountedReference(WeakReference<CefBaseRefCounted> weakRef)
		{
			_count = 0;
			Instance = weakRef;
		}

		public int Count
		{
			get
			{
				lock (this)
				{
					return _count;
				}
			}
		}

		public bool IsRooted
		{
			get
			{
				lock (this)
				{
					return Root != null;
				}
			}
		}

		public void AddRef()
		{
			lock (this)
			{
				_count++;
				if (_count == 1)
				{
					if (Instance.TryGetTarget(out var instance))
						Root = instance;
					else
						throw new InvalidCefObjectException();
				}
			}
		}

		public int Release()
		{
			int count;
			ICriticalRefCounted critical = null;
			lock (this)
			{
				count = --_count;
				if (count == 0)
				{
					critical = Root as ICriticalRefCounted;
					Root = null;
				}
			}

			critical?.Dispose();
			return count;
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	internal unsafe delegate void CefActionDelegate(cef_base_ref_counted_t* self);

	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	internal unsafe delegate int CefIntFunctionDelegate(cef_base_ref_counted_t* self);

	/// <summary>
	///  Base class for all wrapper classes for ref counted CEF structs.
	/// </summary>
	/// <typeparam name="T">A ref counted CEF struct.</typeparam>
	public abstract class CefBaseRefCounted<T> : CefBaseRefCounted
		where T : unmanaged
	{
		private static readonly unsafe CefActionDelegate fnAddRef = AddRefImpl;
		private static readonly unsafe CefIntFunctionDelegate fnRelease = ReleaseImpl;
		private static readonly unsafe CefIntFunctionDelegate fnHasOneRef = HasOneRefImpl;
		private static readonly unsafe CefIntFunctionDelegate fnHasAtLeastOneRef = HasAtLeastOneRefImpl;

		internal static readonly Dictionary<IntPtr, RefCountedReference> RefCounted =
			new Dictionary<IntPtr, RefCountedReference>();

		internal static readonly Dictionary<IntPtr, WeakReference<CefBaseRefCounted>> UnsafeRefCounted =
			new Dictionary<IntPtr, WeakReference<CefBaseRefCounted>>();

		public static readonly ReaderWriterLockSlim GlobalSyncRoot =
			new ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion);

		/// <summary>
		///  Initializes a new instance of <see cref="CefBaseRefCounted{T}" />.
		/// </summary>
		public unsafe CefBaseRefCounted()
			: base(Allocate(sizeof(T)))
		{
			var reference = new RefCountedReference(new WeakReference<CefBaseRefCounted>(this));
			GlobalSyncRoot.EnterWriteLock();
			try
			{
				RefCounted.Add(_instance, reference);
			}
			finally
			{
				GlobalSyncRoot.ExitWriteLock();
			}
		}

		/// <summary>
		///  Initializes a new instance of <see cref="CefBaseRefCounted{T}" /> using
		///  the specified pointer to a specified CEF struct.
		/// </summary>
		/// <param name="instance">The pointer to a specified CEF struct.</param>
		public unsafe CefBaseRefCounted(cef_base_ref_counted_t* instance)
			: base(instance)
		{
		}

		/// <summary>
		///  Gets an unsafe pointer to a specified CEF struct.
		/// </summary>
		public new unsafe T* NativeInstance => (T*) base.NativeInstance;

		protected static IEnumerable<CefBaseRefCounted> GetCached<TClass>()
			where TClass : CefBaseRefCounted
		{
			GlobalSyncRoot.EnterReadLock();
			try
			{
				foreach (var reference in RefCounted.Values)
					if (reference.Instance.TryGetTarget(out var instance)
					    && instance is TClass wrapper)
						yield return wrapper;
			}
			finally
			{
				GlobalSyncRoot.ExitReadLock();
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static unsafe RefCountedWrapperStruct* GetWrapperStructPtr(void* instance)
		{
			if (CefStructure.IsAllocated(new IntPtr(instance)))
				return null;
			return RefCountedWrapperStruct.FromRefCounted(instance);
		}

		/// <summary>
		///  Returns a wrapper for the specified pointer.
		/// </summary>
		/// <typeparam name="TClass">The type of wrapper.</typeparam>
		/// <param name="create">Represents a method that create a new wrapper.</param>
		/// <param name="instance">The pointer to ref-counted CEF struct.</param>
		/// <returns>Returns an existing or new wrapper for the specified pointer.</returns>
		public static unsafe TClass Wrap<TClass>(Func<IntPtr, TClass> create, T* instance)
			where TClass : CefBaseRefCounted<T>
		{
			if (instance == null)
				return null;

			RefCountedWrapperStruct* ws = null;
			CefBaseRefCounted wrapper;
			var key = new IntPtr(instance);
			GlobalSyncRoot.EnterUpgradeableReadLock();
			try
			{
				if (CefApi.UseUnsafeImplementation)
				{
					ws = GetWrapperStructPtr(instance);
					if (ws != null && UnsafeRefCounted.TryGetValue(ws->cppObject, out var weakRef)
					               && weakRef.TryGetTarget(out wrapper))
					{
						((cef_base_ref_counted_t*) instance)->Release();
						return (TClass) wrapper;
					}
				}

				if (RefCounted.TryGetValue(key, out var reference)
				    && reference.Instance.TryGetTarget(out wrapper))
				{
					((cef_base_ref_counted_t*) instance)->Release();
					return (TClass) wrapper;
				}
#if DEBUG
				else if (CefStructure.IsAllocated(key))
				{
					throw new InvalidCefObjectException(string.Format("Unexpected access to {0}.",
						typeof(TClass).Name));
				}
#endif
				else
				{
					GlobalSyncRoot.EnterWriteLock();
					try
					{
						var typedWrapper = create(key);
						var weakRef = new WeakReference<CefBaseRefCounted>(typedWrapper);
						RefCounted[key] = new RefCountedReference(weakRef);
						if (ws != null) UnsafeRefCounted[ws->cppObject] = weakRef;
						return typedWrapper;
					}
					finally
					{
						GlobalSyncRoot.ExitWriteLock();
					}
				}
			}
			finally
			{
				GlobalSyncRoot.ExitUpgradeableReadLock();
			}
		}

#pragma warning disable CS1591
		protected override unsafe void Dispose(bool disposing)
		{
			var key = Volatile.Read(ref _instance);
			if (key != IntPtr.Zero)
			{
				GlobalSyncRoot.EnterWriteLock();
				try
				{
					if (CefApi.UseUnsafeImplementation)
					{
						var ws = GetWrapperStructPtr((void*) key);
						if (ws != null) UnsafeRefCounted.Remove(ws->cppObject);
					}

					RefCounted.Remove(key);
				}
				finally
				{
					GlobalSyncRoot.ExitWriteLock();
				}
#if NETFRAMEWORK
				if (Environment.HasShutdownStarted)
				{
					if (CefStructure.IsAllocated(key)) // allow leaks to fix potential UAF
						return;
				}
				else
#endif
				if (CefStructure.Free(key)) return;

				base.Dispose(disposing);
			}
		}
#pragma warning restore CS1591

		/// <summary>
		///  Returns a pointer to a specified CEF struct and increments the reference count.
		/// </summary>
		/// <returns>
		///  A pointer to a specified CEF struct.
		/// </returns>
		public new unsafe T* GetNativeInstance()
		{
			return (T*) base.GetNativeInstance();
		}

		/// <summary>
		///  Returns an instance of a type that represents a <see cref="CefBaseRefCounted" />
		///  object by an unspecified pointer.
		/// </summary>
		/// <param name="ptr">A pointer to a ref-counted struct.</param>
		/// <returns>
		///  A <see cref="CefBaseRefCounted" />-based object that corresponds to the pointer
		///  or null if wrapper not found.
		/// </returns>
		public static CefBaseRefCounted GetInstance(IntPtr ptr)
		{
			RefCountedReference reference;
			GlobalSyncRoot.EnterReadLock();
			try
			{
				RefCounted.TryGetValue(ptr, out reference);
				if (reference != null && reference.Instance.TryGetTarget(out var instance))
					return instance;
			}
			finally
			{
				GlobalSyncRoot.ExitReadLock();
			}

			return null;
		}

		private static unsafe cef_base_ref_counted_t* Allocate(int size)
		{
			var instance = (cef_base_ref_counted_t*) CefStructure.Allocate(size);
			instance->add_ref = (void*) Marshal.GetFunctionPointerForDelegate(fnAddRef);
			instance->release = (void*) Marshal.GetFunctionPointerForDelegate(fnRelease);
			instance->has_one_ref = (void*) Marshal.GetFunctionPointerForDelegate(fnHasOneRef);
			instance->has_at_least_one_ref = (void*) Marshal.GetFunctionPointerForDelegate(fnHasAtLeastOneRef);
			return instance;
		}

		private static unsafe void AddRefImpl(cef_base_ref_counted_t* self)
		{
			RefCountedReference reference;
			GlobalSyncRoot.EnterReadLock();
			try
			{
				RefCounted.TryGetValue(new IntPtr(self), out reference);
			}
			finally
			{
				GlobalSyncRoot.ExitReadLock();
			}

			if (reference == null)
				throw new InvalidOperationException();
			reference.AddRef();
		}

		private static unsafe int ReleaseImpl(cef_base_ref_counted_t* self)
		{
			RefCountedReference reference;
			GlobalSyncRoot.EnterReadLock();
			try
			{
				RefCounted.TryGetValue(new IntPtr(self), out reference);
			}
			finally
			{
				GlobalSyncRoot.ExitReadLock();
			}

			if (reference == null)
			{
				if (Environment.HasShutdownStarted)
					return 0;
				throw new InvalidOperationException();
			}

			return reference.Release();
		}

		private static unsafe int HasOneRefImpl(cef_base_ref_counted_t* self)
		{
			RefCountedReference reference;
			GlobalSyncRoot.EnterReadLock();
			try
			{
				RefCounted.TryGetValue(new IntPtr(self), out reference);
			}
			finally
			{
				GlobalSyncRoot.ExitReadLock();
			}

			return reference != null && reference.Count == 1 ? 1 : 0;
		}

		private static unsafe int HasAtLeastOneRefImpl(cef_base_ref_counted_t* self)
		{
			RefCountedReference reference;
			GlobalSyncRoot.EnterReadLock();
			try
			{
				RefCounted.TryGetValue(new IntPtr(self), out reference);
			}
			finally
			{
				GlobalSyncRoot.ExitReadLock();
			}

			return reference != null && reference.IsRooted ? 1 : 0;
		}
	}

	/// <summary>
	///  Base class for all wrapper classes for ref counted CEF structs.
	/// </summary>
	public abstract unsafe class CefBaseRefCounted : IDisposable //, IAsyncDisposable
	{
		private protected IntPtr _instance;

		/// <summary>
		///  Initializes a new instance of <see cref="CefBaseRefCounted" /> using
		///  the pointer to ref-counted CEF struct.
		/// </summary>
		/// <param name="instance">The pointer to a ref-counted CEF struct.</param>
		/// <exception cref="NullReferenceException"><paramref name="instance" /> is null.</exception>
		public CefBaseRefCounted(cef_base_ref_counted_t* instance)
		{
			if (instance == null)
				throw new ArgumentNullException(nameof(instance));
			_instance = new IntPtr(instance);
		}

		/// <summary>
		///  Gets an unsafe pointer to a ref-counted struct.
		/// </summary>
		public cef_base_ref_counted_t* NativeInstance
		{
			get
			{
				var instance = (cef_base_ref_counted_t*) Volatile.Read(ref _instance);
				if (instance == null)
					throw new ObjectDisposedException(GetType().Name);
				return instance;
			}
		}

		/// <summary>
		///  Gets a value that indicates whether the object has been disposed.
		/// </summary>
		public bool IsDisposed => _instance == IntPtr.Zero;

		/// <summary>
		///  Allows an object to try to free resources and perform other cleanup operations
		///  before it is reclaimed by garbage collection.
		/// </summary>
		~CefBaseRefCounted()
		{
			Dispose(false);
		}

		/// <summary>
		///  Returns a pointer to a ref-counted struct and increments the reference count.
		/// </summary>
		/// <returns>A pointer to a ref-counted struct.</returns>
		public cef_base_ref_counted_t* GetNativeInstance()
		{
			var instance = (cef_base_ref_counted_t*) Volatile.Read(ref _instance);
			if (instance == null)
				throw new ObjectDisposedException(GetType().Name);
			instance->AddRef();
			return instance;
		}

		/// <summary>
		///  Increments the reference count for the object.
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void AddRef()
		{
			NativeInstance->AddRef();
		}

		/// <summary>
		///  Decrements the reference count for the object.
		/// </summary>
		/// <returns>
		///  Returns true if the resulting reference count is 0.
		/// </returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool Release()
		{
			return NativeInstance->Release() != 0;
		}

		/// <summary>
		///  Returns a value which indicates that the current reference count is 1.
		/// </summary>
		/// <returns>
		///  Returns true if the current reference count is 1.
		/// </returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool HasOneRef()
		{
			return NativeInstance->HasOneRef() != 0;
		}

		/// <summary>
		///  Returns a value which indicates that the current reference count is at least 1.
		/// </summary>
		/// <returns>
		///  Returns true if the current reference count is at least 1.
		/// </returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool HasAtLeastOneRef()
		{
			return NativeInstance->HasAtLeastOneRef() != 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static void ReleaseIfNonNull(cef_base_ref_counted_t* instance)
		{
			if (instance != null)
				instance->Release();
		}

		/// <summary>
		///  Makes himself ineligible for garbage collection from the start of the current routine
		///  to the point where this method is called (like &apos;GC.KeepAlive(this)&apos;) and
		///  returns passed <paramref name="result" />.
		/// </summary>
		/// <typeparam name="T">Any type.</typeparam>
		/// <param name="result">Any value of <typeparamref name="T" /> type.</param>
		/// <returns>Returns the passed parameter of <typeparamref name="T" /> type.</returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public T SafeCall<T>(T result)
		{
			return result;
		}

#pragma warning disable CS1591 // Missing comments
		protected virtual void Dispose(bool disposing)
		{
			ReleaseIfNonNull((cef_base_ref_counted_t*) Interlocked.Exchange(ref _instance, IntPtr.Zero));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
#pragma warning restore CS1591 // Missing comments
	}

	internal sealed unsafe class UnknownRefCounted
		: CefBaseRefCounted<cef_base_ref_counted_t>
	{
		public UnknownRefCounted(cef_base_ref_counted_t* instance)
			: base(instance)
		{
		}

		internal static UnknownRefCounted Create(IntPtr instance)
		{
			return new UnknownRefCounted((cef_base_ref_counted_t*) instance);
		}
	}
}