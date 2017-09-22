using System;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using JetBrains.Annotations;

namespace Ccr.Parsing.Tokenizer.Tokens
{
	public abstract class SymbolToken
		: TokenBase
	{
		protected SymbolToken(
			[RegexPattern] string regexPattern,
			Expression<Func<GroupCollection, string>> symbolValueRouter) : base(
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
			StringComparison stringComparison = StringComparison.CurrentCulture) : this(
				t => t.Equals(matchLiteral, stringComparison))
		{
		}
	}
}
