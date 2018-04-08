using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using Ccr.Core.Extensions;
using Ccr.Std.Introspective.Extensions;
using Ccr.Std.Introspective.Infrastructure;
using Ccr.Std.Introspective.Infrastructure.Context;

namespace Ccr.Data.EntityFramework.Core
{
	public class UnitOfWork<TContext>
    : IUnitOfWork 
		where TContext 
    : DbContext
	{
		private DbContextTransaction _transaction;
		private readonly Dictionary<Type, object> _repositories;
		private readonly TContext _context;

		public UnitOfWork()
		{
			_context = Activator.CreateInstance<TContext>();
			//_context = new TContext();
			_repositories = new Dictionary<Type, object>();
		}

		public TRepository GetCustomRepository<TRepository, TEntity>()
			where TRepository
        : IRepository<TEntity>
			where TEntity 
        : class
		{
      if(_repositories.TryGetValue(typeof(TEntity), out var existing))
        return existing.As<TRepository>();

			var repository = 
				new IntrospectiveStaticContext<TRepository>()
				.InvokeCtorGeneric(
					MemberDescriptor.Any,
					new[] {typeof (TContext)}, 
					new object[] {_context});
			
			_repositories.Add(typeof(TEntity), repository);
			return repository;
		}

		public IRepository<TSet, TKey> GetRepository<TSet, TKey>() 
			where TSet 
        : class
			where TKey
        : IComparable
		{
			if (_repositories.Keys.Contains(typeof(TSet)))
				return _repositories[typeof(TSet)] as IRepository<TSet, TKey>;

			var repository = new Repository<TSet, TKey, TContext>(_context);
			_repositories.Add(typeof(TSet), repository);
			return repository;
		}

		public IRepository<TSet> GetRepositoryBase<TSet>()
			where TSet
        : class
		{
			if (_repositories.Keys.Contains(typeof(TSet)))
				return _repositories[typeof(TSet)] as IRepository<TSet>;

			var repository = new Repository<TSet, IComparable, TContext>(_context);
			_repositories.Add(typeof(TSet), repository);
			return repository;
		}

		/// <summary>
		/// Start Transaction
		/// </summary>
		/// <returns></returns>
		public DbContextTransaction BeginTransaction()
		{
			if (null == _transaction)
			{
				if (_context.Database.Connection.State != ConnectionState.Open)
				{
					_context.Database.Connection.Open();
				}
				_transaction = _context.Database.BeginTransaction();
			}
			return _transaction;
		}

		public int Save()
		{
			return _context.SaveChanges();
		}

		#region IDisposable Members

		public void Dispose()
		{
			_transaction?.Dispose();
			_context?.Dispose();
		}

		#endregion

	}
}
