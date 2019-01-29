using System;
using System.Collections.Generic;
using Ccr.Std.Core.Extensions;
using Ccr.Std.Introspective.Extensions;
using Ccr.Std.Introspective.Infrastructure;
using Ccr.Std.Introspective.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Ccr.Dnc.Data.EntityFramework.Infrastucture
{
	public class UnitOfWork<TContext>
		: IUnitOfWork
			where TContext
				: DbContext
	{
		#region Fields
		private IDbContextTransaction _transaction;
		private readonly Dictionary<Type, object> _repositories;
		private readonly TContext _context;

		#endregion


		#region Constructors
		public UnitOfWork()
			: this(
				Activator.CreateInstance<TContext>())
		{
			_repositories = new Dictionary<Type, object>();
		}

		public UnitOfWork(
			TContext context)
		{
			_context = context;
		}

		#endregion

		public TRepository GetCustomRepository<TRepository, TEntity>()
			where TRepository
				: IRepository<TEntity>
			where TEntity
				: class
		{
			//throw new NotImplementedException();
			if (_repositories.TryGetValue(typeof(TEntity), out var cachedRepository))
				return cachedRepository.As<TRepository>();

			var repository =
				new IntrospectiveStaticContext<TRepository>()
				.InvokeCtorGeneric(
					MemberDescriptor.Any,
					new[] { typeof(TContext) },
					new object[] { _context });

			_repositories.Add(typeof(TEntity), repository);
			return repository;
		}

		public IRepository<TEntity, TKey> GetRepository<TEntity, TKey>()
			where TEntity
				: class
			where TKey
				: IComparable
		{
			if (!_repositories.TryGetValue(typeof(TEntity), out var cachedRepository))
			{
				var repository = new Repository<TEntity, TKey, TContext>(
					_context);

				_repositories.Add(
					typeof(TEntity),
					repository);
				
				return repository;
			}
			else
			{
				if (!(cachedRepository is IRepository<TEntity, TKey> repository))
					throw new InvalidCastException(
						$"Cached repository must be a {typeof(IRepository<TEntity, TKey>).Name.SQuote()}.");

				return repository;
			}
		}

		public IRepository<TEntity> GetRepositoryBase<TEntity>()
			where TEntity
				: class
		{
			if (!_repositories.TryGetValue(typeof(TEntity), out var cachedRepository))
			{
				var repository = new Repository<TEntity, IComparable, TContext>(
					_context);

				_repositories.Add(
					typeof(TEntity),
					repository);

				return repository;
			}
			else
			{
				if (!(cachedRepository is IRepository<TEntity> repository))
					throw new InvalidCastException(
						$"Cached repository must be a {typeof(IRepository<TEntity>).Name.SQuote()}.");

				return repository;
			}
			//if (_repositories
			//	.Keys
			//	.Contains(
			//		typeof(TSet)))
			//	return _repositories[typeof(TSet)] as IRepository<TSet>;

			//var repository = new Repository<TSet, IComparable, TContext>(
			//	_context);

			//_repositories.Add(
			//	typeof(TSet),
			//	repository);

			//return repository;
		}

		/// <summary>
		///		Start Transaction
		/// </summary>
		/// <returns></returns>
		public IDbContextTransaction BeginTransaction()
		{
			if (null == _transaction)
			{
				//using (var connection = _context.GetSingularDbConnection())
				//{
				//}
				_transaction = _context
					.Database
					.BeginTransaction();
			}
			return _transaction;
		}

		public int Save()
		{
			return _context
				.SaveChanges();
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
