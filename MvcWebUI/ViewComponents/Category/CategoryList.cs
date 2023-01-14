using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Category
{
    public class CategoryList : ViewComponent
    {
        ICategoryService _categoryManager;

        public CategoryList(ICategoryService categoryManager)
        {
            _categoryManager = categoryManager;
        }

        public IViewComponentResult Invoke()
        {
            var result = _categoryManager.GetAll();
            return View(result.Data);
        }
    }
}
