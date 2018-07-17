using System;
using Ccr.Core.Extensions.NumericExtensions;
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

	    var g = value.IsNotWithin((12, 16));
			Console.WriteLine();
    }	

	}
}
