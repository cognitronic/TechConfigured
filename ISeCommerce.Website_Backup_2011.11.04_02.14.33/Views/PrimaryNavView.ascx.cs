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
    [PresenterType(typeof(PrimaryNavPresenter))]
    public partial class PrimaryNavView : BaseWebUserControl, IPrimaryNavView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.SelfRegister(this);
            if (this.OnLoadNav != null)
            {
                this.OnLoadNav(this, e);
            }
        }

        #region IPrimaryNavView Members

        public event EventHandler OnLoadNav;

        public event EventHandler OnLinkClicked;

        public string PrimaryNavText
        {
            get
            {
                return navContainer.InnerHtml;
            }
            set
            {
                navContainer.InnerHtml = value;
            }
        }

        #endregion
    }
}