using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Transform;
using IdeaSeed.Core.Data.NHibernate;
using ISeCommerce.Core.Domain;
using ISeCommerce.Core.Domain.Interfaces;
using ISeCommerce.Core.Domain.Interfaces.Data;

namespace ISeCommerce.Persistence.Repositories
{
    public class ProductCategorySpecificationPropertyRepository : BaseRepository<ProductCategorySpecificationProperty, int>
    {
        public IList<IProductCategorySpecificationPropertyValue> GetValuesByPropertyID(int propertyID)
        {
            return Session.CreateCriteria<IProductCategorySpecificationPropertyValue>()
                    .Add(Expression.Eq("ProductCategorySpecificationPropertyID", propertyID))
                    .List<IProductCategorySpecificationPropertyValue>();
        }

        public IList<ProductCategorySpecificationProperty> GetByCategoryID(int categoryID)
        {
            return Session.CreateCriteria<ProductCategorySpecificationProperty>()
                    .Add(Expression.Eq("ProductCategoryID", categoryID))
                    .List<ProductCategorySpecificationProperty>();
        }
    }
}
