using Ccr.Parsing.Tokenizer.Tokens.Range;

namespace Ccr.Parsing.Tokenizer.Tokens
{
	public abstract class ContentToken
		: TokenBase
	{
		protected ContentToken(
			string text) : base(
			new TextLiteralPointer(
				text))
		{
		}
		protected ContentToken(
			int startIndex,
			string text) : base(
			new TextRangePointer(
				startIndex,
				text))
		{
		}
	}
}
