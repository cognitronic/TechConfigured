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
    [PresenterType(typeof(ProductListPresenter))]
    public partial class ProductListView : BaseWebUserControl, IProductListView
    {
        protected override void OnInit(EventArgs e)
        {
            base.SelfRegister(this);
            if (this.InitView != null)
            {
                this.InitView(this, e);
            }
            ((RadComboBox)((RadToolBarItem)rtbList.FindButtonByCommandName("GridPageSize")).FindControl("ddlGridPageSize")).SelectedValue = this.PageSize.ToString();
            ((RadComboBox)((RadToolBarItem)rtbList.FindButtonByCommandName("Sort")).FindControl("ddlSort")).SelectedValue = this.SortDir.ToString();
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
                args.SortDirection = this.SortDir;
                this.OnGetItems(this, args);
            }
        }

        protected void WishListClicked(object o, EventArgs e)
        { 
            
        }

        protected void ProductClicked(object o, EventArgs e)
        {
            NavigateTo(new ProductServices()
                .GetProductURL(
                ((LinkButton)o)
                .Attributes["productname"], 
                Convert.ToInt16(((LinkButton)o)
                .Attributes["categoryid"]), 
                (IList<ProductCategory>)Cache[ResourceStrings.Cache_ProductCategoryList]));
        }

        protected void AddToCartClicked(object o, EventArgs e)
        {
            var args = new IdeaSeedLinkButtonArgs();
            args.ID = Convert.ToInt32(((LinkButton)o).Attributes["itemid"]);
            args.Name = ((LinkButton)o).Attributes["itemprice"];
            if (this.OnCartClick != null)
            {
                this.OnCartClick(o, args);
            } 
        }

        protected override void OnUnload(EventArgs e)
        {
            if (this.UnloadView != null)
            {
                this.UnloadView(this, e);
            }
            base.OnUnload(e);
        }

        protected void SortIndexChanged(object o, EventArgs e)
        {
            this.SortDir = ((RadComboBox)((RadToolBarItem)rtbList.FindButtonByCommandName("Sort")).FindControl("ddlSort")).SelectedValue;
            if (this.OnGetItems != null)
            {
                var args = new IdeaSeedGridArgs();
                args.SortDirection = this.SortDir;
                this.OnGetItems(this, args);
            }
        }

        protected void GridPageSizeChanged(object o, EventArgs e)
        {
            var args = new IdeaSeedGridArgs();
            PageSize = Convert.ToInt16(((RadComboBox)((RadToolBarItem)rtbList.FindButtonByCommandName("GridPageSize")).FindControl("ddlGridPageSize")).SelectedValue);
        }

        protected void NeedDataSource(object o, RadListViewNeedDataSourceEventArgs e)
        {
            var args = new IdeaSeedGridArgs();
            args.BindData = false;
            if (this.OnGetItems != null)
            {
                this.OnGetItems(this, args);
            }
        }

        protected void ButtonClicked(object o, RadToolBarEventArgs e)
        {
        }

        public new event EventHandler LoadView;

        public event EventHandler<IdeaSeedLinkButtonArgs> OnCartClick;

        public new event EventHandler InitView;

        public new event EventHandler UnloadView;

        #region IBaseListView<Product> Members

        public string SortDir 
        {
            get
            {
                return ((RadComboBox)((RadToolBarItem)rtbList.FindButtonByCommandName("Sort")).FindControl("ddlSort")).SelectedValue;
            }
            set
            {
                ((RadComboBox)((RadToolBarItem)rtbList.FindButtonByCommandName("Sort")).FindControl("ddlSort")).SelectedValue = value;
            }
        }

        public IList<Product> CachedProducts
        {
            get
            {
                return (IList<Product>)Cache["ProductList"];
            }
        }

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
            if(args.BindData)
                dlList.DataBind();
        }

        public void NavigateTo(string url)
        {
            HttpContext.Current.Response.Redirect(url);
        }

        public event EventHandler<IdeaSeedGridArgs> OnGetItems;

        public event EventHandler<IdeaSeedLinkButtonArgs> OnItemSelected;

        public event EventHandler<IdeaSeedGridItemEventArgs> OnItemsDataBound;

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

        public IList<Product> ResultSet
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
    }
}