using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ccr.Core.Extensions;
using Ccr.Core.Extensions.Templates;
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
	    byte value = 123;

	    var g= value.IsNotWithin((12, 16));
    }	

	}
}
