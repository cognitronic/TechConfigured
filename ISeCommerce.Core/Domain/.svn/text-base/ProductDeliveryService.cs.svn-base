using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISeCommerce.Core.Domain.Interfaces;

namespace ISeCommerce.Core.Domain
{
    [Serializable]
    public class ProductDeliveryService : IProductDeliveryService
    {
        public virtual int ID { get; set; }
        public virtual int ProductID { get; set; }
        public virtual int CourierServiceID { get; set; }
        public virtual ICourier Courier { get; set; }
    }
}
