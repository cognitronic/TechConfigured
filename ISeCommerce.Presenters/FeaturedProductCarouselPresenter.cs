using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISeCommerce.Presenters.ViewInterfaces;
using ISeCommerce.Core.Domain;
using ISeCommerce.Core.Security;
using IdeaSeed.Core;
using ISeCommerce.Services;
using ISeCommerce.Core;
using ISeCommerce.Core.Domain.Interfaces;

namespace ISeCommerce.Presenters
{
    public class FeaturedProductCarouselPresenter : Presenter
    {
        IFeaturedProductsCarouselView _view;

        public FeaturedProductCarouselPresenter(IFeaturedProductsCarouselView view, ISessionProvider session)
            : base(view, session)
        {
            _view = base.GetView<IFeaturedProductsCarouselView>();
            _view.InitView += new EventHandler(_view_InitView);
            _view.LoadView += new EventHandler(_view_LoadView);
            _view.UnloadView += new EventHandler(_view_UnloadView);
            _view.OnProductClick += new EventHandler(_view_OnProductClick);
            _view.OnAddToCartClick += new EventHandler<IdeaSeedLinkButtonArgs>(_view_OnAddToCartClick);
            _view.OnWishlistClick += new EventHandler<IdeaSeedLinkButtonArgs>(_view_OnWishlistClick);
        }

        void _view_OnWishlistClick(object sender, IdeaSeedLinkButtonArgs e)
        {
            _view.NavigateTo("http://www.cnn.com");
        }

        void _view_OnProductClick(object sender, EventArgs e)
        {
            
        }

        void _view_OnAddToCartClick(object sender, IdeaSeedLinkButtonArgs e)
        {
            //new ShoppingCartItemServices().AddItemToCart(e.ID, 1, Convert.ToDecimal(e.Name));
            var item = new ShoppingCartItem();
            item.ProductID = e.ID;
            item.Qty = 1;
            item.Price = Convert.ToDecimal(e.Name);
            item.ShoppingCartID = SecurityContextManager.Current.CurrentShoppingCart.ID;
            //SecurityContextManager.Current.CurrentShoppingCart.CartItems.Add();
            new ShoppingCartItemServices().Save(item);
            _view.NavigateTo(ResourceStrings.Page_MyCart);
        }

        void _view_UnloadView(object sender, EventArgs e)
        {
           
        }

        void _view_LoadView(object sender, EventArgs e)
        {
            _view.FeaturedProducts = new ProductServices().GetFeatured().ToList<IProduct>();
        }

        void _view_InitView(object sender, EventArgs e)
        {
            
        }
    }
}
