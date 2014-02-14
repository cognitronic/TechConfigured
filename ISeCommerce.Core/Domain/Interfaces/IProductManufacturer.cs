using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISeCommerce.Core.Domain.Interfaces
{
    public interface IProductManufacturer
    {
        string ManufacturerPartNumber { get; set; }
        string SKU { get; set; }
        string Make { get; set; }
        string Model { get; set; }
        int ManufacturerID { get; set; }
        Manufacturer Manufacturer { get; set; }
    }
}
