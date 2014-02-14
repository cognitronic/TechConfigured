using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISeCommerce.Presenters.ViewInterfaces;
using ISeCommerce.Core.Domain;
using ISeCommerce.Core.Security;
using IdeaSeed.Core;
using ISeCommerce.Services;

namespace ISeCommerce.Presenters
{
    public class TwoColumnPagePresenter : Presenter
    {
        ITwoColumnPageView _view;

        public TwoColumnPagePresenter(ITwoColumnPageView view, ISessionProvider session)
            : base(view, session)
        {
            _view = base.GetView<ITwoColumnPageView>();
            _view.LoadView += new EventHandler(_view_LoadView);
            _view.UnloadView += new EventHandler(_view_UnloadView);
        }

        void _view_UnloadView(object sender, EventArgs e)
        {
            
        }

        void _view_LoadView(object sender, EventArgs e)
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
                            _view.ColumnTwoViews.Add(view);
                            break;
                        case ApplicationViewLayout.SIDEBAR:
                            _view.ColumnOneViews.Add(view);
                            break;
                    }
                }
            }
        }
    }
}
