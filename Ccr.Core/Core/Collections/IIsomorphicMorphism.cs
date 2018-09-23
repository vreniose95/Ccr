namespace Ccr.Core.Collections
{
	public interface IIsomorphicMorphism<TA, TB>
		: IMorphism<TA, TB>
	{
		IIsomorphicMorphism<TB, TA> IsomorphicInverse { get; }

		TA EvaluateInverse(TB b);
	}
}