using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISeCommerce.Core.Domain.Interfaces;
using System.Xml.Serialization;
namespace ISeCommerce.Core.Domain
{
    [Serializable]
    public class ShoppingCartItem : IShoppingCartItem
    {
        public virtual int ID { get; set; }
        public virtual int ProductID { get; set; }
        public virtual int ShoppingCartID { get; set; }
        public virtual int Qty { get; set; }
        public virtual decimal Price { get; set; }
        [XmlIgnore]
        public virtual Product Product { get; set; }
        [XmlIgnore]
        public virtual ShoppingCart Cart { get; set; }
    }
}
