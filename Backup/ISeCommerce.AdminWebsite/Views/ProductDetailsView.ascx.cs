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
using IdeaSeed.Web;
using ISeCommerce.AdminWeb.Bases;
using System.Configuration;
using ISeCommerce.Core;
using Telerik.Web.UI;
using ISeCommerce.Services;
using System.Security.Principal;
using System.Runtime.InteropServices;

namespace ISeCommerce.AdminWebsite.Views
{
    [PresenterType(typeof(ProductDetailsPresenter))]
    public partial class ProductDetailsView : BaseWebUserControl, IProductDetailsView
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

        #region IProductDetailsView Members

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

        public int ProductCategoryID
        {
            get
            {
                int i = 0;
                if (int.TryParse(ddlCategory.SelectedValue, out i))
                    return i;
                return i;
            }
            set
            {
                if (value != null && value != 0)
                    ddlCategory.SelectedValue = value.ToString();
                else
                    ddlCategory.SelectedValue = "";
            }
        }

        public bool IsActive
        {
            get
            {
                return cbIsActive.Checked;
            }
            set
            {
                cbIsActive.Checked = value;
            }
        }

        public bool IsFeatured
        {
            get
            {
                return cbIsFeatured.Checked;
            }
            set
            {
                cbIsFeatured.Checked = value;
            }
        }

        public string ManufacturerPartNumber
        {
            get
            {
                return tbManufacturerPartNumber.Text;
            }
            set
            {
                tbManufacturerPartNumber.Text = value;
            }
        }

        public string SKU
        {
            get
            {
                return tbSKU.Text;
            }
            set
            {
                tbSKU.Text = value;
            }
        }

        public string ShortDescription
        {
            get
            {
                return tbShortDescription.Text;
            }
            set
            {
                tbShortDescription.Text = value;
            }
        }

        public string FullDescription
        {
            get
            {
                return tbFullDescription.Text;
            }
            set
            {
                tbFullDescription.Text = value;
            }
        }

        public bool SavedSuccessfully
        {
            get;
            set;
        }

        public int ManufacturerID
        {
            get
            {
                int i = 0;
                if (int.TryParse(ddlManufacturer.SelectedValue, out i))
                    return i;
                return i;
            }
            set
            {
                if (value != null && value != 0)
                    ddlManufacturer.SelectedValue = value.ToString();
                else
                    ddlManufacturer.SelectedValue = "";
            }
        }

        public string Make
        {
            get
            {
                return tbMake.Text;
            }
            set
            {
                tbMake.Text = value;
            }
        }

        public string Model
        {
            get
            {
                return tbModel.Text;
            }
            set
            {
                tbModel.Text = value;
            }
        }

        #endregion

        #region IBasePropertiesView<Product> Members

        public void LoadItem(Product t)
        {
            this.IsActive = t.IsActive;
            this.FullDescription = t.FullDescription;
            this.IsFeatured = t.IsFeatured;
            this.Make = t.Make;
            this.ManufacturerID = t.ManufacturerID;
            this.ManufacturerPartNumber = t.ManufacturerPartNumber;
            this.MarkedForDeletion = t.MarkedForDeletion;
            this.Model = t.Model;
            this.Name = t.Name;
            this.ProductCategoryID = t.ProductCategoryID;
            this.ShortDescription = t.ShortDescription;
            this.SKU = t.SKU;
        }

        public void NavigateTo(string url)
        {
            Response.Redirect(url);
        }

        #endregion

        #region IBaseAuditable Members

        public int ChangedBy
        {
            get;
            set;
        }

        public DateTime DateCreated
        {
            get;
            set;
        }

        public int EnteredBy
        {
            get;
            set;
        }

        public DateTime LastUpdated
        {
            get;
            set;
        }

        public bool MarkedForDeletion
        {
            get;
            set;
        }

        #endregion

        #region IPropertiesActions Members

        public event EventHandler<IdeaSeedLinkButtonArgs> SaveClick;

        public event EventHandler<IdeaSeedLinkButtonArgs> CancelClick;

        public event EventHandler<IdeaSeedLinkButtonArgs> DeleteClick;

        #endregion

        public void RestartAppPool()
        {
            IntPtr token = IntPtr.Zero;
            bool isSuccess = LogonUser("dschreiber", "datapath", "Deathpo3ms",
            LOGON32_LOGON_NEW_CREDENTIALS,
            LOGON32_PROVIDER_DEFAULT, ref token);
            using (WindowsImpersonationContext person = new WindowsIdentity(token).Impersonate())
            {
                ApplicationPoolRecycle.RecycleApplicationPool(ConfigurationManager.AppSettings["PUBLICAPPPOOL"]);
                person.Undo();
            }
        }

         
    }
}