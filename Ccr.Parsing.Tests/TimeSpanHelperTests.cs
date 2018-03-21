using System;
using Ccr.Parsing.Lexer;
using NUnit.Framework;

namespace Ccr.Parsing.Tests
{
  [TestFixture]
  public class TimeSpanHelperTests
  {
    [TestCase("d4h12m58s32")]
    public void CanParseNormalizedFullFormTimeStamps(string str)
    {
      var timeStamp = TimeSpanHelper.Parse(str);

      Assert.AreEqual(timeStamp, new TimeSpan(4, 12, 58, 32));
    }

  }
}
