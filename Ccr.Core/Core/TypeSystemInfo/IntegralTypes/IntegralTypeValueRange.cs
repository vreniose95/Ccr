using System.Diagnostics;

namespace Ccr.Core.TypeSystemInfo.IntegralTypes
{
	[DebuggerDisplay("ToString")]
	public class IntegralTypeValueRange
	{
		public long Minimum { get; }

		public ulong Maximum { get; }


		public IntegralTypeValueRange(
			long minimum,
			ulong maximum)
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