using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MvcWebUI.Areas.Admin.ViewComponents.Widgets
{
    public class LastNotificationWidget : ViewComponent
    {
        INotificationService _notificationManager;

        public LastNotificationWidget(INotificationService notificationManager)
        {
            _notificationManager = notificationManager;
        }

        public IViewComponentResult Invoke()
        {
            var result = _notificationManager.GetLastNotification();
            return View(result.Data);
        }
    }
}
