﻿using Core.DataAccess;
using Entities;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IOrderDal : IEntityRepository<Order>
    {
        //Order tablosuna özel veritabanı operasyonları barındıracak.
        public List<OrderDetailDto> GetOrderDetails();
    }
}
