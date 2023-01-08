using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Asp.NetCoreMVCDemo.ViewComponents.Writer
{
    public class WriterNavbar : ViewComponent
    {
        IUserService _userManager;

        public WriterNavbar(IUserService userManager)
        {
            _userManager = userManager;
        }

        public IViewComponentResult Invoke()
        {
            var email = User.Identity.Name;
            var user = _userManager.GetUserByMail(email);
            return View(user);
        }
    }
}
