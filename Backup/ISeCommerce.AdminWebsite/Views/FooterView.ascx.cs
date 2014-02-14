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
    [PresenterType(typeof(FooterPresenter))]
    public partial class FooterView : BaseWebUserControl, IFooterView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.SelfRegister(this);
            if (this.LoadView != null)
            {
                this.LoadView(this, EventArgs.Empty);
            }
        }

        protected void NewsletterSignupClicked(object o, EventArgs e)
        {
            if (this.OnEmailSignupClick != null)
            {
                this.OnEmailSignupClick(this, e);
            }
        }


        #region IFooterView Members

        public event EventHandler OnEmailSignupClick;
        public new event EventHandler LoadView;

        public string FooterLinksText
        {
            get;
            set;
        }

        #endregion
    }
}