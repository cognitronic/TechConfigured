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
            if (SecurityContextManager.Current.CurrentItem.ItemReference is ProductCategory || SecurityContextManager.Current.CurrentItem.ItemReference is Product)
            {
                var appview = new PageViewServices().GetPageApplicationViewsByPageIDApplicationViewID(SecurityContextManager.Current.CurrentPage.ID, 5);
                var links = ISeCommerce.Services.Utils.JSONSerializationHelper.Deserialize<List<QuickLink>>(appview.ViewProperties);
                _view.QuickLinks = links;
                _view.MessageHTML = BuildMessageList();
            }
        }

        void _view_InitView(object sender, EventArgs e)
        {
            
        }

        private string BuildMessageList()
        {
            if (SecurityContextManager.Current.CurrentItem.ItemReference is Product)
            {
                bool isValid = true;
                var sb = new StringBuilder();
                var p = (Product)SecurityContextManager.Current.CurrentItem.ItemReference;
                sb.Append("<br /><ul class='sideview'>");
                if (string.IsNullOrEmpty(p.DefaultImage))
                {
                    sb.Append("<li>No Default Picture.</li>");
                    isValid = false;
                }
                if (p.Weight == null)
                {
                    sb.Append("<li>Enter Shipping Weight.</li>");
                    isValid = false;
                }
                sb.Append("</ul>");
                if (!isValid)
                {
                    p.IsActive = false;
                    new ProductServices().Save(p);
                }
                return sb.ToString();
            }
            return "";

        }
    }
}
