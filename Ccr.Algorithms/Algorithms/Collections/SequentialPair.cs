using System.Collections.Generic;

namespace Ccr.Algorithms.Collections
{
	public sealed class SequentialPair<TValue>
		: SequentialSet<TValue>
	{
		[SequentialSetValue(0)]
		public TValue Value1 { get; }

		[SequentialSetValue(1)]
		public TValue Value2 { get; }


		public SequentialPair(
			TValue value1,
			TValue value2)
		{
			Value1 = value1;
			Value2 = value2;
		}
		

		public TValue Difference
		{
			get => subtractDynamic(
				Value2,
				Value1);
		}
		
		public IEnumerable<TValue> LinearSpace(
			int count)
		{
			var spacing = divideDynamic(
				Difference,
				count);

			for (var i = 0; i < count; i++)
			{
				yield return addDynamic(
					multiplyDynamic(i, spacing),
					Value1);
			}
		}

		public static implicit operator (TValue a, TValue b)(
			SequentialPair<TValue> @this)
		{
			return (@this.Value1, @this.Value2);
		}

		private static dynamic subtractDynamic(
			dynamic left,
			dynamic right)
		{
			return left - right;
		}

		private static dynamic addDynamic(
			dynamic left,
			dynamic right)
		{
			return left + right;
		}

		private static dynamic multiplyDynamic(
			dynamic left,
			dynamic right)
		{
			return left * right;
		}

		private static dynamic divideDynamic(
			dynamic left,
			dynamic right)
		{
			return left / right;
		}
	}
}
