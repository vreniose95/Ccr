using Ccr.Std.Parsing.Tokenizer.Tokens.Range;

namespace Ccr.Std.Parsing.Tokenizer.Tokens
{
	[TokenQualifier("([[0-9]*]?[.]?[0-9]*)")]
	public class NumberToken
		: TokenBase
	{
		public NumberToken(
			ITextLiteralPointer pointer) : base(
				pointer)
		{
		}
	}
}
