using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfOperationClaimDal : EfEntityRepositoryBase<OperationClaim, BlogSiteContext>, IOperationClaimDal
    {
    }
}
