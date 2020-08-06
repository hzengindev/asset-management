using Core.Utilities.Results;
using Entities.Dtos.ProjectUser;
using System;

namespace Business.Abstract
{
    public interface IProjectUserService
    {
        IDataResult<Guid> Add(ProjectUserAddDto projectUser, Guid owner);
        IResult Delete(ProjectUserDeleteDto projectUser, Guid owner);
    }
}