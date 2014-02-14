using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ISeCommerce.AdminPresenters.ViewInterfaces;
using ISeCommerce.AdminPresenters;
using ISeCommerce.Core.Domain;
using ISeCommerce.Core.Security;
using IdeaSeed.Core;
using ISeCommerce.AdminWeb.Bases;
using ISeCommerce.Core;
using Telerik.Web.UI;
using ISeCommerce.Services;

namespace ISeCommerce.AdminWebsite.Views
{
    [PresenterType(typeof(ProductShippingPresenter))]
    public partial class ProductShippingView : BaseWebUserControl, IProductShippingView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            divSuccess.Visible = false;
            divError.Visible = false;
            base.SelfRegister(this);
            if (this.LoadView != null)
            {
                this.LoadView(this, EventArgs.Empty);
            }
        }

        protected void SaveClicked(object o, EventArgs e)
        {
            var args = new IdeaSeedLinkButtonArgs();
            args.ID = Convert.ToInt32(((LinkButton)o).Attributes["itemid"]);
            args.Name = ((LinkButton)o).Attributes["itemname"];
            if (this.SaveClick != null)
            {
                this.SaveClick(o, args);
            }
            if (SavedSuccessfully)
                divSuccess.Visible = true;
        }

        protected void CancelClicked(object o, EventArgs e)
        {
            var args = new IdeaSeedLinkButtonArgs();
            if (this.CancelClick != null)
            {
                this.CancelClick(o, args);
            }
        }

        protected void DeleteClicked(object o, EventArgs e)
        {
            var args = new IdeaSeedLinkButtonArgs();
            args.ID = Convert.ToInt32(((LinkButton)o).Attributes["itemid"]);
            args.Name = ((LinkButton)o).Attributes["itemname"];
            if (this.DeleteClick != null)
            {
                this.DeleteClick(o, args);
            }
        }



        #region IProductShippingView Members

        public new event EventHandler LoadView;

        public new event EventHandler UnloadView;

        public string ViewTitle
        {
            get
            {
                return lblViewTitle.Text;
            }
            set
            {
                lblViewTitle.Text = value;
            }
        }

        public bool SavedSuccessfully
        {
            get;
            set;
        }

        public decimal Weight
        {
            get
            {
                decimal i = 0;
                if (decimal.TryParse(tbWeight.Text, out i))
                    return i;
                return i;
            }
            set
            {
                if (value != null && value != 0)
                    tbWeight.Text = value.ToString();
                else
                    tbWeight.Text = "";
            }
        }

        public int Height
        {
            get
            {
                int i = 0;
                if (int.TryParse(tbHeight.Text, out i))
                    return i;
                return i;
            }
            set
            {
                if (value != null && value != 0)
                    tbHeight.Text = value.ToString();
                else
                    tbHeight.Text = "";
            }
        }

        public int Length
        {
            get
            {
                int i = 0;
                if (int.TryParse(tbLength.Text, out i))
                    return i;
                return i;
            }
            set
            {
                if (value != null && value != 0)
                    tbLength.Text = value.ToString();
                else
                    tbLength.Text = "";
            }
        }

        public int Width
        {
            get
            {
                int i = 0;
                if (int.TryParse(tbWidth.Text, out i))
                    return i;
                return i;
            }
            set
            {
                if (value != null && value != 0)
                    tbWidth.Text = value.ToString();
                else
                    tbWidth.Text = "";
            }
        }

        #endregion

        #region IBasePropertiesView<Product> Members

        public void LoadItem(Product t)
        {
            tbHeight.Text = t.Height.ToString();
            tbWeight.Text = t.Weight.ToString();
            tbWidth.Text = t.Width.ToString();
            tbLength.Text = t.Length.ToString();
        }

        public void NavigateTo(string url)
        {
            NavigateTo(url);
        }

        #endregion

        #region IPropertiesActions Members

        public event EventHandler<IdeaSeedLinkButtonArgs> SaveClick;

        public event EventHandler<IdeaSeedLinkButtonArgs> CancelClick;

        public event EventHandler<IdeaSeedLinkButtonArgs> DeleteClick;

        #endregion
    }
}