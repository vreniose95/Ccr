using System;
using Ccr.Introspective.Extensions;
using Ccr.Introspective.Infrastructure;
using Ccr.Introspective.Infrastructure.Context;
using Ccr.Parsing.Tokenizer.Tokens.Range;
// ReSharper disable ConvertToAutoProperty
// ReSharper disable ArrangeAccessorOwnerBody
namespace Ccr.Parsing.Tokenizer.Tokens
{
	public abstract class TokenUsage
		: ITextRangePointer
	{
		protected readonly int _startIndex;

		protected readonly string _text;

		private readonly TokenBase _token;


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
			get => _text.Length;
		}
		public string Text
		{
			get => _text;
		}
		public TokenBase TokenBase
		{
			get => _token;
		}
		public virtual Type TokenType
		{
			get => _token.GetType();
		}


		protected TokenUsage(
			int startIndex,
			string text,
			TokenBase token)
		{
			_startIndex = startIndex;
			_text = text;
			_token = token;
		}
	}
	public class TokenUsage<TToken>
		: TokenUsage
		where TToken
			: TokenBase
	{
		protected readonly TToken _token;

		public TToken Token
		{
			get => _token;
		}
		public override Type TokenType
		{
			get => typeof(TToken);
		}


		public TokenUsage(
			int startIndex,
			char text) : this(
				startIndex,
				text.ToString(),
				new IntrospectiveStaticContext<TToken>()
					.CreateInstance(MemberDescriptor.Public))
		{
		}
		protected TokenUsage(
			int startIndex,
			string text,
			TToken token) : base(
				startIndex,
				text,
				token)
		{
			_token = token;
		}
	}
}
