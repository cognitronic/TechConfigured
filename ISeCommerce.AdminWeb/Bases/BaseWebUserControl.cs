using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using IdeaSeed.Core;
using ISeCommerce.AdminWeb.Security;
using ISeCommerce.Core.Security;
using ISeCommerce.Core;
using System.Security.Principal;
using System.Runtime.InteropServices;

namespace ISeCommerce.AdminWeb.Bases
{
    public class BaseWebUserControl : System.Web.UI.UserControl, IView
    {
        public string Message { get; set; }
        public string ViewTitle { get; set; }
        public event EventHandler InitView;
        public event EventHandler LoadView;
        public event EventHandler UnloadView;

        #region imports
        [DllImport("advapi32.dll", SetLastError = true)]
        protected static extern bool LogonUser(string
        lpszUsername, string lpszDomain, string lpszPassword,
        int dwLogonType, int dwLogonProvider, ref 
IntPtr phToken);


        [DllImport("kernel32.dll", CharSet = CharSet.Auto,
        SetLastError = true)]
        protected static extern bool CloseHandle(IntPtr handle
        );

        [DllImport("advapi32.dll", CharSet = CharSet.Auto,
        SetLastError = true)]
        public extern static bool DuplicateToken(IntPtr
        existingTokenHandle,
        int SECURITY_IMPERSONATION_LEVEL, ref IntPtr
        duplicateTokenHandle);
        #endregion
        #region logon consts
        // logon types 
        protected const int LOGON32_LOGON_INTERACTIVE = 2;
        protected const int LOGON32_LOGON_NETWORK = 3;
        protected const int LOGON32_LOGON_NEW_CREDENTIALS = 9;

        // logon providers 
        protected const int LOGON32_PROVIDER_DEFAULT = 0;
        protected const int LOGON32_PROVIDER_WINNT50 = 3;
        protected const int LOGON32_PROVIDER_WINNT40 = 2;
        protected const int LOGON32_PROVIDER_WINNT35 = 1;
        #endregion

        protected T RegisterView<T>() where T : Presenter
        {
            return PresentationManager.RegisterView<T>(typeof(T), this, new WebSessionProvider());
        }

        protected void SelfRegister(System.Web.UI.UserControl control)
        {
            if (control != null && control is IView)
            {
                object[] attributes = control.GetType().GetCustomAttributes(typeof(PresenterTypeAttribute), true);

                if (attributes != null && attributes.Length > 0)
                {
                    foreach (Attribute viewAttribute in attributes)
                    {
                        if (viewAttribute is PresenterTypeAttribute)
                        {
                            //Had to grab the application context that gets created in the global.asax and shoved into the httpcontext.current.items collection.  In order to use it I have to assign it to the ISessionProvider because presenters have no knowledge of httpcontext.
                            var sessionProvider = new WebSessionProvider();
                            SessionManager.Current = sessionProvider;
                            if (HttpContext.Current.Items[ResourceStrings.Session_ApplicationContext] != null)
                            {
                                SessionManager.Current[ResourceStrings.Session_ApplicationContext] = (ApplicationContext)HttpContext.Current.Items[ResourceStrings.Session_ApplicationContext];
                            }
                            PresentationManager.RegisterView((viewAttribute as PresenterTypeAttribute).PresenterType, control as IView, sessionProvider);

                            if (SecurityContextManager.Current == null)
                            {
                                SecurityContextManager.Current = new WebSecurityContext();
                            }
                            break;
                        }
                    }
                }
            }
        }

        protected string ReplaceURLSegment(ISecurityContext securityContext, int segment, string replacementText)
        {
            string retVal = "";
            string[] segments = securityContext.CurrentURL.Split('/');
            if (segments.Length >= segment)
            {
                if (segments.Length >= (segment - 1))
                {
                    segments[segment - 1] = replacementText;
                }
                for (int i = 3; i < segments.Length; i++)
                {
                    retVal += segments[i] + "/";
                }
                return securityContext.BaseURL + "/" + retVal.Remove(retVal.Length - 1);
            }
            return SecurityContextManager.Current.CurrentURL + "/";
        }
    }
}
