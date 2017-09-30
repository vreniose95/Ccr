
using System.ComponentModel.DataAnnotations.Schema;

namespace Ccr.Data.EntityFramework.Core
{
	public abstract class HasStaticStore<TEntity, TStaticEntityStore>
		: IHaveStaticStore
			where TStaticEntityStore
				: StaticEntityStore<TEntity>
					where TEntity
						: class
	{
		[NotMapped]
		public virtual bool IsDatabaseGeneratedValueSimulated => false;
	}
}
