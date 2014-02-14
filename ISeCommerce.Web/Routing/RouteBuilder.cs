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
using ISeCommerce.Services;

namespace ISeCommerce.Web.Routing
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

            Route defaultRoute = new Route("Home", new DefaultRouteHandler("Home"));
            Routes.Add(defaultRoute);

            BuildUtilityRoutes();

            BuildProductRoutes();

            ShoppingCartRoutes();

            defaultRoute = new Route("", new DefaultRouteHandler("Home"));
            Routes.Add(defaultRoute);
        }

        public void BuildUtilityRoutes()
        {
            Route loginRoute = new Route("Login", new UtilityRouteHandler("Login"));
            Routes.Add(loginRoute);

            Route route = new Route("Privacy-Policy", new InfoPageRouteHandler("Privacy-Policy", "/Privacy.aspx"));
            Routes.Add(route);

            route = new Route("Security-Policy", new InfoPageRouteHandler("Security-Policy", "/Security.aspx"));
            Routes.Add(route);
            route = new Route("Return-Policy", new InfoPageRouteHandler("Return-Policy", "/Refund.aspx"));
            Routes.Add(route);
            route = new Route("Shipping-Policy", new InfoPageRouteHandler("Shipping-Policy", "/Shipping.aspx"));
            Routes.Add(route);
            route = new Route("Product-Warranty-Info", new InfoPageRouteHandler("Product-Warranty-Info", "/ProductWarrantyInfo.aspx"));
            Routes.Add(route);
            //route = new Route("Blog", new InfoPageRouteHandler("Blog", ));
            //Routes.Add(route);
            route = new Route("Track-Orders", new InfoPageRouteHandler("Track-Orders", "/TrackOrders.aspx"));
            Routes.Add(route);
            route = new Route("About-Us", new InfoPageRouteHandler("About-Us", "/AboutUs.aspx"));
            Routes.Add(route);
            route = new Route("Contact-Us", new InfoPageRouteHandler("Contact-Us", "/ContactUs.aspx"));
            Routes.Add(route);
            route = new Route("Office-Hours", new InfoPageRouteHandler("Office-Hours", "/OfficeHours.aspx"));
            Routes.Add(route);

        }

        public void ShoppingCartRoutes()
        {
            Route route = new Route("Cart", new ShoppingCartRouteHandler("ShoppingCart"));
            Routes.Add(route);

            route = new Route("Cart/{cartid}", new ShoppingCartRouteHandler("ShoppingCart"));
            route.Constraints = new RouteValueDictionary { { "cartid", @"^\d+" } };
            Routes.Add(route);
        }

        public void BuildProductRoutes()
        {
            var list = new ProductCategoryServices().GetRootCategories();
            foreach (var item in list)
            {
                ProductCategoryRoutes(item, "");
            }
        }

        private void ProductCategoryRoutes(ProductCategory category, string url)
        {
            if (category.ChildCategories.Count > 0)
            {
                foreach (var cat in category.ChildCategories)
                {
                    var updatedUrl = url + category.Name.Replace(" ", "-") + "/";
                    ProductCategoryRoutes((ProductCategory)cat, updatedUrl);
                }
                BuildItemRoute(category, url);
            }
            else
            {
                BuildItemRoute(category, url);
            }
        }

        private void BuildItemRoute(ProductCategory category, string url)
        {
            RouteValueDictionary routeValues = new RouteValueDictionary();
            var updatedUrl = url + category.Name.Replace(" ", "-");
            Route route = new Route(updatedUrl, new ProductCategoryRouteHandler("Products"));
            routeValues.Add("itemID", category.ID);
            routeValues.Add("isProduct", false);
            routeValues.Add("itemURL", url);
            route.DataTokens = routeValues;
            Routes.Add(route);
            if (category.Products.Count > 0)
            {
                foreach (var product in category.Products)
                {
                    routeValues = new RouteValueDictionary();
                    var productURL = url + category.Name.Replace(" ", "-") + "/" + product.Name.Replace(" ", "-");
                    Route productRoute = new Route(productURL, new ProductCategoryRouteHandler("ProductDetail"));
                    routeValues.Add("isProduct", true);
                    routeValues.Add("itemID", product.ID);
                    routeValues.Add("itemURL", productURL);
                    productRoute.DataTokens = routeValues;
                    Routes.Add(productRoute);
                }
            }
        }
    }
}
