using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using JetBrains.Annotations;

namespace Ccr.Data.EntityFramework.Core
{
	public interface IRepository<TEntity>
		where TEntity : class
	{
		[NotNull]
		Expression<Func<TEntity, IComparable>> PrimaryKeyExpressionBase { get; }

		[Pure]
		int Count();

		[NotNull]
		TEntity Insert(TEntity entity);

		[NotNull]
		TEntity InsertOrAttach(TEntity entity);

		[NotNull, ItemNotNull]
		IList<TEntity> InsertAll(IEnumerable<TEntity> entities);

		[NotNull, ItemNotNull]
		IList<TEntity> DeleteAll(IEnumerable<TEntity> entities);

		[NotNull]
		TEntity Delete(TEntity entity);

		[NotNull, ItemNotNull]
		IList<object> DeleteRelatedEntriesBase(TEntity entity, IComparable[] keyListOfIgnoreEntites);

		[NotNull, ItemNotNull]
		IList<TResult> Select<TResult>(Expression<Func<TEntity, TResult>> selector);
		
		[NotNull, ItemNotNull]
		IList<TEntity> FetchAll();

		[NotNull, ItemNotNull]
		IList<TEntity> FetchWhere(Expression<Func<TEntity, bool>> predicate);
		
		[NotNull]
		TEntity FetchSingle(Expression<Func<TEntity, bool>> predicate);

		[CanBeNull]
		TEntity FetchSingleOrDefault(Expression<Func<TEntity, bool>> predicate);
	}

	public interface IRepository<TEntity, TKey> : IRepository<TEntity>
		where TEntity : class
		where TKey : IComparable
	{
		[NotNull]
		Expression<Func<TEntity, TKey>> PrimaryKeyExpression { get; }

		[NotNull]
		TEntity Fetch(TKey primaryKey);

		[CanBeNull]
		TEntity FetchOrDefault(TKey primaryKey);

		[NotNull, ItemNotNull]
		IList<object> DeleteRelatedEntries(TEntity entity, TKey[] keyListOfIgnoreEntites);
	} 
}
