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
    [PresenterType(typeof(ProductCategoryImagesPresenter))]
    public partial class ProductCategoryImagesView : BaseWebUserControl, IProductCategoryImagesView
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
                    //e.Canceled = true;
                    //var i = new ProductCategoryImage();
                    //i.Title = "";
                    //i.Path = "";
                    //i.ToolTip = "";
                    //i.ID = 1;
                    //e.Item.OwnerTableView.InsertItem(i);
                    break;
                case RadGrid.UpdateCommandName:
                    var img = new ProductCategoryImageServices().GetByID(Convert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"].ToString()));
                    GridEditFormItem insertItem = e.Item as GridEditFormItem;
                    string imageName = (insertItem["Title"].FindControl("tbTitle") as RadTextBox).Text;
                    string tooltip = (insertItem["ToolTip"].FindControl("tbToolTip") as RadTextBox).Text;
                    string imagesize = (insertItem["ImageSizeTypeID"].FindControl("ddlImageSizeType") as ISeCommerce.AdminWeb.Controls.ImageSizeTypeDDL).SelectedValue;
                    img.Title = imageName;
                    img.ToolTip = tooltip;
                    img.ImageSizeTypeID = Convert.ToInt16(imagesize);
                    new ProductCategoryImageServices().Save(img);
                    break;
                case RadGrid.PerformInsertCommandName:
                    if (e.Item is GridEditableItem)
                    {
                        insertItem = e.Item as GridEditFormInsertItem;
                        imageName = (insertItem["Title"].FindControl("tbTitle") as RadTextBox).Text;
                        tooltip = (insertItem["ToolTip"].FindControl("tbToolTip") as RadTextBox).Text;
                        imagesize = (insertItem["ImageSizeTypeID"].FindControl("ddlImageSizeType") as ISeCommerce.AdminWeb.Controls.ImageSizeTypeDDL).SelectedValue;
                        RadAsyncUpload radAsyncUpload = insertItem["Upload"].FindControl("AsyncUpload1") as RadAsyncUpload;
                        UploadedFile file = radAsyncUpload.UploadedFiles[0];
                        string filePath = SecurityContextManager.Current.CurrentProductCategory.Name + "_" +
                            DateTime.Now.Ticks.ToString() + "_" +
                            file.FileName;
                        file.SaveAs(Server.MapPath(ResourceStrings.ProductCategoryImagePath) + filePath, false);
                        img = new ProductCategoryImage();
                        img.Path = ResourceStrings.ProductCategoryImagePath + filePath;
                        img.Title = imageName;
                        img.ToolTip = tooltip;
                        img.ImageSizeTypeID = Convert.ToInt16(imagesize);
                        img.ProductCategoryID = SecurityContextManager.Current.CurrentProductCategory.ID;
                        new ProductCategoryImageServices().Save(img);
                        NavigateTo(SecurityContextManager.Current.CurrentURL);
                    }
                    break;
                case RadGrid.DeleteCommandName:
                    img = new ProductCategoryImageServices().GetByID(Convert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"].ToString()));
                    new ProductCategoryImageServices().Delete(img);
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

        #region IBaseListView<ProductCategoryImage> Members

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
                rgImages.DataSource = ResultSet;
            else
                rgImages.DataSource = new List<ProductCategoryImage>();
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

        public IList<IProductCategoryImage> ResultSet
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

        #region IProductCategoryImage Members

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

        public int ProductCategoryID
        {
            get;
            set;
        }

        public int ImageSizeTypeID
        {
            get;
            set;
        }

        public string ToolTip
        {
            get;
            set;
        }

        #endregion

        private void LoadCategoryImages(ProductCategory cat, bool bindData)
        {
            if (cat.Images.Count < 1)
            {
                cat.Images.Add(new ProductCategoryImage());
            }
            rgImages.DataSource = cat.Images;
            if (bindData)
            {
                rgImages.DataBind();
            }
        }
    }
}