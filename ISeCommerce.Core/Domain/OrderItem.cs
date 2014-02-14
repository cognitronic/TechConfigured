using System;
using System.Collections.Generic;
using System.Linq;
using ISeCommerce.Core.Domain.Interfaces;
using System.Text;

namespace ISeCommerce.Core.Domain
{
    [Serializable]
    public class OrderItem : IOrderItem
    {
        public virtual int ID { get; set; }
        public virtual int OrderID { get; set; }
        public virtual int ProductID { get; set; }
        public virtual int Qty { get; set; }
        public virtual decimal Price { get; set; }
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
