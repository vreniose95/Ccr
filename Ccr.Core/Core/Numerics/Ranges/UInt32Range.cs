using System;

namespace Ccr.Core.Numerics
{
  public class UInt32Range
    : IntegralRangeBase<uint>
  {
    public UInt32Range(
      UInt32 minimum,
      UInt32 maximum) : base(
      minimum,
      maximum)
    {
    }
    public static implicit operator UInt32Range(
      Tuple<UInt32, UInt32> value)
    {
      return new UInt32Range(
        value.Item1,
        value.Item2);
    }
    public static implicit operator UInt32Range(
      (UInt32, UInt32) value)
    {
      return new UInt32Range(
        value.Item1,
        value.Item2);
    }
  }
}