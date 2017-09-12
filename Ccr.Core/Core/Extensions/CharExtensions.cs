namespace Ccr.Core.Extensions
{
	public static class CharExtensions
	{
		/// <summary>
		/// Indicates whether the specified Unicode character is categorized as a decimal digit.
		/// </summary>
		/// <remarks>
		/// Extension method mapping to the static method <see cref="M:Char.IsDigit(Char)"/>.
		/// </remarks>
		/// <param name="this">
		/// The Unicode character to evaluate. 
		/// </param>
		/// <returns>
		/// true if <paramref name="this"/> is a decimal digit; otherwise, false.
		/// </returns>
		public static bool IsDigit(this char @this)
		{
			return char.IsDigit(@this);
		}

		/// <summary>
		/// Indicates whether the specified Unicode character is categorized as a Unicode letter.
		/// </summary>
		/// <remarks>
		/// Extension method mapping to the static method <see cref="M:Char.IsLetter(Char)"/>.
		/// </remarks>
		/// <param name="this">
		/// The Unicode character to evaluate. 
		/// </param>
		/// <returns>
		/// true if <paramref name="this"/> is a letter; otherwise, false.
		/// </returns>
		public static bool IsLetter(this char @this)
		{
			return char.IsLetter(@this);
		}

		/// <summary>
		/// Indicates whether the specified Unicode character is categorized as white space.
		/// </summary>
		/// <remarks>
		/// Extension method mapping to the static method <see cref="M:Char.IsWhiteSpace(Char)"/>.
		/// </remarks>
		/// <param name="this">
		/// The Unicode character to evaluate. 
		/// </param>
		/// <returns>
		/// true if <paramref name="this" /> is white space; otherwise, false.
		/// </returns>
		public static bool IsWhiteSpace(this char @this)
		{
			return char.IsWhiteSpace(@this);
		}

		/// <summary>
		/// Indicates whether the specified Unicode character is categorized as an uppercase letter.
		/// </summary>
		/// <remarks>
		/// Extension method mapping to the static method <see cref="M:Char.IsUpper(Char)"/>.
		/// </remarks>
		/// <param name="this">
		/// The Unicode character to evaluate. 
		/// </param>
		/// <returns>
		/// true if <paramref name="this" /> is an uppercase letter; otherwise, false.
		/// </returns>
		public static bool IsUpper(this char @this) => char.IsUpper(@this);

		/// <summary>
		/// Indicates whether the specified Unicode character is categorized as a lowercase letter.
		/// </summary>
		/// <remarks>
		/// Extension method mapping to the static method <see cref="M:Char.IsLower(Char)"/>.
		/// </remarks>
		/// <param name="this">
		/// The Unicode character to evaluate. 
		/// </param>
		/// <returns>
		/// true if <paramref name="this"/> is a lowercase letter; otherwise, false.
		/// </returns>
		public static bool IsLower(this char @this)
		{
			return char.IsLower(@this);
		}
		/// <summary>
		/// Indicates whether the specified Unicode character is categorized as a punctuation mark.
		/// </summary>
		/// <remarks>
		/// Extension method mapping to the static method <see cref="M:Char.IsPunctuation(Char)"/>.
		/// </remarks>
		/// <param name="this">
		/// The Unicode character to evaluate. 
		/// </param>
		/// <returns>
		/// true if <paramref name="this"/> is a punctuation mark; otherwise, false.
		/// </returns>
		public static bool IsPunctuation(this char @this)
		{
			return char.IsPunctuation(@this);
		}

		/// <summary>
		/// Indicates whether the specified Unicode character is categorized as a letter or a decimal digit.
		/// </summary>
		/// <remarks>
		/// Extension method mapping to the static method <see cref="M:Char.IsLetterOrDigit(Char)"/>.
		/// </remarks>
		/// <param name="this">
		/// The Unicode character to evaluate. 
		/// </param>
		/// <returns>
		/// true if <paramref name="this"/> is a letter or a decimal digit; otherwise, false.
		/// </returns>
		public static bool IsLetterOrDigit(this char @this)
		{
			return char.IsLetterOrDigit(@this);
		}

	}
}
