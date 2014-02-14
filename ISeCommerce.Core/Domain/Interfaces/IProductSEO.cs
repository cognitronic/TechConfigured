using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISeCommerce.Core.Domain.Interfaces
{
    public interface IProductSEO
    {
        string SEOKeywords { get; set; }
        string SEODescription { get; set; }
        string SEOTitle { get; set; }
    }
}
