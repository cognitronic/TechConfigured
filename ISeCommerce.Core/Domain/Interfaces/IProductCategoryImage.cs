using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISeCommerce.Core.Domain.Interfaces
{
    public interface IProductCategoryImage
    {
        int ID { get; set; }
        string Title { get; set; }
        string Path { get; set; }
        int ProductCategoryID { get; set; }
        int ImageSizeTypeID { get; set; }
        string ToolTip { get; set; }
    }
}
