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
    public class ShoppingCartListPresenter : Presenter
    {
        IShoppingCartListView _view;

        public ShoppingCartListPresenter(IShoppingCartListView view, ISessionProvider session)
            : base(view, session)
        {
            _view = base.GetView<IShoppingCartListView>();
            _view.InitView += new EventHandler(_view_InitView);
            _view.LoadView += new EventHandler(_view_LoadView);
            _view.UnloadView += new EventHandler(_view_UnloadView);
            _view.OnGetItems += new EventHandler<IdeaSeedGridArgs>(_view_OnGetItems);
            _view.OnItemsDataBound += new EventHandler<IdeaSeedGridItemEventArgs>(_view_OnItemsDataBound);
            _view.OnItemSelected += new EventHandler<IdeaSeedLinkButtonArgs>(_view_OnItemSelected);
        }

        void _view_OnItemSelected(object sender, IdeaSeedLinkButtonArgs e)
        {
            
        }

        void _view_OnItemsDataBound(object sender, IdeaSeedGridItemEventArgs e)
        {
            
        }

        void _view_OnGetItems(object sender, IdeaSeedGridArgs e)
        {
            GetItemResults(e);
        }

        void _view_UnloadView(object sender, EventArgs e)
        {
            if (SessionManager.Current != null)
                SessionManager.Current[ResourceStrings.Session_CurrentPageSize] = _view.PageSize;
        }

        void _view_LoadView(object sender, EventArgs e)
        {
        }

        void _view_InitView(object sender, EventArgs e)
        {
            if (SessionManager.Current[ResourceStrings.Session_CurrentPageSize] != null)
                _view.PageSize = Convert.ToInt16(SessionManager.Current[ResourceStrings.Session_CurrentPageSize]);
            else
                _view.PageSize = 25;
        }

        void GetItemResults(IdeaSeedGridArgs e)
        {
            if (SecurityContextManager.Current.CurrentURL.Split('/').Count() > 3 && !string.IsNullOrEmpty(SecurityContextManager.Current.CurrentURL.Split('/')[4]))
            {
                var session = new SessionDataServices().GetByID(Convert.ToInt32(SecurityContextManager.Current.CurrentURL.Split('/')[4]));
                var cart = IdeaSeed.Core.Utils.Utilities.SerializeFromString<ShoppingCartSerializable>(session.Value);
                if (cart != null)
                {
                    var newcart = new List<ShoppingCartItem>();
                    foreach(var item in cart.CartItems)
                    {
                        var ci = new ShoppingCartItemServices().GetByID(item.ID);
                        newcart.Add(ci);
                    }
                    var c = new ShoppingCart();
                    c.ID = newcart[0].Cart.ID;
                    c.CartItems = newcart;
                    c.DateCreated = newcart[0].Cart.DateCreated;
                    SecurityContextManager.Current.CurrentShoppingCart = c;
                    _view.ResultSet = newcart;
                }
            }
            //if (SecurityContextManager
            //    .Current
            //    .CurrentShoppingCart != null)
            //{
            //    _view.ResultSet = SecurityContextManager
            //    .Current
            //    .CurrentShoppingCart
            //    .CartItems;
            //}
            _view.LoadResultSet(e);
        }
    }
}
