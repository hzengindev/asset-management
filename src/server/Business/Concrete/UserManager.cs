using Business.Abstract;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.User;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserRepository userRepository;
        private IUnitOfWork unitOfWork;

        public UserManager(IUserRepository _userRepository, IUnitOfWork _unitOfWork)
        {
            userRepository = _userRepository;
            unitOfWork = _unitOfWork;
        }

        public IDataResult<Guid> Register(UserRegisterDto user, Guid owner)
        {
            string passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(user.Password, out passwordHash, out passwordSalt);

            var newUserId = Guid.NewGuid();
            userRepository.Add(new User
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
            unitOfWork.SaveChanges();

            return new SuccessDataResult<Guid>(newUserId);
        }

        public IDataResult<User> Get(Guid userId)
        {
            var user = userRepository.Get(z => z.Id == userId);
            if (user == null)
                return new ErrorDataResult<User>("user not found", 1);
            return new SuccessDataResult<User>(user);
        }

        public IDataResult<User> GetByEmail(string email)
        {
            var user = userRepository.Get(z => z.Email == email);
            if (user == null)
                return new ErrorDataResult<User>("user not found", 1);
            return new SuccessDataResult<User>(user);
        }

        public List<string> GetClaims(Guid userId)
        {
            return userRepository.GetClaims(userId);
        }
    }
}