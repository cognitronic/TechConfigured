using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq;
using ISeCommerce.Presenters.ViewInterfaces;
using ISeCommerce.Core.Domain;
using ISeCommerce.Core.Security;
using IdeaSeed.Core;
using ISeCommerce.Services;
using ISeCommerce.Core;
using ISeCommerce.Core.Domain.Interfaces;

namespace ISeCommerce.Presenters
{
    public class ProductListPresenter : Presenter
    {
        IProductListView _view;

        public ProductListPresenter(IProductListView view, ISessionProvider session)
            : base(view, session)
        {
            _view = base.GetView<IProductListView>();
            _view.InitView += new EventHandler(_view_InitView);
            _view.LoadView += new EventHandler(_view_LoadView);
            _view.UnloadView += new EventHandler(_view_UnloadView);
            _view.OnGetItems += new EventHandler<IdeaSeedGridArgs>(_view_OnGetItems);
            _view.OnItemsDataBound += new EventHandler<IdeaSeedGridItemEventArgs>(_view_OnItemsDataBound);
            _view.OnItemSelected += new EventHandler<IdeaSeedLinkButtonArgs>(_view_OnItemSelected);
            _view.OnCartClick += new EventHandler<IdeaSeedLinkButtonArgs>(_view_OnCartClick);
            MessageBus<IdeaSeedListArgs<string>>.MessageReceived += new EventHandler<IdeaSeedListArgs<string>>(ProductListPresenter_MessageReceived);
        }

        void ProductListPresenter_MessageReceived(object sender, IdeaSeedListArgs<string> e)
        {
            if (e.Items.Count > 0 && !string.IsNullOrEmpty(e.Items[0]))
            {
                var specs = from a in _view.ResultSet
                            where
                                a.Specifications.Any(b => e.Items.Contains(b.ProductCategorySpecificationPropertyValueID.ToString()))
                            select a;


                _view.ResultSet = specs.ToList<Product>();
                var args = new IdeaSeedGridArgs();
                args.BindData = true;
                _view.LoadResultSet(args);
            }
            else
            {
                var args = new IdeaSeedGridArgs();
                args.BindData = true;
                args.SortDirection = _view.SortDir;
                GetItemResults(args);
            }       
        }

        void _view_OnCartClick(object sender, IdeaSeedLinkButtonArgs e)
        {
            new ShoppingCartItemServices().AddItemToCart(e.ID, 1, Convert.ToDecimal(e.Name));
            _view.NavigateTo(SecurityContextManager.Current.CurrentURL);
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
                SessionManager.Current[ResourceStrings.Session_CurrentSortOrder] = _view.SortDir;
                MessageBus<IdeaSeedListArgs<string>>.MessageReceived -= new EventHandler<IdeaSeedListArgs<string>>(ProductListPresenter_MessageReceived);

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
            if (SessionManager.Current[ResourceStrings.Session_CurrentSortOrder] != null)
                _view.SortDir = SessionManager.Current[ResourceStrings.Session_CurrentSortOrder].ToString();
        }

        void GetItemResults(IdeaSeedGridArgs e)
        {
            if (((ProductCategory)SecurityContextManager
                .Current
                .CurrentProductCategory)
                .Products != null)
            {
                _view.ResultSet = new ProductServices()
                    .GetProductsByCategoryFamily(
                    (ProductCategory)SecurityContextManager
                    .Current
                    .CurrentProductCategory,
                    _view.CachedProducts,
                    e.SortDirection);
            }
            _view.LoadResultSet(e);
        }
    }
}
