namespace Ccr.Parsing.Tokenizer.Tokens
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