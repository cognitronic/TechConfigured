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
    [PresenterType(typeof(UserDetailsPresenter))]
    public partial class UserDetailsView : BaseWebUserControl, IUserDetailsView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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

        public new event EventHandler LoadView;

        public new event EventHandler UnloadView;

        #region IBasePropertiesView<User> Members

        public void LoadItem(User t)
        {
            this.IsActive = t.IsActive;
            this.Email = t.Email;
            this.LastName = t.LastName;
            this.FirstName = t.FirstName;
            this.UserName = t.UserName;
            this.PasswordQuestion = t.PasswordQuestion;
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

        #region IUser Members

        public string PasswordQuestion
        {
            get
            {
                return tbPasswordQuestion.Text;
            }
            set
            {
                tbPasswordQuestion.Text = value;
            }
        }

        public string PasswordAnswer
        {
            get
            {
                return tbSecurityAnswer.Text;
            }
            set
            {
                tbSecurityAnswer.Text = value;
            }
        }

        public DateTime PasswordLastChangedDate
        {
            get;
            set;
        }

        public DateTime LastLoginDate
        {
            get;
            set;
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

        #endregion

        #region IBaseUser Members

        public string Email
        {
            get
            {
                return tbEmail.Text;
            }
            set
            {
                tbEmail.Text = value;
            }
        }

        public string FirstName
        {
            get
            {
                return tbFirstName.Text;
            }
            set
            {
                tbFirstName.Text = value;
            }
        }

        public string LastName
        {
            get
            {
                return tbLastName.Text;
            }
            set
            {
                tbLastName.Text = value;
            }
        }

        public string Password
        {
            get
            {
                return tbPassword.Text;
            }
            set
            {
                tbPassword.Text = value;
            }
        }

        public string UserName
        {
            get
            {
                return tbUsername.Text;
            }
            set
            {
                tbUsername.Text = value;
            }
        }

        #endregion

        #region IBaseItem Members

        public new int ID
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        #endregion

        #region IItem Members

        public ItemType TypeOfItem
        {
            get
            {
                return ItemType.USER;
            }
            set
            {
                
            }
        }

        #endregion

        #region IBaseNavigation Members

        public string SEOTitle
        {
            get;
            set;
        }

        public string SEOKeywords
        {
            get;
            set;
        }

        public string SEODescription
        {
            get;
            set;
        }

        public string URL
        {
            get;
            set;
        }

        #endregion

        #region IBaseObjectReference Members

        public string Description
        {
            get;
            set;
        }

        public object ItemReference
        {
            get;
            set;
        }

        #endregion
    }
}