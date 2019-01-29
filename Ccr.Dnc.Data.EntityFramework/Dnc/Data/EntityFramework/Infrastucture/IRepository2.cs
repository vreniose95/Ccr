using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Ccr.Dnc.Data.EntityFramework.Infrastucture
{
  //public interface IRepository2
  //{
  //  Expression<Func<EntityBase, IComparable>> PrimaryKeyExpressionBase { get; }


  //  Type KeyType { get; }

  //  Type EntityType { get; }

  //  Type ContextType { get; }


  //  int Count();


  //  void InsertBase(
  //    EntityBase entityBase);

  //  void AddOrUpdateBase(
  //    EntityBase entityBase);

  //  void InsertOrAttatchBase(
  //    EntityBase entityBase);

  //  void DeleteBase(
  //    EntityBase entityBase);


  //  void InsertAllBase(
  //    IEnumerable<EntityBase> entityBases);

  //  void DeleteAllBase(
  //    IEnumerable<EntityBase> entityBases);


  //  IQueryable<EntityBase> FetchAllBase();

  //  IQueryable<EntityBase> FetchWhereBase(
  //    Func<EntityBase, bool> predicate);


  //  EntityBase FetchSingleBase(
  //    Func<EntityBase, bool> predicate);

  //  EntityBase FetchSingleOrDefaultBase(
  //    Func<EntityBase, bool> predicate);


  //  EntityBase FetchFirstBase(
  //    Func<EntityBase, bool> predicate);

  //  EntityBase FetchFirstOrDefaultBase(
  //    Func<EntityBase, bool> predicate);


  //  IQueryable<TResult> SelectBase<TResult>(
  //    Func<EntityBase, TResult> selector);

  //}


  //public abstract class Repository2
  //  : IRepository2
  //{
  //  Expression<Func<EntityBase, IComparable>> IRepository2.PrimaryKeyExpressionBase
  //  {
  //    get { throw new NotImplementedException(); }
  //  }


  //  public abstract Type KeyType { get; }

  //  public abstract Type EntityType { get; }

  //  public abstract Type ContextType { get; }



  //  int IRepository2.Count()
  //  {
  //    throw new NotImplementedException();
  //  }

  //  void IRepository2.InsertBase(EntityBase entityBase)
  //  {
  //    throw new NotImplementedException();
  //  }

  //  void IRepository2.AddOrUpdateBase(EntityBase entityBase)
  //  {
  //    throw new NotImplementedException();
  //  }

  //  void IRepository2.InsertOrAttatchBase(EntityBase entityBase)
  //  {
  //    throw new NotImplementedException();
  //  }

  //  void IRepository2.DeleteBase(EntityBase entityBase)
  //  {
  //    throw new NotImplementedException();
  //  }

  //  void IRepository2.InsertAllBase(IEnumerable<EntityBase> entityBases)
  //  {
  //    throw new NotImplementedException();
  //  }

  //  void IRepository2.DeleteAllBase(IEnumerable<EntityBase> entityBases)
  //  {
  //    throw new NotImplementedException();
  //  }

  //  IQueryable<EntityBase> IRepository2.FetchAllBase()
  //  {
  //    throw new NotImplementedException();
  //  }

  //  IQueryable<EntityBase> IRepository2.FetchWhereBase(Func<EntityBase, bool> predicate)
  //  {
  //    throw new NotImplementedException();
  //  }

  //  EntityBase IRepository2.FetchSingleBase(Func<EntityBase, bool> predicate)
  //  {
  //    throw new NotImplementedException();
  //  }

  //  EntityBase IRepository2.FetchSingleOrDefaultBase(Func<EntityBase, bool> predicate)
  //  {
  //    throw new NotImplementedException();
  //  }

  //  EntityBase IRepository2.FetchFirstBase(Func<EntityBase, bool> predicate)
  //  {
  //    throw new NotImplementedException();
  //  }

  //  EntityBase IRepository2.FetchFirstOrDefaultBase(Func<EntityBase, bool> predicate)
  //  {
  //    throw new NotImplementedException();
  //  }

  //  IQueryable<TResult> IRepository2.SelectBase<TResult>(Func<EntityBase, TResult> selector)
  //  {
  //    throw new NotImplementedException();
  //  }
  //}

  //public abstract class Repository
  //{

  //}

  //public interface IRepository2<TKey, TEntity, TContext>
  //  : IRepository2
  //{

  //}
}
