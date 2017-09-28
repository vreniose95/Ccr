using System;

namespace Ccr.Core.TypeSystemInfo.IntegralTypes
{
	public class IntegralTypeInfo
	{
		public Type SystemType { get; }

		public IntegralTypeValueRange ValueRange { get; }

		public IntegralTypeSizeInfo Size { get; }


		public IntegralTypeInfo(
			Type systemType,
			IntegralTypeValueRange valueRange,
			IntegralTypeSizeInfo size)
		{
			SystemType = systemType;
			ValueRange = valueRange;
			Size = size;
		}

		//public IntegralTypeInfo CreateFrom<TSystemType>()
		//{
			
		//}
	}
}