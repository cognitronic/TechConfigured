using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISeCommerce.Core.Domain.Interfaces;

namespace ISeCommerce.Core.Domain
{
    [Serializable]
    public class Page : IPage
    {
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }
        public virtual string Title { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual int? ParentID { get; set; }
        public virtual int SortOrder { get; set; }
        public virtual int EnteredBy { get; set; }
        public virtual int ChangedBy { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual DateTime LastUpdated { get; set; }
        public virtual bool MarkedForDeletion { get; set; }
        public virtual string URLRoute { get; set; }
        public virtual int PageNavigationTypeID { get; set; }
        public virtual int PageTypeID { get; set; }
        public virtual int ApplicationID { get; set; }
        public virtual string SEOTitle { get; set; }
        public virtual string SEOKeywords { get; set; }
        public virtual string SEODescription { get; set; }
        private IList<IPage> _childPages = new List<IPage>();
        public virtual IList<IPage> ChildPages { get { return _childPages; } set { _childPages = value; } }
    }
}
