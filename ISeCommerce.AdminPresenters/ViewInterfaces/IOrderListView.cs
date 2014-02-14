using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeed.Core;
using ISeCommerce.Core.Domain;
using ISeCommerce.Core.Domain.Interfaces;

namespace ISeCommerce.AdminPresenters.ViewInterfaces
{
    public interface IOrderListView : IBaseListView<Order>
    {
        IList<Order> OrderList();

    }
}
