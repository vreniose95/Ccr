using System;
using System.Globalization;

namespace Ccr.Std.Core.Extensions
{
  public static class StringExtensions
  {
    /// <inheritdoc cref="string.IsNullOrEmpty"/>
    public static bool IsNullOrEmpty(
      this string @this)
    {
      return string.IsNullOrEmpty(@this);
    }

    /// <inheritdoc cref="string.IsNullOrWhiteSpace"/>
    /// <remarks>
    ///   Extension method for post-
    /// </remarks>
    public static bool IsNullOrWhiteSpace(
      this string @this)
    {
      return string.IsNullOrWhiteSpace(@this);
    }

    public static string Surround(
      this string @this,
      char c)
    {
      return $"{c}{@this}{c}";
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
      return @this.Surround('\"');
    }




    public static bool IsDateTime(
      this string @this,
      string dateFormat)
    {
      return DateTime.TryParseExact(
        @this,
        dateFormat,
        CultureInfo.InvariantCulture,
        DateTimeStyles.None,
        out _);
    }



    public static Int16 ToInt16(
      this string @this)
    {
      if (!Int16.TryParse(
        @this,
        out var value))
      {
        throw new FormatException(
          $"Cannot convert the string parameter {@this.Quote()} " +
          $"to the type {typeof(Int16).Name.SQuote()}.");
      }
      return value;
    }

    public static Int32 ToInt32(
      this string @this)
    {
      if (!Int32.TryParse(
        @this,
        out var value))
      {
        throw new FormatException(
          $"Cannot convert the string parameter {@this.Quote()} " +
          $"to the type {typeof(Int32).Name.SQuote()}.");
      }
      return value;
    }

    public static Int64 ToInt64(
      this string @this)
    {
      if (!Int64.TryParse(
        @this,
        out var value))
      {
        throw new FormatException(
          $"Cannot convert the string parameter {@this.Quote()} " +
          $"to the type {typeof(Int64).Name.SQuote()}.");
      }
      return value;
    }

    public static Decimal ToDecimal(
      this string @this)
    {
      if (!Decimal.TryParse(
        @this,
        out var value))
      {
        throw new FormatException(
          $"Cannot convert the string parameter {@this.Quote()} " +
          $"to the type {typeof(Decimal).Name.SQuote()}.");
      }
      return value;
    }


  }
}
