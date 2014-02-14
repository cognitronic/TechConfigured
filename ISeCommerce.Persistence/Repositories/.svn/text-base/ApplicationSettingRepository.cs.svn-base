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
    public class ApplicationSettingRepository : BaseRepository<ApplicationSetting, int>
    {
        public IList<ApplicationSetting> GetByApplicationID(int appID)
        {
            return Session.CreateCriteria<ApplicationSetting>()
                    .Add(Expression.Eq("ApplicationID", appID))
                    .List<ApplicationSetting>();
        }

        public ApplicationSetting GetBySetting(string setting, int appID)
        {
            return Session.CreateCriteria<ApplicationSetting>()
                    .Add(Expression.Eq("ApplicationID", appID))
                    .Add(Expression.Eq("Setting", setting))
                    .UniqueResult<ApplicationSetting>();
        }
    }
}
