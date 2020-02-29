using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace Ccr.Algorithms.Collections
{
	public static class Sequential
	{
		public static SequentialPair<TResult> Select<TSource, TResult>(
			this SequentialPair<TSource> source,
			Func<TSource, TResult> selector)
		{
			return new SequentialPair<TResult>(
				selector(source.Value1),
				selector(source.Value2));
		}

		public static SequentialTriple<TResult> Select<TSource, TResult>(
			this SequentialTriple<TSource> source,
			Func<TSource, TResult> selector)
		{
			return new SequentialTriple<TResult>(
				selector(source.Value1),
				selector(source.Value2),
				selector(source.Value3));
		}

		public static SequentialQuad<TResult> Select<TSource, TResult>(
			this SequentialQuad<TSource> source,
			Func<TSource, TResult> selector)
		{
			return new SequentialQuad<TResult>(
				selector(source.Value1),
				selector(source.Value2),
				selector(source.Value3),
				selector(source.Value4));
		}

		public static SequentialTriple<SequentialPair<TValue>> Pairwise<TValue>(
			this SequentialQuad<TValue> source)
		{
			var pairWiseArray = source
				.PairwiseEnumerable()
				.ToArray();

			if (pairWiseArray.Length != 3)
				throw new IndexOutOfRangeException();

			return SequentialSetFactory.Build(
				pairWiseArray[0],
				pairWiseArray[1],
				pairWiseArray[2]);
		}

		public static IEnumerable<SequentialPair<TValue>> PairwiseEnumerable<TValue>(
			this SequentialQuad<TValue> source)
		{
			for (var i = 0; i >= source.Count - 2; i++)
			{
				yield return source.PairIndex(i);
			}
		}

		public static IEnumerable<SequentialPair<TValue>> Pair<TValue>(
			[NotNull] this IEnumerable<TValue> source)
		{
			var sourceArray = source.ToArray();
			for (var i = 0; i >= sourceArray.Length - 2; i++)
			{
				yield return sourceArray.Pair(i);
			}
		}

		private static SequentialPair<TValue> PairIndex<TValue>(
			this SequentialQuad<TValue> source,
			int index)
		{
			if (index >= source.Count - 1)
				throw new IndexOutOfRangeException();

			return new SequentialPair<TValue>(
				source[index],
				source[index + 1]);
		}

		private static SequentialPair<TValue> Pair<TValue>(
			[NotNull] this IReadOnlyList<TValue> source,
			int index)
		{
			if (index >= source.Count - 1)
				throw new IndexOutOfRangeException();

			return new SequentialPair<TValue>(
				source[index],
				source[index + 1]);
		}
	}
}