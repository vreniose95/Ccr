using System;
// ReSharper disable BuiltInTypeReferenceStyle
namespace Ccr.Core.Numerics.Ranges
{
	public class SingleRange
		: NonIntegralTypeRangeBase<float>
	{
		public SingleRange(
			Single minimum,
			Single maximum) : base(
				minimum,
				maximum)
		{
		}

		public static implicit operator SingleRange(
			Tuple<Double, Double> value)
		{
			return new SingleRange(
				value.Item1,
				value.Item2);
		}
		public static implicit operator SingleRange(
			(Double, Double) value)
		{
			return new SingleRange(
				value.Item1,
				value.Item2);
		}
	}
}