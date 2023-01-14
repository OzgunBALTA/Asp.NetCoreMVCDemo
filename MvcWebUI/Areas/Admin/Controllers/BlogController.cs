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
            return View();
        }

        public IActionResult ExportBlogListExcel()
        {
            var file = _blogManager.GetAll().Data;
            var filePath = @"C:\Users\ozgun\Desktop\Excel";
            var fileName = "Blogs.xlsx";
            _exportHelper.Export(file, filePath, fileName);
            return View();
        }
    }
}
