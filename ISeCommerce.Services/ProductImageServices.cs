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
    public class ProductImageServices
    {
        public ProductImage GetByID(int id)
        {
            return new ProductImageRepository().GetByID(id, false);
        }

        public IList<ProductImage> GetPagedList(int startRow, int pageSize, out int count)
        {
            return new ProductImageRepository()
                .GetPagedList(startRow, pageSize, out count)
                .OrderBy(o => o.Title)
                .ToList<ProductImage>();
        }

        public IList<ProductImage> GetAll()
        {
            return new ProductImageRepository()
                .GetAll();
        }

        public ProductImage Save(ProductImage item)
        {
            return new ProductImageRepository().SaveOrUpdate(item);
        }

        public void Delete(ProductImage item)
        {
            new ProductImageRepository().Delete(item);
        }

        public IList<ProductImage> GetProductCategoryImages(int productID)
        {
            return new ProductImageRepository().GetbyProductID(productID).OrderBy(o => o.Title).ToList<ProductImage>();
        }

        public void UpdateToNoDefault(int productID)
        {
            new ProductImageRepository().UpdateToNoDefault(productID);
        }
    }
}
