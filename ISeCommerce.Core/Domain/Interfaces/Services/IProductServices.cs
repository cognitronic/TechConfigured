using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISeCommerce.Core.Domain.Interfaces.Services
{
    public interface IProductServices<T> where T : IProduct
    {
        T GetByID(int id);
        IList<T> GetPagedList(int startRow, int pageSize, out int count);
        IList<T> GetAll();
        T Save(T item);
        void Delete(T item);
        IList<T> GetByCategoryID(int categoryID);
        IList<T> RecursivelyGetByCategoryID(int categoryID);
    }
}
