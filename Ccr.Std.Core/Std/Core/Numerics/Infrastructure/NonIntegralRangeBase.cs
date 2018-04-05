using System;
using System.ComponentModel;
using Ccr.Std.Core.Extensions;

// ReSharper disable ArrangeAccessorOwnerBody
// ReSharper disable ConvertToAutoProperty
// ReSharper disable ConvertToAutoPropertyWhenPossible
namespace Ccr.Std.Core.Numerics.Infrastructure
{
	public class NonIntegralRangeBase<TNonIntegralType>
		: INonIntegralRange
			where TNonIntegralType
				: struct,
					IComparable
	{
		private decimal? _minimumAsDecimal;
		private decimal? _maximumAsDecimal;

		private readonly TNonIntegralType _minimum;
		private readonly TNonIntegralType _maximum;


		decimal INonIntegralRange.Minimum
		{
			get => _minimumAsDecimal ??
			       (_minimumAsDecimal = Convert
				       .ChangeType(_minimum, typeof(decimal))
				       .As<decimal>())
			       .Value;
		}
		decimal INonIntegralRange.Maximum
		{
			get => _maximumAsDecimal ??
			       (_maximumAsDecimal = Convert
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


		public TNonIntegralType Minimum
		{
			get => _minimum;
		}
		public TNonIntegralType Maximum
		{
			get => _maximum;
		}


		protected NonIntegralRangeBase(
			TNonIntegralType minimum,
			TNonIntegralType maximum)
		{
			_minimum = minimum;
			_maximum = maximum;
		}




		bool INumericRange.IsWithinBase(
			object value,
			EndpointExclusivity exclusivity)
		{
			return IsWithin(
				value.To<TNonIntegralType>(),
				exclusivity);
		}

		bool INumericRange.IsNotWithinBase(
			object value,
			EndpointExclusivity exclusivity)
		{
			return IsNotWithin(
				value.To<TNonIntegralType>(),
				exclusivity);
		}

		object INumericRange.ConstrainBase(
			object value)
		{
			return Constrain(
				value.To<TNonIntegralType>());
		}

		public bool IsWithin(
			TNonIntegralType value,
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
			TNonIntegralType value,
			EndpointExclusivity exclusivity)
		{
			return !IsWithin(
				value,
				exclusivity);
		}

		public bool CheckLow(
			TNonIntegralType value,
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
			TNonIntegralType value,
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
			TNonIntegralType left,
			TNonIntegralType right,
			EndpointExclusivity exclusivity,
			RangeComparisonDirection direction)
		{
			var compare =
				(ComparableResult) left.CompareTo(right);

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

		public TNonIntegralType Constrain(
			TNonIntegralType value)
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