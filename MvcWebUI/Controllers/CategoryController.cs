using Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
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
