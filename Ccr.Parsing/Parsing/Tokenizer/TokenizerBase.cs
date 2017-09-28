using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Ccr.Parsing.Tokenizer.Tokens;
// ReSharper disable ConvertToAutoPropertyWithPrivateSetter
// ReSharper disable ArrangeAccessorOwnerBody
namespace Ccr.Parsing.Tokenizer
{
	public class TokenizerBase
		: IEnumerable<TokenUsage>
	{
		private readonly string sourceText;
		private int currentIndex;

		public string SourceText
		{
			get => sourceText;
		}
		public int CurrentIndex
		{
			get => currentIndex;
		}


		public TokenizerBase(
			string _sourceText)
		{
			sourceText = _sourceText;
		}

		public IEnumerator<TokenUsage> GetEnumerator()
		{
			while (HasMore())
			{
				var c = Read();
				switch (c)
				{
					case '!':
						yield return new TokenUsage<ExclamationMarkToken>(
							currentIndex, c);
						break;

					case '@':
						yield return new TokenUsage<AtSignToken>(
							currentIndex, c);
						break;

					case '#':
						yield return new TokenUsage<PoundSignToken>(
							currentIndex, c);
						break;

					case '$':
						yield return new TokenUsage<DollarSignToken>(
							currentIndex, c);
						break;

					case '%':
						yield return new TokenUsage<PercentSignToken>(
							currentIndex, c);
						break;


					case '^':
						yield return new TokenUsage<CaretToken>(
							currentIndex, c);
						break;

					case '&':
						yield return new TokenUsage<AmpresandToken>(
							currentIndex, c);
						break;

					case '*':
						yield return new TokenUsage<AsteriskToken>(
							currentIndex, c);
						break;

					case '(':
						yield return new TokenUsage<OpenParenthesisToken>(
							currentIndex, c);
						break;

					case ')':
						yield return new TokenUsage<CloseParenthesisToken>(
							currentIndex, c);
						break;


					case '_':
						yield return new TokenUsage<UserscoreToken>(
							currentIndex, c);
						break;

					case '+':
						yield return new TokenUsage<AddToken>(
							currentIndex, c);
						break;

					case '-':
						yield return new TokenUsage<SubtractToken>(
							currentIndex, c);
						break;

					case '=':
						yield return new TokenUsage<EqualsToken>(
							currentIndex, c);
						break;

					case '[':
						yield return new TokenUsage<OpenSquareBraceToken>(
							currentIndex, c);
						break;


					case ']':
						yield return new TokenUsage<CloseSquareBraceToken>(
							currentIndex, c);
						break;

					case '{':
						yield return new TokenUsage<OpenCurlyBraceToken>(
							currentIndex, c);
						break;

					case '}':
						yield return new TokenUsage<CloseCurlyBraceToken>(
							currentIndex, c);
						break;

					case '|':
						yield return new TokenUsage<VerticalPipeToken>(
							currentIndex, c);
						break;

					case '\\':
						yield return new TokenUsage<BlackSlashToken>(
							currentIndex, c);
						break;


					case ';':
						yield return new TokenUsage<SemicolonToken>(
							currentIndex, c);
						break;

					case ':':
						yield return new TokenUsage<ColonToken>(
							currentIndex, c);
						break;

					case '\'':
						yield return new TokenUsage<SingleQuoteToken>(
							currentIndex, c);
						break;

					case '"':
						yield return new TokenUsage<DoubleQuoteToken>(
							currentIndex, c);
						break;

					case '<':
						yield return new TokenUsage<LessThanToken>(
							currentIndex, c);
						break;


					case ',':
						yield return new TokenUsage<CommaToken>(
							currentIndex, c);
						break;

					case '>':
						yield return new TokenUsage<GreaterThanToken>(
							currentIndex, c);
						break;

					case '.':
						yield return new TokenUsage<PeriodToken>(
							currentIndex, c);
						break;

					case '/':
						yield return new TokenUsage<ForwardSlashToken>(
							currentIndex, c);
						break;

					case '?':
						yield return new TokenUsage<QuestionMarkToken>(
							currentIndex, c);
						break;


					case '~':
						yield return new TokenUsage<TildeToken>(
							currentIndex, c);
						break;

					case '`':
						yield return new TokenUsage<BacktickToken>(
							currentIndex, c);
						break;


					default:
						{
							var _builder = new StringBuilder();

							var isDigit = char.IsDigit(c);
							if (isDigit)
							{
								while (isDigit)
								{
									_builder.Append(c);

									c = Read();
									isDigit = char.IsDigit(c);
								}
								yield return new TokenUsage<NumberToken>(
									currentIndex, c);

								break;
							}
							var isLetter = char.IsLetter(c);
							if (isLetter)
							{

							}
							break;
						}
				}
			}

		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}




		public string GetExceptionRangeText(
			TokenizerFrame startFrame = null)
		{
			if (startFrame == null)
				return $"\"{SourceText}\" - (Index {CurrentIndex}): ";
			return $"\"{SourceText}\" - (Range {startFrame.Index} - {CurrentIndex}): ";
		}

		public char Peek(int offset = 0)
		{
			if (TryPeek(out var c, offset))
				return c;
			throw new IndexOutOfRangeException();
		}

		public char Read()
		{
			if (TryRead(out var c))
				return c;
			throw new IndexOutOfRangeException();
		}

		public bool TryPeek(out char c, int offset = 0)
		{
			if (MoreAt(currentIndex, offset))
			{
				c = sourceText[currentIndex + offset];
				return true;
			}
			c = default(char);
			return true;
		}

		public bool TryRead(out char c)
		{
			if (More)
			{
				c = sourceText[currentIndex++];
				return true;
			}
			c = default(char);
			return true;
		}

		public TokenizerFrame GetFrame()
		{
			return new TokenizerFrame(
				currentIndex);
		}

		public bool Step(int offset)
		{
			if (!MoreAt(currentIndex, offset))
				return false;

			currentIndex += offset;
			return true;
		}

		public bool Restore(
			TokenizerFrame frame)
		{
			if (!MoreAt(frame.Index, 0))
				return false;

			currentIndex = frame.Index;
			return true;
		}

		public void SkipWhiteSpace()
		{
			while (TryPeek(out var c)
				&& char.IsWhiteSpace(c))
			{
				currentIndex++;
			}
		}

		public bool HasMore()
		{
			return More;
		}

		private bool More
		{
			get => MoreAt(currentIndex, 0);
		}

		private bool MoreAt(
			int position,
			int offset)
		{
			return position + offset
				< sourceText.Length
				&& position + offset >= 0;
		}


	}
}
