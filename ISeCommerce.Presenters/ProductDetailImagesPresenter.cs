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
    public class ProductDetailImagesPresenter : Presenter
    {
        IProductDetailImagesView _view;

        public ProductDetailImagesPresenter(IProductDetailImagesView view, ISessionProvider session)
            : base(view, session)
        {
            _view = base.GetView<IProductDetailImagesView>();
            _view.InitView += new EventHandler(_view_InitView);
            _view.LoadView += new EventHandler(_view_LoadView);
            _view.UnloadView += new EventHandler(_view_UnloadView);
            _view.AddToCart += new EventHandler<IdeaSeedLinkButtonArgs>(_view_AddToCart);
            _view.AddToWishlist += new EventHandler(_view_AddToWishlist);
        }

        void _view_AddToWishlist(object sender, EventArgs e)
        {
            
        }

        void _view_AddToCart(object sender, IdeaSeedLinkButtonArgs e)
        {
            new ShoppingCartItemServices().AddItemToCart(e.ID, _view.QtyToAdd, Convert.ToDecimal(e.Name));
            _view.NavigateTo(SecurityContextManager.Current.CurrentURL);
        }

        void _view_UnloadView(object sender, EventArgs e)
        {
           
        }

        void _view_LoadView(object sender, EventArgs e)
        {
            _view.SelectedProduct = SecurityContextManager.Current.CurrentProduct;
            _view.ViewTitle = SecurityContextManager.Current.CurrentProduct.Name;
        }

        void _view_InitView(object sender, EventArgs e)
        {
            
        }
    }
}
