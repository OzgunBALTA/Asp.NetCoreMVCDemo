using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Blog
{
    public class BlogListDashboard : ViewComponent
    {
        IBlogService _blogManager;

        public BlogListDashboard(IBlogService blogManager)
        {
            _blogManager = blogManager;
        }
        public IViewComponentResult Invoke()
        {
            var result = _blogManager.GetAllWithCategory();
            return View(result.Data);
        }
    }
}
