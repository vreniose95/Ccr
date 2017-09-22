using System;
using System.Data.Entity;

namespace Ccr.Data.EntityFramework.Core
{
	public interface IUnitOfWork : IDisposable
	{
		IRepository<TSet> GetRepositoryBase<TSet>() 
			where TSet : class;

		DbContextTransaction BeginTransaction();

		int Save();
	}
}
