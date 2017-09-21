using System;
// ReSharper disable BuiltInTypeReferenceStyle
namespace Ccr.Core.Numerics.Ranges
{
  public class Int64Range
    : IntegralRangeBase<Int64>
  {
    public Int64Range(
      Int64 minimum,
      Int64 maximum) : base(
      minimum,
      maximum)
    {
    }

    public static implicit operator Int64Range(
      Tuple<Int64, Int64> value)
    {
      return new Int64Range(
        value.Item1,
        value.Item2);
    }
    public static implicit operator Int64Range(
      (Int64, Int64) value)
    {
      return new Int64Range(
        value.Item1,
        value.Item2);
    }
  }
}