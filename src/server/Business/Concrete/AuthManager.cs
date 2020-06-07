using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Entities.Concrete;
using Core.Utilities.Localizations;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Entities.Dtos.Auth;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        IUserService userService;
        public AuthManager(IUserService _userService)
        {
            userService = _userService;
        }

        public IDataResult<User> SignIn(SignInDto value)
        {
            var validator = new SignInDtoValidator();
            var results = validator.Validate(value);

            if (!results.IsValid)
                foreach (var failure in results.Errors)
                    Console.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);

            //TODO: fluentvalidation eklemeleri yapılacak
            if (string.IsNullOrEmpty(value.Email) || string.IsNullOrEmpty(value.Password))
                return new ErrorDataResult<User>("email or password is empty", 1);

            var user = userService.GetByEmail(value.Email);
            if(!user.Success)
                return new ErrorDataResult<User>(TextCode.UsernameOrPasswordIsWrong);

            if (!HashingHelper.VerifyPasswordHash(value.Password, user.Data.PasswordHash, user.Data.PasswordSalt))
                return new ErrorDataResult<User>(TextCode.UsernameOrPasswordIsWrong);

            return new SuccessDataResult<User>(user.Data);
        }

        public IDataResult<User> SignInRefreshToken(SignInRefreshTokenDto value)
        {
            if (string.IsNullOrEmpty(value.RefreshToken))
                return new ErrorDataResult<User>("refresh token is empty", 1);

            var user = userService.GetByRefreshToken(value.RefreshToken);
            return user;
        }

        public IDataResult<List<string>> GetClaims(Guid userId)
        {
            var rolePermissions = userService.GetClaims(userId);
            if(rolePermissions == null || !rolePermissions.Any())
                return new ErrorDataResult<List<string>>(TextCode.RolePermissionNotFound);
            return new SuccessDataResult<List<string>>(rolePermissions);
        }

        
    }
}