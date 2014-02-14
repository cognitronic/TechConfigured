﻿using System;
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
    public class OrderRouteHandler : IRouteHandler, IRequiresSessionState
    {
        public string VirtualPath { get; set; }

        public OrderRouteHandler(string virtualPath)
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
                var user = new OrderServices().GetByID(Convert.ToInt32(id));
                var item = new Item();
                item.Name = user.Name;
                item.URL = "/Orders/" + user.ID.ToString();
                item.ItemReference = user;
                item.SEOTitle = user.SEOTitle;
                HttpPageHelper.CurrentItem = item;
                page = (System.Web.UI.Page)BuildManager.CreateInstanceFromVirtualPath(ResourceStrings.Page_FullWidthPath, typeof(System.Web.UI.Page));
            }
            else if (isNew)
            {
                var item = new Item();
                item.Description = p.Name;
                item.URL = "/New";
                item.Name = "New Order";
                item.ItemReference = item;
                HttpPageHelper.CurrentItem = item;
                page = (System.Web.UI.Page)BuildManager.CreateInstanceFromVirtualPath(ResourceStrings.Page_FullWidthPath, typeof(System.Web.UI.Page));
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