using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Blog
{
	public class WriterLastBlogs : ViewComponent
	{
		IBlogService _blogManager;

		public WriterLastBlogs(IBlogService blogManager)
		{
			_blogManager = blogManager;
		}

		public IViewComponentResult Invoke()
		{
			var result = _blogManager.GetBlogListByUserId(1);
			return View(result.Data);
		}
	}
}
