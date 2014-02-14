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
    public class CategoryPropertiesPresenter : Presenter
    {
        ICategoryPropertiesView _view;

        public CategoryPropertiesPresenter(ICategoryPropertiesView view, ISessionProvider session)
            : base(view, session)
        {
            _view = base.GetView<ICategoryPropertiesView>();
            _view.LoadView += new EventHandler(_view_LoadView);
            _view.UnloadView += new EventHandler(_view_UnloadView);
            _view.SaveClick += new EventHandler<IdeaSeedLinkButtonArgs>(_view_SaveClick);
            _view.CancelClick += new EventHandler<IdeaSeedLinkButtonArgs>(_view_CancelClick);
            _view.DeleteClick += new EventHandler<IdeaSeedLinkButtonArgs>(_view_DeleteClick);
        }

        void _view_DeleteClick(object sender, IdeaSeedLinkButtonArgs e)
        {
            
        }

        void _view_CancelClick(object sender, IdeaSeedLinkButtonArgs e)
        {
            ClearControls();
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
            if (!IsInsert<ProductCategory>(SecurityContextManager.Current))
            {
                _view.LoadItem(GetCurrentItemReference<ProductCategory>(SecurityContextManager.Current));
            }
        }

        void SaveItem()
        {
            var item = new ProductCategory();
            bool isInsert = false;
            string url = "";
            if (!IsInsert<ProductCategory>(SecurityContextManager.Current))
            {
                item = GetCurrentItemReference<ProductCategory>(SecurityContextManager.Current);
            }
            else
            {
                isInsert = true;
                url = SecurityContextManager.Current.CurrentURL.Replace("New", "");
            }
            item.Name = _view.Name;
            item.Description = _view.Description;
            if(_view.ParentID != null)
                item.ParentID = _view.ParentID;
            item.SEODescription = _view.SEODescription;
            item.SEOKeywords = _view.SEOKeywords;
            item.SEOTitle = _view.SEOTitle;

            item.SortOrder = _view.SortOrder;
            new ProductCategoryServices().Save(item);
            if (isInsert)
                _view.NavigateTo(url + item.Name);
            else
                _view.LoadItem(item);
            _view.SavedSuccessfully = true;
        }

        void ClearControls()
        {
            _view.Name = "";
            _view.ParentID = null;
            _view.SortOrder = 0;
            _view.SEOKeywords = "";
            _view.SEODescription = "";
            _view.Description = "";
        }

        void NavigateBack()
        {
            _view.NavigateTo(SecurityContextManager.Current.PreviousURL);
        }
    }
}
