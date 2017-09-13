using System;

namespace Ccr.Core.TypeSystemInfo.FluentConfiguration
{
	public class SystemTypeConfiguredContext
	{
		public Type SystemType { get; }

		public SystemTypeConfiguredContext(
			Type systemType)
		{
			SystemType = systemType;
		}

		public IntegralRangeConfiguredContext ConfigureRange()
		{
			return new IntegralRangeConfiguredContext();
		}
	}
}
