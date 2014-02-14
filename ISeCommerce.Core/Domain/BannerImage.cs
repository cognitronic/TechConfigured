using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISeCommerce.Core.Domain.Interfaces;

namespace ISeCommerce.Core.Domain
{
    [Serializable]
    public class BannerImage : IBannerImage
    {
        public virtual int ID { get; set; }
        public virtual string Title { get; set; }
        public virtual string Path { get; set; }
        public virtual string ToolTip { get; set; }
    }
}
