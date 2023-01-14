using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterMessageNotifications : ViewComponent
    {
        IMessageService _messageManager;
        IUserService _userManager;
        public WriterMessageNotifications(IMessageService messageManager, IUserService userManager)
        {
            _messageManager = messageManager;
            _userManager = userManager;
        }

        public IViewComponentResult Invoke()
        {
            var email = User.Identity.Name;
            var user = _userManager.GetUserByMail(email);
            var result = _messageManager.GetLast3MessagesWithUserByReciverId(user.Id);
            return View(result.Data);
        }
    }
}
