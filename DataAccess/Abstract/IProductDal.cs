using Core.DataAccess;
using Entities;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {
        //Product tablosuna özel veritabanı operasyonları barındıracak.
        List<ProductDetailDto> GetProductDetails(); //Tamamen product entity'e özgü join yazacağımız methodumuz.
    }
}
