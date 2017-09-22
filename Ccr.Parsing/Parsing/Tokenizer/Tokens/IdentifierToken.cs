namespace Ccr.Parsing.Tokenizer.Tokens
{
	public class IdentifierToken 
		: ContentToken
	{
		public IdentifierToken(
			string text) : base(
				text)
		{
		}

		public IdentifierToken(
			int startIndex, 
			string text) : base(
				startIndex,
				text)
		{
		}
	}
}
