using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface INotificationService
    {
        IResult Add(Notification notification);
        IResult Delete(Notification notification);
        IResult Update(Notification notification);
        IDataResult<Notification> GetByID(int id);
        IDataResult<List<Notification>> GetAll();
        IDataResult<List<Notification>> GetLastNotification();
        
    }
}
