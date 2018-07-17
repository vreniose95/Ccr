// ReSharper disable BuiltInTypeReferenceStyle
namespace Ccr.Std.Core.Numerics.Infrastructure
{
  public interface IIntegralRange
    : INumericRange
  {
    long Minimum { get; }

    ulong Maximum { get; }
  }
}
