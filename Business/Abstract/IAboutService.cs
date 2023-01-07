using Core.Utilities.Results.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAboutService
    {
        IResult Add(About about);
        IResult Delete(About about);
        IResult Update(About about);
        IDataResult<List<About>> GetAll();
        IDataResult<About> GetByID(int id);
    }
}
