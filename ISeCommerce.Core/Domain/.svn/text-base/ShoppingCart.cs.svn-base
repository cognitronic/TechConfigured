using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISeCommerce.Core.Domain.Interfaces;

namespace ISeCommerce.Core.Domain
{
    [Serializable]
    public class ShoppingCart : IShoppingCart
    {
        public virtual int ID { get; set; }
        public virtual DateTime DateCreated { get; set; }
        private IList<ShoppingCartItem> _items = new List<ShoppingCartItem>();
        public virtual IList<ShoppingCartItem> CartItems { get { return _items; } set { _items = value; } }
    }
}
