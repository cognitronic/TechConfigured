using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISeCommerce.AdminPresenters.ViewInterfaces;
using ISeCommerce.Core.Domain;
using ISeCommerce.Core.Security;
using IdeaSeed.Core;
using ISeCommerce.Services;

namespace ISeCommerce.AdminPresenters
{
    public class FullWidthPagePresenter : Presenter
    {
        IFullWidthPageView _view;

        public FullWidthPagePresenter(IFullWidthPageView view, ISessionProvider session)
            : base(view, session)
        {
            _view = base.GetView<IFullWidthPageView>();
            _view.OnLoadData += new EventHandler(_view_OnLoadData);
        }

        void _view_OnLoadData(object sender, EventArgs e)
        {
            var views = new PageViewServices().GetPageApplicationViewsByPageID(SecurityContextManager.Current.CurrentPage.ID);
            var list = new List<ApplicationView>();
            foreach (var view in views)
            {
                if (view.ApplicationView != null)
                {
                    switch (view.ViewLayout)
                    { 
                        case ApplicationViewLayout.MAIN:
                            _view.MainContentViews.Add(view);
                            break;
                    }
                }
            }
        }
    }
}
