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
    public interface IOrderService
    {
        IDataResult<List<Order>> GetAll();
        IDataResult<Order> GetById(int orderId);

        IDataResult<List<OrderDetailDto>> GetAllOrderDetails();

        IResult Add(Order entity);
        IResult Update(Order entity);
        IResult Delete(Order entity);
    }
}
