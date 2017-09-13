using System.Diagnostics;

namespace Ccr.Core.TypeSystemInfo
{
	[DebuggerDisplay("ToString()")]
	public struct IntegralTypeSize
	{
		public Signedness Signedness { get; }

		public int Bits { get; }


		public IntegralTypeSize(
			Signedness signedness,
			int bits)
		{
			Signedness = signedness;
			Bits = bits;
		}


		public override string ToString()
		{
			return $"{Signedness} {Bits}-bit integer";
		}
	}
}