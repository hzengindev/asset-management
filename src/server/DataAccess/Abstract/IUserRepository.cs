using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IUserRepository : IEntityRepositoryBase<User>
    {
        public List<string> GetClaims(Guid userId);
    }
}