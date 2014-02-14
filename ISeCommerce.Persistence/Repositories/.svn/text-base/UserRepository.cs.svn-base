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
    public class UserRepository : BaseRepository<User, int>, IUserRepository
    {

        public User GetByEmail(string email)
        {
            return Session.CreateCriteria<User>()
                .Add(Expression.Eq("Email", email))
                .UniqueResult<User>();
        }

        public IList<User> GetByStatus(bool isActive)
        {
            return Session.CreateCriteria<User>()
                .Add(Expression.Eq("IsActive", isActive))
                .List<User>();
        }

        public User GetByUserName(string username)
        {
            return Session.CreateCriteria<User>()
                .Add(Expression.Eq("UserName", username))
                .UniqueResult<User>();
        }

        public User GetByUserNamePassword(string username, string password)
        {
            return Session.CreateCriteria<User>()
                .Add(Expression.Eq("UserName", username))
                .Add(Expression.Eq("Password", password))
                .UniqueResult<User>();
        }
    }
}
