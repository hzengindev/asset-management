using Core.Utilities.Results;
using Entities.Dtos.Project;
using System;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IProjectService
    {
        IDataResult<Guid> Add(ProjectAddDto project, Guid owner);
        IResult Update(ProjectUpdateDto project, Guid owner);
        IResult Delete(ProjectDeleteDto project, Guid owner);
        IDataResult<IList<Entities.Concrete.Project>> GetByCustomerId(Guid customerId);
    }
}