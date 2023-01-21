using Business.Abstract;
using Business.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        INotificationService _notificationManager;

        public NotificationController(INotificationService notificationManager)
        {
            _notificationManager = notificationManager;
        }

        [HttpPost("add")]
        public IActionResult Add(Notification notification)
        {
            var result = _notificationManager.Add(notification);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(int id)
        {
            var notification = _notificationManager.GetByID(id).Data;
            var result = _notificationManager.Delete(notification);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Notification notification)
        {
            var result = _notificationManager.Update(notification);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _notificationManager.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetByID(int id)
        {
            var result = _notificationManager.GetByID(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getlastnotification")]
        public IActionResult GetLastNotification()
        {
            var result = _notificationManager.GetLastNotification();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
