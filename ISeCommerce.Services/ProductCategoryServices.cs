using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ISeCommerce.Core.Domain;
using ISeCommerce.Core.Domain.Interfaces.Services;
using ISeCommerce.Persistence.Repositories;
using System.Text;
using IdeaSeed.Core;
using ISeCommerce.Core;

namespace ISeCommerce.Services
{
    public class ProductCategoryServices : IProductCategoryServices<ProductCategory>
    {
        #region IProductCategoryServices<ProductCategory> Members

        public ProductCategory GetByID(int id)
        {
            return new ProductCategoryRepository().GetByID(id, false);
        }

        public IList<ProductCategory> GetPagedList(int startRow, int pageSize, out int count)
        {
            return new ProductCategoryRepository()
                .GetPagedList(startRow, pageSize, out count)
                .OrderBy(o => o.Name)
                .ToList<ProductCategory>();
        }

        public IList<ProductCategory> GetAll()
        {
            return new ProductCategoryRepository()
                .GetAll();
        }

        public ProductCategory Save(ProductCategory item)
        {
            return new ProductCategoryRepository().SaveOrUpdate(item);
        }

        public void Delete(ProductCategory item)
        {
            new ProductCategoryRepository().Delete(item);
        }

        public IList<ProductCategory> GetRootCategories()
        {
            return new ProductCategoryRepository()
                .GetRootCategories()
                .ToList<ProductCategory>();
        }

        public IList<ProductCategory> GetChildrenByParentID(int parentID)
        {
            return new ProductCategoryRepository()
                .GetChildrenByParentID(parentID)
                .OrderBy(o => o.Name)
                .ToList<ProductCategory>();
        }

        public IDictionary<ProductCategory, IList<ProductCategory>> BuildPrimaryNavigation()
        {
            IDictionary<ProductCategory, IList<ProductCategory>> list = new Dictionary<ProductCategory, IList<ProductCategory>>();
            var roots = GetRootCategories().OrderBy(o => o.SortOrder);
            foreach (var cat in roots)
            {
                var kids = GetChildrenByParentID(cat.ID).OrderBy(o => o.SortOrder);
                if (kids != null && kids.Count() > 0)
                {
                    var kidsList = new List<ProductCategory>();
                    foreach (var k in kids)
                    {
                        kidsList.Add(k);
                    }
                    list.Add(cat, kidsList);
                }
                else
                {
                    list.Add(cat, new List<ProductCategory>());
                }
            }

            return list;
        }
        #endregion

        public ProductCategory GetByName(string name)
        {
            return new ProductCategoryRepository().GetByName(name);
        }

    }
}
