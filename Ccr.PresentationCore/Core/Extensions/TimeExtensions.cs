using System;
using System.Windows;
using System.Windows.Media.Animation;

namespace Core.Extensions
{
	public static class TimeExtensions
	{
		public static Duration MillisecondsD(this int i)
		{
			return new Duration(TimeSpan.FromMilliseconds(i));
		}
		public static Duration MillisecondsD(this double i)
		{
			return new Duration(TimeSpan.FromMilliseconds(i));
		}

		public static TimeSpan MillisecondsT(this int i)
		{
			return TimeSpan.FromMilliseconds(i);
		}
		public static TimeSpan MillisecondsT(this double i)
		{
			return TimeSpan.FromMilliseconds(i);
		}

		public static KeyTime MillisecondsK(this int i)
		{
			return KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(i));
		}
		public static KeyTime MillisecondsK(this double i)
		{
			return KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(i));
		}

		//private const decimal DaysInAYear = 365.242M;
		//public static int DayIndex(this TimeSpan @this)
		//{
		//	return @this.TotalDays
		//}

	}
}