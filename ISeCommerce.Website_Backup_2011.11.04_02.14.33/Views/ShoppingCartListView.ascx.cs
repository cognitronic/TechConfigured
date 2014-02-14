using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ISeCommerce.Presenters.ViewInterfaces;
using ISeCommerce.Presenters;
using ISeCommerce.Core.Domain;
using ISeCommerce.Core.Security;
using IdeaSeed.Core;
using Telerik.Web.UI;
using ISeCommerce.Web.Bases;
using ISeCommerce.Core;
using ISeCommerce.Services;

namespace ISeCommerce.Website.Views
{
    [ViewStateModeById]
    [PresenterType(typeof(ShoppingCartListPresenter))]
    public partial class ShoppingCartListView : BaseWebUserControl, IShoppingCartListView
    {
        protected override void OnInit(EventArgs e)
        {
            base.SelfRegister(this);
            if (this.InitView != null)
            {
                this.InitView(this, e);
            }
            base.OnInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.LoadView != null)
            {
                this.LoadView(this, EventArgs.Empty);
            }
            if (this.OnGetItems != null)
            {
                var args = new IdeaSeedGridArgs();
                args.BindData = true;
                this.OnGetItems(this, args);
            }
        }

        protected void DeleteClicked(object o, EventArgs e)
        {
            new ShoppingCartItemServices().Delete(new ShoppingCartItemServices().GetByID(Convert.ToInt32((o as IdeaSeed.Web.UI.LinkButton).Attributes["itemID"])));
            SecurityContextManager.Current.CurrentShoppingCart = null;
            Response.Redirect(SecurityContextManager.Current.CurrentURL);
        }

        protected void ContinueShoppingClicked(object o, EventArgs e)
        {
            Response.Redirect(SecurityContextManager.Current.BaseURL);
        }

        protected void UpdateCartClicked(object o, EventArgs e)
        {
            foreach (var item in dlList.Items)
            {
                SecurityContextManager.Current.CurrentShoppingCart.CartItems[SecurityContextManager.Current.CurrentShoppingCart.CartItems.IndexOf((ShoppingCartItem)item.DataItem)].Qty = Convert.ToInt16((item.FindControl("tbQty") as TextBox).Text);
                new ShoppingCartItemServices().UpdateItem(SecurityContextManager.Current.CurrentShoppingCart.CartItems[SecurityContextManager.Current.CurrentShoppingCart.CartItems.IndexOf((ShoppingCartItem)item.DataItem)] as ShoppingCartItem);
            }
            Response.Redirect(SecurityContextManager.Current.CurrentURL);
        }

        #region IBaseListView<IShoppingCartItem> Members

        public new event EventHandler LoadView;
        public new event EventHandler InitView;
        public new event EventHandler UnloadView;

        public int CurrentPageIndex
        {
            get
            {
                return rdpList.CurrentPageIndex;
            }
            set
            {

            }
        }

        public void LoadResultSet(IdeaSeedGridArgs args)
        {
            dlList.DataSource = ResultSet;
            if (args.BindData)
                dlList.DataBind();
        }

        public void NavigateTo(string url)
        {
            Response.Redirect(url);
        }

        public event EventHandler<IdeaSeedGridArgs> OnGetItems;

        public event EventHandler<IdeaSeedLinkButtonArgs> OnItemSelected;

        public event EventHandler<IdeaSeedGridItemEventArgs> OnItemsDataBound;

        protected void NeedDataSource(object o, RadListViewNeedDataSourceEventArgs e)
        {
            var args = new IdeaSeedGridArgs();
            args.BindData = false;
            if (this.OnGetItems != null)
            {
                this.OnGetItems(this, args);
            }
        }

        public int PageSize
        {
            get
            {
                return rdpList.PageSize;
            }
            set
            {
                rdpList.PageSize = value;
            }
        }

        public void RebindGrid()
        {
            rdpList.PageSize = this.PageSize;
            dlList.Rebind();
        }

        public IList<Core.Domain.Interfaces.IShoppingCartItem> ResultSet
        {
            get;
            set;
        }

        public int VirtualItemCount
        {
            get;
            set;
        }

        #endregion

        #region IShoppingCart Members

        public Core.Domain.Interfaces.ICustomer Customer
        {
            get;
            set;
        }

        public IList<Core.Domain.Interfaces.IShoppingCartItem> CartItems
        {
            get;
            set;
        }

        public int ID
        {
            get;
            set;
        }

        public DateTime DateCreated
        {
            get;
            set;
        }

        #endregion
    }
}