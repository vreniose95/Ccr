using System;
using Ccr.Std.Core.Extensions;
using JetBrains.Annotations;

namespace Ccr.Std.Core.TypeSystemInfo.IntegralTypes
{
	public class IntegralTypeInfo
    : BuiltInTypeInfo
	{
    [NotNull]
		public IntegralTypeValueRange ValueRange { get; }

    [NotNull]
		public IntegralTypeSizeInfo Size { get; }

    
		public IntegralTypeInfo(
			[NotNull] Type systemType,
			[NotNull] IntegralTypeValueRange valueRange,
			[NotNull] IntegralTypeSizeInfo size) : base(
        systemType)
		{
      valueRange.IsNotNull(nameof(valueRange));
      size.IsNotNull(nameof(size));

			ValueRange = valueRange;
			Size = size;
		}


		//public IntegralTypeInfo CreateFrom<TSystemType>()
		//{
			
		//}
	}
}