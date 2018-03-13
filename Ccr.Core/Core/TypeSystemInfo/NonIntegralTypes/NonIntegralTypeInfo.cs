using System;
using Ccr.Core.Extensions;
using JetBrains.Annotations;

namespace Ccr.Core.TypeSystemInfo.NonIntegralTypes
{
	public class NonIntegralTypeInfo
    : BuiltInTypeInfo
	{
    [NotNull]
    public NonIntegralTypeValueRange ValueRange { get; }

    [NotNull]
    public NonIntegralTypeSizeInfo Size { get; }


    public NonIntegralTypeInfo(
      [NotNull] Type systemType,
      [NotNull] NonIntegralTypeValueRange valueRange,
      [NotNull] NonIntegralTypeSizeInfo size) : base(
        systemType)
	  {
      valueRange.IsNotNull(nameof(valueRange));
      size.IsNotNull(nameof(size));

      ValueRange = valueRange;
      Size = size;
    }
  }
}
