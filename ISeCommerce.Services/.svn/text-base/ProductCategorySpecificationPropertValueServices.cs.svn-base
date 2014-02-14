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
    public class ProductCategorySpecificationPropertValueServices 
    {
        public ProductCategorySpecificationPropertyValue GetByID(int id)
        {
            return new ProductCategorySpecificationPropertyValueRepository().GetByID(id, false);
        }

        public IList<ProductCategorySpecificationPropertyValue> GetPagedList(int startRow, int pageSize, out int count)
        {
            return new ProductCategorySpecificationPropertyValueRepository()
                .GetPagedList(startRow, pageSize, out count)
                .OrderBy(o => o.ID)
                .ToList<ProductCategorySpecificationPropertyValue>();
        }

        public IList<ProductCategorySpecificationPropertyValue> GetAllProperties()
        {
            return new ProductCategorySpecificationPropertyValueRepository()
                .GetAll();
        }

        public ProductCategorySpecificationPropertyValue SaveProperty(ProductCategorySpecificationPropertyValue item)
        {
            return new ProductCategorySpecificationPropertyValueRepository().SaveOrUpdate(item);
        }

        public void DeleteProperty(ProductCategorySpecificationPropertyValue item)
        {
            new ProductCategorySpecificationPropertyValueRepository().Delete(item);
        }

        public IList<ProductCategorySpecificationPropertyValue> GetValuesByPropertyID(int id)
        {
            return new ProductCategorySpecificationPropertyValueRepository().GetValuesByPropertyID(id);
        }
    }
}
