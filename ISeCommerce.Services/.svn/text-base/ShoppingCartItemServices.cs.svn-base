using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ISeCommerce.Core.Domain;
using ISeCommerce.Core.Security;
using ISeCommerce.Core.Domain.Interfaces.Services;
using ISeCommerce.Persistence.Repositories;

namespace ISeCommerce.Services
{
    public class ShoppingCartItemServices
    {
        #region Shopping Cart Items

        public ShoppingCartItem GetByID(int id)
        {
            return new ShoppingCartItemRepository().GetByID(id, false);
        }

        public IList<ShoppingCartItem> GetPagedList(int startRow, int pageSize, out int count)
        {
            return new ShoppingCartItemRepository()
                .GetPagedList(startRow, pageSize, out count)
                .ToList<ShoppingCartItem>();
        }

        public IList<ShoppingCartItem> GetAll()
        {
            return new ShoppingCartItemRepository()
                .GetAll()
                .ToList<ShoppingCartItem>();
        }

        public ShoppingCartItem Save(ShoppingCartItem item)
        {
            var list = GetByShoppingCartID(item.ShoppingCartID);
            foreach (var i in list)
            {
                if (i.ProductID == item.ProductID)
                {
                    i.Qty += item.Qty;
                    i.Price = item.Price;
                    SecurityContextManager.Current.CurrentShoppingCart.CartItems[list.IndexOf(i)].Qty = i.Qty;
                    SecurityContextManager.Current.CurrentShoppingCart.CartItems[list.IndexOf(i)].Price = i.Price;
                    return new ShoppingCartItemRepository().SaveOrUpdate(i);
                }
            }
            new ShoppingCartItemRepository().SaveOrUpdate(item);
            SecurityContextManager.Current.CurrentShoppingCart = null;
            return item;
        }

        public ShoppingCartItem UpdateItem(ShoppingCartItem item)
        {
            return new ShoppingCartItemRepository().SaveOrUpdate(item);
        }

        public void Delete(ShoppingCartItem item)
        {
            new ShoppingCartItemRepository().Delete(item);
        }

        public IList<ShoppingCartItem> GetByShoppingCartID(int cartID)
        {
            return new ShoppingCartItemRepository()
                .GetByShoppingCartID(cartID)
                .ToList<ShoppingCartItem>();
        }

        public void AddItemToCart(int productID, int Qty, decimal price)
        {
            var item = new ShoppingCartItem();
            item.ProductID = productID;
            item.Qty = Qty;
            item.Price = price;
            item.ShoppingCartID = SecurityContextManager.Current.CurrentShoppingCart.ID;
            new ShoppingCartItemServices().Save(item);
            
        }

        #endregion
    }
}
