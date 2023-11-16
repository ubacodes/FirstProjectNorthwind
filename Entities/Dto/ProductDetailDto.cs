using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dto
{
    public class ProductDetailDto : IDto
    {
        public int ProductID { get; set; }
        public int SupplierId { get; set; }
        public int CategoryId { get; set; }

        public string ProductName { get; set; }
        public string SupplierName { get; set; }    //new
        public string CategoryName { get; set; }    //new
        public string QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public short UnitsInStock { get; set; }
        public short UnitsOnOrder { get; set; }
        public short ReorderLevel { get; set; }
        public bool Discontinued { get; set; }
    }
}
