using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISeCommerce.Core.Domain.Interfaces
{
    public interface IProductSpecification
    {
        int ID { get; set; }
        bool DisplayOnPublicSite { get; set; }
        int ProductID { get; set; }
        int ProductCategorySpecificationPropertyValueID { get; set; }
        IProductCategorySpecificationPropertyValue SpecificationValue { get; set; }
    }
}
