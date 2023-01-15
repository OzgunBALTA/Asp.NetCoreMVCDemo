using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MvcWebUI.Areas.Admin.ViewComponents.Widgets
{
    public class TotalUserCountWidget : ViewComponent
    {
        IUserService _userManager;

        public TotalUserCountWidget(IUserService userManager)
        {
            _userManager = userManager;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.TotalUserCount = _userManager.GetAll().Count;
            return View();
        }
    }
}
