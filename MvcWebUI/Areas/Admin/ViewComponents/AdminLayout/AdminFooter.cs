using Microsoft.AspNetCore.Mvc;

namespace MvcWebUI.Areas.Admin.ViewComponents.AdminLayout
{
    public class AdminFooter : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
