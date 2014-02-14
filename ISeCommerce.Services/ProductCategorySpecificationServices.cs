using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ISeCommerce.Core.Domain;
using ISeCommerce.Core.Domain.Interfaces;
using ISeCommerce.Core.Domain.Interfaces.Services;
using ISeCommerce.Persistence.Repositories;
using System.Text;
using IdeaSeed.Core;
using ISeCommerce.Core;

namespace ISeCommerce.Services
{
    public class ProductCategorySpecificationServices
    {
        public ProductCategorySpecificationProperty GetPropertyByID(int id)
        {
            return new ProductCategorySpecificationPropertyRepository().GetByID(id, false);
        }

        public IList<ProductCategorySpecificationProperty> GetPropertyPagedList(int startRow, int pageSize, out int count)
        {
            return new ProductCategorySpecificationPropertyRepository()
                .GetPagedList(startRow, pageSize, out count)
                .OrderBy(o => o.Name)
                .ToList<ProductCategorySpecificationProperty>();
        }

        public IList<ProductCategorySpecificationProperty> GetAllProperties()
        {
            return new ProductCategorySpecificationPropertyRepository()
                .GetAll();
        }

        public ProductCategorySpecificationProperty SaveProperty(ProductCategorySpecificationProperty item)
        {
            return new ProductCategorySpecificationPropertyRepository().SaveOrUpdate(item);
        }

        public void DeleteProperty(ProductCategorySpecificationProperty item)
        {
            new ProductCategorySpecificationPropertyRepository().Delete(item);
        }

        public IList<IProductCategorySpecificationPropertyValue> GetPropertyValues(int propertyID)
        {
            return new ProductCategorySpecificationPropertyRepository().GetValuesByPropertyID(propertyID).OrderBy(o => o.Value).ToList<IProductCategorySpecificationPropertyValue>();
        }

        public ProductCategorySpecificationPropertyValue GetValueByID(int id)
        {
            return new ProductCategorySpecificationPropertyValueRepository().GetByID(id, false);
        }

        public IList<ProductCategorySpecificationPropertyValue> GetValuePagedList(int startRow, int pageSize, out int count)
        {
            return new ProductCategorySpecificationPropertyValueRepository()
                .GetPagedList(startRow, pageSize, out count)
                .OrderBy(o => o.Value)
                .ToList<ProductCategorySpecificationPropertyValue>();
        }

        public IList<ProductCategorySpecificationPropertyValue> GetAllValues()
        {
            return new ProductCategorySpecificationPropertyValueRepository()
                .GetAll();
        }

        public ProductCategorySpecificationPropertyValue SaveValue(ProductCategorySpecificationPropertyValue item)
        {
            return new ProductCategorySpecificationPropertyValueRepository().SaveOrUpdate(item);
        }

        public void DeleteValue(ProductCategorySpecificationPropertyValue item)
        {
            new ProductCategorySpecificationPropertyValueRepository().Delete(item);
        }

        public IList<ProductCategorySpecificationPropertyValue> GetValuesByPropertyID(int propertyID)
        {
            return new ProductCategorySpecificationPropertyValueRepository()
                .GetValuesByPropertyID(propertyID).OrderBy(o => o.Value).ToList<ProductCategorySpecificationPropertyValue>();
        }

        public IList<ProductCategorySpecificationProperty> GetByCategoryID(int categoryID)
        {
            return new ProductCategorySpecificationPropertyRepository().GetByCategoryID(categoryID);
        }
    }
}
