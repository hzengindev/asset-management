using Business.Abstract;
using Entities.Dtos.Project;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class ProjectController : BaseApiController
    {
        IProjectService _projectService;
        public ProjectController(IProjectService projectService, IHttpContextAccessor _context) : base(_context)
        {
            _projectService = projectService;
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody] ProjectAddDto value)
        {
            var addResult = _projectService.Add(value, base._Id.Value);
            
            if (!addResult.Success)
                return Error(addResult.Message, addResult.Code);

            return Success(new { Id = addResult.Data });
        }

        [HttpPost("update")]
        public IActionResult Update([FromBody] ProjectUpdateDto value)
        {
            var updateResult = _projectService.Update(value, base._Id.Value);

            if (!updateResult.Success)
                return Error(updateResult.Message, updateResult.Code);

            return Success();
        }


    }
}