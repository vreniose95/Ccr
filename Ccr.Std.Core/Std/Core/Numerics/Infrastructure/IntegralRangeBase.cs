using System;
using System.ComponentModel;
using Ccr.Std.Core.Extensions;

// ReSharper disable ArrangeAccessorOwnerBody
namespace Ccr.Std.Core.Numerics.Infrastructure
{
	public class IntegralRangeBase<TIntegralType>
		: IIntegralRange
			where TIntegralType
				: struct,
					IComparable
	{
		private long? _minimumAsLong;
		private ulong? _maximumAsUlong;

		private readonly TIntegralType _minimum;
		private readonly TIntegralType _maximum;

		long IIntegralRange.Minimum
		{
			get => _minimumAsLong ??
					(_minimumAsLong = Convert
						.ChangeType(_minimum, typeof(long))
						.As<long>())
					.Value;
		}
		ulong IIntegralRange.Maximum
		{
			get => _maximumAsUlong ??
						 (_maximumAsUlong = Convert
							 .ChangeType(_minimum, typeof(ulong))
							 .As<ulong>())
						 .Value;
		}

		object INumericRange.MinimumBase
		{
			get => Minimum;
		}
		object INumericRange.MaximumBase
		{
			get => Maximum;
		}


		public TIntegralType Minimum
		{
			get => _minimum;
		}
		public TIntegralType Maximum
		{
			get => _maximum;
		}

		protected IntegralRangeBase(
			TIntegralType minimum,
			TIntegralType maximum)
		{
			_minimum = minimum;
			_maximum = maximum;
		}



		bool INumericRange.IsWithinBase(
			object value,
			EndpointExclusivity exclusivity)
		{
			return IsWithin(
				value.To<TIntegralType>(),
				exclusivity);
		}

		bool INumericRange.IsNotWithinBase(
			object value,
			EndpointExclusivity exclusivity)
		{
			return IsNotWithin(
				value.To<TIntegralType>(),
				exclusivity);
		}

		object INumericRange.ConstrainBase(
			object value)
		{
			return Constrain(
				value.To<TIntegralType>());
		}


		public bool IsWithin(
			TIntegralType value,
			EndpointExclusivity exclusivity)
		{
			var lowResult = CheckLow(
				value,
				exclusivity,
				RangeComparisonDirection.GreaterThan);

			var highResult = CheckHigh(
				value,
				exclusivity,
				RangeComparisonDirection.LessThan);

			return lowResult && highResult;
		}


		public bool IsNotWithin(
			TIntegralType value,
			EndpointExclusivity exclusivity)
		{
			return !IsWithin(
				value,
				exclusivity);
		}

		public bool CheckLow(
			TIntegralType value,
			EndpointExclusivity exclusivity,
			RangeComparisonDirection direction)
		{
			return checkConstraint(
				value,
				Minimum,
				exclusivity,
				direction);
		}

		public bool CheckHigh(
			TIntegralType value,
			EndpointExclusivity exclusivity,
			RangeComparisonDirection direction)
		{
			return checkConstraint(
				value,
				Maximum,
				exclusivity,
				direction);
		}

		private static bool checkConstraint(
				TIntegralType left,
				TIntegralType right,
				EndpointExclusivity exclusivity,
				RangeComparisonDirection direction)
		{
			var compare =
				(ComparableResult)left.CompareTo(right);

			if (direction == RangeComparisonDirection.LessThan)
			{
				switch (exclusivity)
				{
					case EndpointExclusivity.Inclusive:
						return compare == ComparableResult.LessThan
									 || compare == ComparableResult.EqualTo;

					case EndpointExclusivity.Exclusive:
						return compare == ComparableResult.LessThan;

					default:
						throw new InvalidEnumArgumentException();
				}
			}
			if (direction == RangeComparisonDirection.GreaterThan)
			{
				switch (exclusivity)
				{
					case EndpointExclusivity.Inclusive:
						return compare == ComparableResult.GreaterThan
									 || compare == ComparableResult.EqualTo;

					case EndpointExclusivity.Exclusive:
						return compare == ComparableResult.GreaterThan;

					default:
						throw new InvalidEnumArgumentException();
				}
			}
			throw new InvalidEnumArgumentException();
		}

		public TIntegralType Constrain(
			TIntegralType value)
		{
			var lowResult = CheckLow(
				value,
				EndpointExclusivity.Inclusive,
				RangeComparisonDirection.GreaterThan);

			var highResult = CheckHigh(
				value,
				EndpointExclusivity.Inclusive,
				RangeComparisonDirection.LessThan);

			if (!lowResult)
				return Minimum;

			return highResult ? value
				: Maximum;
		}
	}
}
