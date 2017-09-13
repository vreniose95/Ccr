using System;

namespace Ccr.Core.TypeSystemInfo.FluentConfiguration
{
	public static class IntegralTypeExtensions
	{
		public static SystemTypeConfiguredContext Configure(
			this Type @this)
		{
			return new SystemTypeConfiguredContext(
				@this);
		}
	}
}
