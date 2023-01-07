namespace CoreDemo.Models.UserForProfile
{
    public class UserForUpdateModel
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IFormFile UserImage { get; set; }
        public string UserAbout { get; set; }
    }
}
