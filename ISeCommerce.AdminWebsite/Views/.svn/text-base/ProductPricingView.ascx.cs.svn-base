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
    [PresenterType(typeof(ProductPricingPresenter))]
    public partial class ProductPricingView : BaseWebUserControl, IProductPricingView
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

        #region IProductPricingView Members

        public new event EventHandler LoadView;

        public new event EventHandler UnloadView;

        public bool SavedSuccessfully
        {
            get;
            set;
        }

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

        public decimal? RetailPrice
        {
            get
            {
                decimal i = 0;
                if (decimal.TryParse(tbRetailPrice.Text, out i))
                    return i;
                return i;
            }
            set
            {
                if (value != null && value != 0)
                    tbRetailPrice.Text = value.ToString();
                else
                    tbRetailPrice.Text = "";
            }
        }

        public decimal? SalesPrice
        {
            get
            {
                decimal i = 0;
                if (decimal.TryParse(tbSalePrice.Text, out i))
                    return i;
                return i;
            }
            set
            {
                if (value != null && value != 0)
                    tbSalePrice.Text = value.ToString();
                else
                    tbSalePrice.Text = "";
            }
        }

        public decimal? ListPrice
        {
            get
            {
                decimal i = 0;
                if (decimal.TryParse(tbListPrice.Text, out i))
                    return i;
                return i;
            }
            set
            {
                if (value != null && value != 0)
                    tbListPrice.Text = value.ToString();
                else
                    tbListPrice.Text = "";
            }
        }

        public decimal? CostPrice
        {
            get
            {
                decimal i = 0;
                if (decimal.TryParse(tbCostPrice.Text, out i))
                    return i;
                return i;
            }
            set
            {
                if (value != null && value != 0)
                    tbCostPrice.Text = value.ToString();
                else
                    tbCostPrice.Text = "";
            }
        }

        #endregion

        #region IBasePropertiesView<Product> Members

        public void LoadItem(Product t)
        {
            this.RetailPrice = t.RetailPrice;
            this.SalesPrice = t.SalePrice;
            this.ListPrice = t.ListPrice;
            this.CostPrice = t.CostPrice;
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