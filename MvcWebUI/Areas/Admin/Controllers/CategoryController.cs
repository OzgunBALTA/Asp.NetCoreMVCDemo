using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Asp.NetCoreMVCDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        ICategoryService _categoryManager;

        public CategoryController(ICategoryService categoryManager)
        {
            _categoryManager = categoryManager;
        }

        public IActionResult Index()
        {
            var result = _categoryManager.GetAll();
            return View(result.Data);
        }
    }
}
