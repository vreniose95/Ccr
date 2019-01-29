using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using JetBrains.Annotations;

namespace Ccr.Dnc.Data.EntityFramework
{
	//public interface IRepository<TEntity>
	//	where TEntity
 //     : class
 // {
	//	[NotNull]
	//	Expression<Func<TEntity, IComparable>> PrimaryKeyExpressionBase { get; }

	//	[Pure]
	//	int Count();
    
	//	void Insert(TEntity entity);

	//  void AddOrUpdate(TEntity entity);

 //   //[NotNull]
 //   void InsertOrAttach(TEntity entity);
    
	//	void InsertAll(IEnumerable<TEntity> entities);
    
	//	void DeleteAll(IEnumerable<TEntity> entities);

	//	void Delete(TEntity entity);

	//	[NotNull, ItemNotNull]
	//	IList<object> DeleteRelatedEntriesBase(TEntity entity, IComparable[] keyListOfIgnoreEntites);

	//	[NotNull, ItemNotNull]
	//	IList<TResult> Select<TResult>(Expression<Func<TEntity, TResult>> selector);
		
	//	[NotNull, ItemNotNull]
	//	IList<TEntity> FetchAll();

	//	[NotNull, ItemNotNull]
	//	IList<TEntity> FetchWhere(Expression<Func<TEntity, bool>> predicate);
		
	//	[NotNull]
	//	TEntity FetchSingle(Expression<Func<TEntity, bool>> predicate);

	//	[CanBeNull]
	//	TEntity FetchSingleOrDefault(Expression<Func<TEntity, bool>> predicate);
	//}

	//public interface IRepository<TEntity, TKey>
 //   : IRepository<TEntity>
	//	  where TEntity 
	//			: class
 //     where TKey 
	//			: IComparable
	//{
	//	[NotNull]
	//	Expression<Func<TEntity, TKey>> PrimaryKeyExpression { get; }

	//	[NotNull]
	//	TEntity Fetch(TKey primaryKey);

	//	[CanBeNull]
	//	TEntity FetchOrDefault(TKey primaryKey);

	//	[NotNull, ItemNotNull]
	//	IList<object> DeleteRelatedEntries(TEntity entity, TKey[] keyListOfIgnoreEntites);
	//} 
}
