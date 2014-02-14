using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ISeCommerce.Presenters;
using IdeaSeed.Core;
using ISeCommerce.Web.Bases;
using ISeCommerce.Presenters.ViewInterfaces;
using ISeCommerce.Core.Domain;
using ISeCommerce.Core.Domain.Interfaces;
using ISeCommerce.Core.Security;

namespace ISeCommerce.Website
{
    [PresenterType(typeof(TwoColumnPagePresenter))]
    public partial class TwoColumn : ISeCommerceBasePage, ITwoColumnPageView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadViewControls(Master.MainContent);
            Master.Page.Title = SecurityContextManager.Current.CurrentItem.SEOTitle;
            ISeCommerce.Website.Views.PrimaryNavView view = new Views.PrimaryNavView();
        }

        private void LoadViewControls(ContentPlaceHolder mainContent)
        {
            base.SelfRegister(HttpContext.Current.Handler as System.Web.UI.Page);
            LoadData();
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

        public void LoadData()
        {
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

        #endregion
    }
}