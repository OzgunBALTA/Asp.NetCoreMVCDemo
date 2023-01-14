using Microsoft.AspNetCore.Mvc;

namespace Asp.NetCoreMVCDemo.Areas.Admin.ViewComponents
{
    public class AdminNavbar : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
