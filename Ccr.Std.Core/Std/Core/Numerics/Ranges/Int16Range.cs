using System;
using Ccr.Std.Core.Numerics.Infrastructure;

// ReSharper disable BuiltInTypeReferenceStyle
namespace Ccr.Std.Core.Numerics.Ranges
{
  public class Int16Range
    : IntegralRangeBase<short>
  {
    public Int16Range(
      Int16 minimum,
      Int16 maximum) : base(
      minimum,
      maximum)
    {
    }

    public static implicit operator Int16Range(
      Tuple<Int16, Int16> value)
    {
      return new Int16Range(
        value.Item1,
        value.Item2);
    }
    public static implicit operator Int16Range(
      (Int16, Int16) value)
    {
      return new Int16Range(
        value.Item1,
        value.Item2);
    }
  }
}
