using System;

namespace Ccr.Std.Core.Helpers
{
	public class MathHelpers
	{
		public static double ToRadians(
			double degrees)
		{
			return degrees * (Math.PI / 180d);
		}

		public static double ToDegrees(
			double radians)
		{
			return radians * (180d / Math.PI);
		}
	}
}
