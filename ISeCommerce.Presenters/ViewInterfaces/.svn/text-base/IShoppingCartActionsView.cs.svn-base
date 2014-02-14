using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeed.Core;
using ISeCommerce.Core.Domain.Interfaces;

namespace ISeCommerce.Presenters.ViewInterfaces
{
    public interface IShoppingCartActionsView : IView
    {
        event EventHandler<IdeaSeedLinkButtonArgs> OnPurchase;
        event EventHandler<IdeaSeedLinkButtonArgs> OnUpdateShipping;
        bool ShowConfirmation { get; set; }
        bool UpdateShippingEnabled { get; set; }
        bool PurchaseEnabled { get; set; }
        decimal ItemsTotal { get; set; }
        decimal ShippingTotal { get; set; }
        decimal TaxTotal { get; set; }
        decimal GrandTotal { get; set; }
        string ShipToZip { get; set; }
        string ShipToState { get; set; }
        string ShipFromZip { get; set; }
        string ShipFromState { get; set; }
        string BillingFirstName { get; set; }
        string BillingLastName { get; set; }
        string BillingAddress1 { get; set; }
        string BillingAddress2 { get; set; }
        string BillingCity { get; set; }
        string BillingState { get; set; }
        string BillingZip { get; set; }
        string BillingCountry { get; set; }
        string CreditCardNumber { get; set; }
        string CreditCardExpirationDate { get; set; }
        string CreditCardCodeNumber { get; set; }
        string BillingEmail { get; set; }
        string BillingPhone { get; set; }
        string BillingCompany { get; set; }
        string ShippingCompany { get; set; }
        string ShippingFirstName { get; set; }
        string ShippingLastName { get; set; }
        string ShippingEmail { get; set; }
        string ShippingPhone { get; set; }
        string ShippingAddress1 { get; set; }
        string ShippingAddress2 { get; set; }
        string ShippingCity { get; set; }



    }
}
