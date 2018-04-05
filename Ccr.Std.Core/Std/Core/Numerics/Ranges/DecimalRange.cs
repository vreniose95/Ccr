using System;
using Ccr.Std.Core.Numerics.Infrastructure;

// ReSharper disable BuiltInTypeReferenceStyle
namespace Ccr.Std.Core.Numerics.Ranges
{
	public class DecimalRange
		: NonIntegralRangeBase<decimal>
	{
		public DecimalRange(
			Decimal minimum,
			Decimal maximum) : base(
				minimum,
				maximum)
		{
		}

		public static implicit operator DecimalRange(
			Tuple<Decimal, Decimal> value)
		{
			return new DecimalRange(
				value.Item1,
				value.Item2);
		}
		public static implicit operator DecimalRange(
			(Decimal, Decimal) value)
		{
			return new DecimalRange(
				value.Item1,
				value.Item2);
		}
	}
}