using Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class MessageController : Controller
    {
        IMessageService _messageManager;
        IUserService _userManager;

        public MessageController(IMessageService messageService, IUserService userManager)
        {
            _messageManager = messageService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAllByReciverId()
        {
            var email = User.Identity.Name;
            var user = _userManager.GetUserByMail(email);
            var result = _messageManager.GetMessagesWithUserByReciverId(user.Id);
            return View(result.Data);
        }

        public IActionResult GetAllBySenderId(int id)
        {
            var email = User.Identity.Name;
            var user = _userManager.GetUserByMail(email);
            var result = _messageManager.GetMessagesWithUserBySenderId(user.Id);
            return View(result.Data);
        }

        public IActionResult GetMessageById(int id)
        {
            var result = _messageManager.GetByMessageId(id);
            return View(result.Data);
        }
    }
}
