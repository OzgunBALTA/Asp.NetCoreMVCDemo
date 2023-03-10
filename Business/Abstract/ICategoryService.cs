using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        IResult Add(Category category);
        IResult Delete(Category category);
        IResult Update(Category category);
        IResult ChangeCategoryStatus(Category category);
        IDataResult<Category> GetByID(int id);
        IDataResult<List<Category>> GetAll();
        IDataResult<int> TotalCategoryCount();
    }
}
