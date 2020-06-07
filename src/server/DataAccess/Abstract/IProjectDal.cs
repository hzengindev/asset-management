using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IProjectDal: IEntityRepository<Project>
    {
    }
}