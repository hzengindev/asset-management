using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore.Storage;
using System;

namespace DataAccess.Concrete.EntityFramework.Transaction
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private ManagementContext dbContext;
        private IDbContextTransaction transaction;
        private bool _disposed;

        public EFUnitOfWork(ManagementContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public void BeginTransaction()
        {
            try
            {
                transaction = dbContext.Database.BeginTransaction();
            }
            catch (Exception ex)
            {
                throw new Exception($"BeginNewTransaction error in UnitOfWork => {ex}");
            }
        }

        public int SaveChanges()
        {
            var _transaction = transaction != null ? transaction : dbContext.Database.BeginTransaction();
            using (_transaction)
            {
                try
                {
                    if (dbContext == null)
                        throw new ArgumentException("DbContext is null in UnitOfWork");
                    
                    int result = dbContext.SaveChanges();
                    _transaction.Commit();
                    return result;
                }
                catch (Exception ex)
                {
                    _transaction.Rollback();
                    throw new Exception($"Transaction error in UnitOfWork => {ex}");
                }
            }
        }

        public void RollBackTransaction()
        {
            try
            {
                transaction.Rollback();
                transaction = null;
            }
            catch (Exception ex)
            {
                throw new Exception($"RollBackTransaction error in UnitOfWork => {ex}");
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed && disposing)
                    dbContext.Dispose();
            this._disposed = true;
        }
    }
}
