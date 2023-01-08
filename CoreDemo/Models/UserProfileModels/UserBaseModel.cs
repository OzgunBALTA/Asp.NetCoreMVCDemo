namespace Asp.NetCoreMVCDemo.Models.UserProfileModels
{
    public class UserBaseModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IFormFile UserImage { get; set; }
        public string UserAbout { get; set; }
    }
}
