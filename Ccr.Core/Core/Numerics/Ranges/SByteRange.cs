using System;

namespace Ccr.Core.Numerics
{
  public class SByteRange
    : IntegralRangeBase<int>
  {
    public SByteRange(
      Int32 minimum,
      Int32 maximum) : base(
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