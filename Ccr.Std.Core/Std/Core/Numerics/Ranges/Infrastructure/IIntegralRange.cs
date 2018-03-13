using System;
// ReSharper disable BuiltInTypeReferenceStyle
namespace Ccr.Std.Core.Numerics.Ranges.Infrastructure
{
  public interface IIntegralRange
  {
    Int64 Minimum { get; }

    UInt64 Maximum { get; }
  }
}
