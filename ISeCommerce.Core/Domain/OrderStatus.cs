using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISeCommerce.Core.Domain
{
    [Serializable]
    public enum OrderStatus
    {
        OPEN = 1,
        PROCESSED = 2,
        ORDERED = 3,
        SHIPPED = 4,
        DELIVERED = 5,
        BACKORDERED = 6,
        CANCELLED = 7
    }
}
