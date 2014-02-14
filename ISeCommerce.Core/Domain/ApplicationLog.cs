using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISeCommerce.Core.Domain
{
    [Serializable]
    public class ApplicationLog
    {
        public virtual int ID { get; set; }
        public virtual string UserInfo { get; set; }
        public virtual string Description { get; set; }
        public virtual DateTime LogDate { get; set; }
        public virtual int ApplicationLogTypeID { get; set; }
        public virtual string StackTrace { get; set; }
    }
}
