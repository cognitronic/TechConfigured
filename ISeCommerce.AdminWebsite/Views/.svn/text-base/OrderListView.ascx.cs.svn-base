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
using ISeCommerce.Services;
using IdeaSeed.Core;
using ISeCommerce.AdminWeb.Bases;
using ISeCommerce.Core;
using Telerik.Web.UI;

namespace ISeCommerce.AdminWebsite.Views
{
    [PresenterType(typeof(OrderListPresenter))]
    public partial class OrderListView : BaseWebUserControl, IOrderListView
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

        protected void SearchClicked(object o, EventArgs e)
        {
            if (this.OnGetItems != null)
            {
                var args = new IdeaSeedGridArgs();
                args.BindData = true;
                this.OnGetItems(this, args);
            }
        }

        protected void UpdateItemsClicked(object o, EventArgs e)
        {
            foreach (GridDataItem row in rgList.SelectedItems)
            {
                var order = (Order)row.DataItem;
                if (!string.IsNullOrEmpty(ddlUpdateOrderStatus.SelectedValue))
                {
                    order.OrderStatusID = Convert.ToInt16(ddlUpdateOrderStatus.SelectedValue);
                    new OrderServices().Save(order);
                }
            }
            if (this.OnGetItems != null)
            {
                var args = new IdeaSeedGridArgs();
                args.BindData = true;
                this.OnGetItems(this, args);
            }
        }

        protected void ItemCreated(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                e.Item.PreRender += new EventHandler(ItemPreRender);
            }
        }

        private void ItemPreRender(object sender, EventArgs e)
        {
            ((sender as GridDataItem)["CheckBoxTemplateColumn"].FindControl("cbRow") as CheckBox).Checked = (sender as GridDataItem).Selected;
        }

        protected void AddNewItemClicked(object o, EventArgs e)
        {
            NavigateTo(SecurityContextManager.Current.CurrentURL + "/New");
        }

        protected void ToggleRowSelection(object o, EventArgs e)
        {
            ((o as IdeaSeed.Web.UI.CheckBox).NamingContainer as GridItem).Selected = (o as IdeaSeed.Web.UI.CheckBox).Checked;
        }

        protected void ToggleSelectedState(object o, EventArgs e)
        {
            IdeaSeed.Web.UI.CheckBox headerCheckBox = (o as IdeaSeed.Web.UI.CheckBox);
            foreach (GridDataItem dataItem in rgList.MasterTableView.Items)
            {
                (dataItem.FindControl("cbRow") as IdeaSeed.Web.UI.CheckBox).Checked = headerCheckBox.Checked;
                dataItem.Selected = headerCheckBox.Checked;
            }
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

        #region IBaseListView<Product> Members

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

        public new event EventHandler LoadView;

        public new event EventHandler UnloadView;

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

        public IList<Order> ResultSet
        {
            get;
            set;
        }

        public IList<Order> OrderList()
        {
            int? status = null;
            int? id = null;
            if (!string.IsNullOrEmpty(ddlFilterOrderStatus.SelectedValue))
                status = Convert.ToInt16(ddlFilterOrderStatus.SelectedValue);
            if (!string.IsNullOrEmpty(tbFilterOrderID.Text))
                id = Convert.ToInt16(tbFilterOrderID.Text);
            return new OrderServices().GetByFilters(tbFilterEmail.Text, null, status, id).OrderBy(o => o.DateCreated).ToList<Order>();
        }

        public int VirtualItemCount
        {
            get;
            set;
        }

        #endregion
    }
}