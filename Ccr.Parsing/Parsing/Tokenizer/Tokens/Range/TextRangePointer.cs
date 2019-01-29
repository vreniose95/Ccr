//ReSharper disable ConvertToAutoProperty
//ReSharper disable ArrangeAccessorOwnerBody
using System.Text.RegularExpressions;
using JetBrains.Annotations;

namespace Ccr.Parsing.Tokenizer.Tokens.Range
{
	public class TextRangePointer
		: TextLiteralPointer,
			ITextRangePointer
	{
		protected readonly int _startIndex;

		public int StartIndex
		{
			get => _startIndex;
		}
		public int EndIndex
		{
			get => StartIndex + Length;
		}
		public int Length
		{
			get => _literalText.Length;
		}

		public TextRangePointer(
			int startIndex,
			[RegexPattern] string text) 
				: base(
					text,
					Regex.Escape(text)) // TODO fix this 
		{
			_startIndex = startIndex;
		}

	}
}
