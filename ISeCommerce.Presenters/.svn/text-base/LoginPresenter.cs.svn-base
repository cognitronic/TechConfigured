using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISeCommerce.Presenters.ViewInterfaces;
using ISeCommerce.Core.Domain;
using ISeCommerce.Core.Security;
using IdeaSeed.Core;
using ISeCommerce.Services;
using ISeCommerce.Core;
using ISeCommerce.Core.Domain.Interfaces;

namespace ISeCommerce.Presenters
{
    public class LoginPresenter: Presenter
    {
        ILoginView _view;

        public LoginPresenter(ILoginView view, ISessionProvider session)
            : base(view, session)
        {
            _view = base.GetView<ILoginView>();
            _view.InitView += new EventHandler(_view_InitView);
            _view.LoadView += new EventHandler(_view_LoadView);
            _view.UnloadView += new EventHandler(_view_UnloadView);
            _view.OnLoginClick += new EventHandler(_view_OnLoginClick);
        }

        void _view_OnLoginClick(object sender, EventArgs e)
        {
            var response = SecurityContextManager.Current.AuthenticateUser(_view.UserName, _view.Password, "", SecurityContextManager.Current);
            if (response.IsAuthenticated)
            {
                _view.LoginSuccess();
            }
            else
            {
                _view.LoginFailed();
            }
        }

        void _view_UnloadView(object sender, EventArgs e)
        {
           
        }

        void _view_LoadView(object sender, EventArgs e)
        {
            
        }

        void _view_InitView(object sender, EventArgs e)
        {
            
        }
    }
}
