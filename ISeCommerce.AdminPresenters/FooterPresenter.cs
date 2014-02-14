using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISeCommerce.AdminPresenters.ViewInterfaces;
using ISeCommerce.Core.Domain;
using ISeCommerce.Core.Security;
using IdeaSeed.Core;
using ISeCommerce.Services;
using ISeCommerce.Core;
using ISeCommerce.Core.Domain.Interfaces;

namespace ISeCommerce.AdminPresenters
{
    public class FooterPresenter : Presenter
    {
        IFooterView _view;

        public FooterPresenter(IFooterView view, ISessionProvider session)
            : base(view, session)
        {
            _view = base.GetView<IFooterView>();
            _view.InitView += new EventHandler(_view_InitView);
            _view.LoadView += new EventHandler(_view_LoadView);
            _view.UnloadView += new EventHandler(_view_UnloadView);
            _view.OnEmailSignupClick += new EventHandler(_view_OnEmailSignupClick);
        }

        void _view_OnEmailSignupClick(object sender, EventArgs e)
        {
            
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
