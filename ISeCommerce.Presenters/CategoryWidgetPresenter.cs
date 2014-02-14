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
    public class CategoryWidgetPresenter : Presenter
    {
        ICategoryWidgetView _view;

        public CategoryWidgetPresenter(ICategoryWidgetView view, ISessionProvider session)
            : base(view, session)
        {
            _view = base.GetView<ICategoryWidgetView>();
            _view.InitView += new EventHandler(_view_InitView);
            _view.LoadView += new EventHandler(_view_LoadView);
            _view.UnloadView += new EventHandler(_view_UnloadView);   
        }

        void _view_UnloadView(object sender, EventArgs e)
        {
           
        }

        void _view_LoadView(object sender, EventArgs e)
        {
            _view.ViewTitle = SecurityContextManager.Current.CurrentItem.Name;
            if(SecurityContextManager.Current.CurrentItem.ItemReference is ProductCategory)
            {
                _view.ChildCategories = ((ProductCategory)SecurityContextManager.Current.CurrentItem.ItemReference).ChildCategories;
            }
        }

        void _view_InitView(object sender, EventArgs e)
        {
            
        }
    }
}
