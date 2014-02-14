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
using Telerik.Web.UI;
using ISeCommerce.Services;

namespace ISeCommerce.AdminWebsite.Views
{
    [PresenterType(typeof(ProductSEOPresenter))]
    public partial class ProductSEOView : BaseWebUserControl, IProductSEOView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            divSuccess.Visible = false;
            divError.Visible = false;
            base.SelfRegister(this);
            if (this.LoadView != null)
            {
                this.LoadView(this, EventArgs.Empty);
            }
        }

        protected void SaveClicked(object o, EventArgs e)
        {
            var args = new IdeaSeedLinkButtonArgs();
            args.ID = Convert.ToInt32(((LinkButton)o).Attributes["itemid"]);
            args.Name = ((LinkButton)o).Attributes["itemname"];
            if (this.SaveClick != null)
            {
                this.SaveClick(o, args);
            }
            if (SavedSuccessfully)
                divSuccess.Visible = true;
        }

        protected void CancelClicked(object o, EventArgs e)
        {
            var args = new IdeaSeedLinkButtonArgs();
            if (this.CancelClick != null)
            {
                this.CancelClick(o, args);
            }
        }

        protected void DeleteClicked(object o, EventArgs e)
        {
            var args = new IdeaSeedLinkButtonArgs();
            args.ID = Convert.ToInt32(((LinkButton)o).Attributes["itemid"]);
            args.Name = ((LinkButton)o).Attributes["itemname"];
            if (this.DeleteClick != null)
            {
                this.DeleteClick(o, args);
            }
        }

        #region IProductSEOView Members

        public new event EventHandler LoadView;

        public new event EventHandler UnloadView;

        public string ViewTitle
        {
            get
            {
                return lblViewTitle.Text;
            }
            set
            {
                lblViewTitle.Text = value;
            }
        }

        public bool SavedSuccessfully
        {
            get;
            set;
        }

        public string SEOTitle
        {
            get
            {
                return tbSEOTitle.Text;
            }
            set
            {
                tbSEOTitle.Text = value;
            }
        }

        public string SEOKeywords
        {
            get
            {
                return tbSEOKeywords.Text;
            }
            set
            {
                tbSEOKeywords.Text = value;
            }
        }

        public string SEODescription
        {
            get
            {
                return tbSEODescription.Text;
            }
            set
            {
                tbSEODescription.Text = value;
            }
        }

        #endregion

        #region IBasePropertiesView<Product> Members

        public void LoadItem(Product t)
        {
            tbSEODescription.Text = t.SEODescription;
            tbSEOKeywords.Text = t.SEOKeywords;
            tbSEOTitle.Text = t.SEOTitle;
        }

        public void NavigateTo(string url)
        {
            Response.Redirect(url);
        }

        #endregion

        #region IPropertiesActions Members

        public event EventHandler<IdeaSeedLinkButtonArgs> SaveClick;

        public event EventHandler<IdeaSeedLinkButtonArgs> CancelClick;

        public event EventHandler<IdeaSeedLinkButtonArgs> DeleteClick;

        #endregion
    }
}