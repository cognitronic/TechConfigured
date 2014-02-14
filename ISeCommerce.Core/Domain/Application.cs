using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISeCommerce.Core.Domain
{
    [Serializable]
    public class Application
    {
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual string Domain { get; set; }
    }
}
