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
    [PresenterType(typeof(TwoColumnPagePresenter))]
    public partial class TwoColumn : ISeCommerceAdminBasePage, ITwoColumnPageView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadViewControls(Master.MainContent);
            Master.Page.Title = SecurityContextManager.Current.CurrentItem.Name;
            ISeCommerce.AdminWebsite.Views.PrimaryNavView view = new Views.PrimaryNavView();
        }

        private void LoadViewControls(ContentPlaceHolder mainContent)
        {
            base.SelfRegister(HttpContext.Current.Handler as System.Web.UI.Page);
            if (this.LoadView != null)
            {
                this.LoadView(this, EventArgs.Empty);
            }

            foreach (var view in ColumnTwoViews)
            {
                Control c = LoadControl(view.ApplicationView.Path);
                divColumnTwo.Controls.Add(c);
            }

            foreach (var view in ColumnOneViews)
            {
                Control c = LoadControl(view.ApplicationView.Path);
                divColumnOne.Controls.Add(c);
            }
        }

        #region ITwoColumnPageView Members

        public new event EventHandler LoadView;
        private IList<IPageApplicationView> _columnOneViews = new List<IPageApplicationView>();
        public IList<IPageApplicationView> ColumnOneViews
        {
            get
            {
                return _columnOneViews;
            }
            set
            {
                _columnOneViews = value;
            }
        }

        private IList<IPageApplicationView> _columnTwoViews = new List<IPageApplicationView>();
        public IList<IPageApplicationView> ColumnTwoViews
        {
            get
            {
                return _columnTwoViews;
            }
            set
            {
                _columnTwoViews = value;
            }
        }

        #endregion
    }
}