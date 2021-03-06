﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISeCommerce.Core.Domain.Interfaces;

namespace ISeCommerce.Core.Domain
{
    [Serializable]
    public class PageApplicationView : IPageApplicationView
    {
        public virtual int ID { get; set; }
        public virtual int PageID { get; set; }
        public virtual int ApplicationViewID { get; set; }
        public virtual ApplicationViewLayout ViewLayout { get; set; }
        public virtual int SortOrder { get; set; }
        public virtual ApplicationView ApplicationView { get; set; }
        public virtual string ViewProperties { get; set; }
    }
}
