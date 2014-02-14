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
    public class UserListPresenter : Presenter
    {
        IUserListView _view;

        public UserListPresenter(IUserListView view, ISessionProvider session)
            : base(view, session)
        {
            _view = base.GetView<IUserListView>();
            _view.InitView += new EventHandler(_view_InitView);
            _view.LoadView += new EventHandler(_view_LoadView);
            _view.UnloadView += new EventHandler(_view_UnloadView);
            _view.OnGetItems += new EventHandler<IdeaSeedGridArgs>(_view_OnGetItems);
            _view.OnItemsDataBound += new EventHandler<IdeaSeedGridItemEventArgs>(_view_OnItemsDataBound);
            _view.OnItemSelected += new EventHandler<IdeaSeedLinkButtonArgs>(_view_OnItemSelected);
        }

        void _view_OnItemSelected(object sender, IdeaSeedLinkButtonArgs e)
        {
            if (!string.IsNullOrEmpty(e.Name))
                _view.NavigateTo(SecurityContextManager.Current.CurrentURL + "/" + e.ID.ToString());
        }

        void _view_OnItemsDataBound(object sender, IdeaSeedGridItemEventArgs e)
        {
            
        }

        void _view_OnGetItems(object sender, IdeaSeedGridArgs e)
        {
            GetItemResults(e);
        }

        void _view_UnloadView(object sender, EventArgs e)
        {
            if (SessionManager.Current != null)
                SessionManager.Current[ResourceStrings.Session_CurrentPageSize] = _view.PageSize;
        }

        void _view_LoadView(object sender, EventArgs e)
        {
            
        }

        void _view_InitView(object sender, EventArgs e)
        {
            if (SessionManager.Current[ResourceStrings.Session_CurrentPageSize] != null)
                _view.PageSize = Convert.ToInt16(SessionManager.Current[ResourceStrings.Session_CurrentPageSize]);
        }

        void GetItemResults(IdeaSeedGridArgs e)
        {
            _view.ResultSet = _view.UserList;
            _view.LoadResultSet(e);
        }
    }
}
