using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISeCommerce.Core.Domain.Interfaces;

namespace ISeCommerce.Core.Domain
{
    [Serializable]
    public class ProductCategory : IProductCategory
    {
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual int? ParentID { get; set; }
        public virtual int SortOrder { get; set; }
        public virtual ProductCategory ParentCategory { get; set; }
        public virtual string SEOKeywords { get; set; }
        public virtual string SEODescription { get; set; }
        public virtual string SEOTitle { get; set; }
        private IList<IProduct> _products = new List<IProduct>();
        public virtual IList<IProduct> Products { get { return _products; } set { _products = value; } }
        private IList<IProductCategory> _childCategories = new List<IProductCategory>();
        public virtual IList<IProductCategory> ChildCategories { get { return _childCategories; } set { _childCategories = value; } }
        private IList<IProductCategoryImage> _images = new List<IProductCategoryImage>();
        public virtual IList<IProductCategoryImage> Images { get { return _images; } set { _images = value; } }
        private IList<IProductCategorySpecificationProperty> _specs = new List<IProductCategorySpecificationProperty>();
        public virtual IList<IProductCategorySpecificationProperty> Specifications { get { return _specs; } set { _specs = value; } }
    }
}
