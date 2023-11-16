using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    //Bu class EfEntityRepositoryBase class'ından inherit ediliyor. Aynı zamanda IProductDal imzası taşıyor.
    //EfEntityRepositoryBase ise EntityFramework kullanılarak yürütülen CRUD operasyonlarını generic bir yapıda taşıyor.
    {
        public List<ProductDetailDto> GetProductDetails()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from product in context.Products
                             join category in context.Categories
                             on product.CategoryID equals category.Id
                             join supplier in context.Suppliers
                             on product.SupplierID equals supplier.Id
                             select new ProductDetailDto
                             {
                                 ProductID = product.Id,
                                 ProductName = product.ProductName,
                                 SupplierId = product.SupplierID,
                                 SupplierName = supplier.CompanyName,
                                 CategoryId = product.CategoryID,
                                 CategoryName = category.CategoryName,
                                 QuantityPerUnit = product.QuantityPerUnit,
                                 UnitPrice = product.UnitPrice,
                                 UnitsInStock = product.UnitsInStock,
                                 UnitsOnOrder = product.UnitsOnOrder,
                                 ReorderLevel = product.ReorderLevel,
                                 Discontinued = product.Discontinued,
                             };


                return result.ToList();
            }
        }
    }
}
