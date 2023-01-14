using Business.Constants.PathConstants;
using Core.Utilities.Helpers.FileHelper.Concrete;
using Entities.DTOs;

namespace CoreDemo.Models.UserForProfile
{
    public class UserProfileModel
    {
        FileHelper _fileHelper = new FileHelper();
        public UserForCreateDto AddUser(UserForCreateModel userForCreateModel)
        {
            UserForCreateDto userForCreateDto = new UserForCreateDto();
            var userImage = _fileHelper.Upload(userForCreateModel.UserImage, PathConstants.ImagesPath);
            userForCreateDto.Email = userForCreateModel.Email;
            userForCreateDto.Password = userForCreateModel.Password;
            userForCreateDto.FirstName = userForCreateModel.FirstName;
            userForCreateDto.LastName = userForCreateModel.LastName;
            userForCreateDto.UserImage = userImage;
            userForCreateDto.UserAbout = userForCreateModel.UserAbout;
            return userForCreateDto;
        }
        public UserForUpdateDto UpadateUserProfile(UserForUpdateModel userForUpdateModel)
        {
            UserForUpdateDto userForUpdateDto = new UserForUpdateDto();
            var userImage = _fileHelper.Upload(userForUpdateModel.UserImage, PathConstants.ImagesPath);
            userForUpdateDto.UserId = userForUpdateModel.UserId;
            userForUpdateDto.Email = userForUpdateModel.Email;
            userForUpdateDto.Password = userForUpdateModel.Password;
            userForUpdateDto.FirstName = userForUpdateModel.FirstName;
            userForUpdateDto.LastName = userForUpdateModel.LastName;
            userForUpdateDto.UserImage = userImage;
            userForUpdateDto.UserAbout = userForUpdateModel.UserAbout;
            return userForUpdateDto;
        }
    }
}
