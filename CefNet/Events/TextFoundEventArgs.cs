using System;

namespace CefNet
{
	/// <summary>
	///  Represents find results.
	/// </summary>
	public sealed class TextFoundEventArgs : EventArgs, ITextFoundEventArgs
	{
		public TextFoundEventArgs(int identifier, int count, CefRect selectionRect, int index, bool finalUpdate)
		{
			ID = identifier;
			Count = count;
			SelectionRect = selectionRect;
			Index = index;
			FinalUpdate = finalUpdate;
		}

		public int ID { get; }

		public int Index { get; }

		public int Count { get; }

		public CefRect SelectionRect { get; }

		public bool FinalUpdate { get; }
	}
}