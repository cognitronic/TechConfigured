using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Configuration;
using System.Web.Compilation;
using System.Web.UI;
using System.Collections;
using ISeCommerce.AdminWeb.Utils;
using ISeCommerce.Services;
using ISeCommerce.Core.Domain;
using ISeCommerce.AdminWeb.Bases;
using ISeCommerce.Core;
using ISeCommerce.Core.Security;
using System.Web.SessionState;
using IdeaSeed.Core;

namespace ISeCommerce.AdminWeb.Routing
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
            string name = HttpUtility.HtmlDecode((string)requestContext.RouteData.Values["name"]);
            bool isNew = false;
            if(requestContext.RouteData.DataTokens["isNew"] != null)
                isNew = (bool)requestContext.RouteData.DataTokens["isNew"];
            var page = new System.Web.UI.Page();
            var p = new PageServices().GetPageByApplicationIDURL(Convert.ToInt16(ConfigurationManager.AppSettings["APPLICATIONID"]), VirtualPath);
            HttpPageHelper.CurrentPage = p;

            if (!string.IsNullOrEmpty(name))
            {
                var category = new ProductCategoryServices().GetByName(name);
                var item = new Item();
                item.Name = category.Name;
                item.URL = "/Category/" + category.Name;
                item.ItemReference = category;
                HttpPageHelper.CurrentItem = item;
                HttpPageHelper.CurrentProductCategory = category;
                page = (System.Web.UI.Page)BuildManager.CreateInstanceFromVirtualPath(ResourceStrings.Page_TwoColumnPath, typeof(System.Web.UI.Page));
            }
            else if (isNew)
            {
                var item = new Item();
                item.Description = p.Name;
                item.URL = "/New";
                item.Name = "New Category";
                item.ItemReference = item;
                HttpPageHelper.CurrentItem = item;
                HttpPageHelper.CurrentProductCategory = new ProductCategory();
                page = (System.Web.UI.Page)BuildManager.CreateInstanceFromVirtualPath(ResourceStrings.Page_TwoColumnPath, typeof(System.Web.UI.Page));
            }
            else
            {
                page = (System.Web.UI.Page)BuildManager.CreateInstanceFromVirtualPath(ResourceStrings.Page_FullWidthPath, typeof(System.Web.UI.Page));
            }
            HttpPageHelper.IsValidRequest = true;
            return page;
        }
        #endregion
    }
}
