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
    public class ProductImageRepository : BaseRepository<ProductImage, int>
    {
        public IList<ProductImage> GetbyProductID(int productID)
        {
            return Session.CreateCriteria<ProductImage>()
                    .Add(Restrictions.Eq("ProductID", productID))
                    .List<ProductImage>(); 
        }

        public void UpdateToNoDefault(int productid)
        {
            Session.CreateQuery(@"update ProductImage set isDefault = 'False' where ProductID=" + productid.ToString())
                .ExecuteUpdate();
        }
    }
}
