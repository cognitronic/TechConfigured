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
    public class ProductCategorySpecificationPropertyValueRepository : BaseRepository<ProductCategorySpecificationPropertyValue, int>
    {
        public IList<ProductCategorySpecificationPropertyValue> GetValuesByPropertyID(int propertyID)
        {
            return Session.CreateCriteria<ProductCategorySpecificationPropertyValue>()
                    .Add(Expression.Eq("ProductCategorySpecificationPropertyID", propertyID))
                    .List<ProductCategorySpecificationPropertyValue>();
        }
    }
}
