using System;
// ReSharper disable BuiltInTypeReferenceStyle
namespace Ccr.Core.Numerics.Ranges
{
  public class UInt64Range
    : IntegralRangeBase<UInt64>
  {
    public UInt64Range(
      UInt64 minimum,
      UInt64 maximum) : base(
        minimum,
        maximum)
    {
    }

    public static implicit operator UInt64Range(
      Tuple<UInt64, UInt64> value)
    {
      return new UInt64Range(
        value.Item1,
        value.Item2);
    }
    public static implicit operator UInt64Range(
      (UInt64, UInt64) value)
    {
      return new UInt64Range(
        value.Item1,
        value.Item2);
    }
  }
}