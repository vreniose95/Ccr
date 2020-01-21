using System;

namespace Ccr.Std.Core.Extensions
{
	public static class TimeSpanExtensions
	{
		public static TimeSpan MultipliedBy(
			this TimeSpan @this, 
			int x)
		{
			return TimeSpan.FromTicks(@this.Ticks * x);
		}

		public static double MultipliedBy(
			this TimeSpan @this,
			TimeSpan x)
		{
			return (double)@this.Ticks * x.Ticks;
		}

		public static TimeSpan DividedBy(
			this TimeSpan @this, 
			int x)
		{
			return TimeSpan.FromTicks(@this.Ticks / x);
		}

		public static double DividedBy(
			this TimeSpan @this, 
			TimeSpan x)
		{
			return (double)@this.Ticks / x.Ticks;
		}
	}
}
