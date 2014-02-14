using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISeCommerce.Core.Domain.Interfaces
{
    public interface IProductPricing
    {
        decimal? RetailPrice { get; set; }
        decimal? SalePrice { get; set; }
        decimal? CostPrice { get; set; }
        decimal? ListPrice { get; set; }
    }
}
