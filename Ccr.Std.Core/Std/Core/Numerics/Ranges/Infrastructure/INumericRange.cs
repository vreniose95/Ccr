namespace Ccr.Std.Core.Numerics.Ranges.Infrastructure
{
  public interface INumericRange
  {
    object MinimumBase { get; }

    object MaximumBase { get; }


    bool IsWithinBase(
      object value,
      EndpointExclusivity exclusivity);

    bool IsNotWithinBase(
      object value,
      EndpointExclusivity exclusivity);


    object ConstrainBase(
      object value);
  }
}
