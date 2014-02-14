﻿using System;
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
    public class ApplicationLogRepository : BaseRepository<ApplicationLog, int>
    {
        public IList<ApplicationLog> GetByLogType(int type)
        {
            return Session.CreateCriteria<ApplicationLog>()
                .Add(Expression.Eq("ApplicationLogTypeID", type))
                .List<ApplicationLog>();
        }
    }
}
