using Ccr.Std.Parsing.Tokenizer.Tokens.Range;
using JetBrains.Annotations;
using System;
using System.Text.RegularExpressions;

namespace Ccr.Std.Parsing.Tokenizer.Tokens
{
	public abstract class RegexTokenBase : TokenBase
	{
		[NotNull]
		public virtual Regex RegexQualifier { get; }


		protected RegexTokenBase([RegexPattern] string regexPattern)
			: this(
				new Regex(regexPattern))
		{
		}

		protected RegexTokenBase([NotNull] Regex regexQualifier)
			: base(
				regexQualifier.IsMatch)
		{
			RegexQualifier = regexQualifier;
		}


	}
	public abstract class TokenBase
	{
		public TextRangePointer TextRangePointer { get; }

		private readonly Func<string, bool> _matchPredicate;

		public abstract string GetAssembledString();


		protected TokenBase(Func<string, bool> matchPredicate)
		{
			_matchPredicate = matchPredicate;
			//}


			//public bool IsMatch(string text)
			//{
			//	if (Regex != null)
			//		return Regex.IsMatch(text);

			//	if (MatchPredicate == null)
			//		throw new NotSupportedException();

			//	return MatchPredicate(text);
			//}


			//protected TokenBase(
			//	ITextLiteralPointer _textLiteralPointer)
			//{
			//	TextLiteralPointer = _textLiteralPointer;
			//}
		}
	}
}

//"&");

//"*");

//"(");

//")");


//"-");

//"_");

//"+");

//"-");

//public SymbolToken EqualsToken = new SymbolToken("=");


//"[");

//"]");

//"{");

//"}");

//"|");


//"\\");

//";");

//":");

//"'");

//"\"");


//"<");

//",");

//">");

//".");

//"/");


//"?");

//"`");

//"~");