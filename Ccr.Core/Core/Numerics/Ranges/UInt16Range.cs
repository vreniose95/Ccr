using System;
// ReSharper disable BuiltInTypeReferenceStyle
namespace Ccr.Core.Numerics.Ranges
{
  public class UInt16Range
    : IntegralRangeBase<UInt16>
  {
    public UInt16Range(
      UInt16 minimum,
      UInt16 maximum) : base(
        minimum,
        maximum)
    {
    }

    public static implicit operator UInt16Range(
      Tuple<UInt16, UInt16> value)
    {
      return new UInt16Range(
        value.Item1,
        value.Item2);
    }
    public static implicit operator UInt16Range(
      (UInt16, UInt16) value)
    {
      return new UInt16Range(
        value.Item1,
        value.Item2);
    }
  }
}