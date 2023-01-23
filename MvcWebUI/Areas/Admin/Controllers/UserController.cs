using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MvcWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        IUserService _userManager;

        public UserController(IUserService userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var result = _userManager.GetUserListWithClaim();
            return View(result);
        }
    }
}
