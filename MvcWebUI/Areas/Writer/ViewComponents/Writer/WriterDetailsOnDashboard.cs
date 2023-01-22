using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterDetailsOnDashboard : ViewComponent
    {
        IUserService _userManager;

        public WriterDetailsOnDashboard(IUserService userManager)
        {
            _userManager = userManager;
        }

        public IViewComponentResult Invoke()
        {
            var email = User.Identity.Name;
            var user = _userManager.GetUserByMail(email);
            var result = _userManager.GetById(user.Id);
            return View(result);
        }
    }
}
