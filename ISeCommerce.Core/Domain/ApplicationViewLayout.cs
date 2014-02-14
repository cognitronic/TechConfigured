using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISeCommerce.Core.Domain
{
    [Serializable]
    public enum ApplicationViewLayout
    {
        HEADER = 1,
        SIDEBAR = 2,
        MAIN = 3,
        FOOTER = 4,
        TOOLBAR = 5
    }
}
