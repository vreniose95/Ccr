using NUnit.Framework;

namespace Ccr.PresentationCore.Collections
{
  [TestFixture]
  public class ValueEnumTests
  {
    [Test]
    public void CanEnumerateFontfaceOptions()
    {
      var fontfaces = ValueEnum.Enumerate<FontfaceOptions>();
      foreach (var fontface in fontfaces)
      {

      }
    }
  }
}
