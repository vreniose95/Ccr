using System.Diagnostics;
using System.Numerics;
using NUnit.Framework;

namespace Ccr.Algorithms.Tests
{
  [TestFixture]
  public class SplineInterpolationAlgorithmTests
  {
    [Test]
    public void CentripetalCatmullRomSplineInterpolatorTests()
    {
      var vectorsStart = new []
      {
        new Vector2(1, 50),
        new Vector2(2, 20),
        new Vector2(3, 10),
        new Vector2(4, 30),
        new Vector2(5, 60),
        new Vector2(6, 65),
        new Vector2(7, 40),
        new Vector2(8, 35),
        new Vector2(9, 60)
      };

      var vectorsEnd = SplineInterpolationAlgorithms.CentripetalCatmullRomSplineInterpolator(vectorsStart);
      foreach (var vec in vectorsEnd)
      {
        Debug.WriteLine($"{vec.X}, {vec.Y}");
      }
    }
  }
}
