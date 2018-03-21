using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using JetBrains.Annotations;
using static JetBrains.Annotations.AssertionConditionType;

namespace Ccr.Core.Extensions
{
	public static class StringExtensions
	{
	  public static bool IsNullOrWhiteSpace(
	    this string @this)
	  {
	    return string.IsNullOrWhiteSpace(@this);
	  }

		/// <summary>
		/// Assertion method that ensures that <paramref name="this"/> is not null
		/// </summary>
		/// <param name="this">
		/// The object in which to ensure non-nullability upon
		/// </param>
		[ContractAnnotation("this:null => true"), AssertionMethod]
		public static bool IsNullOrEmptyEx(
			[AssertionCondition(IS_NULL)] this string @this)
		{
			return string.IsNullOrEmpty(@this);
		}

		/// <summary>
		/// Assertion method that ensures that <paramref name="this"/> is not null
		/// </summary>
		/// <param name="this">
		/// The object in which to ensure non-nullability upon
		/// </param>
		[ContractAnnotation("this:null => false"), AssertionMethod]
		public static bool IsNotNullOrEmptyEx(
			[AssertionCondition(IS_NOT_NULL)] this string @this)
		{
			return !string.IsNullOrEmpty(@this);
		}

		//IsNotNullOrEmptyEx
		public static string Surround(
	    this string @this,
	    char c)
	  {
	   return $"{c}{@this}{c}";
    }

    public static string SQuote(
      this char @this)
	  {
	    return @this.ToString().Surround('\''); 
	  }

	  public static string Quote(
	    this char @this)
	  {
      return @this.ToString().Surround('\"');
    }

	  public static string SQuote(
	    this string @this)
	  {
	    return @this.Surround('\'');
	  }

	  public static string Quote(
	    this string @this)
	  {
	    return @this.Surround('\"');
	  }



    public static string Limit(
      this string @this, 
      int length)
		{
		  return @this.Length > length 
        ? @this.Substring(0, length) 
        : @this;
		}

	  private static TextInfo _textInfo;
	  internal static TextInfo TextInfo
	  {
	    get => _textInfo
	           ?? (_textInfo = new CultureInfo("en-US", false).TextInfo);
	  }

	  public static string ToTitleCase(
      this string @this)
	  {
	    return TextInfo.ToTitleCase(@this);

	  }

		public static bool ContainsCaseInsensitive(
      this string @this, 
      string toCheck)
		{
			return @this
        .IndexOf(toCheck, StringComparison.OrdinalIgnoreCase) >= 0;
		}

		public static bool IsExclusivelyHex(
      this string source)
		{
			return Regex.IsMatch(
        source, 
        @"\A\b[0-9a-fA-F]+\b\Z");
		}
		public static bool IsCStyleCompilerHexLiteral(
      this string source)
		{
			return Regex.IsMatch(
        source, 
        @"\A\b(0[xX])?[0-9a-fA-F]+\b\Z");
		}//                                  

		// definition of a valid C# identifier: http://msdn.microsoft.com/en-us/library/aa664670(v=vs.71).aspx
		/// <summary>
		/// Information on the standards of how the language specificiation 
		/// consitutes a valid C# member identifier.
		/// </summary>
		// ReSharper disable once RedundantArrayCreationExpression
		private static readonly List<string> _csharpLanguageKeywords 
      = new List<string>
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
			if (@this.IsNullOrEmptyEx())
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

		/// <summary>
		///		Converts the specified input string to Pascal Case.
		/// </summary>
		/// <param name="this">
		///		The subject <see cref="string"/> in which to convert.
		/// </param> c
		/// <returns>
		///		The value of the provided <paramref name="this"/> converted to Pascal Case.
		/// </returns>
		public static string ToPascalCase(
			[NotNull] this string @this)
		{
			@this.IsNotNull(nameof(@this));

			return Regex.Replace(
				@this, 
				"(?:^|_)(.)", 
				match => match
					.Groups[1]
					.Value
					.ToUpper());
		}

		/// <summary>
		///		Converts the specified input string to Camel Case.
		/// </summary>
		/// <param name="this">
		///		The subject <see cref="string"/> in which to convert.
		/// </param>
		/// <returns>
		/// 	The value of the provided <paramref name="this"/> converted to Camel Case.
		/// </returns>
		public static string ToCamelCase(
			[NotNull] this string @this)
		{
			@this.IsNotNull(nameof(@this));

			var pascalCase = @this.ToPascalCase();
			return pascalCase.Substring(0, 1).ToLower() + 
				pascalCase.Substring(1);
		}

		/// <summary>
		///		Separates the input words with underscore.
		/// </summary>
		/// <param name="this">
		///		The subject <see cref="string"/> in which to convert.
		/// </param>
		/// <returns>
		/// 	The provided <paramref name="this"/> with the words separated by underscores.
		/// </returns>
		public static string Underscore(
			[NotNull] this string @this)
		{
			@this.IsNotNull(nameof(@this));

			return
				Regex.Replace(
					Regex.Replace(
						Regex.Replace(
							@this, "([A-Z]+)([A-Z][a-z])", "$1_$2"), 
						"([a-z\\d])([A-Z])", "$1_$2"), 
					"[-\\s]", "_")
				.ToLower();
		}
	}
}
