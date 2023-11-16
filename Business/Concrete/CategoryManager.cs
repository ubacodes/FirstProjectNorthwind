using Business.Abstract;
using Business.Constants.MagicStrings;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IResult Add(Category entity)
        {
            _categoryDal.Add(entity);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Category entity)
        {
            _categoryDal.Delete(entity);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<Category> GetById(int categoryId)
        {
            Category getGategory = _categoryDal.Get(x => x.Id == categoryId);
            return new SuccessDataResult<Category>(getGategory, Messages.Listed);
        }

        public IDataResult<List<Category>> GetAll()
        {
            List<Category> getCategories = _categoryDal.GetAll();
            return new SuccessDataResult<List<Category>>(getCategories, Messages.Listed);
        }

        public IResult Update(Category entity)
        {
            _categoryDal.Update(entity);
            return new SuccessResult(Messages.Updated);
        }
    }
}
