using System;

namespace Ccr.Core.TypeSystemInfo
{
	public struct IntegralTypeInfo
	{
		public Type SystemType { get; }

		public IntegralTypeValueRange ValueRange { get; }

		public IntegralTypeSize Size { get; }


		public IntegralTypeInfo(
			Type systemType,
			IntegralTypeValueRange valueRange,
			IntegralTypeSize size)
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