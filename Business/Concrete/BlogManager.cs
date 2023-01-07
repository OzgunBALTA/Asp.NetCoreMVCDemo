using Business.Abstract;
using Business.Constants.Messages;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
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
    public class BlogManager : IBlogService
    {
        IBlogDal _blogDal;

        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }

        [ValidationAspect(typeof(BlogValidator))]
        public IResult Add(Blog blog)
        {
            _blogDal.Add(blog);
            return new SuccessResult(Messages.BlogAdded);
        }

        public IResult Delete(Blog blog)
        {
            _blogDal.Delete(blog);
            return new SuccessResult(Messages.BlogDeleted);
        }

        public IDataResult<List<Blog>> GetAll()
        {
            return new SuccessDataResult<List<Blog>>(_blogDal.GetAll());
        }

        public IDataResult<Blog> GetByID(int id)
        {
            return new SuccessDataResult<Blog>(_blogDal.Get(b => b.BlogID == id));
        }

        public IDataResult<List<Blog>> GetAllWithCategory()
        {
            return new SuccessDataResult<List<Blog>>(_blogDal.GetAllWithCategoty());
        }

        [ValidationAspect(typeof(BlogValidator))]
        public IResult Update(Blog blog)
        {
            _blogDal.Update(blog);
            return new SuccessResult(Messages.BlogUpdated);
        }

        public IDataResult<List<Blog>> GetBlogListById(int id)
        {
            return new SuccessDataResult<List<Blog>>(_blogDal.GetAll(b => b.BlogID == id));
        }

        public IDataResult<List<Blog>> GetBlogListByUserId(int id)
        {
            return new SuccessDataResult<List<Blog>>(_blogDal.GetAll(b => b.UserId == id));
        }

        public IDataResult<List<Blog>> GetLast3Blogs()
        {
            return new SuccessDataResult<List<Blog>>(_blogDal.GetAll().TakeLast(3).ToList());
        }

        public IDataResult<List<Blog>> GetAllWithCategoryByWriter(int id)
        {
            return new SuccessDataResult<List<Blog>>(_blogDal.GetAllWithCategoty(x => x.UserId == id));
        }

        public IDataResult<int> TotalBlogCount()
        {
            return new SuccessDataResult<int>(_blogDal.GetAll().Count);
        }

        public IDataResult<int> WriterTotalBlogCount(int id)
        {
            return new SuccessDataResult<int>(GetBlogListByUserId(id).Data.Count);
        }
    }
}
