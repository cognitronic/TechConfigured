using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ISeCommerce.Presenters.ViewInterfaces;
using ISeCommerce.Presenters;
using ISeCommerce.Core.Domain;
using ISeCommerce.Core.Domain.Interfaces;
using ISeCommerce.Core.Security;
using IdeaSeed.Core;
using ISeCommerce.Web.Bases;
using ISeCommerce.Core;
using System.Web.UI.HtmlControls;
using System.Text;

namespace ISeCommerce.Website.Views
{
    [PresenterType(typeof(ProductDetailImagesPresenter))]
    public partial class ProductDetailImagesView : BaseWebUserControl, IProductDetailImagesView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.SelfRegister(this);
            if (this.LoadView != null)
            {
                this.LoadView(this, EventArgs.Empty);
            }
            BuildProductImagesLayout();
        }

        protected void AddToCartClicked(object o, EventArgs e)
        {
            var args = new IdeaSeedLinkButtonArgs();
            args.ID = SecurityContextManager.Current.CurrentProduct.ID;
            if (!string.IsNullOrEmpty(SecurityContextManager.Current.CurrentProduct.ListPrice.ToString()))
            {
                args.Name = SecurityContextManager.Current.CurrentProduct.ListPrice.ToString();
            }
            else
            {
                args.Name = "0";
            }
            if (this.AddToCart != null)
            {
                this.AddToCart(o, args);
            }
        }

        protected void AddToWishlistClicked(object o, EventArgs e)
        {
            if (this.AddToWishlist != null)
            {
                this.AddToWishlist(o, e);
            }
        }

        public new event EventHandler LoadView;
        public event EventHandler<IdeaSeedLinkButtonArgs> AddToCart;
        public event EventHandler AddToWishlist;

        #region IProductDetailImagesView Members

        public int QtyToAdd
        {
            get
            {
                int i = 0;
                if (int.TryParse(qty.Text, out i))
                    return i;
                return i;
            }
            set
            {
                if (value != null && value != 0)
                    qty.Text = value.ToString();
                else
                    qty.Text = "";
            }
        }

        public void NavigateTo(string url)
        {
            Response.Redirect(url);
        }

        public IProduct SelectedProduct
        {
            get;
            set;
        }

        private void BuildProductImagesLayout()
        {
            lblListPrice.Text = string.Format("{0:c}", SelectedProduct.ListPrice);
            lblShortDescription.Text = SelectedProduct.ShortDescription;

            var slider = new HtmlGenericControl("div");
            slider.Attributes.Add("id", "slider2");
            slider.InnerHtml = BuildBigThumbMarkkup();
            phSlider.Controls.Add(slider);

            var tiny = new HtmlGenericControl("div");
            tiny.Attributes.Add("class", "anyClass");
            tiny.Attributes.Add("id", "paginate-slider2");
            tiny.InnerHtml = BuildSmallSliderMarkup();
            divSmallSlider.Controls.Add(tiny);
            lblProductTitle.Text = ViewTitle;
        }

        private string BuildBigThumbMarkkup()
        {
            var sb = new StringBuilder();
            foreach (var image in SelectedProduct.Images)
            {
                sb.Append("<div class='contentdiv'>");
                sb.Append("<img src='");
                sb.Append(image.Path.Replace("~",""));
                sb.Append("' alt='");
                sb.Append(image.Title);
                sb.Append("' />");
                sb.Append("<a rel='example_group' href='");
                sb.Append(image.Path.Replace("~", ""));
                sb.Append("' title='");
                sb.Append(image.Title);
                sb.Append("' class='zoom'>&nbsp;</a></div>");
            }
            return sb.ToString();
        }

        private string BuildSmallSliderMarkup()
        {
            var sb = new StringBuilder();
            sb.Append("<ul>");
            foreach (var image in SelectedProduct.Images)
            {
                sb.Append("<li><a href='#' class='toc'><img src='");
                sb.Append(image.Path.Replace("~", ""));
                sb.Append("' alt='");
                //sb.Append(image.Title);
                sb.Append("' /></a></li>");
            }
            sb.Append("</ul>");

            return sb.ToString();
        }

        #endregion
    }
}