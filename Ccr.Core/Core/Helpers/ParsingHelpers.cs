using System;
using System.Collections.Generic;
using System.Linq;
using Ccr.Core.Extensions;
using JetBrains.Annotations;

namespace Ccr.Core.Helpers
{
  public static class ParsingHelpers
  {
    internal abstract class ParseFunction
    {
      internal abstract Type TargetType { get; }

      internal abstract object ParseBase(
        string strValue);

      internal static ParseFunction<TResult> FromFunc<TResult>(
        Func<string, TResult> parseFunc)
      {
        return new ParseFunction<TResult>(
          parseFunc);
      }
    }

    internal class ParseFunction<TResult>
      : ParseFunction
    {
      private readonly Func<string, TResult> _parseFunc;

      internal override Type TargetType => typeof(TResult);


      internal ParseFunction(
        Func<string, TResult> parseFunc)
      {
        _parseFunc = parseFunc;
      }


      internal override object ParseBase(
        string strValue)
      {
        return Parse(
          strValue);
      }

      internal TResult Parse(
        string strValue)
      {
        return _parseFunc(
          strValue);
      }
    }

    private static readonly IList<ParseFunction> _parseFunctions
      = new List<ParseFunction>
      {
        ParseFunction.FromFunc(Boolean.Parse),

        ParseFunction.FromFunc(Byte.Parse),
        ParseFunction.FromFunc(Decimal.Parse),
        ParseFunction.FromFunc(Double.Parse),
        ParseFunction.FromFunc(Int16.Parse),
        ParseFunction.FromFunc(Int32.Parse),
        ParseFunction.FromFunc(Int64.Parse),
        ParseFunction.FromFunc(SByte.Parse),
        ParseFunction.FromFunc(Single.Parse),
        ParseFunction.FromFunc(UInt16.Parse),
        ParseFunction.FromFunc(UInt32.Parse),
        ParseFunction.FromFunc(UInt64.Parse)
      };

    private static IDictionary<Type, Func<string, object>> _parseFunctionMapping
    {
      get => _parseFunctions.ToDictionary(
        t => t.TargetType,
        t => (Func<string, object>) t.ParseBase);
    }


    public static object RuntimeParse(
      [NotNull] string strValue,
      [NotNull] Type type)
    {
      strValue.IsNotNull(nameof(strValue));
      type.IsNotNull(nameof(type));

      if (!_parseFunctionMapping.TryGetValue(
        type,
        out var _parseFunc))
        throw new NotSupportedException(
          $"The type {type.FormatName().SQuote()} does not have a mapped parse function.");

      return _parseFunc(
        strValue);
    }

    public static TResult Parse<TResult>(
      [NotNull] string strValue)
    {
      strValue.IsNotNull(nameof(strValue));

      var value = RuntimeParse(
        strValue,
        typeof(TResult));

      return value.As<TResult>();
    }
  }
}