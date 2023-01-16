using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MvcWebUI.Areas.Admin.ViewComponents.AdminLayout
{
    public class AdminSidebar : ViewComponent
    {
        IUserService _userManager;

        public AdminSidebar(IUserService userManager)
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
