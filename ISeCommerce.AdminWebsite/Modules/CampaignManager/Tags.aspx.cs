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
using CampaignManager.Core;
using CampaignManager.Core.Domain;
using CMData = CampaignManager.Data.Repositories;
using CampaignManager.Presentation;
using IdeaSeed.Core;
using ISeCommerce.Services;
using ISeCommerce.Core.Domain;
using ISeCommerce.AdminWeb.Bases;
using ISeCommerce.Core.Security;
using ISeCommerce.AdminWeb.Utils;
using System.Drawing;
using NHibernate.Exceptions;
using Iesi.Collections.Generic;

namespace ISeCommerce.AdminWebsite.Modules.CampaignManager
{
    public partial class Tags : ISeCommerceAdminBasePage
    {
        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            RadAjaxManager ram = (RadAjaxManager)this.Master.FindControl("RadAjaxManager1");
            RadAjaxLoadingPanel alp = (RadAjaxLoadingPanel)this.Master.FindControl("AjaxLoadingPanel1");
            ram.AjaxSettings.AddAjaxSetting(rgTags, rgTags);
            if (!IsPostBack)
            {
                LoadTags(true);
            }
        }

        protected void TagItemCommand(object o, GridCommandEventArgs e)
        {
            if (e.CommandName == RadGrid.PerformInsertCommandName)
            {
                var tag = new CampaignTag();
                tag.Tag = (e.Item.FindControl("tbTag") as IdeaSeed.Web.UI.TextBox).Text;
                new CMData.CampaignTagRepository().Save(tag);
            }
            if (e.CommandName == RadGrid.UpdateCommandName)
            {
                var tag = new CMData.CampaignTagRepository().GetByID((int)e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"], false);
                tag.Tag = (e.Item.FindControl("tbTag") as IdeaSeed.Web.UI.TextBox).Text;
                new CMData.CampaignTagRepository().SaveOrUpdate(tag);
            }
            if (e.CommandName == RadGrid.DeleteCommandName)
            {
                var tag = new CMData.CampaignTagRepository().GetByID((int)e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"], false);
                try
                {
                    new CMData.CampaignTagRepository().Delete(tag);
                }
                catch (Exception ex)
                {
                    ShowErrorModal(this, "This tag is associated with one or more subscribers, or campaigns and cannot be deleted.  You must first remove this tag from all subscribers and campaigns.");
                }
            }
        }

        protected void TagNeedDataSource(object o, GridNeedDataSourceEventArgs e)
        {
            LoadTags(false);
        }

        #endregion

        #region Methods

        private void LoadTags(bool dataBind)
        {
            rgTags.DataSource = new CMData.CampaignTagRepository().GetAll().OrderBy(t => t.Tag);
            if (dataBind)
            {
                rgTags.DataBind();
            }
        }

        protected string TotalSubscribers(int campaignTagID)
        {
            var total = new CMData.SubscriberRepository().GetSubscribersInCampaignTagGroup(campaignTagID);
            if (total != null)
            {
                return total.Count.ToString();
            }
            return "0";
        }
        #endregion
    }
}