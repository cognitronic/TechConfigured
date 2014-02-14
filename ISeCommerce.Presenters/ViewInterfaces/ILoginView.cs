using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeed.Core;

namespace ISeCommerce.Presenters.ViewInterfaces
{
    public interface ILoginView : IView
    {
        string UserName { get; }
        string Password { get; }
        void LoginSuccess();
        void LoginFailed();
        event EventHandler OnLoginClick;
    }
}
