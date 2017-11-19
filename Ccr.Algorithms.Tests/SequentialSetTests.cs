using Ccr.Algorithms.Collections;
using NUnit.Framework;

namespace Ccr.Algorithms.Tests
{
  [TestFixture]
  public class SequentialSetTests
  {
    [Test]
    public void Pair()
    {
      var s = new SequentialPair<int>(3, 5);
      var t = new SequentialTriple<int>(2, 6, 9);
      var o = new SequentialQuad<int>(6, 9, 10, 14);

    }
  }
}
