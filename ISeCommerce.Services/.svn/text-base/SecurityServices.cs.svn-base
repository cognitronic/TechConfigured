using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISeCommerce.Core.Domain.Interfaces.Services;
using ISeCommerce.Core.Security;
using ISeCommerce.Persistence.Repositories;
using IdeaSeed.Core;

namespace ISeCommerce.Services
{
    public class SecurityServices : ISecurityServices
    {

        #region ISecurityServices Members

        

        public void Signout()
        {
            var response = new AuthenticationResponse();
            SecurityContextManager.Current.IsAuthenticated = false;
            response.IsAuthenticated = false;
            SecurityContextManager.Current.CurrentUser = null;
        }

        public void CreateAuthenticationTicket()
        {
            throw new NotImplementedException();
        }

        //public int GetCurrentPageAccessLevel(ISecurityContext securityContext)
        //{
        //    var pageUser = new PageRepository().GetPageUserByPageIDUserID(securityContext.CurrentPage.ID, securityContext.CurrentUser.ID);
        //    //if there is page level security, return access level
        //    if (pageUser != null)
        //    {
        //        return pageUser.AccessLevel;
        //    }
        //    //else, loop through the current user's module access and if user has access to the current page module, return access level
        //    foreach (var m in securityContext.CurrentUser.UserModules)
        //    {
        //        if (securityContext.CurrentPage.ModuleID == m.ModuleID)
        //        {
        //            return m.AccessLevel;
        //        }
        //    }
        //    //otherwise no access.
        //    return (int)AccessLevels.NOACCESS;
        //}

        public static bool IsUsernameAvailable(string username)
        {
            var u = new UserRepository().GetByUserName(username);
            if (u == null || u.ID < 1)
                return true;
            return false;
        }


        #endregion
    }
}
