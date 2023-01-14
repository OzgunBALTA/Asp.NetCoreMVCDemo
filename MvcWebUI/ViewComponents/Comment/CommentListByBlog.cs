using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Comment
{
    public class CommentListByBlog : ViewComponent
    {
        ICommentService _commentManager;

        public CommentListByBlog(ICommentService commentManager)
        {
            _commentManager = commentManager;
        }

        public IViewComponentResult Invoke(int id)
        {
            var result = _commentManager.GetAllByBlogID(id);
            return View(result.Data);
        }
    }
}
