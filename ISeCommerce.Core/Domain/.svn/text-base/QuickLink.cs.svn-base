using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISeCommerce.Core.Domain.Interfaces;

namespace ISeCommerce.Core.Domain
{
    [Serializable]
    public class QuickLink : IQuickLink
    {
        public virtual string Title { get; set; }
        public virtual string URL { get; set; }
        public virtual string IconPath { get; set; }

        public QuickLink(string title, string url, string iconPath)
        {
            this.Title = title;
            this.URL = url;
            this.IconPath = iconPath;
        }
    }   
}
