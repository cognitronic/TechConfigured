using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ISeCommerce.Core.Domain;
using ISeCommerce.Core.Domain.Interfaces.Services;
using ISeCommerce.Persistence.Repositories;

namespace ISeCommerce.Services
{
    public class OrderServices
    {
        public Order GetByID(int id)
        {
            return new OrderRepository().GetByID(id, false);
        }

        public IList<Order> GetPagedList(int startRow, int pageSize, out int count)
        {
            return new OrderRepository()
                .GetPagedList(startRow, pageSize, out count)
                .OrderBy(o => o.Name)
                .ToList<Order>(); ;
        }

        public IList<Order> GetAll()
        {
            return new OrderRepository()
                .GetAll()
                .OrderBy(o => o.Name)
                .ToList<Order>(); ;
        }

        public Order Save(Order item)
        {
            return new OrderRepository().SaveOrUpdate(item);
        }

        public void Delete(Order item)
        {
            new OrderRepository().Delete(item);
        }

        public IList<ISeCommerce.Core.Domain.Order> GetByCustomerID(int customerID)
        {
            return new OrderRepository().GetByCustomerID(customerID);
        }

        public IList<ISeCommerce.Core.Domain.Order> GetByEmail(string email)
        {
            return new OrderRepository().GetByEmail(email);
        }

        public IList<ISeCommerce.Core.Domain.Order> GetByFilters(string email, DateTime? orderDate, int? status, int? orderID)
        {
            return new OrderRepository().GetByFilters(email, orderDate, status, orderID);
        }
    }
}
