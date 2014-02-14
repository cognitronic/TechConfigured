using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISeCommerce.Core.Domain;
using IdeaSeed.Core;

namespace ISeCommerce.Core.Security
{
    public class ApplicationContext
    {
        public static Customer CurrentCustomer
        {
            get
            {
                if (SessionManager.Current[ResourceStrings.Session_CurrentCustomer] != null)
                {
                    return (Customer)SessionManager.Current[ResourceStrings.Session_CurrentCustomer];
                }
                return null;
            }
            set
            {
                SessionManager.Current[ResourceStrings.Session_CurrentCustomer] = value;
            }
        }
    }
}
