using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Blog
{
    public class BlogLast3Posts : ViewComponent
    {
        IBlogService _blogManager;

        public BlogLast3Posts(IBlogService blogManager)
        {
            _blogManager = blogManager;
        }

        public IViewComponentResult Invoke()
        {
            var result = _blogManager.GetLast3Blogs();
            return View(result.Data);
        }
    }
}
