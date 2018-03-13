namespace Ccr.Std.Core.Numerics.Ranges.Infrastructure
{
  public interface INonIntegralRange
    : INumericRange
  {
    decimal Minimum { get; }

    decimal Maximum { get; }
  }
}
