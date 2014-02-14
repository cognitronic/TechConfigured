using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using IdeaSeed.Core.Data.NHibernate;
using ISeCommerce.Core.Domain;
using ISeCommerce.Core.Domain.Interfaces.Data;

namespace ISeCommerce.Persistence.Repositories
{
    public class PageRepository : BaseRepository<Page, int>, IPageRepository
    {
        public Page GetByURL(string url)
        {
            return Session.CreateCriteria<Page>()
                    .Add(Expression.Eq("IsActive", true))
                    .Add(Expression.Eq("URL", url))
                    .UniqueResult<Page>();
        }

        public Page GetByURLRoute(int applicationID, string urlRoute)
        {
            return Session.CreateCriteria<Page>()
                    .Add(Expression.Eq("IsActive", true))
                    .Add(Expression.Eq("ApplicationID", applicationID))
                    .Add(Expression.Eq("URLRoute", urlRoute))
                    .UniqueResult<Page>();
        }

        public IList<Page> GetChildPagesByParentID(int parentID, int navigationTypeID)
        {
            return Session.CreateCriteria<Page>()
                    .Add(Expression.Eq("IsActive", true))
                    .Add(Expression.Eq("ParentID", parentID))
                    .Add(Expression.Eq("PageNavigationTypeID", navigationTypeID))
                    .List<Page>();
        }

        public IList<Page> GetChildPagesByParentID(int parentID)
        {
            return Session.CreateCriteria<Page>()
                    .Add(Expression.Eq("IsActive", true))
                    .Add(Expression.Eq("ParentID", parentID))
                    .List<Page>();
        }

        public IList<Page> GetRootNodes()
        {
            return Session.CreateCriteria<Page>()
                    .Add(Expression.Eq("IsActive", true))
                    .Add(Expression.IsNull("ParentID"))
                    .Add(Expression.Eq("PageNavigationTypeID", (int)PageNavigationType.PRIMARY))
                    .List<Page>();
        }

        public IList<Page> GetByNavigationType(PageNavigationType type)
        {
            return Session.CreateCriteria<Page>()
                    .Add(Expression.Eq("IsActive", true))
                    .Add(Expression.Eq("PageNavigationTypeID", (int)type))
                    .List<Page>();
        }
    }
}
