using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFUserRepository : EFEntityRepositoryBase<User>, IUserRepository
    {
        private ManagementContext dbContext;        
        public EFUserRepository(ManagementContext _dbContext) : base(_dbContext)
        {
            dbContext = _dbContext;
        }

        public List<string> GetClaims(Guid userId)
        {
            return (from ur in dbContext.UserRoles
                    join rp in dbContext.RolePermissions on ur.RoleId equals rp.RoleId
                    where ur.UserId == userId
                    select rp.Scheme).ToList();
        }
    }
}