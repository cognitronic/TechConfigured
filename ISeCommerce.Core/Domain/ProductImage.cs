using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISeCommerce.Core.Domain.Interfaces;

namespace ISeCommerce.Core.Domain
{
    [Serializable]
    public class ProductImage : IProductImage
    {
        public virtual int ID { get; set; }
        public virtual string Title { get; set; }
        public virtual string Path { get; set; }
        public virtual int ProductID { get; set; }
        public virtual bool IsDefault { get; set; }
        public virtual string ToolTip { get; set; }
        public virtual int ImageSizeTypeID { get; set; }
    }
}
