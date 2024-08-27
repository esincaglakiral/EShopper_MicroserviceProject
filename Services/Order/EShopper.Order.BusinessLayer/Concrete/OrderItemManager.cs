﻿using EShopper.Order.BusinessLayer.Abstract;
using EShopper.Order.DataAccessLayer.Abstract;
using EShopper.Order.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopper.Order.BusinessLayer.Concrete
{
    public class OrderItemManager : GenericManager<OrderItem>, IOrderItemService
    {
        public OrderItemManager(IRepository<OrderItem> repository) : base(repository)
        {
        }
    }
}
