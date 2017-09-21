using System;                  
using Ccr.Core.Extensions;

namespace Ccr.Core.Numerics
{
	public class IntegralRangeBase<TIntegralType>
		: IIntegralRange
			where TIntegralType 
				:	struct
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
						.IsOfType<long>())
					.Value;
		}
		ulong IIntegralRange.Maximum
		{
			get => _maximumAsUlong ??
			       (_maximumAsUlong = Convert
				       .ChangeType(_minimum, typeof(ulong))
				       .IsOfType<ulong>())
			       .Value;
		}

		public TIntegralType Minimum
		{
			get => _maximum;
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

		
	}
}
