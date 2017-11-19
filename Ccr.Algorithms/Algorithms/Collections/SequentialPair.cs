namespace Ccr.Algorithms.Collections
{
  public class SequentialPair<TValue>
    : SequentialSet<TValue>
  {
    [SequentialSetValue(0)]
    public TValue Value1 { get; }

    [SequentialSetValue(1)]
    public TValue Value2 { get; }
    

    public SequentialPair(
      TValue value1,
      TValue value2)
    {
      Value1 = value1;
      Value2 = value2;
    }
  }
}
