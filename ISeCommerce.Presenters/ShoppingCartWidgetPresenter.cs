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
    public class ShoppingCartWidgetPresenter : Presenter
    {
        IShoppingCartWidgetView _view;

        public ShoppingCartWidgetPresenter(IShoppingCartWidgetView view, ISessionProvider session)
            : base(view, session)
        {
            _view = base.GetView<IShoppingCartWidgetView>();
            _view.InitView += new EventHandler(_view_InitView);
            _view.LoadView += new EventHandler(_view_LoadView);
            _view.UnloadView += new EventHandler(_view_UnloadView);
            _view.CheckoutClick += new EventHandler<IdeaSeedLinkButtonArgs>(_view_CheckoutClicked);
            _view.ViewCartClick += new EventHandler<IdeaSeedLinkButtonArgs>(_view_ViewCartClicked);
            //MessageBus<IdeaSeedLinkButtonArgs>.MessageReceived += new EventHandler<IdeaSeedLinkButtonArgs>(ShoppingCartWidgetPresenter_MessageReceived);
        }

        //void ShoppingCartWidgetPresenter_MessageReceived(object sender, IdeaSeedLinkButtonArgs e)
        //{
        //    _view.LoadItems();
        //}

        void _view_ViewCartClicked(object sender, IdeaSeedLinkButtonArgs e)
        {
            var cart = new ShoppingCartSerializable();
            cart.DateCreated = SecurityContextManager.Current.CurrentShoppingCart.DateCreated;
            cart.ID = SecurityContextManager.Current.CurrentShoppingCart.ID;
            cart.CartItems = new List<ShoppingCartItem>();
            foreach (var c in SecurityContextManager.Current.CurrentShoppingCart.CartItems)
            {
                cart.CartItems.Add((ShoppingCartItem)c);
            }
            var session = new SessionData();
            if (SecurityContextManager.Current.CurrentSessionData != null)
            {
                session = new SessionDataServices().GetByID(SecurityContextManager.Current.CurrentSessionData.ID);
                session.Value = IdeaSeed.Core.Utils.Utilities.SerializeToString(cart);
            }
            else
            {
                session.Value = IdeaSeed.Core.Utils.Utilities.SerializeToString(cart);
                SecurityContextManager.Current.CurrentSessionData = session;
            }
            new SessionDataServices().Save(session);
            SecurityContextManager.Current.WentSecure = true;
            _view.NavigateTo(ResourceStrings.Page_SecureCheckout + "Cart/" + session.ID.ToString());
            
        }

        void _view_CheckoutClicked(object sender, IdeaSeedLinkButtonArgs e)
        {
            var cart = new ShoppingCartSerializable();
            cart.DateCreated = SecurityContextManager.Current.CurrentShoppingCart.DateCreated;
            cart.ID = SecurityContextManager.Current.CurrentShoppingCart.ID;
            cart.CartItems = new List<ShoppingCartItem>();
            foreach (var c in SecurityContextManager.Current.CurrentShoppingCart.CartItems)
            {
                cart.CartItems.Add((ShoppingCartItem)c);
            }
            var session = new SessionData();
            if (SecurityContextManager.Current.CurrentSessionData != null)
            {
                session = new SessionDataServices().GetByID(SecurityContextManager.Current.CurrentSessionData.ID);
                session.Value = IdeaSeed.Core.Utils.Utilities.SerializeToString(cart);
            }
            else
            {
                session.Value = IdeaSeed.Core.Utils.Utilities.SerializeToString(cart);
                SecurityContextManager.Current.CurrentSessionData = session;
            }
            new SessionDataServices().Save(session);

            _view.NavigateTo(ResourceStrings.Page_SecureCheckout + "Cart/" + session.ID.ToString());
        }

        void _view_UnloadView(object sender, EventArgs e)
        {
            //MessageBus<IdeaSeedLinkButtonArgs>.MessageReceived -= new EventHandler<IdeaSeedLinkButtonArgs>(ShoppingCartWidgetPresenter_MessageReceived);
        }

        void _view_LoadView(object sender, EventArgs e)
        {
            LoadCart();
        }

        void _view_InitView(object sender, EventArgs e)
        {
            
        }

        private void LoadCart()
        {
            if (SecurityContextManager.Current.WentSecure)
            {
                SecurityContextManager.Current.CurrentShoppingCart = new ShoppingCartServices().GetByID(SecurityContextManager.Current.CurrentShoppingCart.ID);
                _view.CartItems = SecurityContextManager.Current.CurrentShoppingCart.CartItems;
                _view.ItemCount = SecurityContextManager.Current.CurrentShoppingCart.CartItems.Count.ToString();
            }
            if (SecurityContextManager.Current.CurrentShoppingCart != null)
            {
                _view.CartItems = SecurityContextManager.Current.CurrentShoppingCart.CartItems;
                _view.ItemCount = SecurityContextManager.Current.CurrentShoppingCart.CartItems.Count.ToString();
            }
        }
    }
}
