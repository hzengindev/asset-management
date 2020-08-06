using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos.ProjectUser;
using System;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IProjectUserService
    {
        IDataResult<Guid> Add(ProjectUserAddDto projectUser, Guid owner);
        IResult Delete(ProjectUserDeleteDto projectUser, Guid owner);
        IDataResult<IList<ProjectUser>> GetByProjectId(Guid projectId);
    }
}