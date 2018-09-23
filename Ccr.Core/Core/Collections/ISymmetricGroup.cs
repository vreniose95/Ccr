using System.Collections.Generic;

namespace Ccr.Core.Collections
{
	public interface ISymmetricGroup<TA, TB, TMorphism>
		: ICollection<TMorphism>
		where TMorphism
		: IMorphism<TA, TB>
	{
		TMorphism Morphism { get; }


		IReadOnlyList<TA> SetA { get; }

		IReadOnlyList<TB> SetB { get; }


		TB this[TA a] { get; }


		bool Contains(TA a);

		bool Contains(TB b);

		bool Remove(TA a);

		bool Remove(TB b);

		bool TryGetMorphism(TA a, out TMorphism morphism);
	}
}