using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using ISeCommerce.Core.Domain;
using System.Collections.Generic;
using System.Web.Routing;
using ISeCommerce.Core;
using ISeCommerce.Services;

namespace ISeCommerce.AdminWeb.Routing
{
    public class RouteBuilder
    {
        public RouteCollection Routes { get; private set; }
        public RouteBuilder(RouteCollection routes)
        {
            Routes = routes;
        }

        public void Run()
        {
            Route defaultRoute = new Route("Dashboard", new DefaultRouteHandler("Dashboard"));
            Routes.Add(defaultRoute);

            BuildUtilityRoutes();

            BuildCategoryRoutes();

            BuildProductRoutes();

            BuildUserRoutes();

            BuildOrderRoutes();

            BuildManagedListsRoutes();

            BuildCampaignRoutes();

            defaultRoute = new Route("", new DefaultRouteHandler("Login"));
            Routes.Add(defaultRoute);
        }

        public void BuildCategoryRoutes()
        {
            Route categoryPropertiesRoute = new Route("Category/{name}/Details", new ProductCategoryRouteHandler("Category/Details"));
            categoryPropertiesRoute.Constraints = new RouteValueDictionary { { "name", @"^\D+" } };
            Routes.Add(categoryPropertiesRoute);

            categoryPropertiesRoute = new Route("Category/{name}/Images", new ProductCategoryRouteHandler("Category/Images"));
            categoryPropertiesRoute.Constraints = new RouteValueDictionary { { "name", @"^\D+" } };
            Routes.Add(categoryPropertiesRoute);

            categoryPropertiesRoute = new Route("Category/{name}/Specifications", new ProductCategoryRouteHandler("Category/Specifications"));
            categoryPropertiesRoute.Constraints = new RouteValueDictionary { { "name", @"^\D+" } };
            Routes.Add(categoryPropertiesRoute);

            categoryPropertiesRoute = new Route("Category/New", new ProductCategoryRouteHandler("Category/Details"));
            RouteValueDictionary routeValues = new RouteValueDictionary();
            routeValues.Add("isNew", true);
            categoryPropertiesRoute.DataTokens = routeValues;
            Routes.Add(categoryPropertiesRoute);

            categoryPropertiesRoute = new Route("Category/{name}", new ProductCategoryRouteHandler("Category/Details"));
            categoryPropertiesRoute.Constraints = new RouteValueDictionary { { "name", @"^\D+" } };
            Routes.Add(categoryPropertiesRoute);

            Route productCategoryRoute = new Route("Category", new ProductCategoryRouteHandler("Category"));
            Routes.Add(productCategoryRoute);
        }

        public void BuildUtilityRoutes()
        {
            Route loginRoute = new Route("Login", new UtilityRouteHandler("Login"));
            Routes.Add(loginRoute);

        }

        public void BuildProductRoutes()
        {
            Route productPropertiesRoute = new Route("Products/{id}/Details", new ProductRouteHandler("Product/Details"));
            productPropertiesRoute.Constraints = new RouteValueDictionary { { "id", @"^\d+" } };
            Routes.Add(productPropertiesRoute);

            productPropertiesRoute = new Route("Products/{id}/Images", new ProductRouteHandler("Product/Images"));
            productPropertiesRoute.Constraints = new RouteValueDictionary { { "id", @"^\d+" } };
            Routes.Add(productPropertiesRoute);

            productPropertiesRoute = new Route("Products/{id}/Pricing", new ProductRouteHandler("Product/Pricing"));
            productPropertiesRoute.Constraints = new RouteValueDictionary { { "id", @"^\d+" } };
            Routes.Add(productPropertiesRoute);

            productPropertiesRoute = new Route("Products/{id}/Shipping", new ProductRouteHandler("Product/Shipping"));
            productPropertiesRoute.Constraints = new RouteValueDictionary { { "id", @"^\d+" } };
            Routes.Add(productPropertiesRoute);

            productPropertiesRoute = new Route("Products/{id}/Specifications/{specid}", new ProductRouteHandler("Product/Specifications/id"));
            productPropertiesRoute.Constraints = new RouteValueDictionary { { "id", @"^\d+" } };
            productPropertiesRoute.Constraints = new RouteValueDictionary { { "specid", @"^\d+" } };
            Routes.Add(productPropertiesRoute);

            productPropertiesRoute = new Route("Products/{id}/Specifications", new ProductRouteHandler("Product/Specifications"));
            productPropertiesRoute.Constraints = new RouteValueDictionary { { "id", @"^\d+" } };
            Routes.Add(productPropertiesRoute);

            productPropertiesRoute = new Route("Products/{id}/Variations", new ProductRouteHandler("Product/Variations"));
            productPropertiesRoute.Constraints = new RouteValueDictionary { { "id", @"^\d+" } };
            Routes.Add(productPropertiesRoute);

            productPropertiesRoute = new Route("Products/{id}/SEO", new ProductRouteHandler("Product/SEO"));
            productPropertiesRoute.Constraints = new RouteValueDictionary { { "id", @"^\d+" } };
            Routes.Add(productPropertiesRoute);

            productPropertiesRoute = new Route("Products/{id}/Media", new ProductRouteHandler("Product/Media"));
            productPropertiesRoute.Constraints = new RouteValueDictionary { { "id", @"^\d+" } };
            Routes.Add(productPropertiesRoute);

            productPropertiesRoute = new Route("Products/New", new ProductRouteHandler("Product/Details"));
            RouteValueDictionary routeValues = new RouteValueDictionary();
            routeValues.Add("isNew", true);
            productPropertiesRoute.DataTokens = routeValues;
            Routes.Add(productPropertiesRoute);

            productPropertiesRoute = new Route("Products/{id}", new ProductRouteHandler("Product/Details"));
            productPropertiesRoute.Constraints = new RouteValueDictionary { { "id", @"^\d+" } };
            Routes.Add(productPropertiesRoute);

            Route productRoute = new Route("Products", new ProductCategoryRouteHandler("Products"));
            Routes.Add(productRoute);
        }

