using Core.DataAccess;
using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IMessageDal : IEntityRepository<Message>
    {
        List<Message> GetMessagesWithUserByReciver(Expression<Func<Message, bool>> filter = null);
        List<Message> GetMessagesWithUserBySender(Expression<Func<Message, bool>> filter = null);
    }
}
