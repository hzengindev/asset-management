using Business.Abstract;
using Entities.Dtos.Version;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class VersionController : BaseApiController
    {
        IVersionService _versionService;
        public VersionController(IVersionService versionService, IHttpContextAccessor _context) : base(_context)
        {
            _versionService = versionService;
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody] VersionAddDto value)
        {
            var addResult = _versionService.Add(value, base._Id.Value);
            
            if (!addResult.Success)
                return Error(addResult.Message, addResult.Code);

            return Success(new { Id = addResult.Data });
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


    }
}