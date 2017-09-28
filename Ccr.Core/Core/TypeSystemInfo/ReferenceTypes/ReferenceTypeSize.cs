using System.Diagnostics;

namespace Ccr.Core.TypeSystemInfo.ReferenceTypes
{
	[DebuggerDisplay("ToString")]
	public abstract class ReferenceTypeSize
	{
		public int Bits { get; }

		protected ReferenceTypeSize(
			int bits)
		{
			Bits = bits;
		}

		public override string ToString()
		{
			return $"{Bits}-bits";
		}
	}
}
