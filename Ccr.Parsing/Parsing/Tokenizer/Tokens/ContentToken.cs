using Ccr.Parsing.Tokenizer.Tokens.Range;
using JetBrains.Annotations;

namespace Ccr.Parsing.Tokenizer.Tokens
{
	public abstract class ContentToken
		: TokenBase
	{
		protected ContentToken(
			[RegexPattern] string regex) : base(
				regex)
		{
		}
		//protected ContentToken(
		//	int startIndex,
		//	string text) : base(
		//	new TextRangePointer(
		//		startIndex,
		//		text))
		//{
		//}
	}
}
