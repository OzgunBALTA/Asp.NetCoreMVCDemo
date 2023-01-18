using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants.Messages;
using Core.Aspects.Autofac.Caching;
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
    public class AboutManager : IAboutService
    {
        IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        [SecuredOperation("Admin")]
        public IResult Add(About about)
        {
            _aboutDal.Add(about);
            return new SuccessResult(Messages.AboutAdded);
        }

        [SecuredOperation("Admin")]
        public IResult Delete(About about)
        {
            _aboutDal.Delete(about);
            return new SuccessResult(Messages.AboutDeleted);
        }

        public IDataResult<List<About>> GetAll()
        {
            return new SuccessDataResult<List<About>>(_aboutDal.GetAll());
        }

        public IDataResult<About> GetByID(int id)
        {
            return new SuccessDataResult<About>(_aboutDal.Get(a => a.AboutID == id));
        }

        [SecuredOperation("Admin")]
        public IResult Update(About about)
        {
            _aboutDal.Update(about);
            return new SuccessResult(Messages.AboutUpdated);
        }
    }
}
