using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeed.Core;
using ISeCommerce.Core.Domain.Interfaces;

namespace ISeCommerce.Presenters.ViewInterfaces
{
    public interface IFeaturedProductsCarouselView : IView
    {
        string ProductImage { get; set; }
        string ProductName { get; set; }
        string DisplayedPrice { get; set; }
        void NavigateTo(string url);
        IList<IProduct> FeaturedProducts { get; set; }
        event EventHandler<IdeaSeedLinkButtonArgs> OnWishlistClick;
        event EventHandler<IdeaSeedLinkButtonArgs> OnAddToCartClick;
        event EventHandler OnProductClick;
    }
}
