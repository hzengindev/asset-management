using Business.Abstract;
using Entities.Dtos.Project;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WebAPI.Responses;

namespace WebAPI.Controllers
{
    public class ProjectController : BaseApiController
    {
        IProjectService _projectService;
        public ProjectController(IProjectService projectService, IHttpContextAccessor _context) : base(_context)
        {
            _projectService = projectService;
        }

        [SwaggerResponse(200, type: typeof(CreateResponse))]
        [HttpPost("add")]
        public IActionResult Add([FromBody] ProjectAddDto value)
        {
            var addResult = _projectService.Add(value, base._Id.Value);
            
            if (!addResult.Success)
                return Error(addResult.Message, addResult.Code);

            return Success(new CreateResponse { Id = addResult.Data });
        }

        [HttpPost("update")]
        public IActionResult Update([FromBody] ProjectUpdateDto value)
        {
            var updateResult = _projectService.Update(value, base._Id.Value);

            if (!updateResult.Success)
                return Error(updateResult.Message, updateResult.Code);

            return Success();
        }

        [HttpPost("delete")]
        public IActionResult Delete([FromBody] ProjectDeleteDto value)
        {
            var deleteResult = _projectService.Delete(value, base._Id.Value);

            if (!deleteResult.Success)
                return Error(deleteResult.Message, deleteResult.Code);

            return Success();
        }
    }
}