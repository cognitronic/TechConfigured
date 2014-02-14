using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ISeCommerce.Presenters.ViewInterfaces;
using System.Text;
using ISeCommerce.Presenters;
using ISeCommerce.Core.Domain;
using ISeCommerce.Core.Security;
using IdeaSeed.Core;
using ISeCommerce.Web.Bases;
using ISeCommerce.Services;
using ISeCommerce.Core;

namespace ISeCommerce.Website.Views
{
    [PresenterType(typeof(ShoppingCartWidgetPresenter))]
    public partial class ShoppingCartWidgetView : BaseWebUserControl, IShoppingCartWidgetView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.SelfRegister(this);
            LoadItems();
        }

        protected void ViewCartClicked(object o, EventArgs e)
        {
            if (this.ViewCartClick != null)
            {
                var args = new IdeaSeedLinkButtonArgs();
                this.ViewCartClick(o, args);
            }
        }

        protected void CheckOutClicked(object o, EventArgs e)
        {
            if (this.CheckoutClick != null)
            {
                var args = new IdeaSeedLinkButtonArgs();
                this.CheckoutClick(o, args);
            }
        }

        public new event EventHandler LoadView;

        #region IShoppingCartWidgetView Members

        public void NavigateTo(string url)
        {
            Response.Redirect(url);
        }

        public event EventHandler<IdeaSeedLinkButtonArgs> ViewCartClick;

        public event EventHandler<IdeaSeedLinkButtonArgs> CheckoutClick;

        public IList<Core.Domain.ShoppingCartItem> CartItems
        {
            get;
            set;
        }

        public string ItemCount 
        {
            get
            {
                return lblCartItemsCount.Text;
            }
            set
            {
                lblCartItemsCount.Text = value;
            }
        }

        public string BuildItems()
        {
            if (CartItems != null && CartItems.Count > 0)
            {
                var sb = new StringBuilder();
                sb.Append("<ul>");
                foreach (var item in CartItems)
                {
                    if (item != null)
                    {
                        sb.Append("<li><p class='bold title'>");
                        sb.Append("<a href='");
                        sb.Append(new ProductServices()
                        .GetProductURL((item.Product).Name,
                        item.Product.ProductCategoryID,
                        (IList<ProductCategory>)Cache[ResourceStrings.Cache_ProductCategoryList]));
                        sb.Append("'>");
                        sb.Append(item.Product.Name);
                        sb.Append("</a></p><div class='grey'><p class='left'>Qty: <span class='bold'>");
                        sb.Append(item.Qty.ToString());
                        sb.Append("</span></p><p class='right'>Price: <span class='bold'>");
                        sb.Append(string.Format("{0:c}", item.Qty * item.Price));
                        sb.Append("</span></p></div></li>");
                    }
                }
                sb.Append("</ul>");
                return sb.ToString();
            }
            else
            {
                ItemCount = "0";
                var sb = new StringBuilder();
                sb.Append("<ul>");
                sb.Append("<li><p class='bold title'>");
                sb.Append("Cart Empty");
                sb.Append("</p></li>");
                sb.Append("</ul>");
                return sb.ToString();
            }
        }

        public void LoadItems()
        {
            if (this.LoadView != null)
            {
                this.LoadView(this, EventArgs.Empty);
            }
            divItems.InnerHtml = BuildItems();
        }

        #endregion
    }
}