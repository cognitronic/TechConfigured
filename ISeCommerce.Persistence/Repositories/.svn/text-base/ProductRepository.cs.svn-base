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
    public class ProductRepository : BaseRepository<Product, int>, IProductRepository
    {
        #region IProductRepository Members

        public IList<Product> GetByCategoryID(int categoryID)
        {
            return Session.CreateCriteria<Product>()
                    .Add(Expression.Eq("IsActive", true))
                    .Add(Expression.Eq("ProductCategoryID", categoryID))
                    .List<Product>();
        }

        public IList<Product> GetByIsFeatured(bool isFeatured)
        {
            return Session.CreateCriteria<Product>()
                    .Add(Expression.Eq("IsActive", true))
                    .Add(Expression.Eq("IsFeatured", isFeatured))
                    .List<Product>();
        }

        public IList<Product> RecursivelyGetByCategoryID(int categoryID)
        {
            var sql = "with Hierachy(ID, Name, ParentID, Level)" +

          " as" +

          " (" +

          "   select ID, Name, ParentID, 0 as Level" +

          "   from ProductCategory pc" +

          "   where pc.ID = :id" +

          "  union all" +

          "   select pc.ID, pc.Name, pc.ParentID, eh.Level + 1" +

          "   from ProductCategory pc" +

          "   inner join Hierachy eh" +

          "      on pc.ID = eh.ParentId" +

          " )" +

          " select ID, Name, ParentID" +

          " from Hierachy" +

          " where Level > 0";

            var list = Session.CreateSQLQuery(sql)
                .AddEntity(typeof(Product))
                .SetInt32("ID", categoryID)
                .List<Product>();

            return list;
        }

        #endregion
    }
}
