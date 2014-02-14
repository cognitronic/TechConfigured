using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISeCommerce.Core.Domain.Interfaces;

namespace ISeCommerce.Core.Domain
{
    [Serializable]
    public class Order : IOrder
    {
        public virtual int? CustomerID { get; set; }
        public virtual int OrderStatusID { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual DateTime LastUpdated { get; set; }
        public virtual int? CreditCardTypeID { get; set; }
        public virtual decimal SubTotal { get; set; }
        public virtual decimal ShippingCost { get; set; }
        public virtual decimal OrderTotal { get; set; }
        public virtual string CustomerPO { get; set; }
        public virtual bool IsShoppingCart { get; set; }
        public virtual decimal Tax { get; set; }
        public virtual string Email { get; set; }
        public virtual string Phone { get; set; }
        public virtual string BillingLastName { get; set; }
        public virtual string BillingFirstName { get; set; }
        public virtual string BillingCompany { get; set; }
        public virtual string BillingAddress1 { get; set; }
        public virtual string BillingAddress2 { get; set; }
        public virtual string BillingCity { get; set; }
        public virtual string BillingState { get; set; }
        public virtual string BillingZip { get; set; }
        public virtual string BillingPhone { get; set; }
        public virtual string ShippingLastName { get; set; }
        public virtual string ShippingFirstName { get; set; }
        public virtual string ShippingCompany { get; set; }
        public virtual string ShippingAddress1 { get; set; }
        public virtual string ShippingAddress2 { get; set; }
        public virtual string ShippingCity { get; set; }
        public virtual string ShippingState { get; set; }
        public virtual string ShippingZip { get; set; }
        public virtual string ShippingPhone { get; set; }
        public virtual ItemType TypeOfItem { get; set; }
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }
        public virtual string SEOTitle { get; set; }
        public virtual string SEODescription { get; set; }
        public virtual string SEOKeywords { get; set; }
        public virtual string URL { get; set; }
        public virtual string Description { get; set; }
        public virtual object ItemReference { get; set; }
        private IList<IOrderItem> _items = new List<IOrderItem>();
        public virtual IList<IOrderItem> Items { get { return _items; } set { _items = value; } }

        
    }
}
