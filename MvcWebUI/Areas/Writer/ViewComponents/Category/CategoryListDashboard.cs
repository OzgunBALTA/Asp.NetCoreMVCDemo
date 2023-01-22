using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MvcWebUI.Areas.Writer.ViewComponents.Category
{
    public class CategoryListDashboard : ViewComponent
    {
        ICategoryService _categoryManager;

        public CategoryListDashboard(ICategoryService categoryManager)
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
