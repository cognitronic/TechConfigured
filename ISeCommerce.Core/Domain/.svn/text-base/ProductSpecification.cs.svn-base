using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISeCommerce.Core.Domain.Interfaces;

namespace ISeCommerce.Core.Domain
{
    [Serializable]
    public class ProductSpecification
    {
        public virtual int ID { get; set; }
        public virtual bool DisplayOnPublicSite { get; set; }
        public virtual int ProductID { get; set; }
        public virtual int ProductCategorySpecificationPropertyValueID { get; set; }
        public virtual IProductCategorySpecificationPropertyValue SpecificationValue { get; set; }
    }
}
