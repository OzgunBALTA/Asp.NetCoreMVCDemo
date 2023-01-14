using Business.Abstract;
using Core.Utilities.Helpers.ExportHelper.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MvcWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        IBlogService _blogManager;
        IExportHelper _exportHelper;

        public BlogController(IBlogService blogManager, IExportHelper exportHelper)
        {
            _blogManager = blogManager;
            _exportHelper = exportHelper;
        }

        public IActionResult Index()
        {
            var result = _blogManager.GetAllWithCategory();
            return View(result.Data);
        }

        public IActionResult ExportBlogListExcel()
        {
            var file = _blogManager.GetAllWithCategory().Data;
            var filePath = @"C:\Users\ozgun\Desktop\Excel\";
            var fileName = "Blogs";
            _exportHelper.Export(file, filePath, fileName);
            return RedirectToAction("Index", "Blog");
        }

        public IActionResult ChangeBlogStatus(int id)
        {
            var blog = _blogManager.GetByID(id).Data;
            _blogManager.ChangeBlogStatus(blog);
            return RedirectToAction("Index", "Blog");
        }
    }
}
