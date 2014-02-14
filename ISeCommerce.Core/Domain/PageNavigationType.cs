using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISeCommerce.Core.Domain
{
    [Serializable]
    public enum PageNavigationType
    {
        PRIMARY = 1,
        SUB = 2,
        FOOTER = 3,
        NONE = 4,
        ADMIN_PRIMARY = 5,
        ADMIN_SUB = 6,
        ADMIN_FOOTER = 7,
        ADMIN_NONE = 8
    }
}
