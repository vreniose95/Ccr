using System;
using System.Text.RegularExpressions;
using Ccr.Parsing.Tokenizer.Tokens.Range;
using JetBrains.Annotations;

namespace Ccr.Parsing.Tokenizer.Tokens
{
	public abstract class TokenBase
	{
		//public ITextLiteralPointer TextLiteralPointer { get; }

		public Regex Regex { get; }

		public Func<string, bool> MatchPredicate { get; }


		protected TokenBase(
			[RegexPattern] string regexPattern)
		{
			Regex = new Regex(regexPattern);
		}
		protected TokenBase(
			Func<string, bool> matchPredicate)
		{
			MatchPredicate = matchPredicate;
		}

		public bool IsMatch(string text)
		{
			if (Regex != null)
				return Regex.IsMatch(text);

			if (MatchPredicate == null)
				throw new NotSupportedException();

			return MatchPredicate(text);
			
		}
		//protected TokenBase(
		//	ITextLiteralPointer _textLiteralPointer)
		//{
		//	TextLiteralPointer = _textLiteralPointer;
		//}

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