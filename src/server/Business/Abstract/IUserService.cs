using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Dtos.User;
using System;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<User> Get(Guid userId);
        IDataResult<User> GetByEmail(string email);
        IDataResult<User> GetByRefreshToken(string refreshToken);
        List<string> GetClaims(Guid userId);
        IDataResult<Guid> Add(UserAddDto user, Guid owner);
        IResult SetRefreshToken(Guid userId, int refreshTokenExpiryMinutes, out string refreshToken, out DateTime refreshTokenExpiryDate);
    }
}