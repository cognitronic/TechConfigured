using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using IdeaSeed.Core;
using IdeaSeed.Web;
using ISeCommerce.Core.Security;
using ISeCommerce.Core;
using ISeCommerce.Core.Domain;
using ISeCommerce.Core.Domain.Interfaces;
using System.Web.SessionState;
using ISeCommerce.Services;
using ISeCommerce.Web.Utils;

namespace ISeCommerce.Web.Security
{
    public class WebSecurityContext : IeCommerceSecurityContext, IRequiresSessionState
    {
        public WebSecurityContext()
        {
            this.SignOut += new EventHandler(WebSecurityContext_SignOut);
        }

        void WebSecurityContext_SignOut(object sender, EventArgs e)
        {
            SecurityContextManager.Current = null;
            HttpContext.Current.Session.Clear();
            HttpContext.Current.Response.Cookies.Clear();
            FormsAuthentication.SignOut();
            HttpContext.Current.Response.Redirect(ResourceStrings.Page_Login);
        }

        public AuthenticationResponse AuthenticateUser(string userName, string password, string url, ISecurityContext securityContext)
        {
            var u = new UserServices().GetByUsernamePassword(userName, SecurityUtils.GetMd5Hash(password));
            var response = new AuthenticationResponse();
            if (u != null)
            {
                if (!u.IsActive)
                {
                    response.IsAuthenticated = false;
                    response.CurrentAccessLevel = AccessLevels.NOACCESS;
                    response.Message = "Your account has been marked as inactive.";
                }
                else
                {
                    CreateAuthenticationTicket(u.UserName, u.ID.ToString(), DateTime.Now.AddMinutes(240), url);
                    u.LastLoginDate = DateTime.Now;
                    securityContext.CurrentUser = u;
                    securityContext.IsAuthenticated = true;
                    response.IsAuthenticated = true;
                    response.CurrentAccessLevel = AccessLevels.FULLACCESS;
                    //new UserRepository().SaveOrUpdate(u);
                    //UserServices.LoadUserPreferences(SecurityContextManager.Current.CurrentUser);
                }
            }
            else
            {
                securityContext.IsAuthenticated = false;
                response.IsAuthenticated = false;
                securityContext.CurrentUser = null;
                response.Message = "Invalid username or password.  Please try again.";
            }

            return response;
        }

        private static void CreateAuthenticationTicket(string username, string userData, DateTime expiration, string url)
        {
            FormsAuthenticationTicket tkt = new FormsAuthenticationTicket(1, username, DateTime.Now, expiration, true, userData);
            string encryptedCookie = FormsAuthentication.Encrypt(tkt);
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedCookie);
            cookie.Expires = tkt.Expiration;
            cookie.Path = FormsAuthentication.FormsCookiePath;
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        public bool IsAuthenticated
        {
            get
            {
                if (SessionManager.Current[ResourceStrings.Session_IsAuthenticated] != null)
                {
                    return (bool)SessionManager.Current[ResourceStrings.Session_IsAuthenticated];
                }
                else
                {
                    SignOutUser();
                    return false;
                }
            }
            set
            {
                SessionManager.Current[ResourceStrings.Session_IsAuthenticated] = value;
            }
        }

        public IBaseApplicationPage CurrentPage
        {
            get
            {
                if (SessionManager.Current[ResourceStrings.Session_CurrentPage] != null)
                {
                    return (ISeCommerce.Core.Domain.Page)SessionManager.Current[ResourceStrings.Session_CurrentPage];
                }
                return new ISeCommerce.Core.Domain.Page();
            }
            set
            {
                SessionManager.Current[ResourceStrings.Session_CurrentPage] = value;
            }
        }

        public IBaseUser CurrentUser
        {
            get
            {
                if (SessionManager.Current[ResourceStrings.Session_CurrentUser] != null)
                {
                    return (User)SessionManager.Current[ResourceStrings.Session_CurrentUser];
                }
                return new User();
            }
            set
            {
                SessionManager.Current[ResourceStrings.Session_CurrentUser] = value;
            }
        }

        public IProduct CurrentProduct
        {
            get
            {
                if (SessionManager.Current[ResourceStrings.Session_CurrentProduct] != null)
                {
                    return (Product)SessionManager.Current[ResourceStrings.Session_CurrentProduct];
                }
                return new Product();
            }
            set
            {
                SessionManager.Current[ResourceStrings.Session_CurrentProduct] = value;
            }
        }

        public IBaseEntity CurrentItem
        {
            get
            {
                if (SessionManager.Current[ResourceStrings.Session_CurrentItem] != null)
                {
                    return (Item)SessionManager.Current[ResourceStrings.Session_CurrentItem];
                }
                return new Item() ;
            }
            set
            {
                SessionManager.Current[ResourceStrings.Session_CurrentItem] = value;
            }
        }

        public string BaseURL
        {
            get
            {
                if (SessionManager.Current[ResourceStrings.Session_CurrentBaseURL] != null)
                {
                    return SessionManager.Current[ResourceStrings.Session_CurrentBaseURL].ToString();
                }
                else
                {
                    SessionManager.Current[ResourceStrings.Session_CurrentBaseURL] = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);
                    return SessionManager.Current[ResourceStrings.Session_CurrentBaseURL].ToString();
                }
            }
            set
            {
                SessionManager.Current[ResourceStrings.Session_CurrentBaseURL] = value;
            }
        }

