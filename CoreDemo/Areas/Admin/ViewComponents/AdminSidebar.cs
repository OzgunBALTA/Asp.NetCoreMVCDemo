using Microsoft.AspNetCore.Mvc;

namespace Asp.NetCoreMVCDemo.Areas.Admin.ViewComponents
{
    public class AdminSidebar : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
