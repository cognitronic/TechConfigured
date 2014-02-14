using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ISeCommerce.AdminPresenters.ViewInterfaces;
using ISeCommerce.AdminPresenters;
using ISeCommerce.Core.Domain;
using ISeCommerce.Core.Domain.Interfaces;
using ISeCommerce.Core.Security;
using IdeaSeed.Core;
using ISeCommerce.AdminWeb.Bases;
using ISeCommerce.Core;
using Telerik.Web.UI;
using ISeCommerce.Services;

namespace ISeCommerce.AdminWebsite.Views
{
    [PresenterType(typeof(ProductImagesPresenter))]
    public partial class ProductImagesView : BaseWebUserControl, IProductImagesView
    {
        const int MaxTotalBytes = 1048576; // 1 MB
        int totalBytes;

        public bool? IsRadAsyncValid
        {
            get
            {
                if (Session["IsRadAsyncValid"] == null)
                {
                    Session["IsRadAsyncValid"] = true;
                }

                return Convert.ToBoolean(Session["IsRadAsyncValid"].ToString());
            }
            set
            {
                Session["IsRadAsyncValid"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            base.SelfRegister(this);
            if (this.LoadView != null)
            {
                this.LoadView(this, EventArgs.Empty);
            }

            if (this.OnGetItems != null)
            {
                var args = new IdeaSeedGridArgs();
                args.BindData = true;
                this.OnGetItems(this, args);
            }
        }

        protected void ItemNeedDataSource(object o, GridNeedDataSourceEventArgs e)
        {

        }

        protected void ItemCreated(object o, GridItemEventArgs e)
        {
            if (e.Item is GridEditableItem && e.Item.IsInEditMode)
            {
                RadAsyncUpload upload = ((GridEditableItem)e.Item)["Upload"].FindControl("AsyncUpload1") as RadAsyncUpload;
                TableCell cell = (TableCell)upload.Parent;

                CustomValidator validator = new CustomValidator();
                validator.ErrorMessage = "Please select file to be uploaded";
                validator.ClientValidationFunction = "validateRadUpload";
                validator.Display = ValidatorDisplay.Dynamic;
                cell.Controls.Add(validator);
            }
        }

        protected void ItemCommand(object o, GridCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case RadGrid.EditCommandName:
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "SetEditMode", "isEditMode = true;", true);
                    break;
                case RadGrid.InitInsertCommandName:
                    e.Canceled = true;
                    var i = new ProductImage();
                    i.Title = "";
                    i.Path = "";
                    i.ToolTip = "";
                    i.ID = 0;
                    e.Item.OwnerTableView.InsertItem(new ProductImage());
                    break;
                case RadGrid.UpdateCommandName:
                    var img = new ProductImageServices().GetByID(Convert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"].ToString()));
                    GridEditFormItem insertItem = e.Item as GridEditFormItem;
                    string imageName = (insertItem["Title"].FindControl("tbTitle") as RadTextBox).Text;
                    string tooltip = (insertItem["ToolTip"].FindControl("tbToolTip") as RadTextBox).Text;
                    string imagesize = (insertItem["ImageSizeTypeID"].FindControl("ddlImageSizeType") as ISeCommerce.AdminWeb.Controls.ImageSizeTypeDDL).SelectedValue;
                    bool isDefault = (insertItem["IsDefault"].FindControl("cbIsDefault") as IdeaSeed.Web.UI.CheckBox).Checked;
                    img.Title = imageName;
                    img.ToolTip = tooltip;
                    img.ImageSizeTypeID = Convert.ToInt16(imagesize);
                    img.IsDefault = isDefault;
                    new ProductImageServices().UpdateToNoDefault(img.ProductID);

                    new ProductImageServices().Save(img);

                    var p = new ProductServices().GetByID(img.ProductID);
                    p.DefaultImage = img.Path;
                    new ProductServices().Save(p);
                    break;
                case RadGrid.PerformInsertCommandName:
                    insertItem = e.Item as GridEditFormInsertItem;
                    imageName = (insertItem["Title"].FindControl("tbTitle") as RadTextBox).Text;
                    tooltip = (insertItem["ToolTip"].FindControl("tbToolTip") as RadTextBox).Text;
                    isDefault = (insertItem["IsDefault"].FindControl("cbIsDefault") as IdeaSeed.Web.UI.CheckBox).Checked;
                    imagesize = (insertItem["ImageSizeTypeID"].FindControl("ddlImageSizeType") as ISeCommerce.AdminWeb.Controls.ImageSizeTypeDDL).SelectedValue;
                    RadAsyncUpload radAsyncUpload = insertItem["Upload"].FindControl("AsyncUpload1") as RadAsyncUpload;
                    UploadedFile file = radAsyncUpload.UploadedFiles[0];
                    string filePath = SecurityContextManager.Current.CurrentProduct.Name + "_" +
                        DateTime.Now.Ticks.ToString() + "_" +
                        file.FileName;
                    file.SaveAs(Server.MapPath(ResourceStrings.ProductImagePath) + filePath, false);
                    img = new ProductImage();
                    img.Path = ResourceStrings.ProductImagePath + filePath;
                    img.Title = imageName;
                    img.ToolTip = tooltip;
                    img.ImageSizeTypeID = Convert.ToInt16(imagesize);
                    img.IsDefault = isDefault;
                    img.ProductID = SecurityContextManager.Current.CurrentProduct.ID;

                    new ProductImageServices().UpdateToNoDefault(img.ProductID);

                    new ProductImageServices().Save(img);

                    p = new ProductServices().GetByID(img.ProductID);
                    p.DefaultImage = img.Path;
                    new ProductServices().Save(p);

                    NavigateTo(SecurityContextManager.Current.CurrentURL);
                    break;
                case RadGrid.DeleteCommandName:
                    img = new ProductImageServices().GetByID(Convert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"].ToString()));
                    new ProductImageServices().Delete(img);
                    NavigateTo(SecurityContextManager.Current.CurrentURL);
                    break;
            }
        }

        public void RadAsyncUpload1_ValidatingFile(object sender, Telerik.Web.UI.Upload.ValidateFileEventArgs e)
        {
            if ((totalBytes < MaxTotalBytes) && (e.UploadedFile.ContentLength < MaxTotalBytes))
            {
                e.IsValid = true;
                totalBytes += e.UploadedFile.ContentLength;
                IsRadAsyncValid = true;
            }
            else
            {
                e.IsValid = false;
                IsRadAsyncValid = false;
            }
        }

        #region IBaseListView<IProductImage> Members

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

        public int CurrentPageIndex
        {
            get
            {
                return rgImages.CurrentPageIndex;
            }
            set
            {

            }
        }

        public void LoadResultSet(IdeaSeedGridArgs args)
        {
            if (ResultSet.Count > 0)
            {
                rgImages.DataSource = ResultSet;
            }
            else
            {
                rgImages.DataSource = new List<ProductImage>();
            }
            if (args.BindData)
                rgImages.DataBind();
        }

        public void NavigateTo(string url)
        {
            Response.Redirect(url);
        }

        public event EventHandler<IdeaSeedGridArgs> OnGetItems;

        public event EventHandler<IdeaSeedLinkButtonArgs> OnItemSelected;

        public event EventHandler<IdeaSeedGridItemEventArgs> OnItemsDataBound;

        public int PageSize
        {
            get
            {
                return rgImages.PageSize;
            }
            set
            {
                rgImages.PageSize = value;
            }
        }

        public void RebindGrid()
        {
            rgImages.PageSize = this.PageSize;
            rgImages.Rebind();
        }

        public IList<IProductImage> ResultSet
        {
            get;
            set;
        }

        public int VirtualItemCount
        {
            get;
            set;
        }

        #endregion

        #region IProductImage Members

        public new int ID
        {
            get;
            set;
        }

        public string Title
        {
            get;
            set;
        }

        public string Path
        {
            get;
            set;
        }

        public int ProductID
        {
            get;
            set;
        }

        public string ToolTip
        {
            get;
            set;
        }

        public bool IsDefault
        {
            get;
            set;
        }

        public int ImageSizeTypeID
        {
            get;
            set;
        }

        #endregion
    }
}