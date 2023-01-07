using Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class NotificationController : Controller
    {
        INotificationService _notificationManager;

        public NotificationController(INotificationService notificationManager)
        {
            _notificationManager = notificationManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAllNotifications()
        {
            var result = _notificationManager.GetAll();
            return View(result.Data);
        }
    }
}
