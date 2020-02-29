using System;
using System.Windows;
using Ccr.MaterialDesign.Infrastructure.Descriptors;
using Ccr.MaterialDesign.Markup.TypeConverters;
using Ccr.MaterialDesign.Primitives.Textual;
using Ccr.Parsing.Tokenizer;
using Ccr.Parsing.Tokenizer.Tokens.OLD;

namespace Ccr.MaterialDesign.Parsers
{
	//TODO move logical scans to a core Parser class. Make this more generic solution with helper methods common tokens etc
	public class TextualStyleParser
	{
		private TokenizerOld _tokenizer;
		private readonly string _expression;


		public TextualStyleParser(string expression)
		{
			_expression = expression;
		}


		public TextualStyle Parse()
		{
			var textualStyle = new TextualStyle
			{
				//ForegroundDescriptor = new LiteralMaterialDescriptor(Palette.Blue.P600)
			};

			var selectorExpressionParts = _expression.Split(' ');

			foreach (var selectorExpressionPart in selectorExpressionParts)
			{
				_tokenizer = new TokenizerOld(selectorExpressionPart);

				_tokenizer.SkipWhiteSpace();

				var beginFrame = _tokenizer.GetFrame();

				char c;
				if (!_tokenizer.TryRead(out c))
					throw new FormatException(
						$"Could not read from tokenizer.");

				var cl = char.ToLower(c);
				if (cl == 't')
				{
					var frame = _tokenizer.GetFrame();
					if (_tokenizer.HasMore())
						throw new FormatException(
							_tokenizer.GetExceptionRangeText(frame) +
							$"Unexpected character(s) after \'t\' fontWeight flag");

					textualStyle.SetValue(TextualStyle.FontWeightProperty, FontWeights.Thin);
				}
				else if (cl == 'l')
				{
					var frame = _tokenizer.GetFrame();
					if (_tokenizer.HasMore())
						throw new FormatException(
							_tokenizer.GetExceptionRangeText(frame) +
							$"Unexpected character(s) after \'l\' fontWeight flag");

					textualStyle.SetValue(TextualStyle.FontWeightProperty, FontWeights.Light);
				}
				else if (cl == 'm')
				{
					var frame = _tokenizer.GetFrame();
					if (_tokenizer.HasMore())
						throw new FormatException(
							_tokenizer.GetExceptionRangeText(frame) +
							$"Unexpected character(s) after \'m\' fontWeight flag");

					textualStyle.SetValue(TextualStyle.FontWeightProperty, FontWeights.Medium);
				}
				else if (cl == 'b')
				{
					var frame = _tokenizer.GetFrame();
					if (_tokenizer.HasMore())
						throw new FormatException(
							_tokenizer.GetExceptionRangeText(frame) +
							$"Unexpected character(s) after \'b\' fontWeight flag");

					textualStyle.SetValue(TextualStyle.FontWeightProperty, FontWeights.Bold);
				}
				else if (cl == 'h')
				{
					var frame = _tokenizer.GetFrame();
					if (_tokenizer.HasMore())
						throw new FormatException(
							_tokenizer.GetExceptionRangeText(frame) +
							$"Unexpected character(s) after \'h\' fontWeight flag");

					textualStyle.SetValue(TextualStyle.FontWeightProperty, FontWeights.Heavy);
				}
				else if (cl == 'o')
				{
					var frame = _tokenizer.GetFrame();
					if (_tokenizer.HasMore())
						throw new FormatException(
							_tokenizer.GetExceptionRangeText(frame) +
							$"Unexpected character(s) after \'o\' fontStyle flag");

					textualStyle.SetValue(TextualStyle.FontStyleProperty, FontStyles.Oblique);
				}
				else if (cl == 'i')
				{
					var frame = _tokenizer.GetFrame();
					if (_tokenizer.HasMore())
						throw new FormatException(
							_tokenizer.GetExceptionRangeText(frame) +
							$"Unexpected character(s) after \'i\' fontStyle flag");

					textualStyle.SetValue(TextualStyle.FontStyleProperty, FontStyles.Italic);
				}
				else if (c == '-' || cl == 'p' || cl == 'a')
				{
					//TODO use new method .GetInstance for all code behind uses of Singleton xamlconverters
					var descriptorConverter = new MaterialDescriptorConverter();
					_tokenizer.Step(-1);
					var frame = _tokenizer.GetFrame();

					var strValue = scanUntil('#', false);

					var value = descriptorConverter.ConvertFrom(strValue) as AbstractMaterialDescriptor;

					textualStyle.SetValue(TextualStyle.ForegroundDescriptorProperty, value);
				}
				// SET TEXTROTATION PROPERTY 
				else if (cl == 'r')
				{
					TextRotation textRotation;
					var frame = _tokenizer.GetFrame();

					char c3;
					if (!_tokenizer.TryRead(out c3))
						throw new FormatException(
							_tokenizer.GetExceptionRangeText(frame) +
							$"Expected rotation direction after \'r\' character. (\'r\' or \'l\').");

					var c3l = char.ToLower(c3);
					if (c3l == 'r')
					{
						_tokenizer.SkipWhiteSpace();
						var frame2 = _tokenizer.GetFrame();
						if (_tokenizer.HasMore())
							throw new FormatException(
								_tokenizer.GetExceptionRangeText(frame2) +
								$"Unexpected character(s) after rotation direction.");

						textRotation = TextRotation.Right;
					}
					else if (c3l == 'l')
					{
						_tokenizer.SkipWhiteSpace();
						var frame2 = _tokenizer.GetFrame();
						if (_tokenizer.HasMore())
							throw new FormatException(
								_tokenizer.GetExceptionRangeText(frame2) +
								$"Unexpected character(s) after rotation direction.");

						textRotation = TextRotation.Left;
					}
					else if (c3l == 'r')
					{
						_tokenizer.SkipWhiteSpace();
						var frame2 = _tokenizer.GetFrame();
						if (_tokenizer.HasMore())
							throw new FormatException(
								_tokenizer.GetExceptionRangeText(frame2) +
								$"Unexpected character(s) after rotation direction.");

						textRotation = TextRotation.None;
					}
					else
					{
						throw new FormatException(
							_tokenizer.GetExceptionRangeText(frame) +
							$"Unexpected rotation direction. Must be either \'l\', \'n\', or \'r\'.");
					}
					textualStyle.SetValue(TextualStyle.TextRotationProperty, textRotation);
				}
				else if (char.IsDigit(c) || c == '.')
				{
					_tokenizer.Step(-1);
					var numericLiteral = scanNumericLiteral();
					_tokenizer.Step(-1);
					_tokenizer.SkipWhiteSpace();

					var frame3 = _tokenizer.GetFrame();

					char c2;
					if (!_tokenizer.TryRead(out c2))
						throw new FormatException(
							_tokenizer.GetExceptionRangeText(frame3) +
							$"Expected font size unit type (\'em\' or \'%\') after relative font size numeric literal");

					var c2l = char.ToLower(c2);
					if (c2l == '%')
					{
						_tokenizer.SkipWhiteSpace();
						var frame2 = _tokenizer.GetFrame();
						if (_tokenizer.HasMore())
							throw new FormatException(
								_tokenizer.GetExceptionRangeText(frame2) +
								$"Unexpected character(s) after font size unit type");

						var numericValue = double.Parse(numericLiteral.LiteralValue) / 100;
						textualStyle.SetValue(TextualStyle.RelativeFontSizeProperty, numericValue);
					}
					else if (c2l == 'e')
					{
						char c3;
						if (!_tokenizer.TryRead(out c3))
							throw new FormatException(
								_tokenizer.GetExceptionRangeText(frame3) +
								$"Expected font size unit type (\'em\' or \'%\') after relative font size numeric literal");
						var c3l = char.ToLower(c3);
						if (c3l == 'm')
						{
							_tokenizer.SkipWhiteSpace();
							var frame2 = _tokenizer.GetFrame();
							if (_tokenizer.HasMore())
								throw new FormatException(
									_tokenizer.GetExceptionRangeText(frame2) +
									$"Unexpected character(s) after font size unit type");
							var numericValue = double.Parse(numericLiteral.LiteralValue);
							textualStyle.SetValue(TextualStyle.RelativeFontSizeProperty, numericValue);
						}
						else
						{
							throw new FormatException(
								_tokenizer.GetExceptionRangeText(frame3) +
								$"Unexpected font size unit type. Must be either \'em\' or \'%\'");
						}
					}
					else
					{
						throw new FormatException(
							_tokenizer.GetExceptionRangeText(frame3) +
							$"Unexpected unit type. Must be either \'em\' or \'%\'");
					}

					_tokenizer.SkipWhiteSpace();
					var frame = _tokenizer.GetFrame();


					if (_tokenizer.Step(1) && _tokenizer.HasMore())
						throw new FormatException(
							_tokenizer.GetExceptionRangeText(frame) +
							$"Unexpected character(s).");

				}
				else
				{
					throw new FormatException(
						_tokenizer.GetExceptionRangeText(beginFrame) +
						$"Invalid character(s) in textualStyle expression.");
				}
			}
			return textualStyle;
		}

