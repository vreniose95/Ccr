using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ccr.Core.TypeSystemInfo.ReferenceTypes;

namespace Ccr.Core.TypeSystemInfo.NonIntegralTypes
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

