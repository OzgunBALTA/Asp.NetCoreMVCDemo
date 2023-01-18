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

		public IViewComponentResult Invoke(int id)
		{
			var result = _blogManager.GetBlogListByUserId(id);
			return View(result.Data);
		}
	}
}
