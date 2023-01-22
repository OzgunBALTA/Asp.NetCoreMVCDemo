using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using FluentValidation.Results;

namespace MvcWebUI.Areas.Writer.Controllers
{
    [Area("Writer")]
    public class BlogController : Controller
    {
        IBlogService _blogManager;
        IUserService _userManager;
        ICategoryService _categoryManager;

        public BlogController(IBlogService blogManager, IUserService userManager, ICategoryService categoryManager)
        {
            _blogManager = blogManager;
            _userManager = userManager;
            _categoryManager = categoryManager;
        }

        BlogValidator _blogValidator = new BlogValidator();

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddBlog()
        {
            List<SelectListItem> categoryValues = (from x in _categoryManager.GetAll().Data
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.categoryValues = categoryValues;
            return View();
        }
        [HttpPost]
        public IActionResult AddBlog(Blog blog)
        {
            var email = User.Identity.Name;
            var user = _userManager.GetUserByMail(email);
            ValidationResult validationResults = _blogValidator.Validate(blog);
            if (validationResults.IsValid)
            {
                blog.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                blog.BlogStatus = true;
                blog.UserId = user.Id;
                blog.CategoryID = blog.CategoryID;
                _blogManager.Add(blog);
                return RedirectToAction("GetBlogListByWriter", "Blog");
            }

            else
            {
                foreach (var item in validationResults.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }

        public IActionResult ChangeBlogStatus(int id)
        {
            var blog = _blogManager.GetByID(id).Data;
            _blogManager.ChangeBlogStatus(blog);
            return RedirectToAction("GetBlogListByWriter", "Blog");
        }

        [HttpGet]
        public IActionResult UpdateBlog(int id)
        {
            var result = _blogManager.GetByID(id);
            List<SelectListItem> categoryValues = (from x in _categoryManager.GetAll().Data
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.categoryValues = categoryValues;
            return View(result.Data);
        }

        [HttpPost]
        public IActionResult UpdateBlog(Blog blog)
        {
            var email = User.Identity.Name;
            var user = _userManager.GetUserByMail(email);
            ValidationResult validationResults = _blogValidator.Validate(blog);
            if (validationResults.IsValid)
            {
                var initialValues = _blogManager.GetByID(blog.BlogID).Data;
                blog.BlogCreateDate = DateTime.Parse(initialValues.BlogCreateDate.ToShortDateString());
                blog.BlogStatus = true;
                blog.UserId = user.Id;
                _blogManager.Update(blog);
                return RedirectToAction("GetBlogListByWriter", "Blog");
            }

            else
            {
                foreach (var item in validationResults.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }

        public IActionResult GetBlogListByWriter()
        {
            var email = User.Identity.Name;
            var user = _userManager.GetUserByMail(email);
            var result = _blogManager.GetAllWithCategoryByWriter(user.Id);
            return View(result.Data);
        }
    }
}
