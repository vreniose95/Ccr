using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ccr.Core.TypeSystemInfo;
using Ccr.Core.TypeSystemInfo.IntegralTypes;
using NUnit.Framework;

namespace Ccr.Core.Tests
{
  [TestFixture]
  public class IntegralTypeTests
  {
    [Test]
    public void EnumerateIt()
    {
      foreach (var ti in IntegralTypeReference.IntegralTypeInfos)
      {

      }
    }

	}
}
