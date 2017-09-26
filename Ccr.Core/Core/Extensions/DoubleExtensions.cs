using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
