using Business.Abstract;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Entities.Concrete;
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
            //TODO: fluentvalidation eklemeleri yapılacak
            if (string.IsNullOrEmpty(value.Email) || string.IsNullOrEmpty(value.Password))
                return new ErrorDataResult<User>("email or password is empty", 1);

            var user = userService.GetByEmail(value.Email);
            if(!user.Success)
                return new ErrorDataResult<User>("user not found", 1);

            if (!HashingHelper.VerifyPasswordHash(value.Password, user.Data.PasswordHash, user.Data.PasswordSalt))
                return new ErrorDataResult<User>("password is wrong", 1);

            return new SuccessDataResult<User>(user.Data);
        }

        public IDataResult<List<string>> GetClaims(Guid userId)
        {
            var rolePermissions = userService.GetClaims(userId);
            if(rolePermissions == null || !rolePermissions.Any())
                return new ErrorDataResult<List<string>>("role permission not found", 1);
            return new SuccessDataResult<List<string>>(rolePermissions);
        }
    }
}