		//TODO int/no decimal option?
		private NumberToken scanNumericLiteral()
		{
			var text = "";

			var hasDecimal = false;
			char c;
			while (_tokenizer.TryRead(out c))
			{
				if (c == '.')
				{
					if (hasDecimal)
						throw new FormatException(
							$"Numeric literal cannot contain two decimals.");

					hasDecimal = true;
					text += c;
				}
				else if (char.IsDigit(c))
				{
					text += c;
				}
				else if (char.IsWhiteSpace(c) || c == '\0')
				{
					break;
				}
				else
				{
					break;
					//throw new FormatException("Invalid character in numeric literal.");
				}
			}
			return new NumberToken(text);
		}


		private string scanUntil(char stopChar, bool throwIfNotFound = true)
		{
			var frame = _tokenizer.GetFrame();
			var text = "";
			char c;
			while (_tokenizer.TryRead(out c))
			{
				if (c == stopChar || c == '\0')
				{
					_tokenizer.Step(-1);
					return text;
				}
				text += c;
			}
			if (throwIfNotFound)
				throw new FormatException(
					$"\"{_tokenizer.SourceText}\" (Index {frame.Index} - {_tokenizer.CurrentIndex}): " +
					$"StopChar \'{stopChar}\' was not found.");

			return text;
		}
	}
}
