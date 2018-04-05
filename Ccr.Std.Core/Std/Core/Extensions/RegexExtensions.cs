using System;
using System.Text.RegularExpressions;
using JetBrains.Annotations;

namespace Ccr.Std.Core.Extensions
{
  public static class RegexExtensions
  {
    public static Int16 Extract(
      this Match @this,
      [NotNull] string groupName)
    {
      var strValue = @this.Groups[groupName].Value;
      
      if (!Int16.TryParse(strValue, out var value))
        throw new FormatException(
          $"Cannot parse {typeof(Int16).Name.SQuote()} object from " +
          $"the string value {strValue.Quote()}.");

      return value;
    }

    //public static TValue Extract<TValue>(
    //  this Match @this,
    //  [NotNull] string groupName)
    //    where TValue
    //      : struct
    //{
    //  //TypeReference.GetBuiltInTypeInfo()
    //  var strValue = @this.Groups[groupName].Value;

    //  if (!Int16.TryParse(strValue, out var value))
    //    throw new FormatException(
    //      $"Cannot parse {typeof(TValue).Name.SQuote()} object from " +
    //      $"the string value {strValue.Quote()}.");

    //  return value;
    //}




    //[AttributeUsage(AttributeTargets.GenericParameter)]
    //public class IntegralTypeAttribute
    //  : Attribute
    //{
    //}

    //public static class IntegralRangeHelper
    //{
    //  public static IntegralRangeBase<TValue> CreateRange<
    //    [IntegralType] TValue>(
    //      TValue min, 
    //      TValue max)
    //  {
    //   // ...
    //  }
    //}

  }
}
