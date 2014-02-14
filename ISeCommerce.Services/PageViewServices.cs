using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISeCommerce.Core.Domain;
using ISeCommerce.Persistence.Repositories;
using ISeCommerce.Core.Domain.Interfaces.Services;

namespace ISeCommerce.Services
{
    public class PageViewServices : IPageViewServices
    {
        public IOrderedEnumerable<PageApplicationView> GetPageApplicationViewsByPageID(int pageID)
        {
            return new PageApplicationViewRepository().GetByPageID(pageID).OrderBy(o => o.SortOrder);
        }

        public PageApplicationView GetPageApplicationViewsByPageIDApplicationViewID(int pageID, int appViewID)
        {
            return new PageApplicationViewRepository().GetByPageIDApplicationViewID(pageID, appViewID);
        }
    }
}
