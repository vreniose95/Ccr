using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Ccr.Core.Extensions.NumericExtensions;
using JetBrains.Annotations;

namespace Ccr.Core.Extensions
{


  //[AttributeUsage(AttributeTargets.Property)]
  //public class OrderedSetValueAttribute
  //  : Attribute
  //{

  //}

  //public abstract class OrderedSetBase<TValue>
  //{
  //  private static IDictionary<Type, TValue[]> _valuesCache;

  //  public IReadOnlyList<TValue> Values
  //  {
  //    get
  //    {
        
  //    }
  //  }

  //  private static IReadOnlyList<TValue> _reflectValuesImpl(
  //    Type orderedSetType)
  //  {
  //    var members = orderedSetType.Ref 
  //  }

  //  protected abstract int SetSize { get; }


  //  public TValue this[int index]
  //  {
  //    get
  //    {
  //      if (index.IsNotWithin((0, _values.Length - 1)))
  //        throw new IndexOutOfRangeException(
  //          $"The index \'{index}\' is outside the bounds of the OrderedSet type " +
  //          $"{GetType().Name.SQuote()}.");

  //      return _values[index];
  //    }
  //  }

  //  protected OrderedSetBase(
  //    params TValue[] values)
  //  {
  //    VerifyArraySize(values);
  //    _values = values;
  //  }

  //  protected void VerifyArraySize(
  //    TValue[] values)
  //  {
  //    if (values.Length != SetSize)
  //      throw new ArgumentException(
  //        $"The \'values\' argument array length must be equal to \'{SetSize}\' " +
  //        $"for use with the {GetType().Name.SQuote()} type.",
  //        nameof(values));
  //  }
  //}


  //public class OrderedPair<TValue>
  //  : IReadOnlyList<TValue>
  //{
  //  [OrderedSetValue]
  //  public TValue Value1 { get; }

  //  [OrderedSetValue]
  //  public TValue Value2 { get; }

  //  public int Count => 2;


  //  public OrderedPair(
  //    TValue value1,
  //    TValue value2)
  //  {
  //    Value1 = value1;
  //    Value2 = value2;
  //  }

  //  //public TValue this[int index]
  //  //{
  //  //  get
  //  //  {
  //  //    switch (index)
  //  //    {
  //  //      case
  //  //    }
  //  //  }
  //  //}

  //  //public OrderedPair(
  //  //  TValue[] values) : base(
  //  //    values)
  //  //{
  //  //}

  //  //public static explicit operator TValue[] (
  //  //  OrderedPair<TValue> @this)
  //  //{
  //  //  return @this._values;
  //  //}
  //}

  //public sealed class OrderedTriple<TValue>
  //  : OrderedSetBase<TValue>
  //{
  //  public TValue Value1 { get; }

  //  public TValue Value2 { get; }

  //  public TValue Value3 { get; }

  //  protected override int SetSize => 3;


  //  public OrderedTriple(
  //    TValue value1,
  //    TValue value2,
  //    TValue value3) : base(
  //      value1,
  //      value2,
  //      value3)
  //  {
  //    Value1 = value1;
  //    Value2 = value2;
  //    Value3 = value3;
  //  }

  //  public OrderedTriple(
  //    TValue[] values) : base(
  //      values)
  //  {
  //  }


  //  public static explicit operator TValue[] (
  //    OrderedTriple<TValue> @this)
  //  {
  //    return @this._values;
  //  }
  //}

  //public sealed class OrderedQuad<TValue>
  //  : OrderedSetBase<TValue>
  //{
  //  public TValue Value1 { get; }

  //  public TValue Value2 { get; }

  //  public TValue Value3 { get; }

  //  public TValue Value4 { get; }

  //  protected override int SetSize => 4;


  //  public OrderedQuad(
  //    TValue value1,
  //    TValue value2,
  //    TValue value3,
  //    TValue value4) : base(
  //      value1,
  //      value2,
  //      value3,
  //      value4)
  //  {
  //    Value1 = value1;
  //    Value2 = value2;
  //    Value3 = value3;
  //    Value4 = value4;
  //  }

  //  public OrderedQuad(
  //    TValue[] values) : base(
  //      values)
  //  {
  //  }

  //  public static explicit operator TValue[] (
  //    OrderedQuad<TValue> @this)
  //  {
  //    return @this._values;
  //  }
  //}



  public static class LinqExtensions
  {
    public static void ForEach<TValue>(
      [NotNull] this IEnumerable<TValue> @this,
      [NotNull] Action<TValue> action)
    {
      @this.IsNotNull(nameof(@this));
      action.IsNotNull(nameof(action));

      foreach (var item in @this)
        action(item);
    }

    //public static TValue0 
    //  .W indowed<TValue>(
    //  IEnumerable<TValue> source,
    //  )
  }
}
