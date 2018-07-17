using System;
using System.Collections.Generic;
using System.Text;

namespace Ccr.Std.Parsing.Syntax
{
  public enum SyntaxKind
  {
    None,

    AtSignToken,
    PoundSignToken,
    DollarSignToken,
    PercentSignToken,
    CaretToken,
    AmpresandToken,
    AsteriskToken,
    OpenParenthesisToken,
    CloseParenthesisToken,
    UserscoreToken,
    AddToken,
    SubtractToken,
    EqualsToken,
    OpenSquareBraceToken,
    CloseSquareBraceToken,
    OpenCurlyBraceToken,
    CloseCurlyBraceToken,
    VerticalPipeToken,
    BlackSlashToken,
    SemicolonToken,
    ColonToken,
    SingleQuoteToken,
    DoubleQuoteToken,
    LessThanToken,
    CommaToken,
    GreaterThanToken,
    PeriodToken,
    ForwardSlashToken,
    QuestionMarkToken,
    TildeToken,
    BacktickToken
  }
}
