using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gallio.Framework;
using MbUnit.Framework;
using MbUnit.Framework.ContractVerifiers;
using IdeaSeed.Core.Utils;
using IdeaSeed.Core.Data.NHibernate;
using NHibernate.Criterion;
using ISeCommerce.Core.Domain;
using ISeCommerce.Persistence.Repositories;

namespace ISeCommerce.PersistenceTests
{
    [TestFixture]
    public class ApplicationViewTests
    {
        private ApplicationViewRepository _applicationViewRepository;

        [SetUp]
        public void TestFixtureSetup()
        {
            _applicationViewRepository = new ApplicationViewRepository();
        }
    }
}
