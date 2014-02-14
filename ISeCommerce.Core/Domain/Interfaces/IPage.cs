using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeed.Core;

namespace ISeCommerce.Core.Domain.Interfaces
{
    public interface IPage : IBaseApplicationPage, IBaseAuditable
    {
        int SortOrder { get; set; }
        int PageNavigationTypeID { get; set; }
        int PageTypeID { get; set; }
        int ApplicationID { get; set; }
    }
}
