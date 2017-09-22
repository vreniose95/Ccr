namespace Ccr.Parsing.Tokenizer.Tokens.Range
{
	public interface ITextRangePointer
		: ITextLiteralPointer
	{
		int StartIndex { get; }

		int EndIndex { get; }

		int Length { get; }
	}
}
