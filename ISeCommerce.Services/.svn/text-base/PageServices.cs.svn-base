using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ISeCommerce.Core.Domain;
using ISeCommerce.Core.Domain.Interfaces;
using ISeCommerce.Persistence.Repositories;

namespace ISeCommerce.Services
{
    public class PageServices
    {
        public IOrderedEnumerable<Page> GetRootNodes()
        {
            return new PageRepository().GetRootNodes().OrderBy(o => o.SortOrder);
        }

        public IOrderedEnumerable<Page> GetSubNav(int parentID)
        {
            return new PageRepository().GetChildPagesByParentID(parentID, (int)PageNavigationType.SUB).OrderBy(o => o.SortOrder);
        }

        public IOrderedEnumerable<Page> GetByNavigationType(PageNavigationType type)
        {
            return new PageRepository().GetByNavigationType(type).OrderBy(o => o.SortOrder);
        }

        public Page GetPageByApplicationIDURL(int applicationID, string url)
        {
            return new PageRepository().GetByURLRoute(applicationID, url);
        }
    }
}
