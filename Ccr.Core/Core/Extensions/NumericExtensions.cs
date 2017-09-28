﻿using System.Net.NetworkInformation;
using Ccr.Core.Numerics.Ranges;

namespace Ccr.Core.Extensions
{
	public static class NumericExtensions
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

		public static int LinearMap(
			this int @this,
			Int32Range startRange,
			Int32Range endRange)
		{

		}

	}
}