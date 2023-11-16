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
    public class EfOrderDal : EfEntityRepositoryBase<Order, NorthwindContext>, IOrderDal
    {
        public List<OrderDetailDto> GetOrderDetails()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from order in context.Orders
                             join customer in context.Customers
                             on order.CustomerID equals customer.Id
                             join employee in context.Employees
                             on order.EmployeeID equals employee.Id
                             select new OrderDetailDto
                             {
                                 OrderID = order.Id,
                                 EmployeeID = employee.Id,
                                 CustomerID = customer.Id,

                                 CustomerCompanyName = customer.CompanyName,
                                 CustomerContactName = customer.ContactName,
                                 CustomerContactTitle = customer.ContactTitle,
                                 CustomerAddress = customer.Address,

                                 EmployeeName = employee.FirstName + " " + employee.LastName,
                                 EmployeeTitle = employee.Title,
                                 EmployeeAddress = employee.Address,

                                 OrderDate = order.OrderDate,
                                 RequiredDate = order.RequiredDate,
                                 ShippedDate = order.ShippedDate,
                                 ShipVia = order.ShipVia,
                                 Freight = order.Freight,
                                 ShipName = order.ShipName,
                                 ShipAddress = order.ShipAddress,
                                 ShipCity = order.ShipCity,
                                 ShipRegion = order.ShipRegion,
                                 ShipPostalCode = order.ShipPostalCode,
                                 ShipCountry = order.ShipCountry,
                             };
                return result.ToList();
            }
        }
    }
}
