using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos.Auth;
using System;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> SignIn(SignInDto value);
        IDataResult<List<string>> GetClaims(Guid userId);
    }
}