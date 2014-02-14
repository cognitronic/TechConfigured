using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISeCommerce.Core.Domain
{
    [Serializable]
    public class ProductSerializable
    {
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }
    }
}
