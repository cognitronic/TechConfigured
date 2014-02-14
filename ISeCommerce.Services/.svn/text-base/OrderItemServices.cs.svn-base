using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ISeCommerce.Core.Domain;
using ISeCommerce.Core.Domain.Interfaces.Services;
using ISeCommerce.Persistence.Repositories;

namespace ISeCommerce.Services
{
    public class OrderItemServices
    {
        public OrderItem GetByID(int id)
        {
            return new OrderItemRepository().GetByID(id, false);
        }

        public IList<OrderItem> GetPagedList(int startRow, int pageSize, out int count)
        {
            return new OrderItemRepository()
                .GetPagedList(startRow, pageSize, out count)
                .OrderBy(o => o.Price)
                .ToList<OrderItem>(); ;
        }

        public IList<OrderItem> GetAll()
        {
            return new OrderItemRepository()
                .GetAll()
                .OrderBy(o => o.Price)
                .ToList<OrderItem>(); ;
        }

        public OrderItem Save(OrderItem item)
        {
            return new OrderItemRepository().SaveOrUpdate(item);
        }

        public void Delete(OrderItem item)
        {
            new OrderItemRepository().Delete(item);
        }

        public IList<OrderItem> GetByOrderID(int orderID)
        {
            return new OrderItemRepository().GetByOrderID(orderID);
        }
    }
}
