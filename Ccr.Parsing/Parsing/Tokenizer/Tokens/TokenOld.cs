using System.Diagnostics;

namespace Ccr.Parsing.Tokenizer.Tokens.OLD
{
  public abstract class TokenBase
  {
    public string LiteralValue { get; }

    protected TokenBase(string literalValue)
    {
      LiteralValue = literalValue;
    }
  }

  [TokenQualifier("$")]
  public class DollarSignToken : TokenBase
  {
    public DollarSignToken(string literalValue) : base(literalValue)
    {
    }
  }
  [TokenQualifier("@")]
  public class AtSignToken : TokenBase
  {
    public AtSignToken(string literalValue) : base(literalValue)
    {
    }
  }
  [TokenQualifier("%")]
  public class PercentSignToken : TokenBase
  {
    public PercentSignToken(string literalValue) : base(literalValue)
    {
    }
  }
  [TokenQualifier("&")]
  public class AmpresandToken : TokenBase
  {
    public AmpresandToken(string literalValue) : base(literalValue)
    {
    }
  }

  [TokenQualifier("(|)")]
  public abstract class ParenthesisTokenBase : TokenBase
  {
    protected ParenthesisTokenBase(string literalValue) : base(literalValue)
    {
    }
  }
  [TokenQualifier("(")]
  public class LeftParenthesisToken : ParenthesisTokenBase
  {
    public LeftParenthesisToken(string literalValue) : base(literalValue)
    {
    }
  }
  [TokenQualifier(")")]
  public class RightParenthesisToken : ParenthesisTokenBase
  {
    public RightParenthesisToken(string literalValue) : base(literalValue)
    {
    }
  }

  [TokenQualifier("[|]")]
  public abstract class SquareBracketTokenBase : TokenBase
  {
    protected SquareBracketTokenBase(string literalValue) : base(literalValue)
    {
    }
  }
  [TokenQualifier("[")]
  public class LeftSquareBracketToken : SquareBracketTokenBase
  {
    public LeftSquareBracketToken(string literalValue) : base(literalValue)
    {
    }
  }
  [TokenQualifier("]")]
  public class RightSquareBracketToken : SquareBracketTokenBase
  {
    public RightSquareBracketToken(string literalValue) : base(literalValue)
    {
    }
  }


  [TokenQualifier("{|}")]
  public abstract class CurlyBraceTokenBase : TokenBase
  {
    protected CurlyBraceTokenBase(string literalValue) : base(literalValue)
    {
    }
  }
  [TokenQualifier("{")]
  public class LeftCurlyBraceToken : CurlyBraceTokenBase
  {
    public LeftCurlyBraceToken(string literalValue) : base(literalValue)
    {
    }
  }
  [TokenQualifier("}")]
  public class RightCurlyBraceToken : CurlyBraceTokenBase
  {
    public RightCurlyBraceToken(string literalValue) : base(literalValue)
    {
    }
  }


  [TokenQualifier(".")]
  public class PeriodToken : TokenBase
  {
    public PeriodToken(string literalValue) : base(literalValue)
    {
    }
  }
  [TokenQualifier("([A-z][A-z_]*)")]
  public class IdentiferToken : TokenBase
  {
    public IdentiferToken(string literalValue) : base(literalValue)
    {
    }
  }
  [TokenQualifier("\'([^\']*)\'")]
  public class StringLiteralToken : TokenBase
  {
    public StringLiteralToken(string literalValue) : base(literalValue)
    {
    }
  }
  [TokenQualifier("([\t\n\r ]*)")]
  public class WhitespaceToken : TokenBase
  {
    public WhitespaceToken(string literalValue) : base(literalValue)
    {
    }
  }
  [TokenQualifier("([0-9]?.?[0-9]*)")]
  public class NumberToken : TokenBase
  {
    public NumberToken(string literalValue) : base(literalValue)
    {
    }
  }
}
