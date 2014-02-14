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
    public class BannerDetailPresenter : Presenter
    {
        IBannerDetailView _view;

        public BannerDetailPresenter(IBannerDetailView view, ISessionProvider session)
            : base(view, session)
        {
            _view = base.GetView<IBannerDetailView>();
            _view.LoadView += new EventHandler(_view_LoadView);
            _view.UnloadView += new EventHandler(_view_UnloadView);
            _view.SaveClick += new EventHandler<IdeaSeedLinkButtonArgs>(_view_SaveClick);
            _view.CancelClick += new EventHandler<IdeaSeedLinkButtonArgs>(_view_CancelClick);
            _view.DeleteClick += new EventHandler<IdeaSeedLinkButtonArgs>(_view_DeleteClick);
        }

        void _view_DeleteClick(object sender, IdeaSeedLinkButtonArgs e)
        {
            new BannerImageServices().Delete(new BannerImageServices().GetByID(e.ID));
            _view.NavigateTo(SecurityContextManager.Current.PreviousURL);
        }

        void _view_CancelClick(object sender, IdeaSeedLinkButtonArgs e)
        {
            ClearControls();
            _view.NavigateTo(SecurityContextManager.Current.PreviousURL);
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
            _view.ViewTitle = "Banner Details";
            if (!IsInsert<BannerImage>(SecurityContextManager.Current))
            {
                _view.LoadItem(GetCurrentItemReference<BannerImage>(SecurityContextManager.Current));
            }
        }

        void SaveItem()
        {
            var item = new BannerImage();
            bool isInsert = false;
            string url = "";
            if (!IsInsert<BannerImage>(SecurityContextManager.Current))
            {
                item = GetCurrentItemReference<BannerImage>(SecurityContextManager.Current);
            }
            item.Path = _view.Path;
            item.Title = _view.Title;
            item.ToolTip = _view.ToolTip;
            new BannerImageServices().Save(item);
            if (isInsert)
                _view.NavigateTo(url + item.ID.ToString());
            else
                _view.LoadItem(item);
        }

        void ClearControls()
        {
            _view.Path = "";
            _view.Title = "";
            _view.ToolTip = "";
        }

        void NavigateBack()
        {
            _view.NavigateTo(SecurityContextManager.Current.PreviousURL);
        }
    }
}
