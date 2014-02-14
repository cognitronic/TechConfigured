﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeed.Core;
using ISeCommerce.Core.Domain;

namespace ISeCommerce.AdminPresenters.ViewInterfaces
{
    public interface IAdminProductCategoryListView : IBaseListView<ProductCategory>
    {
        IList<ProductCategory> CachedProductCategories { get; }
    }
}