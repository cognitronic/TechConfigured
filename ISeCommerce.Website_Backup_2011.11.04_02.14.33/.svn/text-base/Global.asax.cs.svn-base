using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using IdeaSeed.Core;
using ISeCommerce.Core.Domain;
using ISeCommerce.Web.Routing;
using System.Web.Routing;
using ISeCommerce.Core;
using ISeCommerce.Core.Security;
using ISeCommerce.Services;
using System.Configuration;


namespace ISeCommerce.Website
{
    public class Global : System.Web.HttpApplication
    {

        void Application_Start(object sender, EventArgs e)
        {
            RouteBuilder builder = new RouteBuilder(RouteTable.Routes);
            builder.Run();
            Context.Cache.Insert(ResourceStrings.Cache_PrimaryNavData, new ProductCategoryServices().BuildPrimaryNavigation());
            Context.Cache.Insert(ResourceStrings.Cache_ProductList, new ProductServices().GetAll());
            Context.Cache.Insert(ResourceStrings.Cache_ProductCategoryList, new ProductCategoryServices().GetAll());
        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

        }

        void Session_Start(object sender, EventArgs e)
        {

        }

        void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.

        }

        void Application_BeginRequest(object sender, EventArgs e)
        {
            HttpContext.Current.Items[ResourceStrings.Session_MasterPageContext] = new MasterPageContext();
            HttpContext.Current.Items[ResourceStrings.Session_ApplicationContext] = new ApplicationContext();
        }
    }
}
