namespace Ccr.Std.Parsing.Tokenizer.Tokens
{
	[TokenQualifier("(!)")]
	public class ExclamationMarkToken
		: SymbolToken
	{
		public ExclamationMarkToken() : base(
			"(!)")
		{
		}
	}
}