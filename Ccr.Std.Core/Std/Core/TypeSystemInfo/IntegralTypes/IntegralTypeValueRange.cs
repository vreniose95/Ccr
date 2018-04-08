using System;
using System.Diagnostics;

namespace Ccr.Std.Core.TypeSystemInfo.IntegralTypes
{
	[DebuggerDisplay("ToString")]
	public class IntegralTypeValueRange
    : BuiltInTypeInfo
	{
		public long Minimum { get; }

		public ulong Maximum { get; }


		public IntegralTypeValueRange(
			long minimum,
			ulong maximum,
		  Type systemType) : base(
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