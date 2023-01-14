using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;
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

        public IActionResult Index(int page = 1)
        {
            var result = _categoryManager.GetAll().Data.ToPagedList(page, 10);
            return View(result);
        }
    }
}
