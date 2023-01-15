using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MvcWebUI.Areas.Admin.ViewComponents.Widgets
{
    public class LastUserWidget : ViewComponent
    {
        IUserService _userManager;

        public LastUserWidget(IUserService userManager)
        {
            _userManager = userManager;
        }

        public IViewComponentResult Invoke()
        {
            var result = _userManager.GetLastUser();
            return View(result);
        }
    }
}
