using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants.Messages;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CommentManager : ICommentService
    {
        ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        [CacheRemoveAspect("ICommentService.Get")]
        public IResult Add(Comment comment)
        {
            _commentDal.Add(comment);
            return new SuccessResult(Messages.CommentAdded);
        }

        [SecuredOperation("Admin, Writer")]
        [CacheRemoveAspect("ICommentService.Get")]
        public IResult Delete(Comment comment)
        {
            _commentDal.Delete(comment);
            return new SuccessResult(Messages.CommentDeleted);
        }

        [CacheAspect]
        public IDataResult<List<Comment>> GetAll()
        {
            return new SuccessDataResult<List<Comment>>(_commentDal.GetAll());
        }

        [CacheAspect]
        public IDataResult<List<Comment>> GetAllByBlogID(int id)
        {
            return new SuccessDataResult<List<Comment>>(_commentDal.GetAll(c => c.BlogID == id));
        }

        [CacheAspect]
        public IDataResult<Comment> GetByID(int id)
        {
            return new SuccessDataResult<Comment>(_commentDal.Get(c => c.CommentID == id));
        }

        [CacheAspect]
        public IDataResult<List<Comment>> GetCommentListByBlogId(int id)
        {
            return new SuccessDataResult<List<Comment>>(_commentDal.GetAll(x => x.BlogID == id));
        }

        [SecuredOperation("Admin")]
        [CacheRemoveAspect("ICommentService.Get")]
        public IResult Update(Comment comment)
        {
            _commentDal.Update(comment);
            return new SuccessResult(Messages.CommentUpdated);
        }
    }
}
