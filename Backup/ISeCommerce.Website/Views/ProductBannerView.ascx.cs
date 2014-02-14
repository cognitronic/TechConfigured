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
    [PresenterType(typeof(ProductBannerPresenter))]
    public partial class ProductBannerView : BaseWebUserControl, IProductBannerView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.SelfRegister(this);
            if (this.LoadView != null)
            {
                this.LoadView(this, EventArgs.Empty);
            }
        }
        public new event EventHandler LoadView;
        #region IBannerImagesView Members

        public string BannerHTML
        {
            get
            {
                return divImages.InnerHtml;
            }
            set
            {
                divImages.InnerHtml = value;
            }
        }

        public string ViewTitle
        {
            get
            {
                return lblBannerTitle.Text;
            }
            set
            {
                lblBannerTitle.Text = value;
            }
        }

        #endregion
    }
}