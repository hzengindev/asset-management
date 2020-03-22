using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        [NonAction]
        public IActionResult Success(object data = default(object))
        {
            return Ok(data);
        }

        [NonAction]
        public IActionResult Error(string errorMessage = default(string), int? errorCode = (int?)null, object data = default(object))
        {
            return BadRequest(new
            {
                ErrorMessage = errorMessage,
                ErrorCode = errorCode,
            });
        }
    }
}