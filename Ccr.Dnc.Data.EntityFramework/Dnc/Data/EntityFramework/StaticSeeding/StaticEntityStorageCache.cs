using System;
using System.Collections.Generic;
using System.Linq;

namespace Ccr.Dnc.Data.EntityFramework
{

  public class StaticEntityStorageCache
  {
    #region Singleton
    protected static StaticEntityStorageCache instance;
    public static StaticEntityStorageCache I => instance
      ?? (instance = new StaticEntityStorageCache());


    private StaticEntityStorageCache()
    {      
    }
    #endregion


    private static readonly IList<StaticEntityDeclarationCache> _declarationCaches
      = new List<StaticEntityDeclarationCache>();

    private static IDictionary<Type, StaticEntityDeclarationCache> _declarationMap
      => _declarationCaches.ToDictionary(
        t => t.EntityType,
        t => t);


    public StaticEntityDeclarationCache<TValue> GetDeclarationCache<TValue>()
    {
      if (!_declarationMap.TryGetValue(
        typeof(TValue), 
        out var _typeDeclarationCache))
      {
        var typeDeclarationCache = new StaticEntityDeclarationCache<TValue>();
        //typeDeclarationCache.VerifyEntityTypeIsInitialized();
        _declarationCaches.Add(
          typeDeclarationCache);

        return typeDeclarationCache;
      }
      return (StaticEntityDeclarationCache<TValue>)_typeDeclarationCache;
    }

    

  }
  // public static class StaticEntityStorageCacheManager
  //{
  //	private static readonly IDictionary<Type, StaticEntityDeclarationCache> _staticEntityDeclarationCacheMap
  //		= new Dictionary<Type, StaticEntityDeclarationCache>();


  //	public static StaticEntityDeclarationCache GetEntityDeclarationCache<TEntity>()
  //		where TEntity : class
  //	{
  //		if (_staticEntityDeclarationCacheMap.Keys.Contains(typeof(TEntity)))
  //			return _staticEntityDeclarationCacheMap[typeof(TEntity)];

  //		var _staticEntityDeclarationCache = new StaticEntityDeclarationCache();
  //		_staticEntityDeclarationCacheMap.Add(typeof(TEntity), _staticEntityDeclarationCache);

  //		return _staticEntityDeclarationCache;
  //	}

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
//}
