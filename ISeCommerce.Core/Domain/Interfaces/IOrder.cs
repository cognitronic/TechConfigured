using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ISeCommerce.Core.Domain.Interfaces
{
    public interface IOrder : IItem
    {
        int? CustomerID { get; set; }
        int OrderStatusID { get; set; }
        DateTime DateCreated { get; set; }
        DateTime LastUpdated { get; set; }
        int? CreditCardTypeID { get; set; }
        decimal SubTotal { get; set; }
        decimal ShippingCost { get; set; }
        decimal OrderTotal { get; set; }
        string CustomerPO { get; set; }
        bool IsShoppingCart { get; set; }
        decimal Tax { get; set; }
        string Email { get; set; }
        string Phone { get; set; }
        string BillingLastName { get; set; }
        string BillingFirstName { get; set; }
        string BillingCompany { get; set; }
        string BillingAddress1 { get; set; }
        string BillingAddress2 { get; set; }
        string BillingCity { get; set; }
        string BillingState { get; set; }
        string BillingZip { get; set; }
        string BillingPhone { get; set; }
        string ShippingLastName { get; set; }
        string ShippingFirstName { get; set; }
        string ShippingCompany { get; set; }
        string ShippingAddress1 { get; set; }
        string ShippingAddress2 { get; set; }
        string ShippingCity { get; set; }
        string ShippingState { get; set; }
        string ShippingZip { get; set; }
        string ShippingPhone { get; set; }
        IList<IOrderItem> Items { get; set; }
    }
}
