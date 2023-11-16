using Core.Utilities.Results;
using Entities;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<List<Product>> GetAll();
        IDataResult<Product> GetById(int productId);

        IDataResult<List<ProductDetailDto>> GetProductDetails();

        IResult Add(Product entity);
        IResult Update(Product entity);
        IResult Delete(Product entity);
    }
}
