using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Configuration;
using System.Web.Compilation;
using System.Web.UI;
using System.Collections;
using ISeCommerce.Web.Utils;
using ISeCommerce.Services;
using ISeCommerce.Core.Domain;
using ISeCommerce.Web.Bases;
using ISeCommerce.Core;
using ISeCommerce.Core.Security;
using System.Web.SessionState;
using IdeaSeed.Core;

namespace ISeCommerce.Web.Routing
{
    public class ProductCategoryRouteHandler : IRouteHandler, IRequiresSessionState
    {
        public string VirtualPath { get; set; }

        public ProductCategoryRouteHandler(string virtualPath)
        {
            this.VirtualPath = virtualPath;
        }

        #region IRouteHandler Members

        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {

            string itemURL = HttpUtility.HtmlDecode((string)requestContext.RouteData.DataTokens["itemURL"]);
            int itemID = (int)requestContext.RouteData.DataTokens["itemID"];
            bool isProduct = (bool)requestContext.RouteData.DataTokens["isProduct"];

            HttpPageHelper.CurrentItem = null;
            HttpPageHelper.CurrentProduct = null;
            HttpPageHelper.CurrentProductCategory = null;
            var p = new PageServices().GetPageByApplicationIDURL(Convert.ToInt16(ConfigurationManager.AppSettings["APPLICATIONID"]), VirtualPath);
            HttpPageHelper.CurrentPage = p;
            if (isProduct)
            {
                if (itemID > 0)
                {
                    var product = new ProductServices().GetByID(itemID);
                    var item = new Item();
                    item.Name = product.Name;
                    item.URL = itemURL;
                    item.ItemReference = product;
                    item.SEOTitle = product.SEOTitle;
                    item.SEODescription = product.SEODescription;
                    item.SEOKeywords = product.SEOKeywords;
                    HttpPageHelper.CurrentItem = item;
                    HttpPageHelper.CurrentProduct = product;
                }
            }
            else
            {
                HttpPageHelper.CurrentProduct = null;
                if (itemID > 0)
                {
                    var category = new ProductCategoryServices().GetByID(itemID);
                    var item = new Item();
                    item.Name = category.Name;
                    item.URL = itemURL;
                    item.ItemReference = category;
                    item.SEOTitle = category.SEOTitle;
                    item.SEODescription = category.SEODescription;
                    item.SEOKeywords = category.SEOKeywords;
                    HttpPageHelper.CurrentItem = item;
                    HttpPageHelper.CurrentProductCategory = category;
                }
            }

            ISeCommerceBasePage page;

            page = (ISeCommerceBasePage)BuildManager.CreateInstanceFromVirtualPath(ResourceStrings.Page_TwoColumnPath, typeof(System.Web.UI.Page));

            HttpPageHelper.IsValidRequest = true;
            return page;
        }
        #endregion
    }
}
