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

namespace ISeCommerce.AdminWeb.Bases
{
    public class BaseMasterPage : System.Web.UI.MasterPage
    {
        protected override void OnLoad(EventArgs e)
        {
            if (SessionManager.Current != null)
            {
                BuildNav();
                if (!SecurityContextManager.Current.CurrentURL.Contains("Specifications"))
                    SessionManager.Current["SelectedPropertID"] = null;
            }
            base.OnLoad(e);
        }

        public void BuildNav()
        {
            var sb = new StringBuilder();
            var list = Cache[ResourceStrings.Cache_AdminNavData] as IOrderedEnumerable<Page>;
            //var roots = list.Keys.OrderBy(o => o.SortOrder);
            sb.Append("<ul id='nav' class='dropdown dropdown-linear dropdown-columnar'>");
            foreach (var cat in list)
            {
                
                sb.Append("<li><a href='");
                sb.Append(SecurityContextManager.Current.BaseURL);
                sb.Append("/");
                sb.Append(cat.URLRoute.Replace(" ", "-").Trim());
                sb.Append("'>");
                sb.Append(cat.Name);
                sb.Append("</a>");
                if (cat.ChildPages.Count > 0)
                {
                    sb.Append("<ul class='pad'>");
                    foreach (var k in cat.ChildPages)
                    {
                        sb.Append("<li class='clear'><a href='");
                        sb.Append(SecurityContextManager.Current.BaseURL);
                        sb.Append("/");
                        sb.Append(cat.Name.Replace(" ", "-").Trim());
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

            MasterPageContext.PrimaryNavText = sb.ToString();
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
