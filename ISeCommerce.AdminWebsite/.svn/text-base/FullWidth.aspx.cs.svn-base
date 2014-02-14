using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ISeCommerce.AdminPresenters;
using IdeaSeed.Core;
using ISeCommerce.AdminWeb.Bases;
using ISeCommerce.AdminPresenters.ViewInterfaces;
using ISeCommerce.Core.Domain;
using ISeCommerce.Core.Domain.Interfaces;
using ISeCommerce.Core.Security;

namespace ISeCommerce.AdminWebsite
{
    [PresenterType(typeof(FullWidthPagePresenter))]
    public partial class FullWidth : ISeCommerceAdminBasePage, IFullWidthPageView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadViewControls(Master.MainContent);
            Master.Page.Title = SecurityContextManager.Current.CurrentPage.Title;
            ISeCommerce.AdminWebsite.Views.PrimaryNavView view = new Views.PrimaryNavView();
        }

        private void LoadViewControls(ContentPlaceHolder mainContent)
        {
            base.SelfRegister(HttpContext.Current.Handler as System.Web.UI.Page);
            if (this.OnLoadData != null)
            {
                this.OnLoadData(this, EventArgs.Empty);
            }

            foreach (var view in MainContentViews)
            {
                Control c = LoadControl(view.ApplicationView.Path);
                divFullColumn.Controls.Add(c);
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