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
using ISeCommerce.Core.Domain.Interfaces.Data;

namespace ISeCommerce.Persistence.Repositories
{
    public class ProductCategoryRepository : BaseRepository<ProductCategory, int>, IProductCategoryRepository
    {

        #region IProductCategoryRepository Members

        public IList<ProductCategory> GetRootCategories()
        {
            return Session.CreateCriteria<ProductCategory>()
                    .Add(Restrictions.IsNull("ParentID"))
                    .List<ProductCategory>();
        }

        public IList<ProductCategory> GetChildrenByParentID(int parentID)
        {
            return Session.CreateCriteria<ProductCategory>()
                    .Add(Expression.Eq("ParentID", parentID))
                    .List<ProductCategory>();
        }

        public ProductCategory GetByName(string name)
        {
            return Session.CreateCriteria<ProductCategory>()
                .Add(Expression.Eq("Name", name))
                .UniqueResult<ProductCategory>();
        }

        public IList<ProductCategory> RecursivelyGetByCategoryID(int categoryID)
        {
            var sql = "with Hierachy(ID, Name, Description, ParentID, SortOrder, Level)" +

          " as" +

          " (" +

          "   select ID, Name, Description, ParentID, SortOrder, 0 as Level" +

          "   from ProductCategory e" +

          "   where e.ID = :ID" +

          "  union all" +

          "   select e.ID, e.Name, e.Description, e.ParentID, e.SortOrder, eh.Level + 1" +

          "   from ProductCategory e" +

          "   inner join Hierachy eh" +

          "      on e.ParentID = eh.ID" +

          " )" +

          " select ID, Name, Description, ParentID, SortOrder" +

          " from Hierachy" +

          " where Level > 0";

            var list = Session.CreateSQLQuery(sql)

                .AddEntity(typeof(ProductCategory))

                .SetInt32("ID", categoryID)

                .List<ProductCategory>();

            return list;
        }

        #endregion
    }
}
