using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeed.Core;
using ISeCommerce.Core.Domain.Interfaces;
using ISeCommerce.Core.Domain;

namespace ISeCommerce.Presenters.ViewInterfaces
{
    public interface IShoppingCartListView : IBaseListView<ShoppingCartItem>, IShoppingCart
    {
    }
}
