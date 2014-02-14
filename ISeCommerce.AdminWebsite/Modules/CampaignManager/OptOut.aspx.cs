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
    public partial class OptOut : ISeCommerceAdminBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Master.ModulePageTitle = CurrentPage.Pagename;
            var c = new CMData.SubscriberRepository().GetByID(Convert.ToInt32(Request.QueryString["cid"]), false);
            lblMessage.Text = c.FirstName;
        }
    }
}