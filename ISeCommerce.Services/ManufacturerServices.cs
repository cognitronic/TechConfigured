using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ISeCommerce.Core.Domain;
using ISeCommerce.Core.Domain.Interfaces.Services;
using ISeCommerce.Persistence.Repositories;

namespace ISeCommerce.Services
{
    public class ManufacturerServices : IManufacturerServices<Manufacturer>
    {
        public Manufacturer GetByID(int id)
        {
            return new ManufacturerRepository().GetByID(id, false);
        }

        public IList<Manufacturer> GetPagedList(int startRow, int pageSize, out int count)
        {
            return new ManufacturerRepository()
                .GetPagedList(startRow, pageSize, out count)
                .OrderBy(o => o.Name)
                .ToList<Manufacturer>();
        }

        public IList<Manufacturer> GetAll()
        {
            return new ManufacturerRepository()
                .GetAll();
        }

        public Manufacturer Save(Manufacturer item)
        {
            return new ManufacturerRepository().SaveOrUpdate(item);
        }

        public void Delete(Manufacturer item)
        {
            new ManufacturerRepository().Delete(item);
        }
    }
}
