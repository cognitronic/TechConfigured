using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeed.Web.UI;
using Telerik.Web.UI;
using ISeCommerce.Services;

namespace ISeCommerce.Web.Controls
{
    public class ProductCategorySpecificationsDDL : DropDownList
    {
        public int CategoryID { get; set; }

        public void LoadPropertyValues(int categoryID)
        {
            this.Items.Clear();
            this.EmptyMessage = "-- Select --";
            this.Items.Add(new RadComboBoxItem("", ""));
            this.Skin = "Metro";
            foreach (var s in new ProductCategorySpecificationServices().GetByCategoryID(categoryID))
            {
                this.Items.Add(new RadComboBoxItem(s.Name, s.ID.ToString()));
            }
        }
    }
}
