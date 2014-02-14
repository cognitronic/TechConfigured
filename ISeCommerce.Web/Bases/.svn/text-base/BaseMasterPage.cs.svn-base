using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using ISeCommerce.Services;
using ISeCommerce.Core.Domain;
using ISeCommerce.Core.Security;
using IdeaSeed.Core;
using ISeCommerce.Core;

namespace ISeCommerce.Web.Bases
{
    public class BaseMasterPage : System.Web.UI.MasterPage
    {
        protected override void OnLoad(EventArgs e)
        {
            if (SessionManager.Current != null)
            {
                BuildNav();
            }
            base.OnLoad(e);
        }

        public void BuildNav()
        {
            var sb = new StringBuilder();
            var list = Cache[ResourceStrings.Cache_PrimaryNavData] as IDictionary<ProductCategory, IList<ProductCategory>>;
            //var roots = list.Keys.OrderBy(o => o.SortOrder);
            sb.Append("<ul id='nav' class='dropdown dropdown-linear dropdown-columnar'>");
            foreach (var cat in list)
            {
                sb.Append("<li><a href='");
                sb.Append(SecurityContextManager.Current.BaseURL.Replace("https:", "http:").Replace("secure","www"));
                sb.Append("/");
                sb.Append(cat.Key.Name.Replace(" ", "-").Trim());
                sb.Append("'>");
                sb.Append(cat.Key.Name);
                sb.Append("</a>");
                var kids = cat.Value.OrderBy(o => o.SortOrder);
                if (kids != null && kids.Count() > 0)
                {
                    sb.Append("<ul class='pad'>");
                    foreach (var k in kids)
                    {
                        sb.Append("<li class='clear'><a href='");
                        sb.Append(SecurityContextManager.Current.BaseURL.Replace("https:", "http:").Replace("secure", "www"));
                        sb.Append("/");
                        sb.Append(cat.Key.Name.Replace(" ", "-").Trim());
                        sb.Append("/");
                        sb.Append(k.Name.Replace(" ", "-").Trim());
                        sb.Append("'>");
                        sb.Append(k.Name);
                        sb.Append("</a></li>");
                    }
                    sb.Append("</ul></li>");
                }
                else
                {
                    sb.Append("</li>");
                }
            }
            sb.Append("</ul>");

            //var cart = new ShoppingCartSerializable();
            //cart.DateCreated = SecurityContextManager.Current.CurrentShoppingCart.DateCreated;
            //cart.ID = SecurityContextManager.Current.CurrentShoppingCart.ID;
            //cart.CartItems = SecurityContextManager.Current.CurrentShoppingCart.CartItems.ToList<ShoppingCartItem>();
            var session = new SessionData();
            if (SecurityContextManager.Current.CurrentSessionData != null)
            {
                session = new SessionDataServices().GetByID(SecurityContextManager.Current.CurrentSessionData.ID);
                //session.Value = IdeaSeed.Core.Utils.Utilities.SerializeToString(cart);
            }
            //else
            //{
            //    session.Value = IdeaSeed.Core.Utils.Utilities.SerializeToString(cart);
            //    SecurityContextManager.Current.CurrentSessionData = session;
            //}
            //new SessionDataServices().Save(session);
            if (session.ID > 0)
            {
                sb.Append("<ul class='lang'><li><a href='" + ResourceStrings.Page_SecureCheckout + "Cart/" + session.ID.ToString() + "' style='color: #ffffff;' />View Cart&nbsp;&nbsp; <img src='/Images/cart.gif' border='0' alt='View Shopping Cart'/></a></li></ul>");
            }

            MasterPageContext.PrimaryNavText =  sb.ToString();
        }

        public void BuildSubNav(int parentID)
        {
            var list = new PageServices().GetSubNav(parentID);
            if (list != null)
            {
                var sb = new StringBuilder();
                sb.Append("<ul>");
                foreach (var page in list)
                {
                    sb.Append("<li>");
                    sb.Append("<a href='");
                    sb.Append(Request.Url.GetLeftPart(UriPartial.Authority));
                    sb.Append("/");
                    sb.Append(page.URLRoute);
                    sb.Append("' alt='");
                    sb.Append(page.Name);
                    sb.Append("'>");
                    sb.Append(page.Name);
                    sb.Append("</a>");
                    sb.Append("</li>");
                }
                sb.Append("</ul>");
                MasterPageContext.SubNavText = sb.ToString();
            }
        }
    }
}
