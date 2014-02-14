using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using IdeaSeed.Web.UI;
using System.Data;
using Telerik.Web.UI;
using System.Configuration;
using System.IO;
using CMCore = CampaignManager.Core.Domain;
using CampaignManager.Core;
using CMData = CampaignManager.Data.Repositories;
using CampaignManager.Presentation;
using IdeaSeed.Core;
using ISeCommerce.Services;
using ISeCommerce.Core.Domain;
using ISeCommerce.AdminWeb.Bases;
using ISeCommerce.Core.Security;
using ISeCommerce.AdminWeb.Utils;
using System.Drawing;

namespace ISeCommerce.AdminWebsite.Modules.CampaignManager
{
    public partial class Subscribers : ISeCommerceAdminBasePage
    {
        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            RadAjaxManager ram = (RadAjaxManager)this.Master.FindControl("RadAjaxManager1");
            RadAjaxLoadingPanel alp = (RadAjaxLoadingPanel)this.Master.FindControl("AjaxLoadingPanel1");
            ram.AjaxSettings.AddAjaxSetting(rgSubscribers, rgSubscribers, alp);
            if (!IsPostBack)
            {
                LoadSubscribers(true);
                
            }
        }

        protected void ToggleSelectedState(object o, EventArgs e)
        {
            if ((o as IdeaSeed.Web.UI.CheckBox).Checked)
            {
                foreach (GridDataItem dataItem in rgSubscribers.MasterTableView.Items)
                {
                    (dataItem.FindControl("cbSelectRow") as IdeaSeed.Web.UI.CheckBox).Checked = true;
                    //dataItem.Selected = true;
                }
            }
            else
            {
                foreach (GridDataItem dataItem in rgSubscribers.MasterTableView.Items)
                {
                    (dataItem.FindControl("cbSelectRow") as IdeaSeed.Web.UI.CheckBox).Checked = false;
                    dataItem.Selected = false;
                }
            }
            rgSubscribers.PagerStyle.Position = GridPagerPosition.Bottom;
        }

