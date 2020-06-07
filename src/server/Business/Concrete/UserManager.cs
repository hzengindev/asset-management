using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Localizations;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstract;
using Entities.Dtos.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IDataResult<Guid> Add(UserAddDto user, Guid owner)
        {
            string passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(user.Password, out passwordHash, out passwordSalt);

            var newUserId = Guid.NewGuid();
            _userDal.Add(new User
            {
                Id = newUserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                StateCode = UserStateTypes.Active,
                StatusCode = UserStatusTypes.Active,
                ModifiedBy = owner,
                ModifiedOn = DateTime.Now,
                CreatedBy = owner,
                CreatedOn = DateTime.Now
            });

            return new SuccessDataResult<Guid>(newUserId);
        }

        public IDataResult<User> Get(Guid userId)
        {
            var user = _userDal.Get(z => z.Id == userId);
            if (user == null)
                return new ErrorDataResult<User>(TextCode.UserNotFound);
            return new SuccessDataResult<User>(user);
        }

        public IDataResult<User> GetByEmail(string email)
        {
            var user = _userDal.Get(z => z.Email == email);
            if (user == null)
                return new ErrorDataResult<User>(TextCode.UserNotFound);
            return new SuccessDataResult<User>(user);
        }

        public IDataResult<User> GetByRefreshToken(string refreshToken)
        {
            var user = _userDal.Get(z => z.RefreshToken == refreshToken);
            if (user == null)
                return new ErrorDataResult<User>(TextCode.UserNotFound);
            if(user.RefreshTokenExpiryDate < DateTime.UtcNow)
                return new ErrorDataResult<User>(TextCode.RefreshTokenExpired);

            return new SuccessDataResult<User>(user);
        }

        public List<string> GetClaims(Guid userId)
        {
            return _userDal.GetClaims(userId);
        }

        public IResult SetRefreshToken(Guid userId, int refreshTokenExpiryMinutes, out string refreshToken, out DateTime refreshTokenExpiryDate)
        {
            refreshTokenExpiryDate = DateTime.Now.AddMinutes(refreshTokenExpiryMinutes);
            refreshToken = string.Empty;
            for (int i = 0; i < 25; i++)
                refreshToken += Guid.NewGuid().ToString().Replace("-", "").Trim();
            refreshToken = Convert.ToBase64String(Encoding.UTF8.GetBytes(refreshToken));

            var _user = _userDal.Get(z => z.Id == userId);
            _user.RefreshToken = refreshToken;
            _user.RefreshTokenExpiryDate = refreshTokenExpiryDate;
            _userDal.Update(_user);

            return new SuccessResult();
        }
    }
}