        public void BuildUserRoutes()
        {
            Route route = new Route("Users/{id}", new UserRouteHandler("User"));
            route.Constraints = new RouteValueDictionary { { "id", @"^\d+" } };
            Routes.Add(route);

            route = new Route("Users/New", new UserRouteHandler("User"));
            Routes.Add(route);

            route = new Route("Users", new UserRouteHandler("Users"));
            Routes.Add(route);
        }

        public void BuildOrderRoutes()
        {
            Route route = new Route("Orders/{id}", new OrderRouteHandler("Order"));
            route.Constraints = new RouteValueDictionary { { "id", @"^\d+" } };
            Routes.Add(route);

            route = new Route("Orders/New", new OrderRouteHandler("Order"));
            RouteValueDictionary routeValues = new RouteValueDictionary();
            routeValues.Add("isNew", true);
            route.DataTokens = routeValues;
            Routes.Add(route);

            route = new Route("Orders", new OrderRouteHandler("Orders"));
            Routes.Add(route);
        }

        public void BuildManagedListsRoutes()
        {
            Route route = new Route("Managed-Lists/Banners/{id}", new BannerRouteHandler("Managed-Lists/Banner"));
            route.Constraints = new RouteValueDictionary { { "id", @"^\d+" } };
            Routes.Add(route);

            route = new Route("Managed-Lists/Banners/New", new BannerRouteHandler("Managed-Lists/Banner"));
            RouteValueDictionary routeValues = new RouteValueDictionary();
            routeValues.Add("isNew", true);
            route.DataTokens = routeValues;
            Routes.Add(route);

            route = new Route("Managed-Lists/Banners", new BannerRouteHandler("Managed-Lists/Banners"));
            Routes.Add(route);

            route = new Route("Settings", new DefaultAdminRouteHandler("Settings"));
            Routes.Add(route);
        }

        public void BuildCampaignRoutes()
        {
            Route route = new Route("Campaign-Manager/Dashboard", new CampaignManagerRouteHandler("Campaign-Manager/Dashboard", ResourceStrings.CampaignManager_Dashboard));
            Routes.Add(route);

            route = new Route("Campaign-Manager/Templates", new CampaignManagerRouteHandler("Campaign-Manager/Templates", ResourceStrings.CampaignManager_Templates));
            Routes.Add(route);

            route = new Route("Campaign-Manager/Subscribers", new CampaignManagerRouteHandler("Campaign-Manager/Subscribers", ResourceStrings.CampaignManager_Subscribers));
            Routes.Add(route);

            route = new Route("Campaign-Manager/Tags", new CampaignManagerRouteHandler("Campaign-Manager/Tags", ResourceStrings.CampaignManager_Tags));
            Routes.Add(route);

            route = new Route("Campaign-Manager/Template", new CampaignManagerRouteHandler("Campaign-Manager/Template", ResourceStrings.CampaignManager_Template));
            Routes.Add(route);

            route = new Route("Campaign-Manager/Campaign-Viewer", new CampaignManagerRouteHandler("Campaign-Manager/Viewer", ResourceStrings.CampaignManager_Viewer));
            Routes.Add(route);

            route = new Route("Campaign-Manager/Forward-To-A-Friend", new CampaignManagerRouteHandler("Campaign-Manager/Forward-Friend", ResourceStrings.CampaignManager_ForwardFriend));
            Routes.Add(route);

            route = new Route("Campaign-Manager/Import-Subscribers", new CampaignManagerRouteHandler("Campaign-Manager/Import-Subscribers", ResourceStrings.CampaignManager_ImportSubscribers));
            Routes.Add(route);

            route = new Route("Campaign-Manager/Manage-Subscribers-Tags", new CampaignManagerRouteHandler("Campaign-Manager/Manage-Subscribers-Tags", ResourceStrings.CampaignManager_ManageSubscribersTags));
            Routes.Add(route);

            route = new Route("Campaign-Manager/New-Campaign", new CampaignManagerRouteHandler("Campaign-Manager/New-Campaign", ResourceStrings.CampaignManager_NewCampaign));
            Routes.Add(route);
        }
    }
}
