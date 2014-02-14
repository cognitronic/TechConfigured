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
    public partial class CampaignDashboard : ISeCommerceAdminBasePage
    {
        #region Properties

        public int CurrentCampaignID
        {
            get
            {
                return (int)ViewState["CurrentCampaign"];
            }
            set
            {
                ViewState["CurrentCampaign"] = value;
            }
        }

        public int CurrentTab
        {
            get
            {
                return (int)ViewState["CurrentTab"];
            }
            set
            {
                ViewState["CurrentTab"] = value;
            }
        }

        public OverViewReport CurrentOverView
        {
            get
            {
                return (OverViewReport)Session["CurrentOverView"];
            }
            set
            {
                Session["CurrentOverView"] = value;
            }
        }

        #endregion

        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.Page.Title = TITLE_TEXT + "Campaign Dashboard";
            //RadAjaxManager ram = (RadAjaxManager)this.Master.FindControl("RadAjaxManager1");
            //RadAjaxLoadingPanel alp = (RadAjaxLoadingPanel)this.Master.FindControl("AjaxLoadingPanel1");
            //ram.AjaxSettings.AddAjaxSetting(rgCampaignHistory, rgCampaignHistory, alp);
            //ram.AjaxSettings.AddAjaxSetting(rgCampaignHistory, rgCampaignHistory);
            //ram.AjaxSettings.AddAjaxSetting(rgCampaignHistory, tsCampaignDetails);
            //ram.AjaxSettings.AddAjaxSetting(rgCampaignHistory, mpCampaignDetails);
            //ram.AjaxSettings.AddAjaxSetting(tsCampaignDetails, tsCampaignDetails);
            //ram.AjaxSettings.AddAjaxSetting(tsCampaignDetails, mpCampaignDetails);
            if (!IsPostBack)
            {
                CurrentCampaignID = -1;
                CurrentTab = 0;
                CurrentOverView = null;
                LoadCampaigns(true);
                tsCampaignDetails.SelectedIndex = CurrentTab;
                mpCampaignDetails.PageViews[0].Selected = true;
                LoadDetailsByTab(CurrentTab.ToString(), true);
            }
        }

        protected void ViewCampaignClicked(object o, EventArgs e)
        {
            Response.Redirect("CampaignViewer.aspx?cid=" + ((IdeaSeed.Web.UI.LinkButton)o).Attributes["campaignid"]);
        }

        protected void ItemCreated(object o, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                HyperLink editLink = (HyperLink)e.Item.FindControl("lbViewCampaign");
                editLink.Attributes["href"] = "#";
                editLink.Attributes["onclick"] = String.Format("return ShowEditForm('{0}','{1}');", e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"], e.Item.ItemIndex);
            }

        }

        protected void TabClicked(object o, RadTabStripEventArgs e)
        {
            //LoadDetailsByTab(tsCampaignDetails.SelectedTab.Value, CurrentCampaignID, true);
            CurrentTab = tsCampaignDetails.SelectedIndex;
        }

        protected void UserItemCommand(object o, GridCommandEventArgs e)
        {
            if (e.CommandName == RadGrid.EditCommandName || e.CommandName == "RowClick" && e.Item is GridDataItem)
            {
                e.Item.Selected = true;
                CurrentCampaignID = (int)e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"];
                CurrentOverView = new OverViewReport(CurrentCampaignID);

                tsCampaignDetails.SelectedIndex = CurrentTab;
                LoadDetailsByTab(tsCampaignDetails.SelectedTab.Value, true);
            }
        }

        protected void UserNeedDataSource(object o, GridNeedDataSourceEventArgs e)
        {
            LoadCampaigns(false);
        }

        protected void OptOutNeedDataSource(object o, GridNeedDataSourceEventArgs e)
        {
            LoadOptOuts(false);
        }

        protected void OverviewItemDataBound(object o, Telerik.Charting.ChartItemDataBoundEventArgs e)
        {
            e.SeriesItem.Name = ((DataRowView)e.DataItem)["LinkText"].ToString();
        }




        #endregion

        #region Methods


        protected void LoadLinksChart()
        {
            rcLinksResult.DataSource = CurrentOverView.CampaignLinksResult;
            rcLinksResult.PlotArea.XAxis.DataLabelsColumn = "LinkText";
            rcLinksResult.PlotArea.XAxis.Appearance.LabelAppearance.RotationAngle = 90;
            rcLinksResult.PlotArea.Appearance.Dimensions.Margins.Bottom = Telerik.Charting.Styles.Unit.Pixel(125);
            rcLinksResult.PlotArea.XAxis.Appearance.LabelAppearance.Position.AlignedPosition = Telerik.Charting.Styles.AlignedPositions.Top;
            rcLinksResult.PlotArea.XAxis.Appearance.TextAppearance.AutoTextWrap = Telerik.Charting.Styles.AutoTextWrap.False;
            rcLinksResult.PlotArea.YAxis.AxisMode = Telerik.Charting.ChartYAxisMode.Extended;
            rcLinksResult.DataBind();
            Color[] barColors = new Color[15]{
        Color.Pink,
        Color.SteelBlue,
        Color.Aqua,
        Color.Yellow,
        Color.Navy,
        Color.Green,
        Color.Blue,
        Color.Red,
        Color.Purple,
        Color.PowderBlue,
        Color.PaleGreen,
        Color.Orange,
        Color.LightPink,
        Color.DarkOliveGreen,
        Color.Olive
        };
            int i = 0;
            if (rcLinksResult.Series.Count > 0)
            {
                foreach (var item in rcLinksResult.Series[0].Items)
                {
                    item.Appearance.Border.Color = Color.LightBlue;
                    item.Appearance.FillStyle.MainColor = barColors[i++];
                    item.Appearance.FillStyle.FillType = Telerik.Charting.Styles.FillType.Solid;
                }
            }
        }

        protected string FormatSentBy(string userid)
        {
            var s = new UserServices().GetByID(Convert.ToInt32(userid));
            if (s != null)
            {
                return s.FirstName + " " + s.LastName;
            }
            return "Unknown User ID: " + userid;
        }

        protected void LoadCampaigns(bool binddata)
        {
            rgCampaignHistory.DataSource = new CMData.CampaignRepository().GetAll().OrderByDescending(c => c.DateTimeSent);
            if (binddata)
            {
                rgCampaignHistory.DataBind();
            }
        }

        protected void LoadOptOuts(bool binddata)
        {
            if (CurrentCampaignID > 0)
            {
                rgOptOut.DataSource = new CMData.CampaignOptedOutRepository().GetByCampaignID(CurrentCampaignID);
                if (binddata)
                {
                    rgOptOut.DataBind();
                }
            }
        }

        protected void LoadOverview()
        {
            if (CurrentOverView != null)
            {
                lblTotalRecipients.Text = CurrentOverView.TotalRecipients.ToString();
                lblUniqueEmailReads.Text = CurrentOverView.UniqueEmailReads.ToString();
                lblTotalEmailReads.Text = CurrentOverView.TotalEmailReads.ToString();
                lblUniqueLinkClicks.Text = CurrentOverView.UniqueLinkClicks.ToString();
                lblTotalLinkClicks.Text = CurrentOverView.TotalLinkClicks.ToString();
                LoadLinksChart();
            }
        }

        protected void LoadDetailsByTab(string selectedtab, bool databind)
        {
            switch (selectedtab)
            {
                case "0":
                    LoadOverview();
                    break;
                case "1":
                    //LoadUserGroups(userid, databind);
                    break;
                case "2":
                    //LoadUserGroups(userid, databind);
                    break;
                case "3":
                    LoadOptOuts(true);
                    break;
            }
        }
        #endregion
    }
}