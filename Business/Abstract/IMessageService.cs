using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IMessageService
    {
        IResult Add(Message message);
        IResult Delete(Message message);
        IDataResult<Message> GetByMessageId(int messageId);
        IDataResult<List<Message>> GetMessagesWithUserByReciverId(int reciverId);
        IDataResult<List<Message>> GetMessagesWithUserBySenderId(int senderId);
        IDataResult<List<Message>> GetLast3MessagesWithUserByReciverId(int reciverId);
        IDataResult<List<Message>> GetLast3MessageWithUsersBySenderId(int senderId);
    }
}
