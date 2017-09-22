using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using Ccr.Core.Extensions;

// ReSharper disable ConvertPropertyToExpressionBody
namespace Ccr.Data.EntityFramework.Core
{
	public class Repository<TEntity, TKey, TContext> :
		IRepository<TEntity, TKey>
			where TEntity : class
			where TKey : IComparable
			where TContext : DbContext
	{
		protected readonly TContext _context;

		private DbSet<TEntity> _DBSet;
		protected virtual DbSet<TEntity> DBSet
		{
			get { return _DBSet ?? (_DBSet = _context.Set<TEntity>()); }
		}

		private ObjectContext _objectContext
		{
			get
			{
				var s = _context as IObjectContextAdapter;
				return s.ObjectContext;
			}
		}

		private Func<TEntity, TKey> _primaryKeyFunc;
		protected Func<TEntity, TKey> PrimaryKeyFunc => _primaryKeyFunc ??
			(_primaryKeyFunc = PrimaryKeyExpression.Compile());


		private readonly EntityPrimaryKeyResolver<TEntity, TKey, TContext> _primaryKeyResolver;

		private Expression<Func<TEntity, TKey>> _primaryKeyExpression;
		public virtual Expression<Func<TEntity, TKey>> PrimaryKeyExpression
		{
			get
			{
				if (_primaryKeyExpression != null)
					return _primaryKeyExpression;

				return _primaryKeyExpression = _primaryKeyResolver.PrimaryKeyGetterExpression;//PrimaryKeyExpression;
			}
		}

		private Expression<Func<TEntity, IComparable>> _primaryKeyExpressionBase;
		public Expression<Func<TEntity, IComparable>> PrimaryKeyExpressionBase
		{
			get
			{
				if (_primaryKeyExpressionBase != null)
					return _primaryKeyExpressionBase;

				return _primaryKeyExpressionBase = _primaryKeyResolver.PrimaryKeyExpressionBase;
			}
		}

		public TEntity Fetch(TKey primaryKey)
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

		public IList<object> DeleteRelatedEntries(TEntity entity, TKey[] keyListOfIgnoreEntites)
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


		public Repository(TContext context)
		{
			_context = context;
			_primaryKeyResolver = new EntityPrimaryKeyResolver<TEntity, TKey, TContext>(context);
		}


		public int Count()
		{
			return DBSet.Count();
		}

		public TEntity Insert(TEntity entity)
		{
			return DBSet.Add(entity);
		}

		public TEntity InsertOrAttach(TEntity entity)
		{
			var key = entity.As<IEntityWithKey>().EntityKey;
			if (key == null)
			{

			}
			throw new NotImplementedException();
		}

		public IList<TEntity> InsertAll(IEnumerable<TEntity> entities)
		{
			return DBSet.AddRange(entities).ToList();
		}

		public IList<TEntity> DeleteAll(IEnumerable<TEntity> entities)
		{
			return DBSet.RemoveRange(entities).ToList();
		}

		public TEntity Delete(TEntity entity)
		{
			return DBSet.Remove(entity);
		}

		public IList<object> DeleteRelatedEntriesBase(TEntity entity, IComparable[] keyListOfIgnoreEntites)
		{
			return DeleteRelatedEntries(entity, keyListOfIgnoreEntites.Cast<TKey>().ToArray());
		}

		public IList<TResult> Select<TResult>(Expression<Func<TEntity, TResult>> selector)
		{
			return DBSet.Select(selector).ToList();
		}

		public IList<TEntity> FetchAll()
		{
			return DBSet.ToList();
		}

		public IList<TEntity> FetchWhere(Expression<Func<TEntity, bool>> predicate)
		{
			return DBSet.Where(predicate).ToList();
		}

		public TEntity FetchSingle(Expression<Func<TEntity, bool>> predicate)
		{
			return DBSet.Single(predicate);
		}

		public TEntity FetchSingleOrDefault(Expression<Func<TEntity, bool>> predicate)
		{
			return DBSet.SingleOrDefault(predicate);
		}

		private static IEnumerable<EntityObject> resolveRelatedEntityObjects(TEntity entity)
		{
			return entity.As<IEntityWithRelationships>()
									 .RelationshipManager.GetAllRelatedEnds()
									 .SelectMany(t => t.CreateSourceQuery().OfType<EntityObject>())
									 .Distinct()
									 .ToArray();
		}
	}
}
