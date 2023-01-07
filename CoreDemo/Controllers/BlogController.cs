using Business.Abstract;
using Business.Concrete;
using Business.ValidationRules.FluentValidation;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoreDemo.Controllers
{
    public class BlogController : Controller
    {
        IBlogService _blogManager;
        BlogValidator _blogValidator;
        ICategoryService _categoryManager;
        public BlogController(IBlogService blogManager, BlogValidator blogValidator, ICategoryService categoryManager)
        {
            _blogManager = blogManager;
            _blogValidator = blogValidator;
            _categoryManager = categoryManager;
        }

        public IActionResult Index()
        {
            var result = _blogManager.GetAllWithCategory();
            return View(result.Data);
        }

        public IActionResult BlogReadAll(int id)
        {
            ViewBag.i = id;
            var result = _blogManager.GetBlogListById(id);
            return View(result.Data);
        }
        public IActionResult GetBlogListByWriter(int id)
        {
            var result = _blogManager.GetAllWithCategoryByWriter(1);
            return View(result.Data);
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
            ValidationResult validationResults = _blogValidator.Validate(blog);
            if (validationResults.IsValid)
            {
                blog.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                blog.BlogStatus = true;
                blog.UserId = 1;
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
        public IActionResult DeleteBlog(int id)
        {
            var blog = _blogManager.GetByID(id).Data;
            _blogManager.Delete(blog);
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
            ValidationResult validationResults = _blogValidator.Validate(blog);
            if (validationResults.IsValid)
            {
                var initialValues = _blogManager.GetByID(blog.BlogID).Data;
                blog.BlogCreateDate = DateTime.Parse(initialValues.BlogCreateDate.ToShortDateString());
                blog.BlogStatus = true;
                blog.UserId = 1;
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
    }
}
