using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Ccr.Std.Core.Extensions;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Ccr.Dnc.Extensions
{
	public static class DbContextExtensions
	{
		public static DbConnection GetSingularDbConnection<TContext>(
			this TContext @this)
			where TContext
			: DbContext
		{
			var connection = @this.Database.GetDbConnection();

			if (connection.State != ConnectionState.Open)
			{
				@this.Database.OpenConnection();
				//connection.Open();
			}
			connection.Disposed += (sender, args) =>
			{
				connection.Close();
			};
			return connection;
		}

		//public static DbSet<TEntity> GetSetsToSeed<TEntity, TContext>(
		//  this TContext @this)
		//    where TContext
		//    : DbContext
		//{

		//}
	}


  //public static void AddWithSqlIdentity<TEntity, TContext>(
  //  this TContext @this,
  //  Expression<Func<TContext, DbSet<TEntity>>> setExpression,
  //  params TEntity[] entities)
  //    where TEntity
  //      : class
  //    where TContext
  //      : DbContext
  //{
  //  using (var connection = @this.Database.GetDbConnection())
  //  {
  //    try
  //    {
  //      connection.Open();

  //      connection.SetIdentityInsert(this, setExpression, true);

  //      var compiledExpression = setExpression.Compile();
  //      var dbset = compiledExpression.Invoke(this);
  //      dbset.AddRange(entities);

  //      SaveChanges();
  //    }
  //    catch (Exception ex)
  //    {
  //    }
  //    finally
  //    {
  //      connection.SetIdentityInsert(this, setExpression, false);
  //      connection.Close();
  //    }
  //  }
  //}

  public interface IDbSetWrapper
    : IQueryable
  {
    object Find(
      [NotNull] params object[] keyValues);

    Task<object> FindAsync(
      [NotNull] params object[] keyValues);


    Task<object> FindAsync(
      [NotNull] object[] keyValues,
      CancellationToken cancellationToken);

    EntityEntry<object> Add(
      [NotNull] object entity);

    Task<EntityEntry<object>> AddAsync(
      [NotNull] object entity,
      CancellationToken cancellationToken = default(CancellationToken));

    EntityEntry<object> Attach(
      [NotNull] object entity);

    EntityEntry<object> Remove(
      [NotNull] object entity);

    EntityEntry<object> Update(
      [NotNull] object entity);

    void AddRange(
      [NotNull] params object[] entities);

    Task AddRangeAsync(
      [NotNull] params object[] entities);

    void AttachRange(
      [NotNull] params object[] entities);

    void RemoveRange(
      [NotNull] params object[] entities);

    void UpdateRange(
      [NotNull] params object[] entities);

    void AddRange(
      [NotNull] IEnumerable<object> entities);

    Task AddRangeAsync(
      [NotNull] IEnumerable<object> entities,
      CancellationToken cancellationToken = default(CancellationToken));

    void AttachRange(
      [NotNull] IEnumerable<object> entities);

    void RemoveRange(
      [NotNull] IEnumerable<object> entities);

    void UpdateRange(
      [NotNull] IEnumerable<object> entities);
  }

  public class DbSetWrapper<TEntity>
    : IDbSetWrapper
    where TEntity
    : class
  {
    protected DbSet<TEntity> _dbSet;
    private IDbSetWrapper _DbSetWrapperImplementation;

    private IEnumerable enumerable => _dbSet;
    private IQueryable queryable => _dbSet;


    public DbSetWrapper(
      DbSet<TEntity> dbSet)
    {
      _dbSet = dbSet;
    }


    IEnumerator IEnumerable.GetEnumerator()
    {
      return enumerable.GetEnumerator();
    }

    Type IQueryable.ElementType
    {
      get => queryable.ElementType;
    }

    Expression IQueryable.Expression
    {
      get => queryable.Expression;
    }

    IQueryProvider IQueryable.Provider
    {
      get => queryable.Provider;
    }


    public object Find(params object[] keyValues)
    {
      return _dbSet.Find(keyValues);
    }

    public Task<object> FindAsync(params object[] keyValues)
    {
      throw new NotImplementedException();
      // return _dbSet.FindAsync(keyValues).GetAwaiter().
    }

    public Task<object> FindAsync(object[] keyValues, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public EntityEntry<object> Add(object entity)
    {
      var tEntity = entity.As<TEntity>();
      var set = _dbSet.Add(tEntity);
      var obj = set.As<TEntity>();
      return null;
    }

    public EntityEntry<TEntity> Add(TEntity entity)
    {
      return _dbSet.Add(entity);
    }

    public Task<EntityEntry<object>> AddAsync(object entity,
                                              CancellationToken cancellationToken = new CancellationToken())
    {
      throw new NotImplementedException();
    }

    public EntityEntry<object> Attach(object entity)
    {
      throw new NotImplementedException();
    }

    public EntityEntry<object> Remove(object entity)
    {
      throw new NotImplementedException();
    }

    public EntityEntry<object> Update(object entity)
    {
      throw new NotImplementedException();
    }

    public void AddRange(
      params object[] entities)

    {
      _dbSet.AddRange(
        entities.Cast<TEntity>());
    }

    public void AddRange(
      IEnumerable<TEntity> items)
    {
      _dbSet.AddRange(items);
    }

    public Task AddRangeAsync(params object[] entities)
    {
      throw new NotImplementedException();
    }

    public void AttachRange(params object[] entities)
    {
      throw new NotImplementedException();
    }

    public void RemoveRange(params object[] entities)
    {
      throw new NotImplementedException();
    }

    public void UpdateRange(params object[] entities)
    {
      throw new NotImplementedException();
    }

    public void AddRange(IEnumerable<object> entities)
    {
      throw new NotImplementedException();
    }

    public Task AddRangeAsync(IEnumerable<object> entities,
                              CancellationToken cancellationToken = new CancellationToken())
    {
      throw new NotImplementedException();
    }

    public void AttachRange(IEnumerable<object> entities)
    {
      throw new NotImplementedException();
    }

    public void RemoveRange(IEnumerable<object> entities)
    {
      throw new NotImplementedException();
    }

    public void UpdateRange(IEnumerable<object> entities)
    {
      throw new NotImplementedException();
    }
  }


  public static class DbSetToDbContextMapping
  {
    private static IDictionary<IDbSetWrapper, DbContext> cachedContextInstanceMappings
      = new Dictionary<IDbSetWrapper, DbContext>();

    //public static bool TryGetCachedContext(
    //  IDbSetWrapper _dbSetWrapper, 
    //  out DbContext mappedContext)
    //{
    //  var hashKey = _dbSetWrapper.GetHashCode();


    //}

  }
}