using Business.Abstract;
using Core.Utilities.Security.Jwt;
using Entities.Dtos.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Controllers
{
    public class AuthController : BaseApiController
    {
        IAuthService _authService;
        IUserService _userService;
        ITokenHelper _tokenHelper;
        private TokenOptions _tokenOptions;

        public AuthController(IAuthService authService, ITokenHelper tokenHelper, IUserService userService, IConfiguration configuration, IHttpContextAccessor context):base(context)
        {
            _authService = authService;
            _tokenHelper = tokenHelper;
            _userService = userService;
            _tokenOptions = configuration.GetSection("tokenOptions").Get<TokenOptions>();
        }

        [AllowAnonymous]
        [SwaggerResponse(200, type: typeof(AccessToken))]
        [HttpPost("signin")]
        public IActionResult SignIn([FromBody] SignInDto value)
        {
            var signInResult = _authService.SignIn(value);

            if (!signInResult.Success)
                return Error(signInResult.Message, signInResult.Code);

            var claims = _authService.GetClaims(signInResult.Data.Id);
            var returnValue = _tokenHelper.CreateToken(signInResult.Data, claims.Data);
            _userService.SetRefreshToken(signInResult.Data.Id, _tokenOptions.RefreshTokenExpiryDate, out var refreshToken, out var refreshTokenExpiryDate);
            returnValue.RefreshToken = refreshToken;
            returnValue.RefreshTokenExpiryDate = refreshTokenExpiryDate;
            return Success(returnValue);
        }

        [AllowAnonymous]
        [SwaggerResponse(200, type: typeof(AccessToken))]
        [HttpPost("signin-refresh-token")]
        public IActionResult SignInRefreshToken([FromBody] SignInRefreshTokenDto value)
        {
            var signInResult = _authService.SignInRefreshToken(value);

            if (!signInResult.Success)
                return Error(signInResult.Message, signInResult.Code);

            var claims = _authService.GetClaims(signInResult.Data.Id);
            var returnValue = _tokenHelper.CreateToken(signInResult.Data, claims.Data);
            _userService.SetRefreshToken(signInResult.Data.Id, _tokenOptions.RefreshTokenExpiryDate, out var refreshToken, out var refreshTokenExpiryDate);
            returnValue.RefreshToken = refreshToken;
            returnValue.RefreshTokenExpiryDate = refreshTokenExpiryDate;
            return Success(returnValue);
        }
    }
}