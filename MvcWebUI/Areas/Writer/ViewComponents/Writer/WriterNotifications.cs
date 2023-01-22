using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterNotifications : ViewComponent
    {
        INotificationService _notificationManager;

        public WriterNotifications(INotificationService natificationManager)
        {
            _notificationManager = natificationManager;
        }

        public IViewComponentResult Invoke()
        {
            var result = _notificationManager.GetAll();
            return View(result.Data);
        }
    }
}
