using Business.Abstract;
using Entities.Dtos.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WebAPI.Responses;
using WebAPI.Responses.User;

namespace WebAPI.Controllers
{
    [Route("api/user")]
    public class UserController : BaseApiController
    {
        IUserService userService;
        public UserController(IUserService _userService, IHttpContextAccessor _context) : base(_context)
        {
            userService = _userService;
        }


        [SwaggerResponse(200, type: typeof(GetResponse))]
        [HttpGet("get")]
        public IActionResult Get()
        {
            var getResult = userService.Get(base._Id.Value);

            if (!getResult.Success)
                return Error(getResult.Message, getResult.Code);

            return Success(new GetResponse
            {
                Id = getResult.Data.Id,
                Email = getResult.Data.Email,
                FirstName = getResult.Data.FirstName,
                LastName = getResult.Data.LastName,
                StateCode = (short)getResult.Data.StateCode,
                StatusCode = (short)getResult.Data.StatusCode
            });
        }

        [SwaggerResponse(200, type: typeof(CreateResponse))]
        [HttpPost("add")]
        public IActionResult Add([FromBody] UserAddDto value)
        {
            var addResult = userService.Add(value, base._Id.Value);

            if (!addResult.Success)
                return Error(addResult.Message, addResult.Code);

            return Success(new CreateResponse { Id = addResult.Data });
        }
    }
}