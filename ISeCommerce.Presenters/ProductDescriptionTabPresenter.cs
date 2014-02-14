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
    public class ProductDescriptionTabPresenter : Presenter
    {
        IProductDescriptionTabView _view;

        public ProductDescriptionTabPresenter(IProductDescriptionTabView view, ISessionProvider session)
            : base(view, session)
        {
            _view = base.GetView<IProductDescriptionTabView>();
            _view.InitView += new EventHandler(_view_InitView);
            _view.LoadView += new EventHandler(_view_LoadView);
            _view.UnloadView += new EventHandler(_view_UnloadView);
        }

        void _view_UnloadView(object sender, EventArgs e)
        {
           
        }

        void _view_LoadView(object sender, EventArgs e)
        {
            _view.ProductDescription = SecurityContextManager.Current.CurrentProduct.FullDescription;
            var sb = new StringBuilder();
            foreach(var spec in SecurityContextManager.Current.CurrentProduct.Specifications)
            {
                sb.Append("<ul>");
                sb.Append("<li class='bold title'>");
                sb.Append(spec.SpecificationValue.SpecificationProperty.Name);
                sb.Append("</li>");
                sb.Append("<li class='bold desc'>");
                sb.Append(spec.SpecificationValue.Value);
                sb.Append("</li>");
                sb.Append("</ul>");

            }
            _view.AdditionalInformation = sb.ToString();
        }

        void _view_InitView(object sender, EventArgs e)
        {
            
        }
    }
}
