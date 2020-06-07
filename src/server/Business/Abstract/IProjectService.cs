using Core.Utilities.Results;
using Entities.Dtos.Project;
using System;

namespace Business.Abstract
{
    public interface IProjectService
    {
        IDataResult<Guid> Add(ProjectAddDto project, Guid owner);
        IResult Update(ProjectUpdateDto project, Guid owner);
    }
}