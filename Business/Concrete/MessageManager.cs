using Business.Abstract;
using Business.Constants.Messages;
using Core.Aspects.Autofac.Caching;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public IResult Add(Message message)
        {
            _messageDal.Add(message);
            return new SuccessResult(Messages.MessageSended);
        }

        public IResult Delete(Message message)
        {
            _messageDal.Delete(message);
            return new SuccessResult(Messages.MessageDeleted);
        }

        public IDataResult<Message> GetByMessageId(int messageId)
        {
            return new SuccessDataResult<Message>(_messageDal.Get(x => x.MessageID == messageId));
        }

        public IDataResult<List<Message>> GetMessagesWithUserByReciverId(int reciverId)
        {
            return new SuccessDataResult<List<Message>>(_messageDal.GetMessagesWithUserByReciver(x => x.ReciverID == reciverId));
        }

        public IDataResult<List<Message>> GetMessagesWithUserBySenderId(int senderId)
        {
            return new SuccessDataResult<List<Message>>(_messageDal.GetMessagesWithUserBySender(x => x.SenderID == senderId));
        }

        public IDataResult<List<Message>> GetLast3MessagesWithUserByReciverId(int reciverId)
        {
            return new SuccessDataResult<List<Message>>(_messageDal.GetMessagesWithUserByReciver(x => x.ReciverID == reciverId)
                .TakeLast(3).ToList());
        }

        public IDataResult<List<Message>> GetLast3MessageWithUsersBySenderId(int senderId)
        {
            return new SuccessDataResult<List<Message>>(_messageDal.GetMessagesWithUserBySender(x => x.SenderID == senderId)
                .TakeLast(3).ToList());
        }

        
    }
}
