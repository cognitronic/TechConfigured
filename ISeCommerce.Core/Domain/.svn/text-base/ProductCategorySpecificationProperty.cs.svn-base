using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISeCommerce.Core.Domain.Interfaces;

namespace ISeCommerce.Core.Domain
{
    [Serializable]
    public class ProductCategorySpecificationProperty : IProductCategorySpecificationProperty
    {
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }
        public virtual bool CanFilterBy { get; set; }
        public virtual int ProductCategoryID { get; set; }
        private IList<IProductCategorySpecificationPropertyValue> _vals = new List<IProductCategorySpecificationPropertyValue>();
        public virtual IList<IProductCategorySpecificationPropertyValue> PropertyValues { get { return _vals; } set { _vals = value; } }
    }
}
