using Core.Utilities.Results;
using Entities;
using Entities.Dto;
using Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using Business.Constants.MagicStrings;

namespace Business.Concrete
{
    public class OrderManager : IOrderService
    {
        IOrderDal _orderDal;
        //Constructor injector
        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public IResult Add(Order entity)
        {
            _orderDal.Add(entity);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Order entity)
        {
            _orderDal.Delete(entity);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Order>> GetAll()
        {
            List<Order> getOrders = _orderDal.GetAll();
            return new SuccessDataResult<List<Order>>(getOrders, Messages.Listed);
        }

        public IDataResult<List<OrderDetailDto>> GetAllOrderDetails()
        {
            List<OrderDetailDto> getOrderDetails = _orderDal.GetOrderDetails();
            return new SuccessDataResult<List<OrderDetailDto>>(getOrderDetails, Messages.Listed);
        }

        public IDataResult<Order> GetById(int orderId)
        {
            Order getOrder = _orderDal.Get(x => x.Id == orderId);
            return new SuccessDataResult<Order>(getOrder, Messages.Listed);
        }

        public IResult Update(Order entity)
        {
            _orderDal.Update(entity);
            return new SuccessResult(Messages.Updated);
        }
    }
}
