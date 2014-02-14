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
    [PresenterType(typeof(CategoryPropertiesPresenter))]
    public partial class CategoryPropertiesView : BaseWebUserControl, ICategoryPropertiesView
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

        protected void ProductsClicked(object o, EventArgs e)
        {
            
        }

        protected void SaveCategoryClicked(object o, EventArgs e)
        {
            var args = new IdeaSeedLinkButtonArgs();
            args.ID = Convert.ToInt32(((LinkButton)o).Attributes["itemid"]);
            args.Name = ((LinkButton)o).Attributes["itemname"];
            if (this.SaveClick != null)
                this.SaveClick(o, args);
            if (SavedSuccessfully)
                divSuccess.Visible = true;
        }

        protected void CancelClicked(object o, EventArgs e)
        {
            var args = new IdeaSeedLinkButtonArgs();
            if (this.CancelClick != null)
                this.CancelClick(o, args);
        }

        

        #region IBasePropertiesView<ProductCategory> Members
        
        public new event EventHandler LoadView;
        public new event EventHandler UnloadView;

        public void LoadItem(ProductCategory t)
        {
            Name = t.Name;
            ParentID = t.ParentID;
            Description = t.Description;
            SEODescription = t.SEODescription;
            SEOKeywords = t.SEOKeywords;
            SEOTitle = t.SEOTitle;
        }

        public void NavigateTo(string url)
        {
            Response.Redirect(url);
        }

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

        #endregion

        #region IProductCategory Members

        public event EventHandler<IdeaSeedLinkButtonArgs> SaveClick;

        public event EventHandler<IdeaSeedLinkButtonArgs> CancelClick;

        public event EventHandler<IdeaSeedLinkButtonArgs> DeleteClick;

        public new int ID
        {
            get;
            set;
        }

        public bool SavedSuccessfully
        {
            get;
            set;
        }

        public string Name
        {
            get
            {
                return tbName.Text;
            }
            set
            {
                tbName.Text = value;
            }
        }

        public string Description
        {
            get
            {
                return tbDescription.Text;
            }
            set
            {
                tbDescription.Text = value;
            }
        }

        public int? ParentID
        {
            get
            {
                int i = 0;
                if (int.TryParse(ddlParentCategory.SelectedValue, out i))
                    return i;
                return null;
            }
            set
            {
                if (value != null && value != 0)
                    ddlParentCategory.SelectedValue = value.ToString();
                else
                    ddlParentCategory.SelectedValue = "";
            }
        }

        public int SortOrder
        {
            get;
            set;
        }

        public string SEOKeywords
        {
            get
            {
                return tbSEOKeywords.Text;
            }
            set
            {
                tbSEOKeywords.Text = value;
            }
        }

        public string SEODescription
        {
            get
            {
                return tbSEODescription.Text;
            }
            set
            {
                tbSEODescription.Text = value;
            }
        }

        public string SEOTitle
        {
            get
            {
                return tbSEOTitle.Text;
            }
            set
            {
                tbSEOTitle.Text = value;
            }
        }

        public ProductCategory ParentCategory
        {
            get;
            set;
        }

        public IList<Core.Domain.Interfaces.IProduct> Products
        {
            get;
            set;
        }

        public IList<Core.Domain.Interfaces.IProductCategory> ChildCategories
        {
            get;
            set;
        }

        public IList<Core.Domain.Interfaces.IProductCategoryImage> Images
        {
            get;
            set;
        }

        public IList<Core.Domain.Interfaces.IProductCategorySpecificationProperty> Specifications
        {
            get;
            set;
        }

        #endregion

        
    }
}