using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Ccr.Std.Core.Extensions;
using Ccr.Std.Core.Extensions.NumericExtensions;

namespace Ccr.Algorithms.Collections
{
	public abstract class SequentialSet<TValue>
		: SequentialSet, IReadOnlyList<TValue>
	{
		private TValue[] _valueArrayCache;


		internal IReadOnlyList<TValue> ValueArray
		{
			get => _valueArrayCache
				?? (_valueArrayCache = ValueArrayBase.Cast<TValue>().ToArray());
		}

		protected IList<TValue> VolatileValues
		{
			get => _valueArrayCache
				?? (_valueArrayCache = ValueArrayBase.Cast<TValue>().ToArray());
		}
		
		public int Count
		{
			get => ValueArray.Count;
		}

		public TValue this[int index]
		{
			get
			{
				if (index.IsNotWithin((0, Count - 1)))
					throw new IndexOutOfRangeException(
						$"The index \'{index}\' is outside the bounds of the SequentialSet type " +
						$"{GetType().Name.SQuote()}.");

				return ValueArray[index];
			}
			set
			{
				if (index.IsNotWithin((0, Count - 1)))
					throw new IndexOutOfRangeException(
						$"The index \'{index}\' is outside the bounds of the SequentialSet type " +
						$"{GetType().Name.SQuote()}.");

				VolatileValues[index] = value;
			}
		}

		public IEnumerator<TValue> GetEnumerator()
		{
			return ValueArray.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
