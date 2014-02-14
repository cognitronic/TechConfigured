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

namespace ISeCommerce.AdminWeb.Routing
{
    public class DefaultRouteHandler : IRouteHandler
    {
        public string VirtualPath { get; set; }

        public DefaultRouteHandler(string virtualPath)
        {
            this.VirtualPath = virtualPath;
        }

        #region IRouteHandler Members

        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            HttpPageHelper.CurrentItem = null;
            var p = new PageServices().GetPageByApplicationIDURL(Convert.ToInt16(ConfigurationManager.AppSettings["APPLICATIONID"]), VirtualPath);
            HttpPageHelper.CurrentPage = p;

            var item = new Item();
            item.Description = p.Name;
            item.Name = p.Title;
            item.ItemReference = item;
            HttpPageHelper.CurrentItem = item;

            ISeCommerceAdminBasePage page;

            page = (ISeCommerceAdminBasePage)BuildManager.CreateInstanceFromVirtualPath(ResourceStrings.Page_FullWidthPath, typeof(System.Web.UI.Page));

            HttpPageHelper.IsValidRequest = true;
            return page;
        }

        #endregion
    }
}
