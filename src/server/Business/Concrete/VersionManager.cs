using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Dtos.Version;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Business.Concrete
{
    public class VersionManager : IVersionService
    {
        IVersionDal _versionDal;
        public VersionManager(IVersionDal versionDal)
        {
            _versionDal = versionDal;
        }

        public IDataResult<Guid> Add(VersionAddDto version, Guid owner)
        {
            var versionId = Guid.NewGuid();
            _versionDal.Add(new Entities.Concrete.Version
            {
                Id = versionId,
                Name = version.Name,
                Description = version.Description,
                CustomerId = version.CustomerId,
                ProjectId = version.ProjectId,
                PreviewFile = null, //TODO:
                DirectoryPath = null, //TODO:
                CreatedBy = owner,
                ModifiedBy = owner,
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now,
                StateCode = Entities.Concrete.VersionStateTypes.Active,
                StatusCode = Entities.Concrete.VersionStatusTypes.Active
            });

            return new SuccessDataResult<Guid>(versionId);
        }

        public IResult Delete(VersionDeleteDto version, Guid owner)
        {
            var _version = _versionDal.Get(z => z.Id == version.Id);
            if (_version == null)
                return new ErrorResult("Version definition not found");
            _versionDal.Delete(_version);

            return new SuccessResult();
        }

        public IDataResult<IList<Entities.Concrete.Version>> GetByProjectId(Guid projectId)
        {
            var versions = _versionDal.GetList(z => z.ProjectId == projectId);
            return new SuccessDataResult<IList<Entities.Concrete.Version>>(versions);
        }

        public IResult Update(VersionUpdateDto version, Guid owner)
        {
            var _version = _versionDal.Get(z => z.Id == version.Id);
            if (_version == null)
                return new ErrorResult("Version definition not found");

            _versionDal.Update(new Entities.Concrete.Version
            {
                Id = _version.Id,
                Name = version.Name,
                Description = version.Description,
                CustomerId = version.CustomerId,
                ProjectId = version.ProjectId,
                PreviewFile = null, //TODO:
                DirectoryPath = null, //TODO:
                CreatedBy = _version.CreatedBy,
                ModifiedBy = owner,
                CreatedOn = _version.CreatedOn,
                ModifiedOn = DateTime.Now,
                StateCode = version.StateCode,
                StatusCode = version.StatusCode
            });

            return new SuccessResult();
        }
    }
}
