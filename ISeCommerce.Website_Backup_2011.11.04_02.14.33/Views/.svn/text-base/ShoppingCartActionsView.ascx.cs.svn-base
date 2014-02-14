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
using Telerik.Web.UI;
using ISeCommerce.Web.Bases;
using ISeCommerce.Core;
using ISeCommerce.Services;

namespace ISeCommerce.Website.Views
{
    [ViewStateModeById]
    [PresenterType(typeof(ShoppingCartActionsPresenter))]
    public partial class ShoppingCartActionsView : BaseWebUserControl, IShoppingCartActionsView
    {
        protected override void OnInit(EventArgs e)
        {
            base.SelfRegister(this);
            if (this.InitView != null)
            {
                this.InitView(this, e);
            }
            base.OnInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.LoadView != null)
            {
                this.LoadView(this, EventArgs.Empty);
            }
            ShowConfirmation = false;
        }

        protected void SameAsShippingCheckChanged(object o, EventArgs e)
        {
            tbBillingAddress1.Text = tbShippingAddress1.Text;
            tbBillingAddress2.Text = tbShippingAddress2.Text;
            tbBillingCity.Text = tbShippingCity.Text;
            tbBillingEmail.Text = tbEmail.Text;
            tbBillingFirstName.Text = tbShippingFirstName.Text;
            tbBillingLastName.Text = tbShippingLastName.Text;
            tbBillingPhone.Text = tbPhone.Text;
            tbBillingZip.Text = tbShippingZip.Text;
            ddlBillingState.SelectedValue = ddlShippingState.SelectedValue;
        }

        protected void UpdateShippingClicked(object o, EventArgs e)
        {
            if (this.OnUpdateShipping != null)
            {
                this.OnUpdateShipping(this, new IdeaSeedLinkButtonArgs());
            }
        }

        protected void PurchaseClicked(object o, EventArgs e)
        {
            if (this.OnPurchase != null)
            {
                this.OnPurchase(this, new IdeaSeedLinkButtonArgs());
            }
        }

        #region IShoppingCartActionsView Members

        public event EventHandler<IdeaSeedLinkButtonArgs> OnPurchase;
        public event EventHandler<IdeaSeedLinkButtonArgs> OnUpdateShipping;
        public new event EventHandler LoadView;
        public new event EventHandler InitView;
        public new event EventHandler UnloadView;

        public decimal ItemsTotal
        {
            get
            {
                decimal d = 0;
                decimal.TryParse(lblSubtotal.Text, out d);
                return d;
            }
            set
            {
                lblSubtotal.Text = string.Format("{0:c}", value);
            }
        }

        public decimal ShippingTotal
        {
            get
            {
                decimal d = 0;
                decimal.TryParse(lblShippingTotal.Text, out d);
                return d;
            }
            set
            {
                lblShippingTotal.Text = string.Format("{0:c}", value);
            }
        }

        public decimal TaxTotal
        {
            get
            {
                decimal d = 0;
                decimal.TryParse(lblTaxTotal.Text, out d);
                return d;
            }
            set
            {
                lblTaxTotal.Text = string.Format("{0:c}", value);
            }
        }

        public decimal GrandTotal
        {
            get
            {
                decimal d = 0;
                decimal.TryParse(lblGrandTotal.Text, out d);
                return d;
            }
            set
            {
                lblGrandTotal.Text = string.Format("{0:c}", value);
            }
        }

        public bool ShowConfirmation
        {
            get
            {
                return divConfirmation.Visible;
            }
            set
            {
                divConfirmation.Visible = value;
            }
        }

        public bool PurchaseEnabled
        {
            get
            {
                return lbPurchase.Enabled;
            }
            set
            {
                lbPurchase.Enabled = value;
            }
        }

        public bool UpdateShippingEnabled
        {
            get
            {
                return lbUpdateShipping.Enabled;
            }
            set
            {
                lbUpdateShipping.Enabled = value;
            }
        }

        public string Message
        {
            get
            {
                return pMessage.InnerHtml;
            }
            set
            {
                pMessage.InnerHtml = value;
            }
        }

        #endregion





        #region IShoppingCartActionsView Members


        public string ShipToZip
        {
            get
            {
                return tbShippingZip.Text;
            }
            set
            {
                tbShippingZip.Text = value;
            }
        }

