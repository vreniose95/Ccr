using System;
using System.Data.Entity;

namespace Ccr.Data.EntityFramework.Core
{
	public class StaticEntityFacetAdapter<TEntity, TKey, TContext>
		where TEntity : class
		where TKey : IComparable
		where TContext : DbContext

	{
		private EntityPrimaryKeyResolver<TEntity, TKey, TContext> _entityTypeMappingLayer;
		internal EntityPrimaryKeyResolver<TEntity, TKey, TContext> EntityTypeMappingLayer
		{
			get => _entityTypeMappingLayer ??
			       (_entityTypeMappingLayer =
				       new EntityPrimaryKeyResolver<TEntity, TKey, TContext>(_context));
		} 

		private TEntity _entity;
		private TContext _context;

		public TKey EntityPrimaryKeyIdentifer
		{
			get
			{
				var currentValue = EntityTypeMappingLayer.GetPrimaryKeyValue(_entity);
				throw new NotImplementedException();
			}
		}


		public StaticEntityFacetAdapter(
			TContext context,
			TEntity entity)
		{
			_context = context;
			_entity = entity;
		}
	}
	//{
	//	public static Dictionary<>
	//	public static Ref<TEntity> Declare<TEntity, TKey>(
	//		TEntity entity,
	//		Expression<Func<TEntity, TKey>> primaryKey,
	//		[CallerLineNumber] int lineNumber = 0,
	//		[CallerMemberName] string memberName = null)
	//			where TEntity : class
	//	{
	//		var declarationCache = StaticEntityStorageCacheManager.GetEntityDeclarationCache<TEntity>();
	//		declarationCache.RegisterEntitySeed(lineNumber);
	//		return new Ref<TEntity>(() =>
	//		{
	//			var sequentialValue = declarationCache.ResolvePositionFromLineNumber(lineNumber);

	//			entity.
	//		});


	//		_streetSuffixVariantIDResolver = () => StreetSuffixVariantStoreCache.I.ResolvePositionFromLineNumber(lineNumber);
	//	}
		
	//}
}
