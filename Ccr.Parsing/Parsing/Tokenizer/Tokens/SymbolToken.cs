using System;
using JetBrains.Annotations;

namespace Ccr.Parsing.Tokenizer.Tokens
{
	public abstract class SymbolToken
		: TokenBase
	{
		protected SymbolToken(
			[RegexPattern] string regexPattern) : base(
				regexPattern)
		{
		}
		protected SymbolToken(
			Func<string, bool> matchPredicate) : base(
				matchPredicate)
		{
		}
		protected SymbolToken(
			string matchLiteral,
			StringComparison stringComparison) : this(
				t => t.Equals(matchLiteral, stringComparison))
		{
		}
	}
}
