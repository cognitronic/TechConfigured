using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISeCommerce.Core.Domain.Interfaces;

namespace ISeCommerce.Core.Domain
{
    [Serializable]
    public class Manufacturer : IManufacturer
    {
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }
    }
}
