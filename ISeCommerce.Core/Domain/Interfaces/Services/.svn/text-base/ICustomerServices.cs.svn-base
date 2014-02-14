using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISeCommerce.Core.Domain.Interfaces.Services
{
    public interface ICustomerServices<T> where T : ICustomer
    {
        T GetByID(int id);
        IOrderedEnumerable<T> GetPagedList(int startRow, int pageSize, out int count);
        IOrderedEnumerable<T> GetAll();
        T Save(T item);
        void Delete(T item);
        Customer GetByEmail(string email);
    }
}
