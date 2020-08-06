using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFVersionDal : EFEntityRepositoryBase<Entities.Concrete.Version, ManagementContext>, IVersionDal
    {
    }
}
