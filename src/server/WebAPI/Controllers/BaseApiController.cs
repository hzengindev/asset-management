using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        IHttpContextAccessor context;
        public BaseApiController(IHttpContextAccessor _context)
        {
            context = _context;
        }

        protected Guid? _Id
        {
            get =>
                context.HttpContext.User.Claims.Any(z => z.Type == ClaimTypes.NameIdentifier)
                ? new Guid(context.HttpContext.User.Claims.First(z => z.Type == ClaimTypes.NameIdentifier).Value) : (Guid?)null;
        }

        protected string _Name
        {
            get =>
                context.HttpContext.User.Claims.Any(z => z.Type == ClaimTypes.Name)
                ? context.HttpContext.User.Claims.First(z => z.Type == ClaimTypes.Name).Value : null;
        }

        protected string _Email
        {
            get =>
                context.HttpContext.User.Claims.Any(z => z.Type == ClaimTypes.Email)
                ? context.HttpContext.User.Claims.First(z => z.Type == ClaimTypes.Email).Value : null;
        }

        [NonAction]
        public IActionResult Success()
        {
            return Ok();
        }

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