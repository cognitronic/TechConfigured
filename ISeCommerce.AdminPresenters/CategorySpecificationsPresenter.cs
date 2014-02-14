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
    public class CategorySpecificationsPresenter : Presenter
    {
        ICategorySpecificationsView _view;

        public CategorySpecificationsPresenter(ICategorySpecificationsView view, ISessionProvider session)
            : base(view, session)
        {
            _view = base.GetView<ICategorySpecificationsView>();
            _view.InitView += new EventHandler(_view_InitView);
            _view.LoadView += new EventHandler(_view_LoadView);
            _view.OnGetSpecifications += new EventHandler<IdeaSeedGridArgs>(_view_OnGetSpecifications);
            _view.OnGetValues += new EventHandler<IdeaSeedGridArgs>(_view_OnGetValues);
            _view.OnSpecificationsDataBound += new EventHandler<IdeaSeedGridItemEventArgs>(_view_OnSpecificationsDataBound);
            _view.OnSpecificationSelected += new EventHandler<IdeaSeedLinkButtonArgs>(_view_OnSpecificationSelected);
            _view.OnValuesDataBound += new EventHandler<IdeaSeedGridItemEventArgs>(_view_OnValuesDataBound);
            _view.UnloadView += new EventHandler(_view_UnloadView);
        }

        void _view_UnloadView(object sender, EventArgs e)
        {
           
        }

        void _view_OnValuesDataBound(object sender, IdeaSeedGridItemEventArgs e)
        {
            
        }

        void _view_OnSpecificationSelected(object sender, IdeaSeedLinkButtonArgs e)
        {
            
        }

        void _view_OnSpecificationsDataBound(object sender, IdeaSeedGridItemEventArgs e)
        {
            
        }

        void _view_OnGetValues(object sender, IdeaSeedGridArgs e)
        {
            GetValues(e);
        }

        void _view_OnGetSpecifications(object sender, IdeaSeedGridArgs e)
        {
            GetSpecifications(e);
        }

        void _view_LoadView(object sender, EventArgs e)
        {
            
        }

        void _view_InitView(object sender, EventArgs e)
        {
            
        }

        void GetSpecifications(IdeaSeedGridArgs e)
        {
            _view.SpecificationsResultSet = new ProductCategorySpecificationServices().GetByCategoryID(SecurityContextManager.Current.CurrentProductCategory.ID);
            _view.LoadSpecifications(e);
        }

        void GetValues(IdeaSeedGridArgs e)
        {
            _view.ValuesResultSet = new ProductCategorySpecificationServices().GetValuesByPropertyID(_view.SelectedPropertyID);
            _view.LoadValues(e);
        }
    }
}
