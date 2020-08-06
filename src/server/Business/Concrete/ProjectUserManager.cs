using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Dtos.ProjectUser;
using System;

namespace Business.Concrete
{
    public class ProjectUserManager : IProjectUserService
    {
        IProjectUserDal _projectUserDal;

        public ProjectUserManager(IProjectUserDal projectUserDal)
        {
            _projectUserDal = projectUserDal;
        }

        public IDataResult<Guid> Add(ProjectUserAddDto projectUser, Guid owner)
        {
            var projectUserId = Guid.NewGuid();
            _projectUserDal.Add(new Entities.Concrete.ProjectUser
            {
                Id = projectUserId,
                ProjectId = projectUser.ProjectId,
                UserId = projectUser.UserId
            });
            
            return new SuccessDataResult<Guid>(projectUserId);
        }

        public IResult Delete(ProjectUserDeleteDto projectUser, Guid owner)
        {
            var _projectUser = _projectUserDal.Get(z => z.Id == projectUser.Id);
            if (_projectUser == null)
                return new ErrorResult("Project user definition not found");
            _projectUserDal.Delete(_projectUser);
            
            return new SuccessResult();
        }
    }
}
