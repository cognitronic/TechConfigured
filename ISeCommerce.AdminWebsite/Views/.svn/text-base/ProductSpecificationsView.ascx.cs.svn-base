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
using ISeCommerce.Services;

namespace ISeCommerce.AdminWebsite.Views
{
    [PresenterType(typeof(ProductSpecificationsPresenter))]
    public partial class ProductSpecificationsView : BaseWebUserControl, IProductSpecificationsView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.SelfRegister(this);
            if (this.LoadView != null)
            {
                this.LoadView(this, EventArgs.Empty);
            }
            if (!IsPostBack)
            {
                var args = new IdeaSeedGridArgs();
                args.BindData = false;
                if (this.OnGetItems != null)
                {
                    this.OnGetItems(this, args);
                }
            }
        }

        protected void ViewItemClicked(object o, EventArgs e)
        { 
            
        }

        protected void ItemCommand(object o, GridCommandEventArgs e)
        {
            if (e.CommandName == RadGrid.PerformInsertCommandName)
            {
                if (e.Item is GridEditableItem)
                {
                    var item = new ProductSpecification();
                    item.ProductID = SecurityContextManager.Current.CurrentProduct.ID;
                    item.DisplayOnPublicSite = (e.Item.FindControl("cbDisplayOnPublicSite") as IdeaSeed.Web.UI.CheckBox).Checked;
                    item.ProductCategorySpecificationPropertyValueID = Convert.ToInt16((e.Item.FindControl("ddlValues") as ISeCommerce.AdminWeb.Controls.ProductSpecificationValuesDDL).SelectedValue);
                    new ProductSpecificationServices().Save(item);
                    Response.Redirect(SecurityContextManager.Current.CurrentURL);
                }
            }

            if (e.CommandName == RadGrid.UpdateCommandName)
            {
                if (e.Item is GridEditableItem)
                {
                    var item = new ProductSpecificationServices().GetByID((int)e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"]);
                    item.DisplayOnPublicSite = (e.Item.FindControl("cbDisplayOnPublicSite") as IdeaSeed.Web.UI.CheckBox).Checked;
                    item.ProductCategorySpecificationPropertyValueID = Convert.ToInt16((e.Item.FindControl("ddlValues") as ISeCommerce.AdminWeb.Controls.ProductSpecificationValuesDDL).SelectedValue);
                    new ProductSpecificationServices().Save(item);
                    Response.Redirect(SecurityContextManager.Current.CurrentURL);
                }
            }
        }

        protected void ItemDataBound(object o, GridItemEventArgs e)
        {
            if (e.Item is GridEditableItem && e.Item.IsInEditMode)
            {
                var ddlSpec = e.Item.FindControl("ddlSpecificationProperties") as ISeCommerce.AdminWeb.Controls.ProductCategorySpecificationsDDL;
                var ddlVals = e.Item.FindControl("ddlValues") as ISeCommerce.AdminWeb.Controls.ProductSpecificationValuesDDL;

                ddlSpec.CategoryID = SecurityContextManager.Current.CurrentProduct.Category.ID;
                ddlSpec.LoadPropertyValues(SecurityContextManager.Current.CurrentProduct.Category.ID);
                if (!e.Item.OwnerTableView.IsItemInserted)
                {
                    ddlSpec.SelectedValue = DataBinder.Eval(e.Item.DataItem, "SpecificationValue.SpecificationProperty.ID").ToString();
                    ddlVals.SpecificationID = Convert.ToInt32(ddlSpec.SelectedValue);
                    ddlVals.LoadPropertyValues();

                    ddlVals.SelectedValue = DataBinder.Eval(e.Item.DataItem, "SpecificationValue.ID").ToString();
                }
            }
        }

        protected void SpecificationSelectedIndexChanged(object o, EventArgs e)
        {
            var spec = o as ISeCommerce.AdminWeb.Controls.ProductCategorySpecificationsDDL;
            var val = spec.Parent.FindControl("ddlValues") as ISeCommerce.AdminWeb.Controls.ProductSpecificationValuesDDL;
            if (!string.IsNullOrEmpty(spec.SelectedValue))
            {
                val.SpecificationID = Convert.ToInt16(spec.SelectedValue);
                val.LoadPropertyValues();
            }
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

        public new event EventHandler LoadView;

        public new event EventHandler UnloadView;

        #region IBaseListView<ProductCategorySpecificationProperty> Members

        public string ViewTitle
        {
            get
            {
                return lblViewTitle.Text;
            }
            set
            {
                lblViewTitle.Text = value;
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
            if (ResultSet.Count > 0)
            {
                rgList.DataSource = ResultSet;
            }
            else
            {
                rgList.DataSource = new List<ProductSpecification>();
            }
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
            //rgList.PageSize = this.PageSize;
            rgList.Rebind();
        }

        public IList<ProductSpecification> ResultSet
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