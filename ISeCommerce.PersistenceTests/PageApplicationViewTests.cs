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
using ISeCommerce.Services;

namespace ISeCommerce.PersistenceTests
{
    [TestFixture]
    public class PageApplicationViewTests
    {
        private PageApplicationViewRepository _pageApplicationViewRepository;

        [SetUp]
        public void TestFixtureSetup()
        {
            _pageApplicationViewRepository = new PageApplicationViewRepository();
        }

        [Test]
        public void CanCreateAccountsListPageApplicationViewProperties()
        {
            int PAGEAPPLICATIONVIEWID = 18;
            var linksList = new List<QuickLink>();
            //linksList.Add(new HistoryLink("Profile", "Accounts/Name=/Profile/", "/Images/vcard.png", ""));
            linksList.Add(new QuickLink("Details", "[url]/Details", ""));
            linksList.Add(new QuickLink("Specifications", "[url]/Specifications", ""));
            linksList.Add(new QuickLink("Images", "[url]/Images", ""));
            var pav = _pageApplicationViewRepository.GetByID(PAGEAPPLICATIONVIEWID, false);
            pav.ViewProperties = ISeCommerce.Services.Utils.JSONSerializationHelper.Serialize<IList<QuickLink>>(linksList);
            _pageApplicationViewRepository.SaveOrUpdate(pav);

        }
    }
}
