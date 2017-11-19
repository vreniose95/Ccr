using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Ccr.Core.Extensions;
using Ccr.Core.Extensions.NumericExtensions;

namespace Ccr.Algorithms.Collections
{
  public static class SequentialSetFactory
  {
    public static SequentialSet<TValue> BuildBase<TValue>(
      params TValue[] values)
    {
      if (values.Length.IsNotWithin((2, 4)))
        throw new ArgumentOutOfRangeException(
          $"value out of range 2-4 inclusive");

      switch (values.Length)
      {
        case 2:
          return Build(
            values[0],
            values[1]);
        case 3:
          return Build(
            values[0],
            values[1],
            values[2]);
        case 4:
          return Build(
            values[0],
            values[1],
            values[2],
            values[3]);
        default:
          throw new IndexOutOfRangeException(
            $"Index out of range.");
      }
    }


    public static SequentialPair<TValue> Build<TValue>(
      TValue value1,
      TValue value2)
    {
      return new SequentialPair<TValue>(
        value1,
        value2);
    }

    public static SequentialTriple<TValue> Build<TValue>(
      TValue value1,
      TValue value2,
      TValue value3)
    {
      return new SequentialTriple<TValue>(
        value1,
        value2,
        value3);
    }

    public static SequentialQuad<TValue> Build<TValue>(
      TValue value1,
      TValue value2,
      TValue value3,
      TValue value4)
    {
      return new SequentialQuad<TValue>(
        value1,
        value2,
        value3,
        value4);
    }
  }
  public abstract class SequentialSet
  {
    private static readonly IDictionary<Type, SequentialSetMemberResolver> _memberResolverMap
      = new Dictionary<Type, SequentialSetMemberResolver>();


    protected object[] ValueArrayBase
    {
      get
      {
        var sequentialSetType = GetType();

        if (!_memberResolverMap.TryGetValue(sequentialSetType, out var memberResolver))
        {
          memberResolver = new SequentialSetMemberResolver(sequentialSetType);
          _memberResolverMap.Add(sequentialSetType, memberResolver);
        }
        return memberResolver.ExtractValueArrayBase(this);
      }
    }

    //public static TSequentialSet BuildSet<TValue, TSequentialSet>(
    //  params TValue[] values)
    //    where TSequentialSet
    //      : SequentialPair<TValue>
    //{

    //}
  }

  public abstract class SequentialSet<TValue>
    : SequentialSet,
      IReadOnlyList<TValue>
  {
    private TValue[] _valueArrayCache;

    protected IReadOnlyList<TValue> ValueArray
    {
      get => _valueArrayCache
             ?? (_valueArrayCache = ValueArrayBase.Cast<TValue>().ToArray());
    }

    public int Count
    {
      get => ValueArray.Count;
    }

    public TValue this[int index]
    {
      get
      {
        if (index.IsNotWithin((0, Count - 1)))
          throw new IndexOutOfRangeException(
            $"The index \'{index}\' is outside the bounds of the SequentialSet type " +
            $"{GetType().Name.SQuote()}.");

        return ValueArray[index];
      }
    }

    public IEnumerator<TValue> GetEnumerator()
    {
      return ValueArray.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }
  }
}
