using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ISeCommerce.Core.Domain;
using ISeCommerce.Core.Domain.Interfaces;
using ISeCommerce.Persistence.Repositories;

namespace ISeCommerce.Services
{
    public class BannerImageServices
    {
        public BannerImage GetByID(int id)
        {
            return new BannerImageRepository().GetByID(id, false);
        }

        public IList<BannerImage> GetAll()
        {
            return new BannerImageRepository().GetAll().OrderBy(o => o.Title).ToList<BannerImage>();
        }

        public BannerImage Save(BannerImage item)
        {
            return new BannerImageRepository().SaveOrUpdate(item);
        }

        public void Delete(BannerImage item)
        {
            new BannerImageRepository().Delete(item);
        }
    }
}
