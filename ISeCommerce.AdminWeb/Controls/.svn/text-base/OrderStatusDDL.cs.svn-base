using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISeCommerce.Services;
using Telerik.Web.UI;
using ISeCommerce.Core.Domain;
using ISeCommerce.Core;
using IdeaSeed.Web.UI;
using System.Web;
using System.Web.Caching;

namespace ISeCommerce.AdminWeb.Controls
{
    public class OrderStatusDDL : DropDownList
    {
        public OrderStatusDDL()
        {
            this.Items.Clear();
            this.EmptyMessage = "-- Select --";
            this.Items.Add(new RadComboBoxItem("", ""));
            this.Skin = "Windows7";
            foreach (var s in Enum.GetValues(typeof(ISeCommerce.Core.Domain.OrderStatus)))
            {
                this.Items.Add(new RadComboBoxItem(Enum.GetName(typeof(ISeCommerce.Core.Domain.OrderStatus), Convert.ToInt16(s)), Convert.ToInt16(s).ToString()));
            }
        }
    }
}
