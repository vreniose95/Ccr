using Ccr.Parsing.Tokenizer.Tokens.Range;

namespace Ccr.Parsing.Tokenizer.Tokens
{
	public class WhitespaceLiteralToken
		: TokenBase
	{
		public WhitespaceLiteralToken(
			string text) 
				: base(
					new TextLiteralPointer(
						text,
						text)) // TODO fix this 
		{
		}
		public WhitespaceLiteralToken(
			int startIndex,
			string text)
				: base(
					new TextRangePointer(
						startIndex,
						text))
		{
		}
	}
}
