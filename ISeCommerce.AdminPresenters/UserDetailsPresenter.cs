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
    public class UserDetailsPresenter : Presenter
    {
        IUserDetailsView _view;

        public UserDetailsPresenter(IUserDetailsView view, ISessionProvider session)
            : base(view, session)
        {
            _view = base.GetView<IUserDetailsView>();
            _view.LoadView += new EventHandler(_view_LoadView);
            _view.UnloadView += new EventHandler(_view_UnloadView);
            _view.SaveClick += new EventHandler<IdeaSeedLinkButtonArgs>(_view_SaveClick);
            _view.CancelClick += new EventHandler<IdeaSeedLinkButtonArgs>(_view_CancelClick);
            _view.DeleteClick += new EventHandler<IdeaSeedLinkButtonArgs>(_view_DeleteClick);
        }

        void _view_DeleteClick(object sender, IdeaSeedLinkButtonArgs e)
        {
            new UserServices().Delete(new UserServices().GetByID(e.ID));
            _view.NavigateTo(SecurityContextManager.Current.PreviousURL);
        }

        void _view_CancelClick(object sender, IdeaSeedLinkButtonArgs e)
        {
            ClearControls();
            _view.NavigateTo(SecurityContextManager.Current.CurrentURL);
        }

        void _view_SaveClick(object sender, IdeaSeedLinkButtonArgs e)
        {
            SaveItem();
        }

        void _view_UnloadView(object sender, EventArgs e)
        {

        }

        void _view_LoadView(object sender, EventArgs e)
        {
            _view.ViewTitle = "Details";
            if (!IsInsert<User>(SecurityContextManager.Current))
            {
                _view.LoadItem(GetCurrentItemReference<User>(SecurityContextManager.Current));
            }
            else
            {
                _view.IsActive = true;
            }
        }

        void SaveItem()
        {
            var item = new User();
            bool isInsert = false;
            string url = "";
            if (!IsInsert<User>(SecurityContextManager.Current))
            {
                item = GetCurrentItemReference<User>(SecurityContextManager.Current);
                if (!string.IsNullOrEmpty(_view.Password))
                {
                    item.Password = SecurityUtils.GetMd5Hash(_view.Password);
                    item.PasswordLastChangedDate = DateTime.Now;
                }
            }
            else
            {
                isInsert = true;
                item.EnteredBy = SecurityContextManager.Current.CurrentUser.ID;
                item.DateCreated = DateTime.Now;
                url = SecurityContextManager.Current.CurrentURL.Replace("New", "");
                item.PasswordLastChangedDate = DateTime.Now;
                item.LastLoginDate = DateTime.Now;
                item.UserName = _view.UserName;
                item.Password = SecurityUtils.GetMd5Hash(_view.Password);
                item.PasswordLastChangedDate = DateTime.Now;
            }
            item.Name = _view.Name;
            item.IsActive = _view.IsActive;
            item.Email = _view.Email;
            item.ChangedBy = SecurityContextManager.Current.CurrentUser.ID;
            item.LastUpdated = DateTime.Now;
            item.MarkedForDeletion = _view.MarkedForDeletion;
            item.FirstName = _view.FirstName;
            item.LastName = _view.LastName;
            item.PasswordAnswer = _view.PasswordAnswer;
            item.PasswordQuestion = _view.PasswordQuestion;
            new UserServices().Save(item);
            if (isInsert)
                _view.NavigateTo(url + item.ID.ToString());
            else
                _view.LoadItem(item);
        }

        void ClearControls()
        {
            _view.Name = "";
            _view.Email = "";
            _view.FirstName = "";
            _view.LastName = "";
            _view.PasswordAnswer = "";
            _view.PasswordQuestion = "";
        }

        void NavigateBack()
        {
            _view.NavigateTo(SecurityContextManager.Current.PreviousURL);
        }
    }
}
