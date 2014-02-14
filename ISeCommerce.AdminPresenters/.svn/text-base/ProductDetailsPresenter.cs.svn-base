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
    public class ProductDetailsPresenter : Presenter
    {
        IProductDetailsView _view;

        public ProductDetailsPresenter(IProductDetailsView view, ISessionProvider session)
            : base(view, session)
        {
            _view = base.GetView<IProductDetailsView>();
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
            _view.ViewTitle = "Details";
            if (!IsInsert<Product>(SecurityContextManager.Current))
            {
                _view.LoadItem(GetCurrentItemReference<Product>(SecurityContextManager.Current));
            }
            else
            {
                _view.IsActive = true;
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
            item.Name = _view.Name;
            item.IsActive = _view.IsActive;
            item.ProductCategoryID = _view.ProductCategoryID;
            item.ChangedBy = SecurityContextManager.Current.CurrentUser.ID;
            item.LastUpdated = DateTime.Now;
            item.MarkedForDeletion = _view.MarkedForDeletion;
            item.IsFeatured = _view.IsFeatured;
            item.Make = _view.Make;
            item.Model = _view.Model;
            item.ManufacturerID = _view.ManufacturerID;
            item.ManufacturerPartNumber = _view.ManufacturerPartNumber;
            item.ShortDescription = _view.ShortDescription;
            item.FullDescription = _view.FullDescription;
            item.SKU = _view.SKU;
            new ProductServices().Save(item);
            if (isInsert)
            {
                _view.RestartAppPool();
                _view.SavedSuccessfully = true;
                _view.NavigateTo(url + item.ID.ToString());
            }
            else
                _view.LoadItem(item);
            _view.SavedSuccessfully = true;
        }

        void ClearControls()
        {
            _view.Name = "";
            _view.Model = "";
            _view.ManufacturerID = 0;
            _view.ProductCategoryID = 0;
            _view.ManufacturerPartNumber = "";
            _view.SKU = "";
            _view.ShortDescription = "";
            _view.FullDescription = "";
            _view.Make = "";
        }

        void NavigateBack()
        {
            _view.NavigateTo(SecurityContextManager.Current.PreviousURL);
        }
    }
}
