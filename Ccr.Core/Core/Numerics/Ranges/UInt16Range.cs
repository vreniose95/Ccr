using System;
// ReSharper disable BuiltInTypeReferenceStyle// ReSharper disable BuiltInTypeReferenceStyle// ReSharper disable BuiltInTypeReferenceStyle
namespace Ccr.Core.Numerics
{
  public class UInt16Range
    : IntegralRangeBase<ushort>
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