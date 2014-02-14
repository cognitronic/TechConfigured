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
    [PresenterType(typeof(OrderDetailsPresenter))]
    public partial class OrderDetailsView : BaseWebUserControl, IOrderDetailsView
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

        #region IBasePropertiesView<Order> Members

        public void LoadItem(Order t)
        {
            this.BillingAddress1 = t.BillingAddress1;
            this.BillingAddress2 = t.BillingAddress2;
            this.BillingCity = t.BillingCity;
            this.BillingCompany = t.BillingCompany;
            this.BillingFirstName = t.BillingFirstName;
            this.BillingLastName = t.BillingLastName;
            this.BillingPhone = t.BillingPhone;
            this.BillingState = t.BillingState;
            this.BillingZip = t.BillingZip;
            this.DateCreated = t.DateCreated;
            this.Email = t.Email;
            this.OrderStatusID = t.OrderStatusID;
            this.OrderTotal = t.OrderTotal;
            this.Phone = t.Phone;
            this.ShippingAddress1 = t.ShippingAddress1;
            this.ShippingAddress2 = t.ShippingAddress2;
            this.ShippingCity = t.ShippingCity;
            this.ShippingCompany = t.ShippingCompany;
            this.ShippingCost = t.ShippingCost;
            this.ShippingFirstName = t.ShippingFirstName;
            this.ShippingLastName = t.ShippingLastName;
            this.ShippingPhone = t.ShippingPhone;
            this.ShippingState = t.ShippingState;
            this.ShippingZip = t.ShippingZip;
            this.SubTotal = t.SubTotal;
            this.Tax = t.Tax;

            rgList.DataSource = t.Items;
            rgList.DataBind();

        }

        public void NavigateTo(string url)
        {
            Response.Redirect(url);
        }

        #endregion

        #region IBaseAuditable Members

        public int ChangedBy
        {
            get;
            set;
        }

        public DateTime DateCreated
        {
            get
            {
                return DateTime.Parse(lblOrderDate.Text);
            }
            set
            {
                lblOrderDate.Text = value.ToShortDateString();
            }
        }

        public int EnteredBy
        {
            get;
            set;
        }

        public DateTime LastUpdated
        {
            get;
            set;
        }

        public bool MarkedForDeletion
        {
            get;
            set;
        }

        #endregion

        #region IPropertiesActions Members

        public event EventHandler<IdeaSeedLinkButtonArgs> SaveClick;

        public event EventHandler<IdeaSeedLinkButtonArgs> CancelClick;

        public event EventHandler<IdeaSeedLinkButtonArgs> DeleteClick;

        #endregion

        #region IOrder Members

        public int? CustomerID
        {
            get;
            set;
        }

        public int OrderStatusID
        {
            get
            {
                int i = 0;
                if (int.TryParse(lblStatus.Text, out i))
                    return i;
                return i;
            }
            set
            {
                if (value != null && value != 0)
                    lblStatus.Text = Enum.GetName(typeof(OrderStatus), value);
                else
                    lblStatus.Text = "";
            }
        }

        public int? CreditCardTypeID
        {
            get;
            set;
        }

        public decimal SubTotal
        {
            get;
            set;
        }

        public decimal ShippingCost
        {
            get;
            set;
        }

        public decimal OrderTotal
        {
            get;
            set;
        }

        public string CustomerPO
        {
            get;
            set;
        }

        public bool IsShoppingCart
        {
            get;
            set;
        }

        public decimal Tax
        {
            get;
            set;
        }

        public string Email
        {
            get
            {
                return lblEmail.Text;
            }
            set
            {
                lblEmail.Text = value;
            }
        }

        public string Phone
        {
            get
            {
                return lblShippingPhone.Text;
            }
            set
            {
                lblShippingPhone.Text = value;
            }
        }

        public string BillingLastName
        {
            get
            {
                return lblBillingLastName.Text;
            }
            set
            {
                lblBillingLastName.Text = value;
            }
        }

        public string BillingFirstName
        {
            get
            {
                return lblBillingFirstName.Text;
            }
            set
            {
                lblBillingFirstName.Text = value;
            }
        }

        public string BillingCompany
        {
            get
            {
                return lblBillingCompany.Text;
            }
            set
            {
                lblBillingCompany.Text = value;
            }
        }

        public string BillingAddress1
        {
            get
            {
                return lblBillingAddress1.Text;
            }
            set
            {
                lblBillingAddress1.Text = value;
            }
        }

        public string BillingAddress2
        {
            get
            {
                return lblBillingAddress2.Text;
            }
            set
            {
                lblBillingAddress2.Text = value;
            }
        }

        public string BillingCity
        {
            get
            {
                return lblBillingCity.Text;
            }
            set
            {
                lblBillingCity.Text = value; 
            }
        }

        public string BillingState
        {
            get
            {
                return lblBillingState.Text;
            }
            set
            {
                lblBillingState.Text = value;
            }
        }

        public string BillingZip
        {
            get
            {
                return lblBillingZip.Text;
            }
            set
            {
                lblBillingZip.Text = value;
            }
        }

        public string BillingPhone
        {
            get
            {
                return lblBillingPhone.Text;
            }
            set
            {
                lblBillingPhone.Text = value;
            }
        }

        public string ShippingLastName
        {
            get
            {
                return lblShippingLastName.Text;
            }
            set
            {
                lblShippingLastName.Text = value;
            }
        }

        public string ShippingFirstName
        {
            get
            {
                return lblShippingFirstName.Text;
            }
            set
            {
                lblShippingFirstName.Text = value;
            }
        }

        public string ShippingCompany
        {
            get
            {
                return lblShippingCompany.Text;
            }
            set
            {
                lblShippingCompany.Text = value;
            }
        }

        public string ShippingAddress1
        {
            get
            {
                return lblShippingAddress1.Text;
            }
            set
            {
                lblShippingAddress1.Text = value;
            }
        }

        public string ShippingAddress2
        {
            get
            {
                return lblShippingAddress2.Text;
            }
            set
            {
                lblShippingAddress2.Text = value;
            }
        }

        public string ShippingCity
        {
            get
            {
                return lblShippingCity.Text;
            }
            set
            {
                lblShippingCity.Text = value;
            }
        }

        public string ShippingState
        {
            get
            {
                return lblShippingState.Text;
            }
            set
            {
                lblShippingState.Text = value;
            }
        }

        public string ShippingZip
        {
            get
            {
                return lblShippingZip.Text;
            }
            set
            {
                lblShippingZip.Text = value;
            }
        }

        public string ShippingPhone
        {
            get
            {
                return lblShippingPhone.Text;
            }
            set
            {
                lblShippingPhone.Text = value;
            }
        }

        public IList<Core.Domain.Interfaces.IOrderItem> Items
        {
            get;
            set;
        }

        #endregion

        #region IItem Members

        public ItemType TypeOfItem
        {
            get;
            set;
        }

        #endregion

        #region IBaseItem Members

        public new int ID
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        #endregion

        #region IBaseNavigation Members

        public string SEOTitle
        {
            get;
            set;
        }

        public string SEOKeywords
        {
            get;
            set;
        }

        public string SEODescription
        {
            get;
            set;
        }

        public string URL
        {
            get;
            set;
        }

        #endregion

        #region IBaseObjectReference Members

        public string Description
        {
            get;
            set;
        }

        public object ItemReference
        {
            get;
            set;
        }

        #endregion
    }
}