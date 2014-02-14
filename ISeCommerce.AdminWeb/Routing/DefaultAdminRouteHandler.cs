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
    public class DefaultAdminRouteHandler : IRouteHandler, IRequiresSessionState
    {
        public string VirtualPath { get; set; }

        public DefaultAdminRouteHandler(string virtualPath)
        {
            this.VirtualPath = virtualPath;
        }

        #region IRouteHandler Members;

        IHttpHandler IRouteHandler.GetHttpHandler(RequestContext requestContext)
        {
            var p = new PageServices().GetPageByApplicationIDURL(Convert.ToInt16(ConfigurationManager.AppSettings["APPLICATIONID"]), VirtualPath);
            HttpPageHelper.CurrentPage = p;
            var page = new System.Web.UI.Page();
            page = (System.Web.UI.Page)BuildManager.CreateInstanceFromVirtualPath(ResourceStrings.Page_Admin_FullWidthPath, typeof(System.Web.UI.Page));
            HttpPageHelper.IsValidRequest = true;

            return page;
        }
        #endregion
    }
}
