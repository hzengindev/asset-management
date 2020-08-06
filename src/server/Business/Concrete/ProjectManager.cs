using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.Project;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class ProjectManager : IProjectService
    {
        IProjectDal _projectDal;
        IProjectUserService _projectUserService;
        IVersionService _versionService;
        
        public ProjectManager(IProjectDal projectDal, IProjectUserService projectUserService, IVersionService versionService)
        {
            _projectDal = projectDal;
            _projectUserService = projectUserService;
            _versionService = versionService;
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

        public IResult Delete(ProjectDeleteDto project, Guid owner)
        {
            var _project = _projectDal.Get(z => z.Id == project.Id);
            if (_project == null)
                return new ErrorResult("Project definition not found");

            var deleteResultProjectUser = DeleteProjectUsersByProject(project.Id, owner);
            if (!deleteResultProjectUser.Success)
                return new ErrorResult(deleteResultProjectUser.Message, deleteResultProjectUser.Code);

            var deleteResultVersions = DeleteVersionsByProject(project.Id, owner);
            if (!deleteResultVersions.Success)
                return new ErrorResult(deleteResultVersions.Message, deleteResultVersions.Code);

            _projectDal.Delete(_project);

            return new SuccessResult();
        }

        private IResult DeleteProjectUsersByProject(Guid projectId, Guid owner)
        {
            var projectUsers = _projectUserService.GetByProjectId(projectId);

            if (!projectUsers.Success)
                return new ErrorResult(projectUsers.Message, projectUsers.Code);

            if(projectUsers.Data != null && projectUsers.Data.Any())
                foreach (var item in projectUsers.Data)
                    _projectUserService.Delete(new Entities.Dtos.ProjectUser.ProjectUserDeleteDto { Id = item.Id }, owner);

            return new SuccessResult();
        }

        private IResult DeleteVersionsByProject(Guid projectId, Guid owner)
        {
            var versions = _versionService.GetByProjectId(projectId);
            if (!versions.Success)
                return new ErrorResult(versions.Message, versions.Code);

            if (versions.Data != null && versions.Data.Any())
                foreach (var item in versions.Data)
                    _versionService.Delete(new Entities.Dtos.Version.VersionDeleteDto { Id = item.Id }, owner);

            return new SuccessResult();
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

        public IDataResult<IList<Project>> GetByCustomerId(Guid customerId)
        {
            var projects = _projectDal.GetList(z => z.CustomerId == customerId);
            return new SuccessDataResult<IList<Entities.Concrete.Project>>(projects);
        }
    }
}
