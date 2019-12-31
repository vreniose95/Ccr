namespace Ccr.Std.Parsing.Tokenizer.Tokens
{
	[TokenQualifier("([A-z]*)")]
	public class IdentifierToken 
		: ContentToken
	{
		public IdentifierToken(
			string text) : base(
				text)
		{
		}

		//public IdentifierToken(
		//	int startIndex, 
		//	string text) : base(
		//		startIndex,
		//		text)
		//{
		//}
	}
}
