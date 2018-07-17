using System;
using Ccr.Std.Core.Numerics.Infrastructure;

// ReSharper disable BuiltInTypeReferenceStyle
namespace Ccr.Std.Core.Numerics.Ranges
{
  /// <summary>
  ///   Represents a numeric range using a pair of <see cref="Byte"/> objects, one representing 
  ///   the Minimum, the other the Maximum.
  /// </summary>
  public class ByteRange
    : IntegralRangeBase<Byte>
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