using Microsoft.AspNetCore.Mvc;

namespace Asp.NetCoreMVCDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
