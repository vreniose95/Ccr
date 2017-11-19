using System;

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
      this SequentialQuad<TValue> source,
      int index)
    {
      if (index >= source.ValueArray.Count - 1)
        throw new IndexOutOfRangeException();

      throw new NotImplementedException();
      //return new SequentialPair<TValue>(
      //  ValueArray[index],
      //  ValueArray[index + 1]);
    }

  }
}