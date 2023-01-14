using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class NewsLetterController : Controller
    {
        INewsLetterService _newsletterManager;

        public NewsLetterController(INewsLetterService newsletterManager)
        {
            _newsletterManager = newsletterManager;
        }

        [HttpGet]
        public PartialViewResult SubscribeMail()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult SubscribeMail(NewsLetter newsLetter)
        {
            newsLetter.MailStatus = true;
            _newsletterManager.Add(newsLetter);
            return RedirectToAction("Index", "Blog");
        }
    }
}