        public string ShipToState
        {
            get
            {
                return ddlShippingState.SelectedValue;
            }
            set
            {
                ddlShippingState.SelectedValue = value;
            }
        }

        public string ShipFromZip
        {
            get
            {
                return ResourceStrings.Shipping_ShipFromZip;
            }
            set
            {
               
            }
        }

        public string ShipFromState
        {
            get
            {
                return ResourceStrings.Shipping_ShipFromState;
            }
            set
            {
                
            }
        }

        public string BillingFirstName
        {
            get
            {
                return tbBillingFirstName.Text;
            }
            set
            {
                tbBillingFirstName.Text = value;
            }
        }

        public string BillingLastName
        {
            get
            {
                return tbBillingLastName.Text;
            }
            set
            {
                tbBillingLastName.Text = value;
            }
        }

        public string BillingAddress
        {
            get
            {
                return tbBillingAddress1.Text;
            }
            set
            {
                tbBillingAddress1.Text = value;
            }
        }

        public string BillingCity
        {
            get
            {
                return tbBillingCity.Text;
            }
            set
            {
                tbBillingCity.Text = value;
            }
        }

        public string BillingState
        {
            get
            {
                return ddlBillingState.SelectedValue;
            }
            set
            {
                ddlBillingState.SelectedValue = value;
            }
        }

        public string BillingZip
        {
            get
            {
                return tbBillingZip.Text;
            }
            set
            {
                tbBillingZip.Text = value;
            }
        }

        public string BillingCountry
        {
            get;
            set;
        }

        public string CreditCardNumber
        {
            get
            {
                return tbCardNumber.Text;
            }
            set
            {
                tbCardNumber.Text = value;
            }
        }

        public string CreditCardExpirationDate
        {
            get
            {
                return ddlExpirationDate.SelectedValue + "/" + ddlExpirationYear.SelectedValue;
            }
            set
            {
                
            }
        }

        public string CreditCardCodeNumber
        {
            get
            {
                return tbCvvCode.Text;
            }
            set
            {
                tbCvvCode.Text = value;
            }
        }

        public string BillingEmail
        {
            get
            {
                return tbBillingEmail.Text;
            }
            set
            {
                tbBillingEmail.Text = value;
            }
        }

        public string BillingPhone
        {
            get
            {
                return tbBillingPhone.Text;
            }
            set
            {
                tbBillingPhone.Text = value;
            }
        }

        #endregion

        #region IShoppingCartActionsView Members


        public string BillingAddress1
        {
            get
            {
                return tbBillingAddress1.Text;
            }
            set
            {
                tbBillingAddress1.Text = value;
            }
        }

        public string BillingAddress2
        {
            get
            {
                return tbBillingAddress2.Text;
            }
            set
            {
                tbBillingAddress2.Text = value;
            }
        }

        public string BillingCompany
        {
            get
            {
                return tbCompany.Text;
            }
            set
            {
                tbCompany.Text = value; ;
            }
        }

        public string ShippingCompany
        {
            get
            {
                return tbCompany.Text;
            }
            set
            {
                tbCompany.Text = value; ;
            }
        }

        public string ShippingFirstName
        {
            get
            {
                return tbShippingFirstName.Text;
            }
            set
            {
                tbShippingFirstName.Text = value;
            }
        }

        public string ShippingLastName
        {
            get
            {
                return tbShippingLastName.Text;
            }
            set
            {
                tbShippingLastName.Text = value;
            }
        }

        public string ShippingEmail
        {
            get
            {
                return tbEmail.Text;
            }
            set
            {
                tbEmail.Text = value;
            }
        }

        public string ShippingPhone
        {
            get
            {
                return tbPhone.Text;
            }
            set
            {
                tbPhone.Text = value;
            }
        }

        public string ShippingAddress1
        {
            get
            {
                return tbShippingAddress1.Text;
            }
            set
            {
                tbShippingAddress1.Text = value;
            }
        }

        public string ShippingAddress2
        {
            get
            {
                return tbShippingAddress2.Text;
            }
            set
            {
                tbShippingAddress2.Text = value;
            }
        }

        public string ShippingCity
        {
            get
            {
                return tbShippingCity.Text;
            }
            set
            {
                tbShippingCity.Text = value;
            }
        }

        #endregion
    }
}