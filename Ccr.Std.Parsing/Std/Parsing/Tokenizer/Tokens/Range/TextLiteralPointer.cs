using System.Text.RegularExpressions;
using JetBrains.Annotations;

// ReSharper disable ConvertToAutoProperty
// ReSharper disable ArrangeAccessorOwnerBody

namespace Ccr.Std.Parsing.Tokenizer.Tokens.Range
{
	public class TextLiteralPointer
		: ITextLiteralPointer
	{
		protected readonly string _literalText;
		private readonly Regex _regexPattern;


		public string Text
		{
			get => _literalText;
		}

		public Regex RegexPattern
		{
			get => _regexPattern;
		}


		public TextLiteralPointer(
			string literalText,
			[RegexPattern] string regexPattern)
		{
			_literalText = literalText;
			_regexPattern = new Regex(regexPattern);
		}
	}
}