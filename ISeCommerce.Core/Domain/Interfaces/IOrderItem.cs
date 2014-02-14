using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISeCommerce.Core.Domain.Interfaces
{
    public interface IOrderItem
    {
        int ID { get; set; }
        int OrderID { get; set; }
        int ProductID { get; set; }
        int Qty { get; set; }
        decimal Price { get; set; }
        Order Order { get; set; }
        Product Product { get; set; }
    }
}
