using System;

namespace DataAccess.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        void BeginTransaction();
        void RollBackTransaction();
        int SaveChanges();
    }
}