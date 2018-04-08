using System.Diagnostics;

namespace Ccr.Std.Core.TypeSystemInfo.ReferenceTypes
{
	[DebuggerDisplay("ToString")]
	public abstract class ReferenceTypeSize
	{
		public int Bits { get; }

	  public Signedness Signedness { get; }

    
    protected ReferenceTypeSize(
      Signedness signedness,
      int bits)
    {
      Signedness = signedness;
			Bits = bits;
		}

		public override string ToString()
		{
			return $"{Bits}-bits";
		}
	}
}
