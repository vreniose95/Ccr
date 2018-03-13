namespace Ccr.Core.Numerics
{
  public interface IIntegralRange
    : INumericRange
  {
    long Minimum { get; }

    ulong Maximum { get; }
  }
}
