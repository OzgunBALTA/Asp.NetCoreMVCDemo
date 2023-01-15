using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MvcWebUI.Areas.Admin.ViewComponents.Widgets
{
    public class TotalCommentCountWidget : ViewComponent
    {
        ICommentService _commentManager;

        public TotalCommentCountWidget(ICommentService commentManager)
        {
            _commentManager = commentManager;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.TotalCommentCount = _commentManager.GetAll().Data.Count();
            return View();
        }
    }
}
