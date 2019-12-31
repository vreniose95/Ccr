using System;
using Ccr.Std.Core.Extensions.NumericExtensions;

namespace Ccr.Algorithms.Collections
{
  public static class SequentialSetFactory
  {
    public static SequentialSet<TValue> BuildBase<TValue>(
      params TValue[] values)
    {
      if (values.Length.IsNotWithin((2, 4)))
        throw new ArgumentOutOfRangeException(
          $"value out of range 2-4 inclusive");

      switch (values.Length)
      {
        case 2:
          return Build(
            values[0],
            values[1]);
        case 3:
          return Build(
            values[0],
            values[1],
            values[2]);
        case 4:
          return Build(
            values[0],
            values[1],
            values[2],
            values[3]);
        default:
          throw new IndexOutOfRangeException(
            $"Index out of range.");
      }
    }


    public static SequentialPair<TValue> Build<TValue>(
      TValue value1,
      TValue value2)
    {
      return new SequentialPair<TValue>(
        value1,
        value2);
    }

    public static SequentialTriple<TValue> Build<TValue>(
      TValue value1,
      TValue value2,
      TValue value3)
    {
      return new SequentialTriple<TValue>(
        value1,
        value2,
        value3);
    }

    public static SequentialQuad<TValue> Build<TValue>(
      TValue value1,
      TValue value2,
      TValue value3,
      TValue value4)
    {
      return new SequentialQuad<TValue>(
        value1,
        value2,
        value3,
        value4);
    }
  }
}