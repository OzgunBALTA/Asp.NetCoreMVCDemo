using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants.Messages;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
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

        [SecuredOperation("Admin, Writer")]
        [ValidationAspect(typeof(BlogValidator))]
        public IResult Add(Blog blog)
        {
            _blogDal.Add(blog);
            return new SuccessResult(Messages.BlogAdded);
        }

        public IResult ChangeBlogStatus(Blog blog)
        {
            blog.BlogStatus = !blog.BlogStatus;
            _blogDal.Update(blog);
            return new SuccessResult(Messages.BlogStatusChanged);
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

        [SecuredOperation("Admin")]
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

        public IDataResult<List<Blog>> GetAllStatusTrueWithCategory()
        {
            return new SuccessDataResult<List<Blog>>(_blogDal.GetAllWithCategoty().Where(x => x.BlogStatus == true).ToList());
        }

        public IDataResult<List<Blog>> GetLastBlog()
        {
            return new SuccessDataResult<List<Blog>>(_blogDal.GetAll().TakeLast(1).ToList());
        }

        public IDataResult<List<Blog>> GetBlogListByCategoryId(int id)
        {
            return new SuccessDataResult<List<Blog>>(_blogDal.GetAll(x => x.CategoryID == id));
        }
    }
}
