namespace Ccr.Std.Parsing.Tokenizer.Tokens.Range
{
	public interface ITextRange
	{
		int StartIndex { get; }

		int Length { get; }
	}


	public class TextRange
		: ITextRange
	{
		/// <inheritdoc />
		public int StartIndex { get; }

		/// <inheritdoc />
		public int Length { get; }


		public TextRange(int startIndex, int length)
		{
			StartIndex = startIndex;
			Length = length;
		}
	}


	public interface ITextSource
	{
		string Text { get; }
	}


	/// <inheritdoc />
	public class StringTextSource 
		: ITextSource
	{
		private readonly string _text;

		
		public StringTextSource(
			string text)
		{
			_text = text;
		}


		/// <inheritdoc />
		public string Text
		{
			get => _text;
		}
	}

}