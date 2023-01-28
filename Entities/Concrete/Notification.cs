using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Notification : IEntity
    {
        public int NotificationID { get; set; }
        public string NotificationType { get; set; } = string.Empty;
        public string NotificationTypeSymbol { get; set; } = string.Empty;
        public string NotificationColor { get; set; } = string.Empty;
        public string NotificationDetails { get; set; } = string.Empty;
        public DateTime NotificationDate { get; set; }
        public bool NotificationStatus { get; set; }
    }
}
