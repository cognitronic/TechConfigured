using System;
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
    public class OrderRepository : BaseRepository<ISeCommerce.Core.Domain.Order, int>
    {
        public IList<ISeCommerce.Core.Domain.Order> GetByCustomerID(int customerID)
        {
            return Session.CreateCriteria<ISeCommerce.Core.Domain.Order>()
                    .Add(Expression.Eq("CustomerID", customerID))
                    .List<ISeCommerce.Core.Domain.Order>();
        }

        public IList<ISeCommerce.Core.Domain.Order> GetByEmail(string email)
        {
            return Session.CreateCriteria<ISeCommerce.Core.Domain.Order>()
                    .Add(Expression.Eq("Email", email))
                    .List<ISeCommerce.Core.Domain.Order>();
        }

        public IList<ISeCommerce.Core.Domain.Order> GetByFilters(string email, DateTime? orderDate, int? status, int? orderID)
        {
            var list = new List<SearchCriterion>();
            if (!string.IsNullOrEmpty(email))
                list.Add(new SearchCriterion("Email", Operators.EQUALS, email));
            if (orderDate != null)
                list.Add(new SearchCriterion("DateCreated", Operators.EQUALS, orderDate));
            if (status != null)
                list.Add(new SearchCriterion("OrderStatusID", Operators.EQUALS, status));
            if (orderID != null)
                list.Add(new SearchCriterion("ID", Operators.EQUALS, orderID));
            ICriteria query = Session.CreateCriteria<ISeCommerce.Core.Domain.Order>();
            foreach (var l in list)
            {
                switch (l.Operator)
                {
                    case Operators.EQUALS:
                        query.Add(Restrictions.Eq(l.SearchColumn, l.SearchCriteria));
                        break;
                    case Operators.GREATER_THAN:
                        query.Add(Restrictions.Ge(l.SearchColumn, l.SearchCriteria));
                        break;
                    case Operators.LESS_THAN:
                        query.Add(Restrictions.Le(l.SearchColumn, l.SearchCriteria));
                        break;
                }
            }
            return query.List<ISeCommerce.Core.Domain.Order>();
        }
    }
}
