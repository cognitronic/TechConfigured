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
    public class ProductBannerPresenter : Presenter
    {
        IProductBannerView _view;

        public ProductBannerPresenter(IProductBannerView view, ISessionProvider session)
            : base(view, session)
        {
            _view = base.GetView<IProductBannerView>();
            _view.InitView += new EventHandler(_view_InitView);
            _view.LoadView += new EventHandler(_view_LoadView);
            _view.UnloadView += new EventHandler(_view_UnloadView);
        }

        void _view_UnloadView(object sender, EventArgs e)
        {
           
        }

        void _view_LoadView(object sender, EventArgs e)
        {
            var sb = new StringBuilder();
            sb.Append("<ul>");
            var list = new ProductCategoryImageServices()
                .GetProductCategoryImages(SecurityContextManager.Current
                .CurrentProductCategory
                .ID);
            foreach (var item in list)
            {
                sb.Append("<li><img src='");
                sb.Append(item.Path);
                sb.Append("' alt='' /></li>");
            }
            sb.Append("</ul>");
            _view.BannerHTML = sb.ToString();
            _view.ViewTitle = SecurityContextManager.Current.CurrentItem.Name;
        }

        void _view_InitView(object sender, EventArgs e)
        {
            
        }
    }
}
