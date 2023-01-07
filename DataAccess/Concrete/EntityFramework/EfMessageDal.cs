using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
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
    public class EfMessageDal : EfEntityRepositoryBase<Message, BlogSiteContext>, IMessageDal
    {
        public List<Message> GetMessagesWithUserByReciver(Expression<Func<Message, bool>> filter = null)
        {
            using(var context = new BlogSiteContext())
            {
                return filter == null ? context.Messages.Include(x => x.MessageSender).ToList()
                    : context.Messages.Include(x => x.MessageSender).Where(filter).ToList();
            }
        }

        public List<Message> GetMessagesWithUserBySender(Expression<Func<Message, bool>> filter = null)
        {
            using(var context = new BlogSiteContext())
            {
                return filter == null ? context.Messages.Include(x => x.MessageReciver).ToList()
                    : context.Messages.Include(x => x.MessageReciver).Where(filter).ToList();
            }
        }
    }
}
