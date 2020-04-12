using Business.Abstract;
using Core.Utilities.Security.Jwt;
using Entities.Dtos.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class AuthController : BaseApiController
    {
        IAuthService authService;
        ITokenHelper tokenHelper;
        public AuthController(IAuthService _authService, ITokenHelper _tokenHelper, IHttpContextAccessor _context):base(_context)
        {
            authService = _authService;
            tokenHelper = _tokenHelper;
        }

        [AllowAnonymous]
        [HttpPost("signin")]
        public IActionResult SignIn([FromBody] SignInDto value)
        {
            var signInResult = authService.SignIn(value);

            if (!signInResult.Success)
                return Error(signInResult.Message, signInResult.Code);

            var claims = authService.GetClaims(signInResult.Data.Id);
            var returnValue = tokenHelper.CreateToken(signInResult.Data, claims.Data);
            return Success(returnValue);
        }


    }
}