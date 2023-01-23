using Business.Abstract;
using Business.Constants.Messages;
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
    public class OperationClaimManager : IOperationClaimService
    {
        IOperationClaimDal _operationClaimDal;

        public OperationClaimManager(IOperationClaimDal operationClaimDal)
        {
            _operationClaimDal = operationClaimDal;
        }

        public IResult Add(OperationClaim operationClaim)
        {
            _operationClaimDal.Add(operationClaim);
            return new SuccessResult(Messages.OperationClaimAdded);
        }

        public IResult Delete(OperationClaim operationClaim)
        {
            _operationClaimDal.Delete(operationClaim);
            return new SuccessResult(Messages.OperationClaimDeleted);
        }

        public IDataResult<List<OperationClaim>> GetAll()
        {
            return new SuccessDataResult<List<OperationClaim>>(_operationClaimDal.GetAll());
        }

        public IDataResult<OperationClaim> GetById(int id)
        {
            return new SuccessDataResult<OperationClaim>(_operationClaimDal.Get(x => x.Id == id));
        }

        public IResult Update(OperationClaim operationClaim)
        {
            _operationClaimDal.Update(operationClaim);
            return new SuccessResult(Messages.OperationClaimUpdated);
        }
    }
}
