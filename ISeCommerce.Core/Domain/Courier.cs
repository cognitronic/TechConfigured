using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISeCommerce.Core.Domain.Interfaces;

namespace ISeCommerce.Core.Domain
{
    [Serializable]
    public class Courier : ICourier
    {
        public virtual IList<ICourierService> Services { get; set; }

        public virtual string Description { get; set; }

        public virtual int ID { get; set; }

        public virtual object ItemReference { get; set; }

        public virtual string Name { get; set; }

        public virtual string SEOTitle { get; set; }

        public virtual string URL { get; set; }
    }
}
