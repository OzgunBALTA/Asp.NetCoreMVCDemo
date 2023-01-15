using Business.Abstract;
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
    public class NotificationManager : INotificationService
    {
        INotificationDal _notificationDal;

        public NotificationManager(INotificationDal notificationDal)
        {
            _notificationDal = notificationDal;
        }

        public IResult Add(Notification notification)
        {
            _notificationDal.Add(notification);
            return new SuccessResult();
        }

        public IResult Delete(Notification notification)
        {
            _notificationDal.Delete(notification);
            return new SuccessResult();
        }

        public IDataResult<List<Notification>> GetAll()
        {
            return new SuccessDataResult<List<Notification>>(_notificationDal.GetAll());
        }

        public IDataResult<Notification> GetById(int id)
        {
            return new SuccessDataResult<Notification>(_notificationDal.Get(x => x.NotificationID == id));
        }

        public IDataResult<List<Notification>> GetLastNotification()
        {
            return new SuccessDataResult<List<Notification>>(_notificationDal.GetAll().TakeLast(1).ToList());
        }

        public IResult Update(Notification notification)
        {
            _notificationDal.Update(notification);
            return new SuccessResult();
        }
    }
}