        public string PreviousURL
        {
            get
            {
                if (SessionManager.Current[ResourceStrings.Session_CurrentPreviousURL] != null)
                {
                    return SessionManager.Current[ResourceStrings.Session_CurrentPreviousURL].ToString();
                }
                return ResourceStrings.Page_Default;
            }
            set
            {
                SessionManager.Current[ResourceStrings.Session_CurrentPreviousURL] = value;
            }
        }

        public string CurrentURL
        {
            get
            {
                return HttpContext.Current.Request.Url.ToString();
            }
        }

        public AccessLevels CurrentAccessLevel
        {
            get
            {
                if (SessionManager.Current[ResourceStrings.Session_CurrentAccessLevel] != null)
                {
                    return (AccessLevels)SessionManager.Current[ResourceStrings.Session_CurrentAccessLevel];
                }
                return AccessLevels.NOACCESS;
            }
            set
            {
                SessionManager.Current[ResourceStrings.Session_CurrentAccessLevel] = value;
            }
        }

        public event EventHandler SignOut;

        protected virtual void OnSignOut(EventArgs e)
        {
            var handler = this.SignOut;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public void SignOutUser()
        {
            SecurityContextManager.Current = null;
            HttpContext.Current.Session.Clear();
            HttpContext.Current.Response.Cookies.Clear();
            FormsAuthentication.SignOut();
            HttpContext.Current.Response.Redirect(ResourceStrings.Page_Login);
        }

        #region IeCommerceSecurityContext Members

        public ICustomer CurrentCustomer
        {
            get
            {
                if (SessionManager.Current[ResourceStrings.Session_CurrentCustomer] != null)
                {
                    return (ICustomer)SessionManager.Current[ResourceStrings.Session_CurrentCustomer];
                }
                return new Customer();
            }
            set
            {
                SessionManager.Current[ResourceStrings.Session_CurrentCustomer] = value;
            }
        }

        public IShoppingCart CurrentShoppingCart
        {
            get
            {
                if (SessionManager.Current[ResourceStrings.Session_CurrentShoppingCart] != null)
                {
                    return (IShoppingCart)SessionManager.Current[ResourceStrings.Session_CurrentShoppingCart];
                }
                else if (!string.IsNullOrEmpty(new CookieServices().Retrieve(ResourceStrings.Cookie_Name)))
                {
                    var cart = new ShoppingCartServices().
                    GetByID(Convert.ToInt32(new CookieServices().Retrieve(ResourceStrings.Cookie_Name)));
                    SessionManager.Current[ResourceStrings.Session_CurrentShoppingCart] = cart;
                    return (IShoppingCart)SessionManager.Current[ResourceStrings.Session_CurrentShoppingCart];
                }
                else
                {
                    var cart = new ShoppingCart();
                    cart.DateCreated = DateTime.Now;
                    new ShoppingCartServices().Save(cart);
                    new CookieServices().Save(ResourceStrings.Cookie_Name, cart.ID.ToString(), DateTime.Now.AddDays(5));
                    SessionManager.Current[ResourceStrings.Session_CurrentShoppingCart] = cart;
                    return (IShoppingCart)SessionManager.Current[ResourceStrings.Session_CurrentShoppingCart];
                }
            }
            set
            {
                if (value != null)
                {
                    new CookieServices().Save(ResourceStrings.Cookie_Name, value.ID.ToString(), DateTime.Now.AddDays(5));
                }
                SessionManager.Current[ResourceStrings.Session_CurrentShoppingCart] = value;
            }
        }

        public bool WentSecure
        {
            get
            {
                if (SessionManager.Current["WENT_SECURE"] != null)
                {
                    return (bool)SessionManager.Current["WENT_SECURE"];
                }
                return false;
            }
            set
            {
                SessionManager.Current["WENT_SECURE"] = true;
            }
        }

        public SessionData CurrentSessionData
        {
            get
            {
                if (SessionManager.Current["CURRENT_SESSION_DATA"] != null)
                {
                    return (SessionData)SessionManager.Current["CURRENT_SESSION_DATA"];
                }
                return null;
            }
            set
            {
                SessionManager.Current["CURRENT_SESSION_DATA"] = value;
            }
        }

        public IProductCategory CurrentProductCategory
        {
            get
            {
                if (SessionManager.Current[ResourceStrings.Session_CurrentProductCategory] != null)
                {
                    return (IProductCategory)SessionManager.Current[ResourceStrings.Session_CurrentProductCategory];
                }
                return null;
            }
            set
            {
                SessionManager.Current[ResourceStrings.Session_CurrentProductCategory] = value;
            }
        }

        public ApplicationContext AppContext
        {
            get;
            set;
        }

        public IList<ApplicationSetting> CurrentApplicationSettings
        {
            get
            {
                return HttpContext.Current.Cache[ResourceStrings.Cache_ApplicationSettings] as IList<ApplicationSetting>;
            }
        }

        #endregion
    }
}
