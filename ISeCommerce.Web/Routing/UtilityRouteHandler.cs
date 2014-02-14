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
using System.Web.SessionState;

namespace ISeCommerce.Web.Routing
{
    public class UtilityRouteHandler : IRouteHandler, IRequiresSessionState
    {
        public string VirtualPath { get; set; }

        public UtilityRouteHandler(string virtualPath)
        {
            this.VirtualPath = virtualPath;
        }

        #region IRouteHandler Members;

        IHttpHandler IRouteHandler.GetHttpHandler(RequestContext requestContext)
        {
            var p = new PageServices().GetPageByApplicationIDURL(Convert.ToInt16(ConfigurationManager.AppSettings["APPLICATIONID"]), VirtualPath);
            HttpPageHelper.CurrentPage = p;

            var item = new Item();
            item.Description = p.Name;
            item.Name = p.Title;
            item.SEOTitle = p.Title;
            item.ItemReference = item;
            HttpPageHelper.CurrentItem = item;

            var page = new System.Web.UI.Page();
            page = (System.Web.UI.Page)BuildManager.CreateInstanceFromVirtualPath(ResourceStrings.Page_FullWidthPath, typeof(System.Web.UI.Page));
            HttpPageHelper.IsValidRequest = true;

            return page;
        }
        #endregion
    }
}
