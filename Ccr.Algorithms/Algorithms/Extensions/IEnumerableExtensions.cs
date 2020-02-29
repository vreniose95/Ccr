using Ccr.Algorithms.Collections;

namespace Ccr.Algorithms.Extensions
{
	public static class IEnumerableExtensions
	{
		//public static TSequentialSet Slice<TValue, TSequentialSet>(
		//  this IEnumerable<TValue> @this)
		//    where TSequentialSet
		//      : SequentialSet<TValue>
		//{

		//}

		public static SequentialPair<TValue> SlicePair<TValue>(
			this TValue[] @this,
			int startIndex)
		{
			return SequentialSetFactory.Build(
				@this[startIndex + 0],
				@this[startIndex + 1]);
		}

		public static SequentialTriple<TValue> SliceTriple<TValue>(
			this TValue[] @this,
			int startIndex)
		{
			return SequentialSetFactory.Build(
				@this[startIndex + 0],
				@this[startIndex + 1],
				@this[startIndex + 2]);
		}

		public static SequentialQuad<TValue> SliceQuad<TValue>(
			this TValue[] @this,
			int startIndex)
		{
			return SequentialSetFactory.Build(
				@this[startIndex + 0],
				@this[startIndex + 1],
				@this[startIndex + 2],
				@this[startIndex + 3]);
		}
	}
}
