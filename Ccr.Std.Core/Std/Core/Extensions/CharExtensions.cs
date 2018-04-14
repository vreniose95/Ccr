namespace Ccr.Std.Core.Extensions
{
  /// <summary>
  ///   Extension methods for <see cref="char"/> subjects.
  /// </summary>
  public static class CharExtensions
	{
		/// <inheritdoc cref="char.IsDigit(char)"/>
		public static bool IsDigit(
		  this char @this)
		{
			return char.IsDigit(
			  @this);
		}

    /// <inheritdoc cref="char.IsLetter(char)"/>
    public static bool IsLetter(
		  this char @this)
		{
			return char.IsLetter(
			  @this);
		}

    /// <inheritdoc cref="char.IsWhiteSpace(char)"/>
    public static bool IsWhiteSpace(
      this char @this)
		{
			return char.IsWhiteSpace(
			  @this);
		}

    /// <inheritdoc cref="char.IsUpper(char)"/>
    public static bool IsUpper(
      this char @this)
	  {
	    return char.IsUpper(
	      @this);
    }

    /// <inheritdoc cref="char.IsLower(char)"/>
    public static bool IsLower(
      this char @this)
		{
			return char.IsLower(
			  @this);
		}

    /// <inheritdoc cref="char.IsPunctuation(char)"/>
    public static bool IsPunctuation(
      this char @this)
		{
			return char.IsPunctuation(
			  @this);
		}

    /// <inheritdoc cref="char.IsLetterOrDigit(char)"/>
    public static bool IsLetterOrDigit(
      this char @this)
		{
			return char.IsLetterOrDigit(
			  @this);
		}

	}
}
