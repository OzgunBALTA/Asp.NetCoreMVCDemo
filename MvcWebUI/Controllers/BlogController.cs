using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Entities.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoreDemo.Controllers
{
    public class BlogController : Controller
    {
        IBlogService _blogManager;
        ICategoryService _categoryManager;
        IUserService _userManager;
        public BlogController(IBlogService blogManager, ICategoryService categoryManager, IUserService userManager)
        {
            _blogManager = blogManager;
            _categoryManager = categoryManager;
            _userManager = userManager;
        }

        BlogValidator _blogValidator = new BlogValidator();

        public IActionResult Index()
        {
            var result = _blogManager.GetAllStatusTrueWithCategory();
            return View(result.Data);
        }

        public IActionResult BlogReadAll(int id)
        {
            var result = _blogManager.GetBlogListById(id);
            ViewBag.blogId = id;
            ViewBag.userId = result.Data[0].UserId;
            return View(result.Data);
        }
    }
}
