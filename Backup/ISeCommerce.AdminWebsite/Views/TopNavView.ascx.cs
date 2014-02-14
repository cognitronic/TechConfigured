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
using ISeCommerce.Core;

namespace ISeCommerce.AdminWebsite.Views
{
    [PresenterType(typeof(TopNavPresenter))]
    public partial class TopNavView : BaseWebUserControl, ITopNavView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (SecurityContextManager.Current.CurrentUser == null || SecurityContextManager.Current.CurrentUser.ID < 1)
            {
                divTopNav.InnerHtml = "<br /><br /><br />";
            }
            base.SelfRegister(this);
            if (this.LoadView != null)
            {
                this.LoadView(this, EventArgs.Empty);
            }
        }

        protected void LogoClicked(object o, EventArgs e)
        {
            Response.Redirect(ResourceStrings.Page_Admin_Default);   
        }

        protected void UsersClicked(object o, EventArgs e)
        {
            Response.Redirect(ResourceStrings.Page_Users);
        }

        protected void ManagedListsClicked(object o, EventArgs e)
        {
            Response.Redirect(ResourceStrings.Page_ManagedLists + "/Banners");
        }

        protected void SettingsClicked(object o, EventArgs e)
        {
            Response.Redirect(ResourceStrings.Page_Settings);
        }

        protected void SearchClicked(object o, EventArgs e)
        {
            if (this.OnSearch != null)
            {
                this.OnSearch(this, e);
            }
        }

        protected void LogoutClicked(object o, EventArgs e)
        {
            if (this.OnLogout != null)
            {
                this.OnLogout(this, EventArgs.Empty);
            }
        }

        #region ITopNavView Members

        public bool CustomerLoggedIn
        {
            get
            {
                //if (lbLogout.Visible)
                //    return true;
                return false;
            }
            set
            {
                //if (value)
                //{
                //    lbLogin.Visible = false;
                //    lbLogout.Visible = true;
                //}
                //else
                //{
                //    lbLogin.Visible = true;
                //    lbLogout.Visible = false;
                //}
            }
        }

        public string LoggedOnUser
        {
            get
            {
                return lblCurrentUser.Text;
            }
            set
            {
                lblCurrentUser.Text = value;
            }
        }

        #endregion

        #region IView Members

        public new event EventHandler InitView;
        public new event EventHandler LoadView;
        public new event EventHandler UnloadView;
        public event EventHandler OnLogout;
        public event EventHandler OnSearch;
        #endregion
    }
}