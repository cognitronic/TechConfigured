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
using System.Configuration;
using ISeCommerce.Core;
using Telerik.Web.UI;
using ISeCommerce.Services;

namespace ISeCommerce.AdminWebsite.Views
{
    [PresenterType(typeof(BannerDetailPresenter))]
    public partial class BannerDetailView : BaseWebUserControl, IBannerDetailView
    {
        const int MaxTotalBytes = 1048576; // 1 MB
        int totalBytes;

        public bool? IsRadAsyncValid
        {
            get
            {
                if (Session["IsRadAsyncValid"] == null)
                {
                    Session["IsRadAsyncValid"] = true;
                }

                return Convert.ToBoolean(Session["IsRadAsyncValid"].ToString());
            }
            set
            {
                Session["IsRadAsyncValid"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.SelfRegister(this);
            if (this.LoadView != null)
            {
                this.LoadView(this, EventArgs.Empty);
            }

            lblViewTitle.Text = "Banner Details";
        }

        public void RadAsyncUpload1_ValidatingFile(object sender, Telerik.Web.UI.Upload.ValidateFileEventArgs e)
        {
            if ((totalBytes < MaxTotalBytes) && (e.UploadedFile.ContentLength < MaxTotalBytes))
            {
                e.IsValid = true;
                totalBytes += e.UploadedFile.ContentLength;
                IsRadAsyncValid = true;
            }
            else
            {
                e.IsValid = false;
                IsRadAsyncValid = false;
            }
        }

        protected void SaveClicked(object o, EventArgs e)
        {
            var args = new IdeaSeedLinkButtonArgs();
            args.ID = Convert.ToInt32(((LinkButton)o).Attributes["itemid"]);
            args.Name = ((LinkButton)o).Attributes["itemname"];
            if (this.SaveClick != null)
            {
                this.SaveClick(o, args);
            }
        }

        protected void CancelClicked(object o, EventArgs e)
        {
            var args = new IdeaSeedLinkButtonArgs();
            if (this.CancelClick != null)
            {
                this.CancelClick(o, args);
            }
        }

        protected void DeleteClicked(object o, EventArgs e)
        {
            var args = new IdeaSeedLinkButtonArgs();
            args.ID = Convert.ToInt32(((LinkButton)o).Attributes["itemid"]);
            args.Name = ((LinkButton)o).Attributes["itemname"];
            if (this.DeleteClick != null)
            {
                this.DeleteClick(o, args);
            }
        }

        #region IPropertiesActions Members

        public event EventHandler<IdeaSeedLinkButtonArgs> SaveClick;

        public event EventHandler<IdeaSeedLinkButtonArgs> CancelClick;

        public event EventHandler<IdeaSeedLinkButtonArgs> DeleteClick;

        public new event EventHandler LoadView;

        public new event EventHandler UnloadView;

        #endregion

        #region IBasePropertiesView<BannerImage> Members

        public void LoadItem(BannerImage t)
        {
            this.Title = t.Title;
            this.ToolTip = t.ToolTip;
            this.Path = t.Path;
        }

        public void NavigateTo(string url)
        {
            Response.Redirect(url);
        }

        #endregion

        #region IBannerImage Members

        public new int ID
        {
            get;
            set;
        }

        public string Title
        {
            get
            {
                return tbTitle.Text;
            }
            set
            {
                tbTitle.Text = value;
            }
        }

        public string Path
        {
            get
            {
                if (radAsyncUpload.UploadedFiles.Count > 0)
                {
                    UploadedFile file = radAsyncUpload.UploadedFiles[0];
                    string filePath = DateTime.Now.Ticks.ToString() + "_" +
                        file.FileName;
                    //string filePath = file.FileName;
                    file.SaveAs(Server.MapPath(ConfigurationManager.AppSettings["BANNERIMAGEPATH"]) + filePath, false);
                   return ConfigurationManager.AppSettings["BANNERIMAGEPATH"] + filePath;
                }
                return "";
            }
            set
            {
                RadBinaryImage1.ImageUrl = value;
            }
        }

        public string ToolTip
        {
            get
            {
                return tbToolTip.Text;
            }
            set
            {
                tbToolTip.Text = value;
            }
        }

        #endregion
    }
}