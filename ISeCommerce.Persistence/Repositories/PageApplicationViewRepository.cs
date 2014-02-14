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
    public class PageApplicationViewRepository : BaseRepository<PageApplicationView, int>, IPageApplicationViewRepository
    {
        public IList<PageApplicationView> GetByPageID(int pageID)
        {
            return Session.CreateCriteria<PageApplicationView>()
                .Add(Expression.Eq("PageID", pageID))
                .List<PageApplicationView>();
        }

        public PageApplicationView GetByPageIDApplicationViewID(int pageID, int appViewID)
        {
            return Session.CreateCriteria<PageApplicationView>()
                .Add(Expression.Eq("PageID", pageID))
                .Add(Expression.Eq("ApplicationViewID", appViewID))
                .UniqueResult<PageApplicationView>();
        }

        public IList<PageApplicationView> GetByApplicationViewID(int applicationViewID)
        {
            return Session.CreateCriteria<PageApplicationView>()
                .Add(Expression.Eq("ApplicationViewID", applicationViewID))
                .List<PageApplicationView>();
        }
    }
}
