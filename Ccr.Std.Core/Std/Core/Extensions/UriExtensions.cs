using System;

namespace Ccr.Std.Core.Extensions
{
  public static class UriExtensions
  {
    public static Uri RequireRelative(
      this Uri @this)
    {
      if (@this.IsAbsoluteUri)
        throw new NotSupportedException(
          $"Cannot use the Uri (value: {@this.OriginalString.SQuote()}) on the current " +
          $"operation because a Relative Uri is required.");

      return @this;
    }

    public static Uri RequireAbsolute(
      this Uri @this)
    {
      if (!@this.IsAbsoluteUri)
        throw new NotSupportedException(
          $"Cannot use the Uri (value: {@this.OriginalString.SQuote()}) on the current " +
          $"operation because an Absolute Uri is required.");

      return @this;
    }
  }
}
