using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ISeCommerce.Presenters;
using IdeaSeed.Core;
using ISeCommerce.Web.Bases;
using System.Web.UI.HtmlControls;
using ISeCommerce.Presenters.ViewInterfaces;
using ISeCommerce.Core.Domain;
using ISeCommerce.Core.Domain.Interfaces;
using ISeCommerce.Core.Security;

namespace ISeCommerce.Website
{
    [PresenterType(typeof(FullWidthPagePresenter))]
    public partial class FullWidth : ISeCommerceBasePage, IFullWidthPageView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadViewControls(Master.MainContent);
            Master.Page.Title = SecurityContextManager.Current.CurrentItem.SEOTitle;
            ISeCommerce.Website.Views.PrimaryNavView view = new Views.PrimaryNavView();
        }

        private void LoadViewControls(ContentPlaceHolder mainContent)
        {
            var header = new ContentPlaceHolder();
            header = (ContentPlaceHolder)this.Master.FindControl("head");
            this.Title = SecurityContextManager.Current.CurrentPage.Title;
            

            Master.Page.Title = SecurityContextManager.Current.CurrentItem.Name + " from TechConfigured.com";


            header = new ContentPlaceHolder();
            header = (ContentPlaceHolder)this.Master.FindControl("head");
            HtmlMeta meta = new HtmlMeta();
            meta.Name = "keywords";
            meta.Content = SecurityContextManager.Current.CurrentItem.SEOKeywords;
            header.Controls.Add(meta);

            meta = new HtmlMeta();
            meta.Name = "Description";
            meta.Content = SecurityContextManager.Current.CurrentItem.SEODescription;
            header.Controls.Add(meta);

            base.SelfRegister(HttpContext.Current.Handler as System.Web.UI.Page);
            if (this.OnLoadData != null)
            {
                this.OnLoadData(this, EventArgs.Empty);
            }

            foreach (var view in MainContentViews)
            {
                Control c = LoadControl(view.ApplicationView.Path);
                mainContent.Controls.Add(c);
            }

        }

        #region IPageManagerView Members

        public event EventHandler OnLoadData;

        private IList<IPageApplicationView> _mainContentViews = new List<IPageApplicationView>();
        public IList<IPageApplicationView> MainContentViews
        {
            get
            {
                return _mainContentViews;
            }
            set
            {
                _mainContentViews = value;
            }
        }

        #endregion
    }
}