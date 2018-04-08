using System.Diagnostics;
using Ccr.Std.Core.TypeSystemInfo.ReferenceTypes;

namespace Ccr.Std.Core.TypeSystemInfo.NonIntegralTypes
{
    [DebuggerDisplay("ToString")]
    public class NonIntegralTypeSizeInfo
      : ReferenceTypeSize
    {


      public NonIntegralTypeSizeInfo(
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

