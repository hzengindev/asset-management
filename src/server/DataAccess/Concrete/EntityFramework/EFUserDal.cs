using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFUserDal : EFEntityRepositoryBase<User, ManagementContext>, IUserDal
    {
        public List<string> GetClaims(Guid userId)
        {
            using (var dbContext = new ManagementContext())
            {
                var result = (from ur in dbContext.UserRoles
                              join rp in dbContext.RolePermissions on ur.RoleId equals rp.RoleId
                              where ur.UserId == userId
                              select rp.Scheme).ToList();
                return result;       
            }
        }
    }
}