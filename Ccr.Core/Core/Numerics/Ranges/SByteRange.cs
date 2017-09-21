using System;
// ReSharper disable BuiltInTypeReferenceStyle
namespace Ccr.Core.Numerics.Ranges
{
  public class SByteRange
    : IntegralRangeBase<SByte>
  {
    public SByteRange(
      SByte minimum,
      SByte maximum) : base(
        minimum,
        maximum)
    {
    }

    public static implicit operator SByteRange(
      Tuple<SByte, SByte> value)
    {
      return new SByteRange(
        value.Item1,
        value.Item2);
    }
    public static implicit operator SByteRange(
      (SByte, SByte) value)
    {
      return new SByteRange(
        value.Item1,
        value.Item2);
    }
  }
}