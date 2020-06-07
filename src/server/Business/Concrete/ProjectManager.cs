using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Dtos.Project;
using System;

namespace Business.Concrete
{
    public class ProjectManager : IProjectService
    {
        IProjectDal _projectDal;

        public ProjectManager(IProjectDal projectDal)
        {
            _projectDal = projectDal;
        }

        public IDataResult<Guid> Add(ProjectAddDto project, Guid owner)
        {
            var projectId = Guid.NewGuid();
            _projectDal.Add(new Entities.Concrete.Project
            {
                Id = projectId,
                Name = project.Name,
                Description = project.Description,
                CustomerId = project.CustomerId,
                ShortCode = project.ShortCode,
                CreatedBy = owner,
                ModifiedBy = owner,
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now,
                StateCode = Entities.Concrete.ProjectStateTypes.Active,
                StatusCode = Entities.Concrete.ProjectStatusTypes.Active
            });

            return new SuccessDataResult<Guid>(projectId);
        }

        public IResult Update(ProjectUpdateDto project, Guid owner)
        {
            var _project = _projectDal.Get(z => z.Id == project.Id);
            _projectDal.Update(new Entities.Concrete.Project
            {
                Id = project.Id,
                Name = project.Name,
                Description = project.Description,
                CustomerId = project.CustomerId,
                ShortCode = project.ShortCode,
                CreatedBy = _project.CreatedBy,
                CreatedOn = _project.CreatedOn,
                ModifiedBy = owner,
                ModifiedOn = DateTime.Now,
                StateCode = project.StateCode,
                StatusCode = project.StatusCode
            });

            return new SuccessResult();
        }
    }
}
