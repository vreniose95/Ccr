using System;
using System.Collections.Generic;
using System.Linq;
using Ccr.Core.Extensions;

namespace Ccr.Parsing
{
  public static class TimeSpanHelper
  {
    internal enum SyntaxDirective
    {
      Seconds = 0,
      Minutes = 1,
      Hours = 2,
      Days = 3
    }

    private static readonly Dictionary<char, SyntaxDirective> SyntaxDirectives
      = new Dictionary<char, SyntaxDirective>
      {
        ['s'] = SyntaxDirective.Seconds,
        ['m'] = SyntaxDirective.Minutes,
        ['h'] = SyntaxDirective.Hours,
        ['d'] = SyntaxDirective.Days
      };



    public static TimeSpan Parse(
      string input)
    {
      var syntacticBlocks = new List<(SyntaxDirective directive, int value)>();
      var numericBuffer = "";

      void AcceptNumericBuffer(SyntaxDirective targetDirective)
      {
        if (numericBuffer.Length == 0)
          throw new FormatException(
            $"Cannot accept the numeric buffer with the SyntaxDirective {targetDirective.ToString().Quote()} " +
            $"in the current context because the numeric buffer is empty.");

        var integralValue = int.Parse(numericBuffer);

        syntacticBlocks.Add((targetDirective, integralValue));
        numericBuffer = "";
      }

      foreach (var c in input)
      {
        if (char.IsLetter(c))
        {
          if (!SyntaxDirectives.TryGetValue(c, out var syntaxDirective))
            throw new FormatException(
              $"The character {c.SQuote()} is not a valid directive character. Expected [s, m, h, d].");

          if (syntacticBlocks.Any(t => t.directive == syntaxDirective))
            throw new FormatException(
              $"The syntax directive character {c.SQuote()}, mapping to the directive {syntaxDirective.ToString().Quote()}, " +
              $"is not valid because it has already been set.");

          AcceptNumericBuffer(syntaxDirective);
        }
        else if (char.IsDigit(c))
        {
          numericBuffer += c;
        }
        else
        {
          throw new FormatException(
            $"The character {c.SQuote()} is invalid. The extended formatting TimeSpan parser only accepts the characters " +
            $"[s, m, h, d], and digit characters [0-9].");
        }
      }

      if (numericBuffer.Length > 0)
      {
        throw new FormatException(
          $"The TimeSpan format is invalid because it does not end with a valid directive character [s, m, h, d]. " +
          $"The numeric buffer {numericBuffer.Quote()} must be empty.");
      }


      var rankOrderedBlocks = syntacticBlocks
                              .OrderBy(t => (int) t.directive)
                              .ToArray();

      var timeSpanComponents = Enumerable.Repeat(0, 4).ToArray();

      foreach (var (directive, value) in rankOrderedBlocks)
      {
        var componentIndex = (int)directive;

        timeSpanComponents[componentIndex] = value;
      }

      return new TimeSpan(
        timeSpanComponents[3],
        timeSpanComponents[2],
        timeSpanComponents[1],
        timeSpanComponents[0]);
    }
  }
}
