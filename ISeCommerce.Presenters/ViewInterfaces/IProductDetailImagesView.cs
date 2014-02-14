using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeed.Core;
using ISeCommerce.Core.Domain.Interfaces;

namespace ISeCommerce.Presenters.ViewInterfaces
{
    public interface IProductDetailImagesView : IView
    {
        IProduct SelectedProduct { get; set; }
        event EventHandler<IdeaSeedLinkButtonArgs> AddToCart;
        event EventHandler AddToWishlist;
        void NavigateTo(string url);
        int QtyToAdd { get; set; }
    }
}