        protected void ItemCommand(object o, GridCommandEventArgs e)
        {
            if (e.CommandName == RadGrid.PerformInsertCommandName)
            {
                var subscriber = new CMCore.Subscriber();
                subscriber.Email = (e.Item.FindControl("tbEmail") as IdeaSeed.Web.UI.TextBox).Text;
                subscriber.FirstName = (e.Item.FindControl("tbFirstName") as IdeaSeed.Web.UI.TextBox).Text;
                subscriber.LastName = (e.Item.FindControl("tbLastName") as IdeaSeed.Web.UI.TextBox).Text;
                subscriber.IsActive = (e.Item.FindControl("cbIsActive") as IdeaSeed.Web.UI.CheckBox).Checked;
                if (CampaignManagerUtils.IsDuplicateSubscriber(subscriber.Email))
                {
                    ShowErrorModal(this, "This email address already exists.");
                }
                else
                {
                    new CMData.SubscriberRepository().Save(subscriber);
                }
            }
            if (e.CommandName == RadGrid.UpdateCommandName)
            {
                if (e.Item is GridEditableItem)
                {
                    var subscriber = new CMData.SubscriberRepository().GetByID((int)e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"], false);
                    subscriber.Email = (e.Item.FindControl("tbEmail") as IdeaSeed.Web.UI.TextBox).Text;
                    subscriber.FirstName = (e.Item.FindControl("tbFirstName") as IdeaSeed.Web.UI.TextBox).Text;
                    subscriber.LastName = (e.Item.FindControl("tbLastName") as IdeaSeed.Web.UI.TextBox).Text;
                    subscriber.IsActive = (e.Item.FindControl("cbIsActive") as IdeaSeed.Web.UI.CheckBox).Checked;
                    //This checks to make sure the original subscriber object and dirty subscriber object's email matches.  If not, then check for duplicate.

                    if ((e.Item.FindControl("tbEmail") as IdeaSeed.Web.UI.TextBox).Attributes["email"].Equals(subscriber.Email))
                    {
                        new CMData.SubscriberRepository().SaveOrUpdate(subscriber);
                    }
                    else
                    {
                        if (CampaignManagerUtils.IsDuplicateSubscriber(subscriber.Email))
                        {
                            ShowErrorModal(this, "This email address already exists.");
                            e.Item.Expanded = true;
                        }
                        else
                        {
                            if (IdeaSeed.Core.Validation.ValidationUtils.IsEmailValid(subscriber.Email))
                            {
                                new CMData.SubscriberRepository().SaveOrUpdate(subscriber);
                            }
                        }
                    }
                }
            }
            if (e.CommandName == RadGrid.DeleteCommandName)
            {
                var subscriber = new CMData.SubscriberRepository().GetByID((int)e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"], false);
                try
                {
                    new CMData.SubscriberRepository().Delete(subscriber);
                }
                catch (Exception ex)
                {
                    ShowErrorModal(this, "This tag is associated with one or more subscribers, or campaigns and cannot be deleted.  You must first remove this tag from all subscribers and campaigns.");
                }
            }
        }

        protected void NeedDataSource(object o, GridNeedDataSourceEventArgs e)
        {
            LoadSubscribers(false);
        }

        protected void AddTagsClicked(object o, EventArgs e)
        {
            Session["SubscribersAddTags"] = BuildSubscriberListForTags();
            Session["IsAdd"] = true;
            Response.Redirect("Manage-Subscribers-Tags");
        }

        protected void DeleteTagsClicked(object o, EventArgs e)
        {
            Session["SubscribersAddTags"] = BuildSubscriberListForTags();
            Session["IsAdd"] = false;
            Response.Redirect("Manage-Subscribers-Tags");
        }

        protected void ImportSubscribersClicked(object o, EventArgs e)
        {
            Response.Redirect("Import-Subscribers");
        }

        protected void SearchSubscribersClicked(object o, EventArgs e)
        {
            var list = new List<CMCore.Subscriber>();
            switch (ddlSearchColumn.SelectedValue)
            {
                case "Email":
                    list = (List<CMCore.Subscriber>)new CMData.SubscriberRepository().GetByLikeEmail(tbSearch.Text);
                    rgSubscribers.DataSource = list;
                    rgSubscribers.DataBind();
                    break;
                case "FirstName":
                    list = new CMData.SubscriberRepository().GetByLikeFirstName(tbSearch.Text) as List<CMCore.Subscriber>;
                    rgSubscribers.DataSource = list;
                    rgSubscribers.DataBind();
                    break;
                case "LastName":
                    list = new CMData.SubscriberRepository().GetByLikeLastName(tbSearch.Text) as List<CMCore.Subscriber>;
                    rgSubscribers.DataSource = list;
                    rgSubscribers.DataBind();
                    break;
                case "":
                    tbSearch.Text = "";
                    LoadSubscribers(true);
                    break;
            }
        }

        #endregion

        #region Methods

        private void LoadSubscribers(bool dataBind)
        {
            rgSubscribers.DataSource = new CMData.SubscriberRepository().GetAll().OrderBy(s => s.Email);
            if (dataBind)
            {
                rgSubscribers.DataBind();
            }
        }

        private List<CMCore.Subscriber> BuildSubscriberListForTags()
        {
            var subscribers = new List<CMCore.Subscriber>();
            foreach (GridDataItem row in rgSubscribers.MasterTableView.Items)
            {
                if (row.ItemType == GridItemType.AlternatingItem || row.ItemType == GridItemType.Item)
                {
                    var cb = row.FindControl("cbSelectRow") as IdeaSeed.Web.UI.CheckBox;
                    if (cb.Checked)
                    {
                        var subscriber = new CMCore.Subscriber();
                        subscriber.ID = Convert.ToInt32(cb.Attributes["subscriberID"]);
                        subscriber.Email = row["Email"].Text;
                        subscriber.FirstName = row["FirstName"].Text;
                        subscriber.LastName = row["LastName"].Text;
                        subscribers.Add(subscriber);
                    }
                }
            }
            return subscribers;
        }
        #endregion
    }
}