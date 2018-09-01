
using System;
using Ccr.Std.Core.Extensions.NumericExtensions;
using NUnit.Framework;

namespace Ccr.Std.Core.Tests.Extensions
{
  [TestFixture]
  public static class ByteRangeNumericExtensions
  {
    [TestCase(34, 78)]
    [TestCase(67, 36)]
    [TestCase(10, 210)]
    [TestCase(150, 25)]
    public static void can_return_smallest_byte(
      byte left,
      byte right)
    {
      var smallest = left.Smallest(right);

      Assert.LessOrEqual(smallest, left);
      Assert.GreaterOrEqual(right, smallest);
    }
    
    [TestCase(34, 78)]
    [TestCase(67, 36)]
    [TestCase(10, 210)]
    [TestCase(150, 25)]
    public static void throws_on_smallest_byte_range_inconsistency(
      byte left,
      byte right)
    {
      var smallest = left.Smallest(right);

      Assert.Throws<NotSupportedException>(
        () =>
        {
          Assert.LessOrEqual(smallest, left);
          Assert.GreaterOrEqual(right, smallest);
        },
        $"The two provided values[a =\'{left}\', b=\'{right}\'] were passed " +
        $"to the .Smallest(byte) extension method, however the function returned " +
        $"the value \'{right}\', which is not Smaller than the \'{left}\' value.");
    }
  }
}
