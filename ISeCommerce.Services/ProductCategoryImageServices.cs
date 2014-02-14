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
    public class ProductCategoryImageServices
    {
        public ProductCategoryImage GetByID(int id)
        {
            return new ProductCategoryImageRepository().GetByID(id, false);
        }

        public IList<ProductCategoryImage> GetPagedList(int startRow, int pageSize, out int count)
        {
            return new ProductCategoryImageRepository()
                .GetPagedList(startRow, pageSize, out count)
                .OrderBy(o => o.Title)
                .ToList<ProductCategoryImage>();
        }

        public IList<ProductCategoryImage> GetAll()
        {
            return new ProductCategoryImageRepository()
                .GetAll();
        }

        public ProductCategoryImage Save(ProductCategoryImage item)
        {
            return new ProductCategoryImageRepository().SaveOrUpdate(item);
        }

        public void Delete(ProductCategoryImage item)
        {
            new ProductCategoryImageRepository().Delete(item);
        }

        public IList<ProductCategoryImage> GetProductCategoryImages(int categoryID)
        {
            return new ProductCategoryImageRepository().GetByProductCategoryID(categoryID).OrderBy(o => o.Title).ToList<ProductCategoryImage>();
        }
    }
}
