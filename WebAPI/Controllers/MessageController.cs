using Business.Abstract;
using Business.Concrete;
using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        IMessageService _messageManager;

        public MessageController(IMessageService messageManager)
        {
            _messageManager = messageManager;
        }

        [HttpPost("add")]
        public IActionResult Add(Message message)
        {
            var result = _messageManager.Add(message);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(int id)
        {
            var message = _messageManager.GetByMessageId(id).Data;
            var result = _messageManager.Delete(message);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbymessageid")]
        public IActionResult GetByMessageId(int id)
        {
            var result = _messageManager.GetByMessageId(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getmessageswithuserbyreciverid")]
        public IActionResult GetMessagesWithUserByReciverId(int id)
        {
            var result = _messageManager.GetMessagesWithUserByReciverId(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getmessageswithuserbysenderid")]
        public IActionResult GetMessagesWithUserBySenderId(int id)
        {
            var result = _messageManager.GetMessagesWithUserBySenderId(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getlast3messageswithuserbyreciverid")]
        public IActionResult GetLast3MessagesWithUserByReciverId(int id)
        {
            var result = _messageManager.GetLast3MessagesWithUserByReciverId(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getlast3messageswithuserbysenderid")]
        public IActionResult GetLast3MessageWithUsersBySenderId(int id)
        {
            var result = _messageManager.GetLast3MessageWithUsersBySenderId(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
