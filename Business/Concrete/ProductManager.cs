using Business.Abstract;
using Business.Constants.MagicStrings;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Entities;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        //Bu Class içerisindeki global Dal (DataAccessLayer) nesnem
        IProductDal _productDal;
        ICategoryService _categoryService;

        public ProductManager(IProductDal productDal,
            ICategoryService categoryService)
        {
            //DataAccess katmanındaki productDataAccessLayer katmanına erişmek için onun imzası olan IProductDal'dan instance alıyorum.
            _productDal = productDal;
            _categoryService = categoryService;
        }

        [ValidationAspect(typeof(ProductValidator))]    //Parametre olarak gelen entity için ProductValidator içerisindeki validasyon kurallarını denetle.
        public IResult Add(Product entity)
        {
            //İş parçacıkları aşağıda private method olarak yazıldı.
            //BusinessRules iş motoru olarak Core -> Utilities içerisine yazıldı. Bizim iş parçacıklarımızı çalıştıran bir methodtur.
            IResult result = BusinessRules.Run(
                CheckIfProductCountOfCategoryCorrect(entity.CategoryID),
                CheckIfProductNameExists(entity.ProductName),
                CheckIfCategoryLimitExceded()
                );

            #region Alternatif yöntem II
            //List<IResult> errorResult = BusinessRules.Run(
            //    CheckIfProductCountOfCategoryCorrect(entity.CategoryID),
            //    CheckIfProductNameExists(entity.ProductName)
            //    );

            //if (errorResult.Count > 0)
            //{
            //    foreach (var result in errorResult)
            //    {
            //        return new ErrorResult(result.Message);
            //    }
            //}
            #endregion

            if ( result != null ) 
            {
                return result;
            }

            _productDal.Add(entity);
            return new SuccessResult(Messages.Added);            
        }

        public IResult Delete(Product entity)
        {
            _productDal.Delete(entity);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<Product> GetById(int productId)
        {
            Product getProduct = _productDal.Get(p => p.Id == productId);
            return new SuccessDataResult<Product>(getProduct, Messages.Listed);
        }

        public IDataResult<List<Product>> GetAll()
        {
            List<Product> getProducts = _productDal.GetAll();
            return new SuccessDataResult<List<Product>>(getProducts, Messages.Listed);
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Update(Product entity)
        {
            IResult result = BusinessRules.Run(
                CheckIfCategoryLimitExceded(),
                CheckIfProductCountOfCategoryCorrect(entity.CategoryID),
                CheckIfProductNameExists(entity.ProductName)
                );

            if (result != null)
            {
                return result;
            }

            _productDal.Update(entity);
            return new SuccessResult(Messages.Updated);
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            List<ProductDetailDto> getProductDetails = _productDal.GetProductDetails();
            return new SuccessDataResult<List<ProductDetailDto>>(getProductDetails, Messages.Listed);
        }

        #region İş Parçacıkları
        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            var result = _productDal.GetAll().Where(x => x.CategoryID == categoryId).Count();

            if (result >= 10)
            {
                return new ErrorResult(Messages.MaximumProductQuantity);
            }

            return new SuccessResult();
        }

        private IResult CheckIfProductNameExists(string productName)
        {
            var result = _productDal.GetAll().Where(x => x.ProductName == productName).Any();
            
            if (result) 
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }
            return new SuccessResult();
        }

        private IResult CheckIfCategoryLimitExceded()
        {
            var result = _categoryService.GetAll().Data.Select(x => x.Id).Distinct().Count();

            if (result >= 15) 
            {
                return new ErrorResult(Messages.CategoryLimitExceded);
            }

            return new SuccessResult();
        }
        #endregion

    }
}
