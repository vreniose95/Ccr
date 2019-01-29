using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

// ReSharper disable ConvertPropertyToExpressionBody
namespace Ccr.Dnc.Data.EntityFramework.Infrastucture
{
  public class Repository<
    TEntity,
    TKey,
    TContext>
			: IRepository<TEntity>,
				IRepository<TEntity, TKey>
    where TEntity
      : class
    where TKey
      : IComparable
    where TContext
			: DbContext
  {
    protected readonly TContext _context;


    private DbSet<TEntity> _dbSet;
    protected virtual DbSet<TEntity> DBSet
    {
      get => _dbSet
             ?? (_dbSet = _context.Set<TEntity>());
    }

    private Func<TEntity, TKey> _primaryKeyFunc;
    protected Func<TEntity, TKey> PrimaryKeyFunc
    {
      get => _primaryKeyFunc
             ?? (_primaryKeyFunc = PrimaryKeyExpression.Compile());
    }


    private readonly EntityPrimaryKeyResolver<TEntity, TKey, TContext> _primaryKeyResolver;

    private Expression<Func<TEntity, TKey>> _primaryKeyExpression;
    public virtual Expression<Func<TEntity, TKey>> PrimaryKeyExpression
    {
      get
      {
        if (_primaryKeyExpression != null)
          return _primaryKeyExpression;

        return _primaryKeyExpression = _primaryKeyResolver
          .PrimaryKeyGetterExpression;
      }
    }

    private Expression<Func<TEntity, IComparable>> _primaryKeyExpressionBase;
    public Expression<Func<TEntity, IComparable>> PrimaryKeyExpressionBase
    {
      get
      {
        throw new Exception();
        //if (_primaryKeyExpressionBase != null)
        //	return _primaryKeyExpressionBase;

        // return _primaryKeyExpressionBase = _primaryKeyResolver.CreatePrimaryKeyExpressionPredicateBase();
        // //.PrimaryKeyExpressionBase;
      }
    }

    public TEntity Fetch(
      TKey primaryKey)
    {
      var entity = FetchOrDefault(primaryKey);

      if (entity == null)
        throw new KeyNotFoundException();

      return entity;
    }

    public TEntity FetchOrDefault(TKey primaryKey)
    {
      return DBSet.Find(primaryKey);
    }

    public IList<object> DeleteRelatedEntries(
      TEntity entity,
      TKey[] keyListOfIgnoreEntites)
    {
      throw new NotImplementedException();
      /*var deletedEntities = new List<object>();
			foreach (var relatedEntity in resolveRelatedEntityObjects(entity))
			{
				var relatedTEntity = relatedEntity as TEntity;
				if (relatedTEntity != null)
				{
					var keyValue = PrimaryKeyFunc(relatedTEntity);
					if (keyListOfIgnoreEntites.Contains(keyValue))
						continue;

					var removedEntity = _DBSet.Remove(relatedTEntity);
					deletedEntities.Add(removedEntity);
				}
				else
				{
					var propertyInfo = relatedEntity.GetType().GetProperty(_primaryKeyResolver.PropertyInfo.Name);
					if (null != propertyInfo)
					{
						var value = propertyInfo.GetValue(relatedEntity, null).As<TKey>();
						if (keyListOfIgnoreEntites.Contains(value))
							continue;

						var _currentDBSet = _context
							.Reflect()
							.InvokeMethodGeneric<object>(
								MemberDescriptor.Any,
								"Set", 
								new[] { relatedEntity.GetType() }, 
								new object[] { });

						var removedEntity = _currentDBSet
							.Reflect()
							.InvokeMethod<object>(
								MemberDescriptor.Any,
								"Remove", 
								relatedEntity);

						deletedEntities.Add(removedEntity);
					}
				}
			}
			return deletedEntities;*/
    }


    public Repository(
      TContext context)
    {
      _context = context;

      _primaryKeyResolver = new EntityPrimaryKeyResolver<
        TEntity, 
        TKey,
        TContext>(
          context);
    }


    public int Count()
    {
      return DBSet
        .Count();
    }

    public void Insert(
      TEntity entity)
    {
      DBSet
        .Add(
          entity);
    }

    public void InsertOrAttach(
      TEntity entity)
    {

    }

    public void AddOrUpdate(
      TEntity entity)
    {
      var primaryKeyValue = _primaryKeyFunc(entity);

      var equalityExpression = _primaryKeyResolver
        .CreatePrimaryKeyExpressionPredicate(primaryKeyValue);

      var existingEntity = DBSet.FirstOrDefault(
        equalityExpression);

      if (existingEntity == default(TEntity))
      {
        _context.Add(entity);
      }
      else
      {
        var x = _context.Update(existingEntity);

      }
    }


    public void InsertAll(
      IEnumerable<TEntity> entities)
    {
      DBSet.AddRange(
        entities);
    }

    public void DeleteAll(
      IEnumerable<TEntity> entities)
    {
      DBSet.RemoveRange(
        entities);
    }

    public void Delete(
      TEntity entity)
    {
      DBSet.Remove(
        entity);
    }

    public IList<object> DeleteRelatedEntriesBase(
      TEntity entity,
      IComparable[] keyListOfIgnoreEntites)
    {
      return DeleteRelatedEntries(
        entity, 
        keyListOfIgnoreEntites
          .Cast<TKey>()
          .ToArray());
    }

    public IList<TResult> Select<TResult>(
      Expression<Func<TEntity, TResult>> selector)
    {
      return DBSet
        .Select(
          selector)
        .ToList();
    }

    public IList<TEntity> FetchAll()
    {
      return DBSet
        .ToList();
    }

    public IList<TEntity> FetchWhere(
      Expression<Func<TEntity, bool>> predicate)
    {
      return DBSet
        .Where(
          predicate)
        .ToList();
    }

    public TEntity FetchSingle(
      Expression<Func<TEntity, bool>> predicate)
    {
      return DBSet
        .Single(
          predicate);
    }

    public TEntity FetchSingleOrDefault(
      Expression<Func<TEntity, bool>> predicate)
    {
      return DBSet
        .SingleOrDefault(
          predicate);
    }

    //private static IEnumerable<EntityObject> resolveRelatedEntityObjects(TEntity entity)
    //{
    //	return entity.As<IEntityWithRelationships>()
    //							 .RelationshipManager.GetAllRelatedEnds()
    //							 .SelectMany(t => t.CreateSourceQuery().OfType<EntityObject>())
    //							 .Distinct()
    //							 .ToArray();
    //}
  }
}
