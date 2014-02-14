using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ISeCommerce.Presenters.ViewInterfaces;
using ISeCommerce.Presenters;
using ISeCommerce.Core.Domain;
using ISeCommerce.Core.Security;
using IdeaSeed.Core;
using ISeCommerce.Web.Bases;
using System.Text;
using ISeCommerce.Core;
using ISeCommerce.Services;
using ISeCommerce.Core.Domain.Interfaces;
using System.Web.UI.HtmlControls;
using ISeCommerce.Web.Controls;

namespace ISeCommerce.Website.Views
{
    [PresenterType(typeof(CategoryWidgetPresenter))]
    public partial class CategoryWidgetView : BaseWebUserControl, ICategoryWidgetView
    {
        List<string> specVals = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            base.SelfRegister(this);
            if (this.LoadView != null)
            {
                this.LoadView(this, EventArgs.Empty);
            }
            LoadSubCategories();
        }

        public new event EventHandler LoadView;

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

        #region ICategoryWidgetView Members

        public IList<IProductCategory> ChildCategories
        {
            get;
            set;
        }

        public void LoadSubCategories()
        {
            if (ChildCategories != null && ChildCategories.Count > 0)
            {
                var sb = new StringBuilder();
                sb.Append("<ul>");
                foreach (var cat in ChildCategories)
                {
                    sb.Append("<li><a class='menuheader' href='");
                    sb.Append(SecurityContextManager.Current.CurrentURL);
                    sb.Append("/");
                    sb.Append(cat.Name.Replace(" ", "-"));
                    sb.Append("'>");
                    sb.Append(cat.Name);
                    sb.Append("</a></li>");
                }
                sb.Append("</ul>");
                divSubCats.InnerHtml = sb.ToString();
            }
            else if(SecurityContextManager.Current.CurrentProduct == null || SecurityContextManager.Current.CurrentProduct.ID == 0)
            {
                this.ViewTitle = "Filters";
                bool hasFilters = false;
                foreach (var spec in new ProductCategorySpecificationServices().GetByCategoryID(SecurityContextManager.Current.CurrentProductCategory.ID))
                {
                    if (spec.CanFilterBy)
                    {
                        var div = new HtmlGenericControl("div");
                        div.Attributes.Add("style", "margin-bottom: 5px;");
                        var title = new HtmlGenericControl("div");
                        title.InnerText = spec.Name + ":";
                        div.Controls.Add(title);
                        var ddl = new ProductSpecificationValuesDDL();
                        ddl.SpecificationID = spec.ID;
                        ddl.LoadPropertyValues();
                        div.Controls.Add(ddl);
                        divSubCats.Controls.Add(div);
                        hasFilters = true;
                        ddl.SelectedIndexChanged += new Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventHandler(ddl_SelectedIndexChanged);
                    }
                }
                if (hasFilters)
                {
                    var btn = new LinkButton();
                    btn.CssClass = "simplebtn";
                    btn.Attributes.Add("style", "margin-top: 5px;");
                    btn.Text = "Update";
                    divSubCats.Controls.Add(btn);
                    btn.Click += new EventHandler(btn_Click);
                }
            }
        }

        void ddl_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            specVals.Add(((sender) as ISeCommerce.Web.Controls.ProductSpecificationValuesDDL).SelectedValue);
        }

        void btn_Click(object sender, EventArgs e)
        {
            var args = new IdeaSeedListArgs<string>();
            foreach(var ctl in divSubCats.Controls)
            {
                if(ctl.GetType() == typeof(DropDownList))
                {
                    args.Items.Add(((DropDownList)ctl).SelectedValue);
                }
            }
            args.Items = specVals;
            MessageBus<IdeaSeedListArgs<string>>.SendMessage(sender, args);
        }
        #endregion
    }
}