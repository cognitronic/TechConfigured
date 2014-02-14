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
using System.Text;
using ISeCommerce.Core;
using ISeCommerce.Core.Domain.Interfaces;

namespace ISeCommerce.AdminWebsite.Views
{
    [PresenterType(typeof(CategoryWidgetPresenter))]
    public partial class CategoryWidgetView : BaseWebUserControl, ICategoryWidgetView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.SelfRegister(this);
            if (this.LoadView != null)
            {
                this.LoadView(this, EventArgs.Empty);
            }
            LoadSubCategories();
        }

        public new event EventHandler LoadView;

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

        #region ICategoryWidgetView Members

        public List<QuickLink> QuickLinks
        {
            get;
            set;
        }

        public string MessageHTML
        {
            get
            {
                return divMessage.InnerHtml;
            }
            set
            {
                divMessage.InnerHtml = value;
            }
        }

        public void LoadSubCategories()
        {
            if (QuickLinks != null && QuickLinks.Count > 0)
            {
                var sb = new StringBuilder();
                sb.Append("<ul>");
                foreach (var cat in QuickLinks)
                {
                    sb.Append("<li><a class='menuheader' href='");
                    sb.Append(ReplaceURLSegment(SecurityContextManager.Current,6, ""));
                    sb.Append(cat.URL.Replace("[url]/", "").Replace(" ", "-"));
                    sb.Append("'>");
                    sb.Append(cat.Title);
                    sb.Append("</a></li>");
                }
                sb.Append("</ul>");
                divLinks.InnerHtml = sb.ToString();
            }
        }


        #endregion
    }
}