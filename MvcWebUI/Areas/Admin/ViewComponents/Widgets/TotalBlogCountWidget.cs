using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MvcWebUI.Areas.Admin.ViewComponents.Widgets
{
    public class TotalBlogCountWidget : ViewComponent
    {
        IBlogService _blogManager;

        public TotalBlogCountWidget(IBlogService blogManager)
        {
            _blogManager = blogManager;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.TotalBlogCount = _blogManager.GetAll().Data.Count;
            return View();
        }
    }
}
