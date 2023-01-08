using Microsoft.AspNetCore.Mvc;

namespace Asp.NetCoreMVCDemo.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
