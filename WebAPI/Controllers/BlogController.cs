using Business.Abstract;
using Business.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        IBlogService _blogManager;

        public BlogController(IBlogService blogManager)
        {
            _blogManager = blogManager;
        }

        [HttpPost("add")]
        public IActionResult Add(Blog blog)
        {
            var result = _blogManager.Add(blog);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("changeblogstatus")]
        public IActionResult Delete(int id)
        {
            var blog = _blogManager.GetByID(id).Data;
            var result = _blogManager.ChangeBlogStatus(blog);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Blog blog)
        {
            var result = _blogManager.Update(blog);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _blogManager.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetByID(int id)
        {
            var result = _blogManager.GetByID(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getallwithcategory")]
        public IActionResult GetAllWithCategory()
        {
            var result = _blogManager.GetAllWithCategory();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getallstatustruewithcategory")]
        public IActionResult GetAllStatusTrueWithCategory()
        {
            var result = _blogManager.GetAllStatusTrueWithCategory();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getlastblog")]
        public IActionResult GetLastBlog()
        {
            var result = _blogManager.GetLastBlog();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getlast3blog")]
        public IActionResult GetLast3Blogs()
        {
            var result = _blogManager.GetLast3Blogs();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbloglistbyuserid")]
        public IActionResult GetBlogListByUserId(int id)
        {
            var result = _blogManager.GetBlogListByUserId(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getallwithcategorybywriter")]
        public IActionResult GetAllWithCategoryByWriter(int id)
        {
            var result = _blogManager.GetAllWithCategoryByWriter(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbloglistbycategoryid")]
        public IActionResult GetBlogListByCategoryId(int id)
        {
            var result = _blogManager.GetBlogListByCategoryId(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("totalblogcount")]
        public IActionResult TotalBlogCount()
        {
            var result = _blogManager.TotalBlogCount();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("writertotalblogcount")]
        public IActionResult WriterTotalBlogCount(int id)
        {
            var result = _blogManager.WriterTotalBlogCount(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
