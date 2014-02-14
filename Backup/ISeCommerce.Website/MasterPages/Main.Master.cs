using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ISeCommerce.Web.Bases;
using System.Web.UI.HtmlControls;

namespace ISeCommerce.Website.MasterPages
{
    public partial class Main : BaseMasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BuildSiteMap();
        }

        public Views.PrimaryNavView PrimaryNavView
        {
            get
            {
                return primaryNavView;
            }
        }

        public ContentPlaceHolder MainContent
        {
            get
            {
                return cpMainContent;
            }
        }

        public ContentPlaceHolder Footer
        {
            get
            {
                return cpFooter;
            }
        }

        private void BuildSiteMap()
        {
            string[] items = HttpContext.Current.Request.Url.Segments;
            string domain = Request.Url.GetLeftPart(UriPartial.Authority).Replace("https:", "http:").Replace("secure", "www");
            string result = "";
            string url = "";
            result = "<div class='crumb'><ul>";
            for (int i = 0; items.Length > i; i++)
            {
                if (i == 0 && items.Length > 2)
                {
                    result += "<li class='first'><a href='" + domain + "/Home'>Home</a></li>";
                }
                else if (i == (items.Length - 1))
                {
                    if (items.Length == 2)
                    {
                        if (!items[i].Equals("Home"))
                        {
                            result += "<li class='first'><a href='" + domain + "/Home'>Home</a></li>";
                        }
                        url += items[i];
                        result += "<li class='first'>" + items[i].Replace("-", " ").Replace("/", "") + "</li>";
                    }
                    else
                    {
                        url += items[i];
                        result += "<li>" + items[i].Replace("-", " ").Replace("/", "") + "</li>";
                    }
                }
                else
                {
                    url += "/" + items[i].Remove(items[i].Length - 1, 1);
                    result += "<li><a href='" + domain + url + "'>" + items[i].Replace("-", " ").Replace("/", "") + "</a></li>";
                }
            }
            result += "</ul></div>";
            var div = new LiteralControl(result);
            phSiteMap.Controls.Add(div);

        }
    }
}