using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeed.Core;

namespace ISeCommerce.Core.Domain.Interfaces
{
    public interface ICourierService : IBaseItem
    {
        int CourierID { get; set; }
        string ServiceCode { get; set; }
        ICourier Courier { get; set; }
    }
}
