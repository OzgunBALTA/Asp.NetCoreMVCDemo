using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsLetterController : ControllerBase
    {
        INewsLetterService _newsletterManager;

        public NewsLetterController(INewsLetterService newsletterManager)
        {
            _newsletterManager = newsletterManager;
        }

        [HttpGet("add")]
        public IActionResult Add(NewsLetter newsLetter) 
        {
            var result = _newsletterManager.Add(newsLetter);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
