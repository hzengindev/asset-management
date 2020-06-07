using Core.DataAccess;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        public List<string> GetClaims(Guid userId);
    }
}