using System;
using System.Net.NetworkInformation;
using Ccr.Core.Numerics;
using Ccr.Core.Numerics.Ranges;
// ReSharper disable BuiltInTypeReferenceStyle
namespace Ccr.Core.Extensions
{
	public static partial class NumericExtensions
	{
		public static int Smallest(
			this int @this,
			int value)
		{
			return @this < value
				? value
				: @this;
		}
		public static int Largest(
			this int @this,
			int value)
		{
			return @this > value
				? value
				: @this;
		}

		public static Byte LinearMap(
			this Byte @this,
			ByteRange startRange,
			ByteRange endRange)
		{
			return (
					(@this - startRange.Minimum) *
					(endRange.Maximum - endRange.Minimum) /
					(startRange.Maximum - startRange.Minimum) +
					endRange.Minimum)
				.To<Byte>();
		}
		public static SByte LinearMap(
			this SByte @this,
			SByteRange startRange,
			SByteRange endRange)
		{
			return (
					(@this - startRange.Minimum) *
					(endRange.Maximum - endRange.Minimum) /
					(startRange.Maximum - startRange.Minimum) +
					endRange.Minimum)
				.To<SByte>();
		}
		public static Int16 LinearMap(
			this Int16 @this,
			Int16Range startRange,
			Int16Range endRange)
		{
			return (
					(@this - startRange.Minimum) *
					(endRange.Maximum - endRange.Minimum) /
					(startRange.Maximum - startRange.Minimum) +
					endRange.Minimum)
				.To<Int16>();
		}

		public static Int32 LinearMap(
			this Int32 @this,
			Int32Range startRange,
			Int32Range endRange)
		{
			return (
					(@this - startRange.Minimum) *
					(endRange.Maximum - endRange.Minimum) /
					(startRange.Maximum - startRange.Minimum) +
					endRange.Minimum)
				.To<Int32>();
		}

		public static Int64 LinearMap(
			this Int64 @this,
			Int64Range startRange,
			Int64Range endRange)
		{
			return (
					(@this - startRange.Minimum) *
					(endRange.Maximum - endRange.Minimum) /
					(startRange.Maximum - startRange.Minimum) +
					endRange.Minimum)
				.To<Int64>();
		}

		public static UInt16 LinearMap(
			this UInt16 @this,
			UInt16Range startRange,
			UInt16Range endRange)
		{
			return (
					(@this - startRange.Minimum) *
					(endRange.Maximum - endRange.Minimum) /
					(startRange.Maximum - startRange.Minimum) +
					endRange.Minimum)
				.To<UInt16>();
		}

		public static UInt32 LinearMap(
			this UInt32 @this,
			UInt32Range startRange,
			UInt32Range endRange)
		{
			return (
					(@this - startRange.Minimum) *
					(endRange.Maximum - endRange.Minimum) /
					(startRange.Maximum - startRange.Minimum) +
					endRange.Minimum)
				.To<UInt32>();
		}

		public static UInt64 LinearMap(
			this UInt64 @this,
			UInt64Range startRange,
			UInt64Range endRange)
		{
			return (
					(@this - startRange.Minimum) *
					(endRange.Maximum - endRange.Minimum) /
					(startRange.Maximum - startRange.Minimum) +
					endRange.Minimum)
				.To<UInt64>();
		}


		public static Single LinearMap(
			this Single @this,
			SingleRange startRange,
			SingleRange endRange)
		{
			return (
					(@this - startRange.Minimum) *
					(endRange.Maximum - endRange.Minimum) /
					(startRange.Maximum - startRange.Minimum) +
					endRange.Minimum)
				.To<Single>();
		}

		public static Double LinearMap(
			this Double @this,
			DoubleRange startRange,
			DoubleRange endRange)
		{
			return (
					(@this - startRange.Minimum) *
					(endRange.Maximum - endRange.Minimum) /
					(startRange.Maximum - startRange.Minimum) +
					endRange.Minimum)
				.To<Double>();
		}

		public static Decimal LinearMap(
			this Decimal @this,
			DecimalRange startRange,
			DecimalRange endRange)
		{
			return (
					(@this - startRange.Minimum) *
					(endRange.Maximum - endRange.Minimum) /
					(startRange.Maximum - startRange.Minimum) +
					endRange.Minimum)
				.To<Decimal>();
		}
	}
}