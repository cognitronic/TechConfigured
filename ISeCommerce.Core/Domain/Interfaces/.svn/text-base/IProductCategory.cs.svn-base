using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISeCommerce.Core.Domain.Interfaces
{
    public interface IProductCategory
    {
        int ID { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        int? ParentID { get; set; }
        int SortOrder { get; set; }
        string SEOKeywords { get; set; }
        string SEODescription { get; set; }
        string SEOTitle { get; set; }
        ProductCategory ParentCategory { get; set; }
        IList<IProduct> Products { get; set; }
        IList<IProductCategory> ChildCategories { get; set; }
        IList<IProductCategoryImage> Images { get; set; }
        IList<IProductCategorySpecificationProperty> Specifications { get; set; }
    }
}
