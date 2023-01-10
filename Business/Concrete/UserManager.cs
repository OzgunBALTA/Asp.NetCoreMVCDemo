﻿using Business.Abstract;
using Business.Constants.DefaultValues;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        public User GetById(int id)
        {
            return _userDal.Get(u => u.Id == id);
        }

        public User GetUserByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }

        public void Update(User user)
        {
            _userDal.Update(user);
        }

        public UserForUpdateDto GetUserForUpdate(User user)
        {
            return _userDal.UserForUpdate(user);
        }

        public string GetUserImageByUserId(int id)
        {
            var result = _userDal.Get(x => x.Id == id).UserImage;
            return result;
        }

        public string GetUserAboutById(int id)
        {
            var result = _userDal.Get(x => x.Id == id).UserAbout;
            return result;
        }
    }
}