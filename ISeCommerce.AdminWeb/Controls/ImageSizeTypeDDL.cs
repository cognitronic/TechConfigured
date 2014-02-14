using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISeCommerce.Services;
using Telerik.Web.UI;
using ISeCommerce.Core.Domain;
using ISeCommerce.Core;
using IdeaSeed.Web.UI;

namespace ISeCommerce.AdminWeb.Controls
{
    public class ImageSizeTypeDDL : DropDownList
    {
        public ImageSizeTypeDDL()
        {
            this.Items.Clear();
            this.EmptyMessage = "-- Select Size --";
            this.Items.Add(new RadComboBoxItem("", ""));
            this.Skin = "Default";
            this.Items.Add(new RadComboBoxItem("Banner", "1"));
            this.Items.Add(new RadComboBoxItem("Small Banner", "2"));
            this.Items.Add(new RadComboBoxItem("Large Detail", "3"));
            this.Items.Add(new RadComboBoxItem("Medium Detail", "4"));
            this.Items.Add(new RadComboBoxItem("Small Detail", "5"));
            this.Items.Add(new RadComboBoxItem("Thumbnail", "6"));
        }
    }
}
