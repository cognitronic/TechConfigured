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
    public class TopNavPresenter : Presenter
    {
        ITopNavView _view;

        public TopNavPresenter(ITopNavView view, ISessionProvider session)
            : base(view, session)
        {
            _view = base.GetView<ITopNavView>();
            _view.InitView += new EventHandler(_view_InitView);
            _view.LoadView += new EventHandler(_view_LoadView);
            _view.UnloadView += new EventHandler(_view_UnloadView);
            _view.OnLogout += new EventHandler(_view_OnLogout);
            _view.OnSearch += new EventHandler(_view_OnSearch);
        }

        void _view_OnSearch(object sender, EventArgs e)
        {
            
        }

        void _view_OnLogout(object sender, EventArgs e)
        {
            SecurityContextManager.Current.SignOutUser();
        }

        void _view_UnloadView(object sender, EventArgs e)
        {
           
        }

        void _view_LoadView(object sender, EventArgs e)
        {
            if (ApplicationContext.CurrentCustomer != null &&
                SecurityContextManager.Current.CurrentCustomer.ID > 0)
            {
                _view.LoggedOnUser = ApplicationContext.CurrentCustomer.FirstName + " " + ApplicationContext.CurrentCustomer.LastName;
                _view.CustomerLoggedIn = true;
            }
            else if (SecurityContextManager.Current.CurrentUser != null && 
                SecurityContextManager.Current.CurrentUser.ID > 0)
            {
                _view.LoggedOnUser = SecurityContextManager.Current.CurrentUser.FirstName +
                    " " +
                    SecurityContextManager.Current.CurrentUser.LastName;
                _view.CustomerLoggedIn = true;
            }
            else
            {
                _view.CustomerLoggedIn = false;
                _view.LoggedOnUser = "Welcome!";
            }
        }

        void _view_InitView(object sender, EventArgs e)
        {
            
        }
    }
}
