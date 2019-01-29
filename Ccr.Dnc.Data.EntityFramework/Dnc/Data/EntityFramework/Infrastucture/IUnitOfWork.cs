using System;
using Microsoft.EntityFrameworkCore.Storage;

namespace Ccr.Dnc.Data.EntityFramework.Infrastucture
{
	public interface IUnitOfWork
    : IDisposable
	{
		IRepository<TEntity> GetRepositoryBase<TEntity>() 
			where TEntity
				: class;

	  IDbContextTransaction BeginTransaction();

		int Save();
	}
}
