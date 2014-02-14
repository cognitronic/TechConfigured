using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ISeCommerce.AdminPresenters.ViewInterfaces;
using ISeCommerce.AdminPresenters;
using ISeCommerce.Core.Domain;
using ISeCommerce.Core.Security;
using IdeaSeed.Core;
using ISeCommerce.AdminWeb.Bases;
using ISeCommerce.Core;
using Telerik.Web.UI;

namespace ISeCommerce.AdminWebsite.Views
{
    [PresenterType(typeof(AdminProductCategoryListPresenter))]
    public partial class AdminProductCategoryListView : BaseWebUserControl, IAdminProductCategoryListView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.SelfRegister(this);
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

        protected void AddCategoryClicked(object o, EventArgs e)
        {
            NavigateTo(SecurityContextManager.Current.CurrentURL + "/New");
        }

        protected void ViewCategoryProductsClicked(object o, EventArgs e)
        { 
            
        }

        protected void ViewItemClicked(object o, EventArgs e)
        {
            var lb = o as LinkButton;
            var args = new IdeaSeedLinkButtonArgs();
            args.ID = Convert.ToInt32(lb.Attributes["itemid"]);
            args.Name = lb.Attributes["itemname"];
            if (this.OnItemSelected != null)
            {
                this.OnItemSelected(o, args);
            }
        }

        protected void ItemCommand(object o, GridCommandEventArgs e)
        {

        }

        protected void ItemDataBound(object o, GridItemEventArgs e)
        {

        }

        protected void NeedDataSource(object o, GridNeedDataSourceEventArgs e)
        {
            var args = new IdeaSeedGridArgs();
            args.BindData = false;
            if (this.OnGetItems != null)
            {
                this.OnGetItems(this, args);
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

        public new event EventHandler LoadView;
        public new event EventHandler UnloadView;

        #region IBaseListView<ProductCategory> Members

        public IList<ProductCategory> CachedProductCategories
        {
            get
            {
                return (IList<ProductCategory>)Cache[ResourceStrings.Cache_ProductCategoryList];
            }
        }

        public int CurrentPageIndex
        {
            get
            {
                return rgList.CurrentPageIndex;
            }
            set
            {

            }
        }

        public void LoadResultSet(IdeaSeedGridArgs args)
        {
            rgList.DataSource = ResultSet;
            if (args.BindData)
                rgList.DataBind();
        }

        public void NavigateTo(string url)
        {
            Response.Redirect(url);
        }

        public event EventHandler<IdeaSeedGridArgs> OnGetItems;

        public event EventHandler<IdeaSeedLinkButtonArgs> OnItemSelected;

        public event EventHandler<IdeaSeedGridItemEventArgs> OnItemsDataBound;

        public int PageSize
        {
            get
            {
                return rgList.PageSize;
            }
            set
            {
                rgList.PageSize = value;
            }
        }

        public void RebindGrid()
        {
            rgList.PageSize = this.PageSize;
            rgList.Rebind();
        }

        public IList<ProductCategory> ResultSet
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