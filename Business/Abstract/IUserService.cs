using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Entities.DTOs;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        List<OperationClaim> GetClaims(User user);
        void Add(User user);
        User GetUserByMail(string email);
        User GetById(int id);
        void Update(User user);
        UserForUpdateDto GetUserForUpdate(User user);
        string GetUserImageByUserId(int id);
        string GetUserAboutById(int id);
    }
}
