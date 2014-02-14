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
    public class ProductCategoriesDDL : DropDownList
    {
        public ProductCategoriesDDL()
        {
            this.Items.Clear();
            this.EmptyMessage = "-- Select Category --";
            this.Items.Add(new RadComboBoxItem("", ""));
            this.Skin = "Default";
            foreach (var c in ((IList<ProductCategory>)HttpContext.Current.Cache[ResourceStrings.Cache_ProductCategoryList]).OrderBy(o => o.Name))
            {
                this.Items.Add(new RadComboBoxItem(c.Name, c.ID.ToString()));
            }
        }
    }
}
