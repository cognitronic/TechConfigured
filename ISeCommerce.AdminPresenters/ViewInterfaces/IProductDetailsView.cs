using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeed.Core;
using ISeCommerce.Core.Domain;
using ISeCommerce.Core.Domain.Interfaces;

namespace ISeCommerce.AdminPresenters.ViewInterfaces
{
    public interface IProductDetailsView : IBasePropertiesView<Product>, IBaseAuditable, IPropertiesActions
    {
        string Name { get; set; }
        int ProductCategoryID { get; set; }
        bool IsActive { get; set; }
        bool IsFeatured { get; set; }
        string ManufacturerPartNumber { get; set; }
        string SKU { get; set; }
        string ShortDescription { get; set; }
        string FullDescription { get; set; }
        int ManufacturerID { get; set; }
        string Make { get; set; }
        string Model { get; set; }
        void RestartAppPool();
        bool SavedSuccessfully { get; set; }
    }
}
