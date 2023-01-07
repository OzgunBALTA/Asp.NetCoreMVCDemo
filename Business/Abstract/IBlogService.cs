using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBlogService
    {
        IResult Add(Blog blog);
        IResult Delete(Blog blog);
        IResult Update(Blog blog);
        IDataResult<List<Blog>> GetAll();
        IDataResult<Blog> GetByID(int id);
        IDataResult<List<Blog>> GetAllWithCategory();
        IDataResult<List<Blog>> GetBlogListById(int id);
        IDataResult<List<Blog>> GetBlogListByUserId(int id);
        IDataResult<List<Blog>> GetLast3Blogs();
        IDataResult<List<Blog>> GetAllWithCategoryByWriter(int id);
        IDataResult<int> TotalBlogCount();
        IDataResult<int> WriterTotalBlogCount(int id);
    }
}
