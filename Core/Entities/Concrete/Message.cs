using Core.Entities.Abstract;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public class Message : IEntity
    {
        public int MessageID { get; set; }
        public int? SenderID { get; set; }
        public int? ReciverID { get; set; }
        public string Subject { get; set; }
        public string MessageDetails { get; set; }
        public DateTime MessageDate { get; set; }
        public bool MessageStatus { get; set; }
        public User MessageSender { get; set; }
        public User MessageReciver { get; set; }
    }
}
