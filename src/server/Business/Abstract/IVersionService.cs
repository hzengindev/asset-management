using Core.Utilities.Results;
using Entities.Dtos.Version;
using System;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IVersionService
    {
        IDataResult<Guid> Add(VersionAddDto version, Guid owner);
        IResult Update(VersionUpdateDto version, Guid owner);
        IResult Delete(VersionDeleteDto version, Guid owner);
        IDataResult<IList<Entities.Concrete.Version>> GetByProjectId(Guid projectId);
        IResult SaveVersionFile(SaveVersionFileDto value, Guid owner);
    }
}