using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
	public class ContactController : Controller
	{
		IContactService _contactManager;

		public ContactController(IContactService contactManager)
		{
			_contactManager = contactManager;
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Index(Contact contact)
		{
			contact.ContectDate = DateTime.Parse(DateTime.Now.ToShortDateString());
			contact.ContectStatus = true;
			_contactManager.Add(contact);
			return RedirectToAction("Index", "Blog");
		}
	}
}
