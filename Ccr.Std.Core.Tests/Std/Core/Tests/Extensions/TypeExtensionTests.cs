using NUnit.Framework;
//using ;

namespace Ccr.Std.Core.Tests.Extensions
{
  [TestFixture]
  public class TypeExtensionTests
  {
    [Test]
    public void AsExtensionTypeCastTest()
    {
      const int value_1 = 32;

      var trash = new Ccr.SomeGarbage("me");

      var boxed_2 = (object)value_1;
     // var unbox_3 = Ccr.Std.Core.Extensions.TypeExtensions.As<int>(boxed_2);

      //Assert.AreEqual(boxed_2, unbox_3);
    }
  }
}
