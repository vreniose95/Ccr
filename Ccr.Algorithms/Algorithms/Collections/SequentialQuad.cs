using System;

namespace Ccr.Algorithms.Collections
{
  public class SequentialQuad<TValue>
    : SequentialTriple<TValue>
  {
    [SequentialSetValue(3)]
    public TValue Value4 { get; }


    public SequentialQuad(
      TValue value1,
      TValue value2,
      TValue value3,
      TValue value4) : base(
        value1,
        value2,
        value3)
    {
      Value4 = value4;
    }

    public SequentialPair<TValue> PairwiseIndex(
      int index)
    {
      if(index >= ValueArray.Count - 1)
        throw new IndexOutOfRangeException();

      return new SequentialPair<TValue>(
        ValueArray[index],
        ValueArray[index + 1]);
    }
  }
}