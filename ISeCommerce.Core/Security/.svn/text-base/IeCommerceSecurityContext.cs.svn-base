using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeed.Core;
using ISeCommerce.Core.Domain.Interfaces;
using ISeCommerce.Core.Domain;

namespace ISeCommerce.Core.Security
{
    public interface IeCommerceSecurityContext : ISecurityContext
    {
        ICustomer CurrentCustomer { get; set; }
        IShoppingCart CurrentShoppingCart { get; set; }
        IProductCategory CurrentProductCategory { get; set; }
        IProduct CurrentProduct { get; set; }
        AuthenticationResponse AuthenticateUser(string userName, string password, string url, ISecurityContext securityContext);
        ApplicationContext AppContext { get; set; }
        IList<ApplicationSetting> CurrentApplicationSettings { get;}
        SessionData CurrentSessionData { get; set; }
        bool WentSecure { get; set; }
    }
}
