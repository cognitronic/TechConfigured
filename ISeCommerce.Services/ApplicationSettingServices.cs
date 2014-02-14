using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ISeCommerce.Core.Domain;
using ISeCommerce.Core.Domain.Interfaces;
using ISeCommerce.Persistence.Repositories;

namespace ISeCommerce.Services
{
    public class ApplicationSettingServices
    {
        public IList<ApplicationSetting> GetAll()
        {
            return new ApplicationSettingRepository().GetAll().OrderBy(o => o.Setting).ToList<ApplicationSetting>();
        }

        public ApplicationSetting Save(ApplicationSetting item)
        {
            return new ApplicationSettingRepository().SaveOrUpdate(item);
        }

        public void Delete(ApplicationSetting item)
        {
            new ApplicationSettingRepository().Delete(item);
        }

        public ApplicationSetting GetByID(int id)
        {
            return new ApplicationSettingRepository().GetByID(id, false);
        }

        public IList<ApplicationSetting> GetByApplicationID(int appid)
        {
            return new ApplicationSettingRepository().GetByApplicationID(appid);
        }

        public ApplicationSetting GetBySetting(string setting, int appID)
        {
            return new ApplicationSettingRepository().GetBySetting(setting, appID);
        }
    }
}
