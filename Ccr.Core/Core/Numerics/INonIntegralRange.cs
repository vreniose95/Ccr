namespace Ccr.Core.Numerics
{
	public interface INonIntegralRange
		: INumericRange
	{
		decimal Minimum { get; }

		decimal Maximum { get; }
	}
}
