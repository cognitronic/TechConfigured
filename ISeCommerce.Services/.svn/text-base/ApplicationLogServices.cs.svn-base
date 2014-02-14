using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ISeCommerce.Core.Domain;
using ISeCommerce.Core.Domain.Interfaces;
using ISeCommerce.Persistence.Repositories;

namespace ISeCommerce.Services
{
    public class ApplicationLogServices
    {
        public IList<ApplicationLog> GetAll()
        {
            return new ApplicationLogRepository().GetAll().OrderBy(o => o.LogDate).ToList<ApplicationLog>();
        }

        public ApplicationLog Save(ApplicationLog item)
        {
            return new ApplicationLogRepository().SaveOrUpdate(item);
        }

        public void Delete(ApplicationLog item)
        {
            new ApplicationLogRepository().Delete(item);
        }

        public IList<ApplicationLog> GetByLogType(int type)
        {
            return new ApplicationLogRepository().GetByLogType(type).OrderBy(o => o.LogDate).ToList<ApplicationLog>();
        }
    }
}
