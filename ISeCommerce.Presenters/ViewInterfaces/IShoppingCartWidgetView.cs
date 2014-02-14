using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeed.Core;
using ISeCommerce.Core.Domain.Interfaces;
using ISeCommerce.Core.Domain;

namespace ISeCommerce.Presenters.ViewInterfaces
{
    public interface IShoppingCartWidgetView : IView
    {
        event EventHandler<IdeaSeedLinkButtonArgs> ViewCartClick;
        event EventHandler<IdeaSeedLinkButtonArgs> CheckoutClick;
        IList<ShoppingCartItem> CartItems { get; set; }
        string ItemCount { get; set; }
        void NavigateTo(string url);
        void LoadItems();
    }
}
