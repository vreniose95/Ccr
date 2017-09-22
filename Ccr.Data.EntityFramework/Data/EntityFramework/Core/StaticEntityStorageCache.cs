using System;
using System.Collections.Generic;
using System.Linq;

namespace Ccr.Data.EntityFramework.Core
{
	public sealed class StaticEntityDeclarationCache
	{
		private readonly SortedSet<int> entityLineNumbers = new SortedSet<int>(Comparer<int>.Default);

		public void RegisterEntitySeed(int lineNumber)
		{
			if (!entityLineNumbers.Add(lineNumber))
				throw new NotSupportedException();
		}
		public int ResolvePositionFromLineNumber(int lineNumber)
		{
			var subset = entityLineNumbers.GetViewBetween(0, lineNumber);
			return subset.Count;
		}
	}
	public static class StaticEntityStorageCacheManager
	{
		private static readonly Dictionary<Type, StaticEntityDeclarationCache> _staticEntityDeclarationCacheMap
			= new Dictionary<Type, StaticEntityDeclarationCache>();

		public static StaticEntityDeclarationCache GetEntityDeclarationCache<TEntity>()
			where TEntity : class
		{
			if (_staticEntityDeclarationCacheMap.Keys.Contains(typeof(TEntity)))
				return _staticEntityDeclarationCacheMap[typeof(TEntity)];

			var _staticEntityDeclarationCache = new StaticEntityDeclarationCache();
			_staticEntityDeclarationCacheMap.Add(typeof(TEntity), _staticEntityDeclarationCache);

			return _staticEntityDeclarationCache;
		}

		//public abstract class StaticEntityDatabaseGeneratedValueProviderStrategy
		//{

			
		//}
		//public class RegistrarDispatcherCallbackProviderStrategy
		//	: StaticEntityDatabaseGeneratedValueProviderStrategy
		//{
		//	public void PrepareEntityForInsert<TStaticEntity>()
		//		where TStaticEntity : HasStaticStore<>
		//}
	}
	//public abstract class StaticEntityStorageCache<TEntity> : StaticEntityStorageCache
	//		where TEntity : class
	//{

	//}
}
