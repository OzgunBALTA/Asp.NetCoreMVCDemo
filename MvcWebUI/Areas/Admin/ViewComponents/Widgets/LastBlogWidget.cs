using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MvcWebUI.Areas.Admin.ViewComponents.Widgets
{
    public class LastBlogWidget : ViewComponent
    {
        IBlogService _blogManager;

        public LastBlogWidget(IBlogService blogManager)
        {
            _blogManager = blogManager;
        }

        public IViewComponentResult Invoke()
        {
            var result = _blogManager.GetLastBlog();
            return View(result.Data);
        }
    }
}
