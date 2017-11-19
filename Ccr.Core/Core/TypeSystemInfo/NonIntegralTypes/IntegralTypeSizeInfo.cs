using System.Diagnostics;
using Ccr.Core.TypeSystemInfo.ReferenceTypes;

namespace Ccr.Core.TypeSystemInfo.IntegralTypes
{
	[DebuggerDisplay("ToString")]
	public class IntegralTypeSizeInfo
		: ReferenceTypeSize
	{
		public Signedness Signedness { get; }

		public IntegralTypeSizeInfo(
			Signedness signedness,
			int bits) : base(
				bits)
		{
			Signedness = signedness;
		}


		public override string ToString()
		{
			return $"{Signedness} {Bits}-bit integer";
		}
	}
}