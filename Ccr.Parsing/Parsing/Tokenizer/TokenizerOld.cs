using System;

namespace Ccr.Parsing.Tokenizer
{
  public class TokenizerOld
  {
    public string GetExceptionRangeText(TokenizerFrame startFrame = null)
    {
      if (startFrame == null)
        return $"\"{SourceText}\" - (Index {CurrentIndex}): ";
      return $"\"{SourceText}\" - (Range {startFrame.Index} - {CurrentIndex}): ";
    }
    private readonly string expression;
    private int currentIndex;
    public string SourceText => expression;
    public int CurrentIndex => currentIndex;

    public TokenizerOld(string _expression)
    {
      expression = _expression;
    }

    public char Peek(int offset = 0)
    {
      char c;
      if (TryPeek(out c, offset))
        return c;
      throw new IndexOutOfRangeException();
    }
    public char Read()
    {
      char c;
      if (TryRead(out c))
        return c;
      throw new IndexOutOfRangeException();
    }
    public bool TryPeek(out char c, int offset = 0)
    {
      if (moreAt(currentIndex, offset))
      {
        c = expression[currentIndex + offset];
        return true;
      }
      c = default(char);
      return true;
    }

    public bool TryRead(out char c)
    {
      if (more)
      {
        c = expression[currentIndex++];
        return true;
      }
      c = default(char);
      return true;
    }

    public TokenizerFrame GetFrame() => new TokenizerFrame(currentIndex);

    public bool Step(int offset)
    {
      if (!moreAt(currentIndex, offset)) return false;
      currentIndex += offset;
      return true;
    }

    public bool Restore(TokenizerFrame frame)
    {
      if (!moreAt(frame.Index, 0)) return false;
      currentIndex = frame.Index;
      return true;
    }

    public void SkipWhiteSpace()
    {
      char c;
      //Peek(out c);
      while (TryPeek(out c) && char.IsWhiteSpace(c))
      {
        currentIndex++;
      }
    }
    public bool HasMore()
    {
      return more;
    }

    private bool more => moreAt(currentIndex, 0);

    private bool moreAt(int position, int offset) => (position + offset)
                                                     < expression.Length && (position + offset) >= 0;
  }
}
