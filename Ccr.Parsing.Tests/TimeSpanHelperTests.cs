using System;
using NUnit.Framework;

namespace Ccr.Parsing.Tests
{
  [TestFixture]
  public class TimeSpanHelperTests
  {
    [TestCase("4d12h58m32s", 4, 12, 58, 32)]
    [TestCase("9d08h02m00s", 9, 08, 02, 00)]
    [TestCase("100d12h30m30s", 100, 12, 30, 30)]
    public void CanParseNormalizedFullFormTimeStamps(
      string str, 
      params int[] components)
    {
      var timeStamp1 = ComponentsToTimeSpan(components);
      var timeStamp2 = TimeSpanHelper.Parse(str);

      Assert.AreEqual(timeStamp1, timeStamp2);
    }


    private static TimeSpan ComponentsToTimeSpan(
      params int[] components)
    {
      return new TimeSpan(
        components[0],
        components[1],
        components[2],
        components[3]);
    }

  }
}
