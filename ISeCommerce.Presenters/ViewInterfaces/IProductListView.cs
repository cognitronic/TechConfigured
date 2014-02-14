using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeed.Core;
using ISeCommerce.Core.Domain;

namespace ISeCommerce.Presenters.ViewInterfaces
{
    public interface IProductListView : IBaseListView<Product>
    {
        IList<Product> CachedProducts { get; }
        string SortDir { get; set; }
        event EventHandler<IdeaSeedLinkButtonArgs> OnCartClick;
    }
}
