using Business.Abstract;
using Business.Constants.DefaultValues;
using Business.Constants.Messages;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Jwt;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        [ValidationAspect(typeof(RegisterValidator))]
        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto)
        {
            var defaultImage = DefaultValues.DefaultImagePath;
            var defaultUserAbout = DefaultValues.DefaultUserAbout;
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                UserImage = defaultImage,
                UserAbout = defaultUserAbout,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user, Messages.UserRegistered);
        }

        public IDataResult<User> CreateUser(UserForCreateDto userForCreateDto)
        {
            BusinessRules.Run(GetDefaultUserImage(userForCreateDto), GetDefaultUserAbout(userForCreateDto));
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userForCreateDto.Password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = userForCreateDto.Email,
                FirstName = userForCreateDto.FirstName,
                LastName = userForCreateDto.LastName,
                UserImage = userForCreateDto.UserImage,
                UserAbout = userForCreateDto.UserAbout,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user, Messages.UserRegistered);
        }

        public IDataResult<User> UpdateUser(UserForUpdateDto userForUpdateDto)
        {
            BusinessRules.Run(GetDefaultUserImage(userForUpdateDto), GetDefaultUserAbout(userForUpdateDto));
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userForUpdateDto.Password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Id = userForUpdateDto.UserId,
                Email = userForUpdateDto.Email,
                FirstName = userForUpdateDto.FirstName,
                LastName = userForUpdateDto.LastName,
                UserAbout = userForUpdateDto.UserAbout,
                UserImage = userForUpdateDto.UserImage,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userService.Update(user);
            return new SuccessDataResult<User>(user, Messages.UserUpdated);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetUserByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }

            return new SuccessDataResult<User>(userToCheck, Messages.SuccessfulLogin);
        }

        public IResult UserExists(string email)
        {
            if (_userService.GetUserByMail(email) != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }

        private IResult CheckIfValueNull(object value)
        {
            if (value == null)
            {
                return new SuccessResult();
            }

            return new ErrorResult();
        }

        private IResult GetDefaultUserImage(UserBase userBase)
        {
            var checkIfUserImageNull = CheckIfValueNull(userBase.UserImage);
            if (checkIfUserImageNull.Success)
            {
                userBase.UserImage = DefaultValues.DefaultImagePath;
                return new SuccessResult();
            }

            return new SuccessResult();
        }

        private IResult GetDefaultUserAbout(UserBase userBase)
        {
            var checkIfUserAboutNull = CheckIfValueNull(userBase.UserAbout);
            if (checkIfUserAboutNull.Success)
            {
                userBase.UserAbout = DefaultValues.DefaultUserAbout;
                return new SuccessResult();
            }

            return new SuccessResult();
        }
    }
}
