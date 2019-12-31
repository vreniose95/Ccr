namespace Ccr.Std.Parsing.Tokenizer.Tokens.Range
{
	public interface ITextRangePointer
		: ITextLiteralPointer
	{
		int EndIndex { get; }

		int Length { get; }
	}
}
