using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISeCommerce.Core.Domain.Interfaces.Services
{
    public interface IPageViewServices
    {
        IOrderedEnumerable<PageApplicationView> GetPageApplicationViewsByPageID(int pageID);
    }
}
