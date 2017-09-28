using System;
using JetBrains.Annotations;

namespace Ccr.Parsing.Tokenizer.Tokens
{
	[AttributeUsage(AttributeTargets.Class)]
	public class TokenQualifierAttribute
		: Attribute
	{
		public string Regex { get; }

		public TokenQualifierAttribute(
			[RegexPattern] string regex)
		{
			Regex = regex;
		}
	}
}
