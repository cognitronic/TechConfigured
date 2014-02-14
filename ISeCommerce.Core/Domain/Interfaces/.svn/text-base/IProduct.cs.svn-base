using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeed.Core;

namespace ISeCommerce.Core.Domain.Interfaces
{
    public interface IProduct : IBaseAuditable, IItem, IProductShipping, IProductPricing, IProductSEO, IProductManufacturer
    {
        string ShortDescription { get; set; }
        string FullDescription { get; set; }
        int ProductCategoryID { get; set; }
        bool IsActive { get; set; }
        bool IsFeatured { get; set; }
        bool IsCategoryFeatured { get; set; }
        string DefaultImage { get; set; }
        IList<IProductImage> Images { get; set; }
        IList<ProductSpecification> Specifications { get; set; }
        ProductCategory Category { get; set; }
    }
}
