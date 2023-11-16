using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dto
{
    public class OrderDetailDto : IDto
    {
        public int OrderID { get; set; }
        public int EmployeeID { get; set; }     //Employee tablosundan,
        public string CustomerID { get; set; }     //Customer tablosundan
        //public int ProductID { get; set; }      //Product tablosuna foreign key yokmuş

        #region Customers Table
        public string CustomerCompanyName { get; set; }
        public string CustomerContactName { get; set; }
        public string CustomerContactTitle { get; set; }
        public string CustomerAddress { get; set; }
        #endregion

        #region Employees Table
        public string EmployeeName { get; set; }
        public string EmployeeTitle { get; set; }
        public string EmployeeAddress { get; set; }
        #endregion

        #region Products Table
        //public string ProductName { get; set; }
        //public decimal UnitPrice { get; set; }
        //public string QuantityPerUnit { get; set; }
        //public short UnitsInStock { get; set; }
        #endregion

        #region OrdersTable
        public DateTime? OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public int? ShipVia { get; set; }
        public decimal? Freight { get; set; }
        public string? ShipName { get; set; }
        public string? ShipAddress { get; set; }
        public string? ShipCity { get; set; }
        public string? ShipRegion { get; set; }
        public string? ShipPostalCode { get; set; }
        public string? ShipCountry { get; set; }
        #endregion

    }
}
