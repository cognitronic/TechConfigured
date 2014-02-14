using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeed.Core;
using ISeCommerce.Core.Domain.Interfaces;

namespace ISeCommerce.AdminPresenters.ViewInterfaces
{
    public interface ITopNavView : IView
    {
        bool CustomerLoggedIn { get; set; }
        string LoggedOnUser { get; set; }
        event EventHandler OnLogout;
        event EventHandler OnSearch;
    }
}
