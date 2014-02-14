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
    public class ManufacturerDDL : DropDownList
    {
        public ManufacturerDDL()
        {
            this.Items.Clear();
            this.EmptyMessage = "-- Select Manufacturer --";
            this.Items.Add(new RadComboBoxItem("", ""));
            this.Skin = "Default";
            if (HttpContext.Current.Cache[ResourceStrings.Cache_ManufacturerList] == null)
            {
                HttpContext.Current.Cache[ResourceStrings.Cache_ManufacturerList] = new ManufacturerServices().GetAll();
            }
            foreach (var c in ((IList<Manufacturer>)HttpContext.Current.Cache[ResourceStrings.Cache_ManufacturerList]).OrderBy(o => o.Name))
            {
                this.Items.Add(new RadComboBoxItem(c.Name, c.ID.ToString()));
            }
        }
    }
}
