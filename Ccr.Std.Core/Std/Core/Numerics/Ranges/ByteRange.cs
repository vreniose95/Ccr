using System;
using Ccr.Std.Core.Numerics.Infrastructure;

// ReSharper disable BuiltInTypeReferenceStyle
namespace Ccr.Std.Core.Numerics.Ranges
{
  public class ByteRange
    : IntegralRangeBase<byte>
  {
    public ByteRange(
      Byte minimum,
      Byte maximum) : base(
      minimum,
      maximum)
    {
    }

    public static implicit operator ByteRange(
      Tuple<Byte, Byte> value)
    {
      return new ByteRange(
        value.Item1,
        value.Item2);
    }
    public static implicit operator ByteRange(
      (Byte, Byte) value)
    {
      return new ByteRange(
        value.Item1,
        value.Item2);
    }
  }
}