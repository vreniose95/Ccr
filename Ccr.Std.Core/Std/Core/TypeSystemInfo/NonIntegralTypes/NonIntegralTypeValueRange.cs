using System;
using JetBrains.Annotations;

namespace Ccr.Std.Core.TypeSystemInfo.NonIntegralTypes
{
	public sealed class NonIntegralTypeValueRange
    : BuiltInTypeInfo
	{
	  public double Minimum { get; }

    public double Maximum { get; }


    public NonIntegralTypeValueRange(
      double minimum,
      double maximum,
      [NotNull] Type systemType)
        : base(
            systemType)
    {
      Minimum = minimum;
      Maximum = maximum;
    }
    

    public override string ToString()
    {
      return $"[{Minimum:N} to {Maximum:N}]";
    }
  }
}
