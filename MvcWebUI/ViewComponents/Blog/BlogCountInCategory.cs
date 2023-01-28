using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MvcWebUI.ViewComponents.Blog
{
    public class BlogCountInCategory : ViewComponent
    {
        IBlogService _blogManager;

        public BlogCountInCategory(IBlogService blogManager)
        {
            _blogManager = blogManager;
        }

        public IViewComponentResult Invoke(int id)
        {
            ViewBag.BlogCount = _blogManager.GetBlogListByCategoryId(id).Data.Count;
            return View();
        }
    }
}
