using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ISeCommerce.Core.Domain;
using ISeCommerce.Core.Domain.Interfaces;
using ISeCommerce.Persistence.Repositories;

namespace ISeCommerce.Services
{
    public class SessionDataServices
    {
        public SessionData GetByID(int id)
        {
            return new SessionDataRepository().GetByID(id, false);
        }

        public IList<SessionData> GetAll()
        {
            return new SessionDataRepository().GetAll().OrderBy(o => o.ID).ToList<SessionData>();
        }

        public SessionData Save(SessionData item)
        {
            return new SessionDataRepository().SaveOrUpdate(item);
        }

        public void Delete(SessionData item)
        {
            new SessionDataRepository().Delete(item);
        }
    }
}
