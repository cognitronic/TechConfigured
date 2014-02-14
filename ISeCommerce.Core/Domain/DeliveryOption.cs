using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISeCommerce.Core.Domain.Interfaces;

namespace ISeCommerce.Core.Domain
{
    [Serializable]
    public class DeliveryOption
    {
        public virtual int ID { get; set; }
        public virtual decimal Cost { get; set; }
        public virtual int CourierServiceID { get; set; }
        public virtual decimal FreeDeliveryThreshold { get; set; }
    }
}
