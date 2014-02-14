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
    public class ProductShippingPresenter : Presenter
    {
        IProductShippingView _view;

        public ProductShippingPresenter(IProductShippingView view, ISessionProvider session)
            : base(view, session)
        {
            _view = base.GetView<IProductShippingView>();
            _view.LoadView += new EventHandler(_view_LoadView);
            _view.UnloadView += new EventHandler(_view_UnloadView);
            _view.SaveClick += new EventHandler<IdeaSeedLinkButtonArgs>(_view_SaveClick);
            _view.CancelClick += new EventHandler<IdeaSeedLinkButtonArgs>(_view_CancelClick);
            _view.DeleteClick += new EventHandler<IdeaSeedLinkButtonArgs>(_view_DeleteClick);
        }

        void _view_DeleteClick(object sender, IdeaSeedLinkButtonArgs e)
        {
            new ProductServices().Delete(new ProductServices().GetByID(e.ID));
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
            _view.ViewTitle = "Shipping";
            if (!IsInsert<Product>(SecurityContextManager.Current))
            {
                _view.LoadItem(GetCurrentItemReference<Product>(SecurityContextManager.Current));
            }
        }

        void SaveItem()
        {
            var item = new Product();
            bool isInsert = false;
            string url = "";
            if (!IsInsert<Product>(SecurityContextManager.Current))
            {
                item = GetCurrentItemReference<Product>(SecurityContextManager.Current);
            }
            else
            {
                isInsert = true;
                item.EnteredBy = SecurityContextManager.Current.CurrentUser.ID;
                item.DateCreated = DateTime.Now;
                url = SecurityContextManager.Current.CurrentURL.Replace("New", "");
            }
            item.ChangedBy = SecurityContextManager.Current.CurrentUser.ID;
            item.LastUpdated = DateTime.Now;
            item.Weight = _view.Weight;
            item.Height = _view.Height;
            item.Length = _view.Length;
            item.Width = _view.Width;
            new ProductServices().Save(item);
            if (isInsert)
                _view.NavigateTo(url + item.ID.ToString());
            else
                _view.LoadItem(item);
            _view.SavedSuccessfully = true;
        }

        void ClearControls()
        {
            _view.Weight = 0;
            _view.Width = 0;
            _view.Length = 0;
            _view.Height = 0;
        }

        void NavigateBack()
        {
            _view.NavigateTo(SecurityContextManager.Current.PreviousURL);
        }
    }
}
