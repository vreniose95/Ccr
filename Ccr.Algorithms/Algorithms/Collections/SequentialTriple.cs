namespace Ccr.Algorithms.Collections
{
  public class SequentialTriple<TValue>
    : SequentialPair<TValue>
  {
    [SequentialSetValue(2)]
    public TValue Value3 { get; }


    public SequentialTriple(
      TValue value1,
      TValue value2,
      TValue value3) : base(
      value1,
      value2)
    {
      Value3 = value3;
    }

    public SequentialQuad<TValue> PrependValue(
      TValue firstValue)
    {
      return new SequentialQuad<TValue>(
        firstValue,
        Value1,
        Value2,
        Value3);
    }
    public SequentialQuad<TValue> AppendValue(
      TValue lastValue)
    {
      return new SequentialQuad<TValue>(
        Value1,
        Value2,
        Value3,
        lastValue);
    }

  }
}