using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISeCommerce.Core.Domain
{
    [Serializable]
    public enum ItemType
    {
        CUSTOMER = 1,
        USER = 2,
        PRODUCT = 3,
        SHOPPINGCART = 4,
        WISHLIST = 5,
        ORDER = 6,
        PRODUCTPROPERTY = 7,
    }
}
