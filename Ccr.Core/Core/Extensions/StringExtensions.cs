using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Ccr.Core.Extensions
{
	public static class StringExtensions
	{
		public static bool IsNullOrWhiteSpace(this string @this) => string.IsNullOrWhiteSpace(@this);

		public static bool IsNullOrEmpty(this string @this) => string.IsNullOrEmpty(@this);



		public static string SQuote(this string @this) => @this.Surround('\'');

		public static string Quote(this string @this) => @this.Surround('\"');

		public static string Surround(this string @this, char c) => $"{c}{@this}{c}";


		public static string Limit(this string @this, int length)
		{
			if (@this.Length > length)
				return @this.Substring(0, length);
			return @this;
		}

		public static string ToTitleCase(this string i)
		{
			var textInfo = new CultureInfo("en-US", false).TextInfo;
			return textInfo.ToTitleCase(i.ToLower());
		}

		public static bool ContainsCaseInsensitive(this string source, string toCheck)
		{
			return source.IndexOf(toCheck, StringComparison.OrdinalIgnoreCase) >= 0;
		}

		public static bool IsExclusivelyHex(this string source)
		{
			return Regex.IsMatch(source, @"\A\b[0-9a-fA-F]+\b\Z");
		}
		public static bool IsCStyleCompilerHexLiteral(this string source)
		{
			return Regex.IsMatch(source, @"\A\b(0[xX])?[0-9a-fA-F]+\b\Z");
		}//

		// definition of a valid C# identifier: http://msdn.microsoft.com/en-us/library/aa664670(v=vs.71).aspx
		/// <summary>
		/// Information on the standards of how the language specificiation 
		/// consitutes a valid C# meember identifier.
		/// </summary>
		// ReSharper disable once RedundantArrayCreationExpression
		private static readonly List<string> _csharpLanguageKeywords = new List<string>
		{
			"abstract",  "event",      "new",        "struct",
			"as",        "explicit",   "null",       "switch",
			"base",      "extern",     "object",     "this",
			"bool",      "false",      "operator",   "throw",
			"breal",     "finally",    "out",        "true",
			"byte",      "fixed",      "override",   "try",
			"case",      "float",      "params",     "typeof",
			"catch",     "for",        "private",    "uint",
			"char",      "foreach",    "protected",  "ulong",
			"checked",   "goto",       "public",     "unchekeced",
			"class",     "if",         "readonly",   "unsafe",
			"const",     "implicit",   "ref",        "ushort",
			"continue",  "in",         "return",     "using",
			"decimal",   "int",        "sbyte",      "virtual",
			"default",   "interface",  "sealed",     "volatile",
			"delegate",  "internal",   "short",      "void",
			"do",        "is",         "sizeof",     "while",
			"double",    "lock",       "stackalloc",
			"else",      "long",       "static",
			"enum",      "namespace",  "string"
		};


		private const string formattingCharacter = @"\p{Cf}";
		private const string connectingCharacter = @"\p{Pc}";
		private const string decimalDigitCharacter = @"\p{Nd}";
		private const string combiningCharacter = @"\p{Mn}|\p{Mc}";
		private const string letterCharacter = @"\p{Lu}|\p{Ll}|\p{Lt}|\p{Lm}|\p{Lo}|\p{Nl}";

		private const string identifierPartCharacter =
			letterCharacter + "|" +
			decimalDigitCharacter + "|" +
			connectingCharacter + "|" +
			combiningCharacter + "|" +
			formattingCharacter;


		private const string identifierPartCharacters =
			"(" + identifierPartCharacter + ")";

		private const string identifierStartCharacter =
			"(" + letterCharacter + "|_)";

		private const string identifierOrKeyword =
			identifierStartCharacter + "(" + identifierPartCharacters + ")*";



		public static bool IsValidCSharpIdentifier(
			this string @this)
		{
			if (@this.IsNullOrEmpty())
				return false;

			var validIdentifierRegex = new Regex(
				$"^{identifierOrKeyword}$",
				RegexOptions.Compiled);

			var normalizedIdentifier = @this.Normalize();

			if (validIdentifierRegex.IsMatch(normalizedIdentifier) &&
				!_csharpLanguageKeywords.Contains(normalizedIdentifier))
				return true;

			return normalizedIdentifier.StartsWith("@") &&
				validIdentifierRegex.IsMatch(
					normalizedIdentifier.Substring(1));
		}

		//public static string ToCommaSeparatedList(
		//		this object[] series,
		//		CoordinatingConjunction coordinatingConjunction = CoordinatingConjunction.None)
		//{
		//	var stringBuilder = new StringBuilder();

		//	var seriesLength = series.Length;
		//	for (var i = 0; i < seriesLength - 2; i++)
		//	{
		//		stringBuilder.Append(series[i]);
		//		stringBuilder.Append(", ");
		//	}
		//	stringBuilder.Append(series[seriesLength - 1]);
		//	return stringBuilder.ToString();
		//}

	}
}
