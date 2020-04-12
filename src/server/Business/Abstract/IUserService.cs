using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos.User;
using System;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<User> Get(Guid userId);
        IDataResult<User> GetByEmail(string email);
        List<string> GetClaims(Guid userId);
        IDataResult<Guid> Register(UserRegisterDto user, Guid owner);
    }
}