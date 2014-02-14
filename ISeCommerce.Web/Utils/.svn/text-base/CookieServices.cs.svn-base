using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using ISeCommerce.Core.Domain.Interfaces.Services;

namespace ISeCommerce.Web.Utils
{
    public class CookieServices : ICookieServices
    {
        #region ICookieServices Members

        public void Save(string key, string value, DateTime expires)
        {
            HttpContext.Current.Response.Cookies[key].Value = value;
            HttpContext.Current.Response.Cookies[key].Expires = expires;
        }

        public string Retrieve(string key)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[key];
            if (cookie != null)
                return cookie.Value;
            return "";
        }

        #endregion
    }
}
