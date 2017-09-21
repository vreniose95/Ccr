using System;
// ReSharper disable BuiltInTypeReferenceStyle
namespace Ccr.Core.Numerics.Ranges
{
  //SByte, Byte,
  public class Int32Range
		: IntegralRangeBase<Int32>
	{
		public Int32Range(
			Int32 minimum,
			Int32 maximum) : base(
				minimum, 
				maximum)
		{
		}

		public static implicit operator Int32Range(
			Tuple<Int32, Int32> value)
		{
			return new Int32Range(
				value.Item1,
				value.Item2);
		}
		public static implicit operator Int32Range(
			(Int32, Int32) value)
		{
			return new Int32Range(
				value.Item1,
				value.Item2);
		}
	}
}
