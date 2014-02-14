using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ISeCommerce.Core.Domain;
using ISeCommerce.Core.Domain.Interfaces.Services;
using ISeCommerce.Persistence.Repositories;

namespace ISeCommerce.Services
{
    public class ProductServices : IProductServices<Product>
    {
        #region IProductServices<Product> Members

        public Product GetByID(int id)
        {
            return new ProductRepository().GetByID(id, false);
        }

        public IList<Product> GetPagedList(int startRow, int pageSize, out int count)
        {
            return new ProductRepository()
                .GetPagedList(startRow, pageSize, out count)
                .OrderBy(o => o.Name)
                .ToList<Product>(); ;
        }

        public IList<Product> GetAll()
        {
            return new ProductRepository()
                .GetAll()
                .OrderBy(o => o.Name)
                .ToList<Product>(); ;
        }

        public Product Save(Product item)
        {
            return new ProductRepository().SaveOrUpdate(item);
        }

        public void Delete(Product item)
        {
            new ProductRepository().Delete(item);
        }

        public IList<Product> GetByCategoryID(int categoryID)
        {
            return new ProductRepository()
                .GetByCategoryID(categoryID)
                .OrderBy(o => o.Name)
                .ToList<Product>(); ;
        }

        public IList<Product> GetFeatured()
        {
            return new ProductRepository()
                .GetByIsFeatured(true)
                .OrderBy(o => o.Name)
                .ToList<Product>(); ;
        }

        public IList<Product> RecursivelyGetByCategoryID(int categoryID)
        {
            return new ProductRepository()
                .RecursivelyGetByCategoryID(categoryID)
                .OrderBy(o => o.Name)
                .ToList<Product>();
        }

        private IList<Product> _ProductsList = new List<Product>();
        public IList<Product> GetProductsByCategoryFamily(ProductCategory category, IList<Product> products, string direction)
        {
            switch (direction)
            {
                case "LowPrice":
                    GetAllByCategoryIDFromCache(category, products);
                    return _ProductsList.OrderBy( o => o.ListPrice).ToList<Product>();
                case "HiPrice":
                    GetAllByCategoryIDFromCache(category, products);
                    return _ProductsList.OrderByDescending( o => o.ListPrice).ToList<Product>();
            }
            return null;
        }

        public IList<Product> GetProductsByCategoryFamily(int startRow, int pageSize, out int count, ProductCategory category, IList<Product> products)
        {
            GetAllByCategoryIDFromCache(category, products);
            count = _ProductsList.Count();
            return _ProductsList.Skip((startRow - 1) * pageSize).Take(pageSize).ToList<Product>();
        }

        private void GetAllByCategoryIDFromCache(ProductCategory category, IList<Product> products)
        {
            var list = new List<Product>();
            if (category.ChildCategories.Count > 0)
            {
                foreach (var cat in category.ChildCategories)
                {
                    GetAllByCategoryIDFromCache((ProductCategory)cat, products);
                }
                var t = from prod in products where prod.ProductCategoryID == category.ID select prod;
                foreach (var p in t)
                {
                    _ProductsList.Add((Product)p);
                }
            }
            else
            {
                var t = from prod in products where prod.ProductCategoryID == category.ID select prod;
                foreach (var p in t)
                {
                    _ProductsList.Add((Product)p);
                }
            }
        }

        private string _productURL;
        public string GetProductURL(string product, int categoryID, IList<ProductCategory> categories)
        {
            BuildProductURL(categoryID, categories);
            return "/" + _productURL + product.Replace(" ", "-");
        }

        private void BuildProductURL(int categoryID, IList<ProductCategory> categories)
        {
            var pc = categories.First(p => p.ID == categoryID);
            if (pc.ParentID != null)
            {
                BuildProductURL((int)pc.ParentID, categories);
            }
            _productURL += pc.Name.Replace(" ", "-") + "/";
        }
        #endregion
    }
}
