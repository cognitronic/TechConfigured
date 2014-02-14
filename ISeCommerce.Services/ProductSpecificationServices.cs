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
    public class ProductSpecificationServices
    {
        public ProductSpecification GetByID(int id)
        {
            return new ProductSpecificationRepository().GetByID(id, false);
        }

        public IList<ProductSpecification> GetPagedList(int startRow, int pageSize, out int count)
        {
            return new ProductSpecificationRepository()
                .GetPagedList(startRow, pageSize, out count)
                .OrderBy(o => o.ID)
                .ToList<ProductSpecification>();
        }

        public IList<ProductSpecification> GetAll()
        {
            return new ProductSpecificationRepository()
                .GetAll();
        }

        public ProductSpecification Save(ProductSpecification item)
        {
            return new ProductSpecificationRepository().SaveOrUpdate(item);
        }

        public void Delete(ProductSpecification item)
        {
            new ProductSpecificationRepository().Delete(item);
        }



        //public IList<IProductSpecificationPropertyValue> GetPropertyValues(int propertyID)
        //{
        //    return new ProductSpecificationRepository().GetValuesByPropertyID(propertyID).OrderBy(o => o.Value).ToList<IProductSpecificationPropertyValue>();
        //}

        //public ProductSpecificationPropertyValue GetValueByID(int id)
        //{
        //    return new ProductSpecificationPropertyValueRepository().GetByID(id, false);
        //}

        //public IList<ProductSpecificationPropertyValue> GetValuePagedList(int startRow, int pageSize, out int count)
        //{
        //    return new ProductSpecificationPropertyValueRepository()
        //        .GetPagedList(startRow, pageSize, out count)
        //        .OrderBy(o => o.Value)
        //        .ToList<ProductSpecificationPropertyValue>();
        //}

        //public IList<ProductSpecificationPropertyValue> GetAllValues()
        //{
        //    return new ProductSpecificationPropertyValueRepository()
        //        .GetAll();
        //}

        //public ProductSpecificationPropertyValue SaveValue(ProductSpecificationPropertyValue item)
        //{
        //    return new ProductSpecificationPropertyValueRepository().SaveOrUpdate(item);
        //}

        //public void DeleteValue(ProductSpecificationPropertyValue item)
        //{
        //    new ProductSpecificationPropertyValueRepository().Delete(item);
        //}

        //public IList<IProductSpecificationPropertyValue> GetValuesByPropertyID(int propertyID)
        //{
        //    return new ProductSpecificationPropertyValueRepository()
        //        .GetValuesByPropertyID(propertyID).OrderBy(o => o.Value).ToList<IProductSpecificationPropertyValue>();
        //}
    }
}
