using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ISeCommerce.Core.Domain;
using ISeCommerce.Core.Domain.Interfaces;
using ISeCommerce.Persistence.Repositories;

namespace ISeCommerce.Services
{
    public class ShoppingCartServices
    {
        public ShoppingCart GetByID(int id)
        {
            return new ShoppingCartRepository().GetByID(id, false);
        }

        public IList<ShoppingCart> GetPagedList(int startRow, int pageSize, out int count)
        {
            return new ShoppingCartRepository()
                .GetPagedList(startRow, pageSize, out count)
                .ToList<ShoppingCart>(); ;
        }

        public IList<ShoppingCart> GetAll()
        {
            return new ShoppingCartRepository()
                .GetAll()
                .ToList<ShoppingCart>(); ;
        }

        public ShoppingCart Save(ShoppingCart item)
        {
            return new ShoppingCartRepository().SaveOrUpdate(item);
        }

        public void Delete(ShoppingCart item)
        {
            new ShoppingCartRepository().Delete(item);
        }

        
    }
}
