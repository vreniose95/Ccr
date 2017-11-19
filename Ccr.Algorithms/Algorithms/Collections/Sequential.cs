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
  }
}