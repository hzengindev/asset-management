using Business.Abstract;
using Entities.Dtos.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class UserController : BaseApiController
    {
        IUserService userService;
        public UserController(IUserService _userService, IHttpContextAccessor _context):base(_context)
        {
            userService = _userService;
        }

        [HttpGet("get")]
        public IActionResult Get()
        {
            var getResult = userService.Get(base._Id.Value);

            if (!getResult.Success)
                return Error(getResult.Message, getResult.Code);

            return Success(new {
                getResult.Data.Id,
                getResult.Data.Email,
                getResult.Data.FirstName,
                getResult.Data.LastName,
                getResult.Data.StateCode,
                getResult.Data.StatusCode
            });
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody] UserAddDto value)
        {
            var addResult = userService.Add(value, base._Id.Value);

            if (!addResult.Success)
                return Error(addResult.Message, addResult.Code);

            return Success(new { Id = addResult.Data });
        }
    }
}