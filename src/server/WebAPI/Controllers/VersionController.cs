using Business.Abstract;
using Entities.Dtos.Version;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using WebAPI.Responses;

namespace WebAPI.Controllers
{
    [Route("api/version")]
    public class VersionController : BaseApiController
    {
        IVersionService _versionService;
        public VersionController(IVersionService versionService, IHttpContextAccessor _context) : base(_context)
        {
            _versionService = versionService;
        }

        [SwaggerResponse(200, type: typeof(CreateResponse))]
        [HttpPost("add")]
        public IActionResult Add([FromBody] VersionAddDto value)
        {
            var addResult = _versionService.Add(value, base._Id.Value);
            
            if (!addResult.Success)
                return Error(addResult.Message, addResult.Code);

            return Success(new CreateResponse { Id = addResult.Data });
        }

        [HttpPost("update")]
        public IActionResult Update([FromBody] VersionUpdateDto value)
        {
            var updateResult = _versionService.Update(value, base._Id.Value);

            if (!updateResult.Success)
                return Error(updateResult.Message, updateResult.Code);

            return Success();
        }

        [HttpPost("delete")]
        public IActionResult Delete([FromBody] VersionDeleteDto value)
        {
            var deleteResult = _versionService.Delete(value, base._Id.Value);

            if (!deleteResult.Success)
                return Error(deleteResult.Message, deleteResult.Code);

            return Success();
        }

        [HttpPost("add-files/{versionId}")]
        public IActionResult AddFiles(IFormFile file, [FromRoute] Guid versionId)
        {
            if (file == null || file.Length == 0)
                return Error("Content is null");

            string fileName = file.FileName;
            string fileMimeType = file.ContentType;
            byte[] bytes;
            using (var memoryStream = new System.IO.MemoryStream())
            {
                file.CopyTo(memoryStream);
                bytes = memoryStream.ToArray();
            }

            var saveVersionFileResult = _versionService.SaveVersionFile(new SaveVersionFileDto
            {
                VersionId = versionId,
                Filename = fileName,
                FileMimeType = fileMimeType,
                File = bytes
            }, base._Id.Value);

            if (!saveVersionFileResult.Success)
                return Error(saveVersionFileResult.Message, saveVersionFileResult.Code);

            return Success();
        }
    }
}