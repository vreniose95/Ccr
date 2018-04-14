namespace Ccr.Core.Extensions
{
	public static class DoubleExtensions
	{
		public static double Smallest(
			this double @this,
			double value)
		{
			return @this < value
				? value
				: @this;
		}
		public static double Largest(
			this double @this,
			double value)
		{
			return @this > value
				? value
				: @this;
		}

    

  }
}
