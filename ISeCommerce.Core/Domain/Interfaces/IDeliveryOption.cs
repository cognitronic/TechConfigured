using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeed.Core;

namespace ISeCommerce.Core.Domain.Interfaces
{
    public interface IDeliveryOption
    {
        int ID { get; set; }
        decimal Cost { get; set; }
        int CourierServiceID { get; set; }
        decimal FreeDeliveryThreshold { get; set; }
    }
}
