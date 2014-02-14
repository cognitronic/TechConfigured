using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeed.Core.Data;
using ISeCommerce.Core.Domain.Interfaces;

namespace ISeCommerce.Core.Domain.Interfaces.Data
{
    public interface IProductCategoryRepository : IRepository<ProductCategory, int>
    {
        IList<ProductCategory> GetRootCategories();
        IList<ProductCategory> GetChildrenByParentID(int parentID);
    }
}
