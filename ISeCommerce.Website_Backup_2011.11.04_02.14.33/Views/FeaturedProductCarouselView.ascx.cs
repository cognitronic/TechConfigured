using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI;
using System.Text;
using System.Web.UI.WebControls;
using ISeCommerce.Presenters.ViewInterfaces;
using ISeCommerce.Presenters;
using ISeCommerce.Core.Domain;
using ISeCommerce.Core.Security;
using IdeaSeed.Core;
using ISeCommerce.Web.Bases;
using ISeCommerce.Core;
using ISeCommerce.Services;

namespace ISeCommerce.Website.Views
{
    [PresenterType(typeof(FeaturedProductCarouselPresenter))]
    public partial class FeaturedProductCarouselView : BaseWebUserControl, IFeaturedProductsCarouselView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.SelfRegister(this);
            if (this.LoadView != null)
            {
                this.LoadView(this, EventArgs.Empty);
            }

            if (FeaturedProducts != null && FeaturedProducts.Count > 0)
            {
                var ul = new HtmlGenericControl("ul");
                foreach (var p in FeaturedProducts)
                {
                    ul.Controls.Add(BuildFeaturedProduct((Product)p));
                }
                phProducts.Controls.Add(ul);
            }
        }
        public new event EventHandler LoadView;

        #region IFeaturedProductsCarouselView Members

        public string ProductImage
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string ProductName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string DisplayedPrice
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public IList<Core.Domain.Interfaces.IProduct> FeaturedProducts
        {
            get;
            set;
        }

        public event EventHandler<IdeaSeedLinkButtonArgs> OnWishlistClick;

        public event EventHandler<IdeaSeedLinkButtonArgs> OnAddToCartClick;

        public event EventHandler OnProductClick;

        private Control BuildFeaturedProduct(Product p)
        {
            var lc = new LiteralControl();
            //var div = new HtmlGenericControl("div");
            //div.Attributes.Add("class", "addwish");
            //var wish = new LinkButton();
            //wish.ID = "lbAddToWish_" + p.ID.ToString();
            //wish.Text = "Wishlist";
            //wish.Attributes.Add("productid", p.ID.ToString());
            //wish.Click += new EventHandler(wish_Click);
            //div.Controls.Add(wish);

            var li = new HtmlGenericControl("li");
            var h6 = new HtmlGenericControl("h6");
            h6.Attributes.Add("class", "colr");
            h6.InnerText = p.Name;

            
            var img = new Image();
            img.Width = 158;
            img.Height = 160;
            if (!string.IsNullOrEmpty(p.DefaultImage))
            {
                img.ImageUrl = p.DefaultImage.Replace("~", "");
            }
            else
            {
                img.ImageUrl = SecurityContextManager.Current.BaseURL + ResourceStrings.DummyImagePath.Replace("~", "");
            }

            var productLink = new HyperLink();
            productLink.NavigateUrl = new ProductServices()
                .GetProductURL(p.Name, 
                p.ProductCategoryID,
                (IList<ProductCategory>)Cache[ResourceStrings.Cache_ProductCategoryList]);
            productLink.Controls.Add(img);

            li.Controls.Add(productLink);
            li.Controls.Add(h6);
            //li.Controls.Add(div);

            var par = new HtmlGenericControl("p");
            par.Attributes.Add("class", "price colr bold");
            par.InnerText = string.Format("{0:c}", p.ListPrice);
            li.Controls.Add(par);

            var cart = new LinkButton();
            cart.ID = "lbAddToCart_" + p.ID.ToString();
            cart.Attributes.Add("class", "adcart");
            cart.ToolTip = "Add To Cart";
            cart.Attributes.Add("productid", p.ID.ToString());
            cart.Attributes.Add("price", p.ListPrice.ToString());
            cart.Click += new EventHandler(cart_Click);
            li.Controls.Add(cart);
            return li;
            
        }

        void cart_Click(object sender, EventArgs e)
        {
            var lb = sender as LinkButton;
            var args = new IdeaSeedLinkButtonArgs();
            args.ID = Convert.ToInt32(lb.Attributes["productid"]);
            args.Name = lb.Attributes["price"];
            if (this.OnAddToCartClick != null)
            {
                this.OnAddToCartClick(this, args);
            }
        }

        void wish_Click(object sender, EventArgs e)
        {
            var lb = sender as LinkButton;
            var args = new IdeaSeedLinkButtonArgs();
            args.ID = Convert.ToInt32(lb.Attributes["productid"]);
            if (this.OnWishlistClick != null)
            {
                this.OnWishlistClick(this, args);
            }
        }

        public void NavigateTo(string url)
        {
            Response.Redirect(url);
        }

        #endregion
    }
}