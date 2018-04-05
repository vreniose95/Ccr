namespace Ccr.Std.Core.Numerics.Infrastructure
{
  public interface INonIntegralRange
    : INumericRange
  {
    decimal Minimum { get; }

    decimal Maximum { get; }
  }
}
