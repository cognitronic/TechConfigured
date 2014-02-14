using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISeCommerce.Core.Domain.Interfaces;

namespace ISeCommerce.Core.Domain
{
    [Serializable]
    public class Product : IProduct
    {
        public virtual int ID { get; set; }
        public virtual string ManufacturerPartNumber { get; set; }
        public virtual string SKU { get; set; }
        public virtual string Name { get; set; }
        public virtual string ShortDescription { get; set; }
        public virtual string FullDescription { get; set; }
        public virtual decimal? Weight { get; set; }
        public virtual int? Width { get; set; }
        public virtual int? Height { get; set; }
        public virtual int? Length { get; set; }
        public virtual string Make { get; set; }
        public virtual string Model { get; set; }
        public virtual int ManufacturerID { get; set; }
        public virtual int ProductCategoryID { get; set; }
        public virtual decimal? RetailPrice { get; set; }
        public virtual decimal? SalePrice { get; set; }
        public virtual decimal? CostPrice { get; set; }
        public virtual decimal? ListPrice { get; set; }
        public virtual int EnteredBy { get; set; }
        public virtual int ChangedBy { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual DateTime LastUpdated { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual object ItemReference { get; set; }
        public virtual string URL { get; set; }
        public virtual ItemType TypeOfItem { get; set; }
        public virtual string Description { get; set; }
        public virtual bool MarkedForDeletion { get; set; }
        public virtual bool IsFeatured { get; set; }
        public virtual bool IsCategoryFeatured { get; set; }
        public virtual string DefaultImage { get; set; }
        public virtual string SEOKeywords { get; set; }
        public virtual string SEODescription { get; set; }
        public virtual string SEOTitle { get; set; }
        private IList<IProductImage> _images = new List<IProductImage>();
        public virtual IList<IProductImage> Images { get{return _images;} set{_images = value;} }
        private IList<ProductSpecification> _specs = new List<ProductSpecification>();
        public virtual IList<ProductSpecification> Specifications { get { return _specs; } set { _specs = value; } }
        public virtual ProductCategory Category { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }

        public Product()
        {
            this.TypeOfItem = ItemType.PRODUCT;
        }
    }
}
