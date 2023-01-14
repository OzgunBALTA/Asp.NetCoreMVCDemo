using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Entities.Concrete;
using FluentValidation.Results;
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

        CategoryValidator categoryValidator = new CategoryValidator();
        public IActionResult Index(int page = 1)
        {
            var result = _categoryManager.GetAll().Data.ToPagedList(page, 10);
            return View(result);
        }

        [HttpGet]
        public IActionResult AddCategory()
        {

            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            ValidationResult result = categoryValidator.Validate(category);
            if (result.IsValid)
            {
                category.CategoryStatus = true;
                _categoryManager.Add(category);
                return RedirectToAction("Index", "Category");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }

        public IActionResult ChangeCategoryStatus(int id)
        {
            var category = _categoryManager.GetByID(id).Data;
            _categoryManager.ChangeCategoryStatus(category);
            return RedirectToAction("Index", "Category");
        }
    }
}
