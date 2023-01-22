using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using MvcWebUI.Areas.Admin.Models.Charts;

namespace MvcWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MetricController : Controller
    {
        ICategoryService _categoryManager;
        IBlogService _blogService;

        public MetricController(ICategoryService categoryManager, IBlogService blogService)
        {
            _categoryManager = categoryManager;
            _blogService = blogService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult BlogCountInCategoryChart()
        {
            List<ChartsModel> charts = new List<ChartsModel>();
            var categories = _categoryManager.GetAll().Data;
            foreach (var item in categories)
            {
                ChartsModel CategoryChartModel = new ChartsModel();
                CategoryChartModel.CategoryName = item.CategoryName;
                CategoryChartModel.TCountInCategory = _blogService.GetBlogListByCategoryId(item.CategoryID).Data.Count;
                charts.Add(CategoryChartModel);
            }

            return Json(new { jsonList = charts });
        }
    }
}
