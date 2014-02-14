using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using IdeaSeed.Core.Data.NHibernate;
using ISeCommerce.Core.Domain;
using ISeCommerce.Core.Domain.Interfaces.Data;

namespace ISeCommerce.Persistence.Repositories
{
    public class ShoppingCartItemRepository : BaseRepository<ShoppingCartItem, int>
    {
        public IList<ShoppingCartItem> GetByShoppingCartID(int cartID)
        {
            return Session.CreateCriteria<ShoppingCartItem>()
                    .Add(Expression.Eq("ShoppingCartID", cartID))
                    .List<ShoppingCartItem>();
        }
    }
}
