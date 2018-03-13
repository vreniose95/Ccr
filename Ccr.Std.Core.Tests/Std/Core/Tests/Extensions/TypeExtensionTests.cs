using System;
using Ccr.Std.Core.Extensions;
using NUnit.Framework;
namespace Ccr.Std.Core.Tests.Extensions
{
  [TestFixture]
  public class TypeExtensionTests
  {
    [Test]
    public void AsExtensionTypeCastTest()
    {
      const int value_1 = 32;

      var boxed_2 = (object)value_1;
      var unbox_3 = boxed_2.As<int>();

      Assert.AreEqual(boxed_2, unbox_3);
    }

    public void AsExtensionTypeCastTestFails()
    {
      Assert.Throws<Exception>(() =>
      {
        const string @string = "test";
        var boxed_2 = (object) @string;

        var unbox_3 = boxed_2.AsOrDefault<string>();
      });
    }
  }
}
