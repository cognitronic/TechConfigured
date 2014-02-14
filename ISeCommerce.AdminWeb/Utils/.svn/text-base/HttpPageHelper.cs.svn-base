using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeed.Web;
using ISeCommerce.Core.Domain;
using IdeaSeed.Core;

namespace ISeCommerce.AdminWeb.Utils
{
    public class HttpPageHelper
    {
        public static Page CurrentPage
        {
            get { return HttpContextHelper.Get<Page>("SQ_CURRENT_PAGE"); }
            set { HttpContextHelper.Set("SQ_CURRENT_PAGE", value); }
        }

        public static Product CurrentProduct
        {
            get { return HttpContextHelper.Get<Product>("SQ_CURRENT_PRODUCT"); }
            set { HttpContextHelper.Set("SQ_CURRENT_PRODUCT", value); }
        }

        public static ProductCategory CurrentProductCategory
        {
            get { return HttpContextHelper.Get<ProductCategory>("SQ_CURRENT_PRODUCTCATEGORY"); }
            set { HttpContextHelper.Set("SQ_CURRENT_PRODUCTCATEGORY", value); }
        }

        public static bool IsValidRequest
        {
            get { return HttpContextHelper.Get<bool>("SQ_IS_VALID_REQUEST"); }
            set { HttpContextHelper.Set("SQ_IS_VALID_REQUEST", value); }
        }

        public static IBaseItem CurrentItem
        {
            get { return HttpContextHelper.Get<IBaseItem>("SQ_CURRENTITEM"); }
            set { HttpContextHelper.Set("SQ_CURRENTITEM", value); }
        }
    }
}
