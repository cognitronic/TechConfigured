using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeed.Web.UI;
using Telerik.Web.UI;
using ISeCommerce.Services;

namespace ISeCommerce.AdminWeb.Controls
{
    public class ProductSpecificationValuesDDL : DropDownList
    {
        public int SpecificationID { get; set; }

        public void LoadPropertyValues()
        {
            this.Items.Clear();
            this.EmptyMessage = "-- Select --";
            this.Items.Add(new RadComboBoxItem("", ""));
            this.Skin = "Default";
            foreach (var s in new ProductCategorySpecificationPropertValueServices().GetValuesByPropertyID(SpecificationID))
            {
                this.Items.Add(new RadComboBoxItem(s.Value, s.ID.ToString()));
            }
        }
    }
}
