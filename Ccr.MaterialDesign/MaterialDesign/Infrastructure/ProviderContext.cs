namespace Ccr.MaterialDesign.Infrastructure
{
  public class ProviderContext
  {
    public int CycleLength { get; }


    public ProviderContext(
      int cycleLength)
    {
      CycleLength = cycleLength;
    }
  }
}
