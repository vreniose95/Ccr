using Ccr.Parsing.Tokenizer.Tokens.Range;

namespace Ccr.Parsing.Tokenizer.Tokens
{
	public class NumberToken
		: TokenBase
	{
		public NumberToken(
			string text) : base(
			new TextLiteralPointer(
				text))
		{
		}
		public NumberToken(
			int startIndex,
			string text) : base(
			new TextRangePointer(
				startIndex,
				text))
		{
		}
	}
}
