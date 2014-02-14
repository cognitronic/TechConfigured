using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using IdeaSeed.Core.Data.NHibernate;
using ISeCommerce.Core.Domain;
using ISeCommerce.Core.Domain.Interfaces.Data;

namespace ISeCommerce.Persistence.Repositories
{
    public class ProductCategoryImageRepository : BaseRepository<ProductCategoryImage, int>
    {
        public IList<ProductCategoryImage> GetByProductCategoryID(int categoryID)
        {
            return Session.CreateCriteria<ProductCategoryImage>()
                .Add(Expression.Eq("ProductCategoryID", categoryID))
                .List<ProductCategoryImage>(); 
        }
    }
}
