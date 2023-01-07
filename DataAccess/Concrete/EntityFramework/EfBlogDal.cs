using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBlogDal : EfEntityRepositoryBase<Blog, BlogSiteContext>, IBlogDal
    {
        public List<Blog> GetAllWithCategoty(Expression<Func<Blog, bool>> filter = null)
        {
            using (var context = new BlogSiteContext())
            {
                return filter == null ? context.Blogs.Include(x => x.Category).ToList() :
                    context.Blogs.Include(x => x.Category).Where(filter).ToList();
            }
        }
    }
}
