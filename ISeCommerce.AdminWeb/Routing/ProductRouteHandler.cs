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
    public class ProductRouteHandler : IRouteHandler, IRequiresSessionState
    {
        public string VirtualPath { get; set; }

        public ProductRouteHandler(string virtualPath)
        {
            this.VirtualPath = virtualPath;
        }

        #region IRouteHandler Members

        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            string id = HttpUtility.HtmlDecode((string)requestContext.RouteData.Values["id"]);
            bool isNew = false;
            if(requestContext.RouteData.DataTokens["isNew"] != null)
                isNew = (bool)requestContext.RouteData.DataTokens["isNew"];
            var page = new System.Web.UI.Page();
            var p = new PageServices().GetPageByApplicationIDURL(Convert.ToInt16(ConfigurationManager.AppSettings["APPLICATIONID"]), VirtualPath);
            HttpPageHelper.CurrentPage = p;

            if (!string.IsNullOrEmpty(id))
            {
                var product = new ProductServices().GetByID(Convert.ToInt32(id));
                var item = new Item();
                item.Name = product.Name;
                item.URL = "/Products/" + product.ID.ToString();
                item.ItemReference = product;
                item.SEOTitle = product.SEOTitle;
                HttpPageHelper.CurrentItem = item;
                HttpPageHelper.CurrentProduct = product;
                page = (System.Web.UI.Page)BuildManager.CreateInstanceFromVirtualPath(ResourceStrings.Page_TwoColumnPath, typeof(System.Web.UI.Page));
            }
            else if (isNew)
            {
                var item = new Item();
                item.Description = p.Name;
                item.URL = "/New";
                item.Name = "New Product";
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
