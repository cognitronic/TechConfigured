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
using ISeCommerce.Services;
using ISeCommerce.AdminWeb.Bases;
using ISeCommerce.Core;
using Telerik.Web.UI;

namespace ISeCommerce.AdminWebsite.Views
{
    [PresenterType(typeof(CategorySpecificationsPresenter))]
    public partial class CategorySpecificationsView : BaseWebUserControl, ICategorySpecificationsView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.SelfRegister(this);
            if (this.LoadView != null)
            {
                this.LoadView(this, EventArgs.Empty);
            }
            //if (this.OnGetSpecifications != null)
            //{
            //    var args = new IdeaSeedGridArgs();
            //    args.BindData = true;
            //    this.OnGetSpecifications(this, args);
            //}
            if (SelectedPropertyID > 0)
            {
                var args = new IdeaSeedGridArgs();
                args.BindData = true;
                if (this.OnGetValues != null)
                {
                    this.OnGetValues(this, args);
                }
            }
        }

        protected void SpecificationsItemCommand(object o, GridCommandEventArgs e)
        {
            if (e.CommandName == RadGrid.EditCommandName || e.CommandName == "RowClick" && e.Item is GridDataItem)
            {
                e.Item.Selected = true;
                SelectedPropertyID = Convert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"]);
                var args = new IdeaSeedGridArgs();
                args.BindData = true;
                if (this.OnGetValues != null)
                {
                    this.OnGetValues(this, args);
                }
            }

            if (e.CommandName == RadGrid.PerformInsertCommandName)
            {
                if (e.Item is GridEditableItem)
                {
                    var item = new ProductCategorySpecificationProperty();
                    item.Name = (e.Item.FindControl("tbName") as IdeaSeed.Web.UI.TextBox).Text;
                    item.CanFilterBy = (e.Item.FindControl("cbCanFilterBy") as IdeaSeed.Web.UI.CheckBox).Checked;
                    item.ProductCategoryID = SecurityContextManager.Current.CurrentProductCategory.ID;
                    new ProductCategorySpecificationServices().SaveProperty(item);
                    Response.Redirect(SecurityContextManager.Current.CurrentURL);
                }
            }

            if (e.CommandName == RadGrid.UpdateCommandName)
            {
                if (e.Item is GridEditableItem)
                {
                    var item = new ProductCategorySpecificationServices().GetPropertyByID((int)e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"]);
                    item.CanFilterBy = (e.Item.FindControl("cbCanFilterBy") as IdeaSeed.Web.UI.CheckBox).Checked;
                    item.Name = (e.Item.FindControl("tbName") as IdeaSeed.Web.UI.TextBox).Text;
                    new ProductCategorySpecificationServices().SaveProperty(item);
                    Response.Redirect(SecurityContextManager.Current.CurrentURL);
                }
            }
        }

        protected void SpecificationsItemDataBound(object o, GridItemEventArgs e)
        {
            
        }

        protected void SpecificationsNeedDataSource(object o, GridNeedDataSourceEventArgs e)
        {
            var args = new IdeaSeedGridArgs();
            args.BindData = false;
            if (this.OnGetSpecifications != null)
            {
                this.OnGetSpecifications(this, args);
            }
        }

        protected void ValuesItemCommand(object o, GridCommandEventArgs e)
        {
            if (e.CommandName == RadGrid.PerformInsertCommandName)
            {
                if (e.Item is GridEditableItem)
                {
                    var item = new ProductCategorySpecificationPropertyValue();
                    item.Value = (e.Item.FindControl("tbValue") as IdeaSeed.Web.UI.TextBox).Text;
                    item.ProductCategorySpecificationPropertyID = this.SelectedPropertyID;
                    new ProductCategorySpecificationServices().SaveValue(item);
                    Response.Redirect(SecurityContextManager.Current.CurrentURL);
                }
            }

            if (e.CommandName == RadGrid.UpdateCommandName)
            {
                if (e.Item is GridEditableItem)
                {
                    var item = new ProductCategorySpecificationServices().GetValueByID((int)e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"]);
                    item.Value = (e.Item.FindControl("tbValue") as IdeaSeed.Web.UI.TextBox).Text;
                    new ProductCategorySpecificationServices().SaveValue(item);
                    Response.Redirect(SecurityContextManager.Current.CurrentURL);
                }
            }
        }

        protected void ValuesItemDataBound(object o, GridItemEventArgs e)
        {

        }

        protected void ValuesNeedDataSource(object o, GridNeedDataSourceEventArgs e)
        {
            var args = new IdeaSeedGridArgs();
            args.BindData = false;
            if (this.OnGetValues != null)
            {
                this.OnGetValues(this, args);
            }
        }

        #region ICategorySpecificationsView Members

        public new event EventHandler LoadView;

        public new event EventHandler UnloadView;

        public IList<ProductCategorySpecificationProperty> SpecificationsResultSet
        {
            get;
            set;
        }

        public IList<ProductCategorySpecificationPropertyValue> ValuesResultSet
        {
            get;
            set;
        }

        public event EventHandler<IdeaSeedGridArgs> OnGetSpecifications;

        public event EventHandler<IdeaSeedGridItemEventArgs> OnSpecificationsDataBound;

        public event EventHandler<IdeaSeedLinkButtonArgs> OnSpecificationSelected;

        public event EventHandler<IdeaSeedGridArgs> OnGetValues;

        public event EventHandler<IdeaSeedGridItemEventArgs> OnValuesDataBound;

        public void LoadSpecifications(IdeaSeedGridArgs args)
        {
            if (SpecificationsResultSet.Count > 0)
            {
                rgSpecifications.DataSource = SpecificationsResultSet;
            }
            else
            {
                rgSpecifications.DataSource = new List<ProductCategorySpecificationProperty>();
            }
            if (args.BindData)
                rgSpecifications.DataBind();
        }

        public void LoadValues(IdeaSeedGridArgs args)
        {
            if (ValuesResultSet.Count > 0)
            {
                rgValues.DataSource = ValuesResultSet;
            }
            else
            {
                rgValues.DataSource = new List<ProductCategorySpecificationPropertyValue>();
            }
            if (args.BindData)
                rgValues.DataBind();
        }

        public void NavigateTo(string url)
        {
            Response.Redirect(url);
        }

        public int SelectedPropertyID
        {
            get
            {
                if (SessionManager.Current["SelectedPropertID"] != null)
                {
                    return Convert.ToInt32(SessionManager.Current["SelectedPropertID"]);
                }
                return 0;
            }
            set
            {
                SessionManager.Current["SelectedPropertID"] = value;
            }
        }

        #endregion
    }
}