using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, BlogSiteContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new BlogSiteContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                             on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();

            }
        }

        public List<UserDetailsDto> UserDetails(User user)
        {
            using (var context = new BlogSiteContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                             on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new UserDetailsDto
                             {
                                 UserId = user.Id,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 Email = user.Email,
                                 UserImage = user.UserImage,
                                 UserAbout = user.UserAbout,
                                 Claim = operationClaim.Name
                             };
                return result.ToList();
            }
        }

        public UserForUpdateDto UserForUpdate(User user)
        {
            var result = new UserForUpdateDto 
            { 
                UserId = user.Id, 
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = null,
                UserAbout = user.UserAbout,
                UserImage = user.UserImage,
            };

            return result;
        }
    }
}
