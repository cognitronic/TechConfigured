using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ISeCommerce.Presenters.ViewInterfaces;
using ISeCommerce.Presenters;
using ISeCommerce.Core.Domain;
using ISeCommerce.Core.Security;
using IdeaSeed.Core;
using ISeCommerce.Web.Bases;
using ISeCommerce.Core;

namespace ISeCommerce.Website.Views
{
    [PresenterType(typeof(LoginPresenter))]
    public partial class LoginView : BaseWebUserControl, ILoginView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.SelfRegister(this);
            if (this.LoadView != null)
            {
                this.LoadView(this, EventArgs.Empty);
            }
        }

        protected void LoginClicked(object o, EventArgs e)
        {
            if (this.OnLoginClick != null)
            {
                this.OnLoginClick(o, e);
            }
        }

        protected void ForgotPasswordClicked(object o, EventArgs e)
        { 
            
        }

        public new event EventHandler LoadView;


        #region ILoginView Members

        public void LoginSuccess()
        {
            Response.Redirect("~/Admin/Dashboard");
        }

        public void LoginFailed()
        {
            
        }

        public string UserName
        {
            get
            {
                return tbUsername.Text;
            }
        }

        public string Password
        {
            get
            {
                return tbPassword.Text;
            }
        }

        public event EventHandler OnLoginClick;

        #endregion
    }
}