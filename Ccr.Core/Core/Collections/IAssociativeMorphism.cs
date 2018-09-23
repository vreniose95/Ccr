namespace Ccr.Core.Collections
{
	public interface IAssociativeMorphism<TA, TB>
		: IIsomorphicMorphism<TA, TB>
	{
		TA A { get; }

		TB B { get; }
	}
}