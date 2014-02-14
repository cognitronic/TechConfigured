using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISeCommerce.Core.Security
{
    public class SecurityContextManager
    {
        private static IeCommerceSecurityContext _securityContext;

        private SecurityContextManager()
        { 
        
        }

        public static IeCommerceSecurityContext Current
        {
            get
            {
                return _securityContext;
            }
            set
            {
                _securityContext = value;
            }
        }

    }
}
