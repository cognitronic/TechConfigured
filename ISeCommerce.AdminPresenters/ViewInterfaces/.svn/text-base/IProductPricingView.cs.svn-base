using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeed.Core;
using ISeCommerce.Core.Domain;
using ISeCommerce.Core.Domain.Interfaces;

namespace ISeCommerce.AdminPresenters.ViewInterfaces
{
    public interface IProductPricingView : IBasePropertiesView<Product>, IPropertiesActions
    {
        decimal? RetailPrice { get; set; }
        decimal? SalesPrice { get; set; }
        decimal? ListPrice { get; set; }
        decimal? CostPrice { get; set; }
        bool SavedSuccessfully { get; set; }
    }
}
