using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Dtos.Version;
using System;
using System.Collections.Generic;

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
            var directoryPath = $"/version-files/project_{version.ProjectId}__version_{versionId}";
            _versionDal.Add(new Entities.Concrete.Version
            {
                Id = versionId,
                Name = version.Name,
                Description = version.Description,
                CustomerId = version.CustomerId,
                ProjectId = version.ProjectId,
                PreviewFile = null,
                DirectoryPath = directoryPath,
                CreatedBy = owner,
                ModifiedBy = owner,
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now,
                StateCode = Entities.Concrete.VersionStateTypes.Active,
                StatusCode = Entities.Concrete.VersionStatusTypes.Active
            });
            CreateVersionFilesDirectory(directoryPath);

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

        public IResult SaveVersionFile(SaveVersionFileDto value, Guid owner)
        {
            var version = _versionDal.Get(z => z.Id == value.VersionId);
            var path = $"{AppDomain.CurrentDomain.BaseDirectory}/{version.DirectoryPath}/{value.Filename}";
            System.IO.File.WriteAllBytes(path, value.File);

            return new SuccessResult();
        }

        public IResult Update(VersionUpdateDto version, Guid owner)
        {
            var _version = _versionDal.Get(z => z.Id == version.Id);
            if (_version == null)
                return new ErrorResult("Version definition not found");

            var directoryPath = $"/version-files/project_{version.ProjectId}__version_{_version.Id}";
            _versionDal.Update(new Entities.Concrete.Version
            {
                Id = _version.Id,
                Name = version.Name,
                Description = version.Description,
                CustomerId = version.CustomerId,
                ProjectId = version.ProjectId,
                PreviewFile = null,
                DirectoryPath = directoryPath,
                CreatedBy = _version.CreatedBy,
                ModifiedBy = owner,
                CreatedOn = _version.CreatedOn,
                ModifiedOn = DateTime.Now,
                StateCode = version.StateCode,
                StatusCode = version.StatusCode
            });
            CreateVersionFilesDirectory(directoryPath);

            return new SuccessResult();
        }

        private void CreateVersionFilesDirectory(string path)
        {
            System.IO.Directory.CreateDirectory($"{AppDomain.CurrentDomain.BaseDirectory}{path}");
        }
    }
}
