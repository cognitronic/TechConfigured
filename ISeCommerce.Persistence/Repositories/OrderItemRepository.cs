﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using IdeaSeed.Core.Data.NHibernate;
using IdeaSeed.Core.Data;
using ISeCommerce.Core.Domain;
using ISeCommerce.Core.Domain.Interfaces.Data;

namespace ISeCommerce.Persistence.Repositories
{
    public class OrderItemRepository : BaseRepository<OrderItem, int>
    {
        public IList<OrderItem> GetByOrderID(int orderID)
        {
            return Session.CreateCriteria<OrderItem>()
                    .Add(Expression.Eq("OrderID", orderID))
                    .List<OrderItem>();
        }
    }
}