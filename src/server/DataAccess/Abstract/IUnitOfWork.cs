using System;

namespace DataAccess.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        void BeginNewTransaction();
        void RollBackTransaction();
        int SaveChanges();
    }
}