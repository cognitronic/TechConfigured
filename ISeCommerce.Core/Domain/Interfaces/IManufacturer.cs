using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISeCommerce.Core.Domain.Interfaces
{
    public interface IManufacturer
    {
        int ID { get; set; }
        string Name { get; set; }
    }
}
