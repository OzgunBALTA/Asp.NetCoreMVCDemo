using Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class DashboardController : Controller
    {
        IBlogService _blogManager;
        ICategoryService _categoryManager;
        IUserService _userManager;

        public DashboardController(IBlogService blogManager, ICategoryService categoryManager, IUserService userManager)
        {
            _blogManager = blogManager;
            _categoryManager = categoryManager;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var email = User.Identity.Name;
            var user = _userManager.GetUserByMail(email);
            ViewBag.totalBlogCount = _blogManager.TotalBlogCount().Data;
            ViewBag.writerTotalBlogCount = _blogManager.WriterTotalBlogCount(user.Id).Data;
            ViewBag.totalCategoryCount = _categoryManager.TotalCategoryCount().Data;
            return View();
        }
    }
}
