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
    [PresenterType(typeof(ProductDescriptionTabPresenter))]
    public partial class ProductDescriptionTabView : BaseWebUserControl, IProductDescriptionTabView
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

        public string ProductDescription
        {
            get
            {
                return pProductDescription.InnerText;
            }
            set
            {
                pProductDescription.InnerText = value;
            }
        }

        public string AdditionalInformation
        {
            get
            {
                return divAddtionalInfo.InnerHtml;
            }
            set
            {
                divAddtionalInfo.InnerHtml = value;
            }
        }


    }
}