using System.Diagnostics;
using Ccr.Std.Core.TypeSystemInfo.ReferenceTypes;

namespace Ccr.Std.Core.TypeSystemInfo.IntegralTypes
{
	[DebuggerDisplay("ToString")]
	public class IntegralTypeSizeInfo
		: ReferenceTypeSize
	{
		public IntegralTypeSizeInfo(
			Signedness signedness,
			int bits) : base(
        signedness,
				bits)
		{
		}

	  public override string ToString()
		{
			return $"{Signedness} {Bits}-bit integer";
		}
	}
}