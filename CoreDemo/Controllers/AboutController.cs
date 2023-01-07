using Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
	public class AboutController : Controller
	{
		IAboutService _aboutManager;

		public AboutController(IAboutService aboutManager)
		{
			_aboutManager = aboutManager;
		}

		public IActionResult Index()
		{
			var result = _aboutManager.GetAll();
			return View(result.Data);
		}

		public PartialViewResult SocialMediaAbout()
		{
			return PartialView();
		}
	}
}
